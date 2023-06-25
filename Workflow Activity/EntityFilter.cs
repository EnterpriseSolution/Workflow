using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data.Common;
using System.Reflection;
using CRD.Common;
using CRD.Common.Helper;
using SD.LLBLGen.Pro.ORMSupportClasses;
using System.Runtime.Serialization;
using System.Security.Permissions;
using System.Xml.Serialization;
using System.ComponentModel.Design.Serialization;

namespace ActivityLibrary
{
	public partial class EntityFilter: UserControl
	{
        int _seqID;
		public EntityFilter(int seqenceID)
		{
			InitializeComponent();
            _seqID = seqenceID;
		}
        string _type;//Entity, Database
        public EntityFilter(int seqenceID,string type)
        {
            InitializeComponent();
            _seqID = seqenceID;
            _type = type;
            LoadType();
        }

        public bool Checked
        {
            get { return chkRemove.Checked; }
        }

        string tables = "SELECT Name FROM dbo.sysobjects where OBJECTPROPERTY(id, N'IsUserTable') = 1 order by name ";
        string fields=" select c.name as ColumnName  from dbo.syscolumns c inner join dbo.sysobjects t  "+
                      " on c.id = t.id  inner join dbo.systypes typ on typ.xtype = c.xtype "+
                      "  where OBJECTPROPERTY(t.id, N'IsUserTable') = 1  "+
                      " and t.name='{0}' order by c.colorder;  ";

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            if(cmbTables.Items.Count<=10)
                LoadType();
        }

        private void LoadType()
        {
            if (_type == "Database")
            {
                Database db = DatabaseFactory.CreateDatabase();
                DbCommand dbCommand = db.GetSqlStringCommand(tables);
                DataSet ds = db.ExecuteDataSet(dbCommand);
                var tbls = from tbl in ds.Tables[0].AsEnumerable()
                           select tbl.Field<string>("Name"); ;
                cmbTables.Items.AddRange(tbls.ToArray());
            }
            else
            {
                Assembly assembly = Assembly.Load(ApplicationAssembly.BusinessLogic);
                Type[] types = assembly.GetTypes();

                DataTable table = new DataTable("Entities");
                table.Columns.Add("EntityName", typeof(string));
                table.Columns.Add("EntityFullName", typeof(string));
                table.Columns.Add("ReadableFullName", typeof(string));
                table.PrimaryKey = new DataColumn[] { table.Columns["EntityName"] };
                table.BeginLoadData();
                foreach (Type type in types)
                {
                    StringBuilder sb = new StringBuilder();
                    string typeName = type.Name;
                    if (type.Namespace == "CDC.BusinessLogic.EntityClasses")
                    {
                        if (typeName.Length >= 6 && typeName.Substring(typeName.Length - 6).ToUpper() == "ENTITY")
                        {
                            typeName = typeName.Substring(0, typeName.Length - 6);
                            DataRow newRow = table.NewRow();
                            newRow["EntityName"] = type.Name;
                            newRow["EntityFullName"] = type.FullName;
                            newRow["ReadableFullName"] = typeName;
                            table.Rows.Add(newRow);
                        }
                    }
                }
                table.EndLoadData();
                table.AcceptChanges();
                cmbTables.Items.Clear();
                var boms = from bom in table.AsEnumerable()
                           orderby bom.Field<string>("EntityName")
                           select bom;
                foreach (var bom in boms)
                {
                    Item it = new Item(bom.Field<string>("EntityName"), bom.Field<string>("EntityFullName"));
                    cmbTables.Items.Add(it);
                }
            }
        }

      
        private void cmbTables_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_type == "Database")
            {
                cmbFields.Items.Clear();
                string table = cmbTables.SelectedItem.ToString();
                Database db = DatabaseFactory.CreateDatabase();
                DbCommand dbCommand = db.GetSqlStringCommand(string.Format(fields, table));
                DataSet ds = db.ExecuteDataSet(dbCommand);
                var tbls = from tbl in ds.Tables[0].AsEnumerable()
                           select tbl.Field<string>("ColumnName"); ;
                cmbFields.Items.AddRange(tbls.ToArray());
            }
            else
            {
                int idx = cmbTables.SelectedIndex;
                cmbFields.Items.Clear();
                Item it = cmbTables.SelectedItem as Item;
                IEntity2 entity = ReflectionHelper.CreateObjectInstance(ApplicationAssembly.BusinessLogic, it.FullName) as IEntity2;
                Type type = entity.GetType();
                foreach (PropertyInfo fi in type.GetProperties(BindingFlags.FlattenHierarchy | BindingFlags.NonPublic | BindingFlags.Public
                                                   | BindingFlags.Instance))
                {
                    EntityBase2 entityInstance = (EntityBase2)entity;
                    IEntityField2 field = entityInstance.Fields[fi.Name];
                    if (field != null)
                    {
                        string fileType = field.DataType.ToString().Substring(7);
                        Item itfield = new Item(fi.Name, fileType);
                        cmbFields.Items.Add(itfield);
                    }
                }
                //cmbFields.SelectedIndex = idx;
            }   
            
        }

        private void cmbOperator_SelectedIndexChanged(object sender, EventArgs e)
        {
        
        }

        public string Output
        {
            get
            {
                string filter = string.Format("{0}.{1} {2} {3}",
                           cmbTables.SelectedItem.ToString(), cmbFields.SelectedItem.ToString(),
                           cmbOperator.SelectedItem.ToString(), cmbValue.Text);
                return filter;
            }
        }
        public AvatarIfElseCondition Condition
        {
            get
            {
                
                AvatarIfElseCondition exp = new AvatarIfElseCondition();
                try{
                exp.SequenceID = _seqID;
                exp.ConditionType = "FieldValueCondition";
                Item it=cmbTables.SelectedItem as Item;
                exp.ObjectName = it.EntityName;
                it=cmbFields.SelectedItem as Item;
                exp.PropertyName = it.EntityName;
                exp.PropertyType = it.FullName;
                exp.Operator = cmbOperator.SelectedItem.ToString();
                exp.Value = cmbValue.Text;
                }
                catch{   }
                return exp;
            }
        }

        private void cmbValue_KeyUp(object sender, KeyEventArgs e)
        {

        }

        private void cmbValue_Leave(object sender, EventArgs e)
        {
            EntityFilterForm frm = this.FindForm() as EntityFilterForm;
            frm.Add(Condition);
        }
	}

    [Serializable]
    public class AvatarIfElseCondition : ISerializable 
    {
        [XmlAttribute("SequenceID")]
        public int SequenceID;
        [XmlAttribute("ConditionType")]
        public string ConditionType;
        [XmlAttribute("ObjectName")]
        public string ObjectName;
        [XmlAttribute("PropertyName")]
        public string PropertyName;

        [XmlAttribute("PropertyType")]
        public string PropertyType;
        [XmlAttribute("Operator")]
        public string Operator;
        [XmlAttribute("Value")]
        public string Value;

        public AvatarIfElseCondition() { }

        protected AvatarIfElseCondition(SerializationInfo info, StreamingContext context)
        {
            SequenceID = info.GetInt32("SequenceID");
            ConditionType = info.GetString("ConditionType");
            ObjectName = info.GetString("ObjectName");
            PropertyName = info.GetString("PropertyName");
            PropertyType = info.GetString("PropertyType");
            Operator = info.GetString("Operator");
            Value = info.GetString("Value");          
        }

        [SecurityPermissionAttribute(SecurityAction.Demand, SerializationFormatter = true)]
         public virtual void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("SequenceID", SequenceID);
            info.AddValue("ConditionType", ConditionType);
            info.AddValue("ObjectName", ObjectName);
            info.AddValue("PropertyName", PropertyName);
            info.AddValue("PropertyType", PropertyType);
            info.AddValue("Operator", Operator);
            info.AddValue("Value", Value);

            //info.SetType(typeof(AvatarIfElseCondition));
            //info.SetType(SequenceID.GetType());
            //info.SetType(ConditionType.GetType());
            //info.SetType(ObjectName.GetType());
            //info.SetType(PropertyName.GetType());
            //info.SetType(PropertyType.GetType());
            //info.SetType(Operator.GetType());
            //info.SetType(Value.GetType());
        }

        public override string ToString()
        {
            return string.Format("{0}.{1} {2} {3}  ", ObjectName, PropertyName, Operator, Value);
        }
        public  string ToRuleString()
        {
            //字符串类型要加引号
            string right = Value;
            if(PropertyType=="String")
                right="\""+Value+"\"";

            return string.Format("this.{0} {1} {2}  ", PropertyName, Operator, right);
        }

        public override bool Equals(object obj)
        {           
            if (obj == null)
            {
                return false;
            }           
            AvatarIfElseCondition p = obj as AvatarIfElseCondition;
            if (p == null)
                return false;         

            return p.ObjectName==this.ObjectName&&p.PropertyName==this.PropertyName;           
        }

        public bool Equals(AvatarIfElseCondition p)
        {         
            if ((object)p == null)
            {
                return false;
            }
            return p.ObjectName == this.ObjectName && p.PropertyName == this.PropertyName;           

        }

        public override int GetHashCode()
        {
            return  (new Random()).Next();           
        }

        public static bool operator ==(AvatarIfElseCondition left, AvatarIfElseCondition right)
        {
            if (System.Object.ReferenceEquals(left, right))
            {
                return true;
            }                      
            if (((object)left == null) || ((object)right == null))
            {
                return false;
            }

            return left.ObjectName == right.ObjectName && left.PropertyName == right.PropertyName;
        }

        public static bool operator !=(AvatarIfElseCondition left, AvatarIfElseCondition right)
        {
            return !(left == right);
        }
    }

    public class Item
    {
        private string _entityName;

        public string EntityName
        {
            get { return _entityName; }
            set { _entityName = value; }
        }
        private string _fullName;

        public string FullName
        {
            get { return _fullName; }
            set { _fullName = value; }
        }
        public Item(string entityName, string fullName)
        {
            _entityName = entityName;
            _fullName = fullName;
        }
        public override string ToString()
        {
            return EntityName;
        }
    }
    [DesignerSerializer(typeof(AvatarIfElseConditionCollectionSerializer), typeof(CodeDomSerializer))]
    [Serializable]
    public class AvatarIfElseConditionCollection : List<AvatarIfElseCondition>,ISerializable
    {
       
        [SecurityPermissionAttribute(SecurityAction.LinkDemand,Flags = SecurityPermissionFlag.SerializationFormatter)]
        void ISerializable.GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.SetType(typeof(AvatarIfElseCondition));           
        }

    }

    public class AvatarIfElseConditionCollectionSerializer : CodeDomSerializer
    {
        public override object Deserialize(IDesignerSerializationManager manager, object codeObject)
        {
            return base.Deserialize(manager, codeObject);
        }

        public override object Serialize(IDesignerSerializationManager manager, object value)
        {
            return base.Serialize(manager, value);
        }
    }

}
