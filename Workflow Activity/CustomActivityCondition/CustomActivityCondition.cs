using System;
using System.Collections.Generic;
using System.Text;
using System.Workflow.ComponentModel;
using System.Workflow.Activities;
using System.ComponentModel;
using System.Workflow.Activities.Rules;
using System.Collections;
using System.Globalization;
using ActivityLibrary;
using DmRules;
using CodeDomExpParser;
using CRD.Common.Helper;
using DmCodeDom;
using CRD.Common.Enums;
using SD.LLBLGen.Pro.ORMSupportClasses;
using System.Runtime.Serialization;

namespace CustomActivityLibrary
{
    public class WorkflowBase : SequentialWorkflowActivity
    {
        public WorkflowBase() { }       
       
        public static DependencyProperty WorkflowNameProperty =
            DependencyProperty.Register("WorkflowName", typeof(string), typeof(WorkflowBase));
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public string WorkflowName
        {
            get
            {
                return ((string)(base.GetValue(WorkflowBase.WorkflowNameProperty)));
            }
            set
            {
                base.SetValue(WorkflowBase.WorkflowNameProperty, value);
            }
        }

        public static DependencyProperty WorkflowTypeProperty =
           DependencyProperty.Register("WorkflowType", typeof(string), typeof(WorkflowBase));
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public string WorkflowType
        {
            get
            {
                return ((string)(base.GetValue(WorkflowBase.WorkflowTypeProperty)));
            }
            set
            {
                base.SetValue(WorkflowBase.WorkflowTypeProperty, value);
            }
        }    
    }

    public partial class TransactionBaseWorkflow : WorkflowBase
    {
        public TransactionBaseWorkflow()  {     }

        public static DependencyProperty EntityProperty =
           DependencyProperty.Register("Entity", typeof(IEntity2), typeof(TransactionBaseWorkflow));
        public IEntity2 Entity
        {
            get
            {
                return ((IEntity2)(base.GetValue(TransactionBaseWorkflow.EntityProperty)));
            }
            set
            {
                base.SetValue(TransactionBaseWorkflow.EntityProperty, value);
            }
        }

        public static DependencyProperty RefNoProperty =
        DependencyProperty.Register("RefNo", typeof(IEntity2), typeof(TransactionBaseWorkflow));     
        public System.Collections.Generic.Dictionary<string, string> RefNo        
        {
            get
            {
                return ((Dictionary<string, string>)(base.GetValue(TransactionBaseWorkflow.RefNoProperty)));
            }
            set
            {
                base.SetValue(TransactionBaseWorkflow.RefNoProperty, value);
            }
        }
      

      
        public static DependencyProperty TableNameProperty =
         DependencyProperty.Register("TableName", typeof(string), typeof(TransactionBaseWorkflow));
        public string TableName
        {
            get
            {
                return ((string)(base.GetValue(TransactionBaseWorkflow.TableNameProperty)));
            }
            set
            {
                base.SetValue(TransactionBaseWorkflow.TableNameProperty, value);
            }
        }  
        

    }
        
    public class TransactionCreatedWorkflow : TransactionBaseWorkflow
    {
        public TransactionCreatedWorkflow() { }
         public TransactionCreatedWorkflow(SerializationInfo info, StreamingContext context)
        {

        }
    }

     public class TransactionDeletedWorkflow  : TransactionBaseWorkflow
     {
         public TransactionDeletedWorkflow() { }
         public TransactionDeletedWorkflow(SerializationInfo info, StreamingContext context)
         {

         }
     }

     public class TransactionPostedWorkflow  : TransactionBaseWorkflow
     {
         public TransactionPostedWorkflow() { }
         public TransactionPostedWorkflow(SerializationInfo info, StreamingContext context)
         {

         }
     }
    
     public class TransactionClosedWorkflow  : TransactionBaseWorkflow
     {
         public TransactionClosedWorkflow() { }
         public TransactionClosedWorkflow(SerializationInfo info, StreamingContext context)
         {

         }
     }
    
    public class TransactionUpdatedWorkflow : TransactionBaseWorkflow
    {
        public TransactionUpdatedWorkflow() { }
        public TransactionUpdatedWorkflow(SerializationInfo info, StreamingContext context)
        {

        }
    }

    public class ScheduledWorkflow : TransactionBaseWorkflow
    {
        public ScheduledWorkflow(SerializationInfo info, StreamingContext context)
        {

        }
    }
     
    public class DocumentApprovalWorkflow : TransactionBaseWorkflow
    {
        public DocumentApprovalWorkflow(SerializationInfo info, StreamingContext context)
        {

        }
    }
     
     

    [DisplayName("Custom Activity Condition")]
    public class CustomActivityCondition : ActivityCondition
	{
        public override bool Evaluate(Activity activity, IServiceProvider provider)
        {
            TransactionBaseWorkflow baseWorkflow = activity as TransactionBaseWorkflow;
            IEntity2 entity = baseWorkflow.Entity;
            DmRule[] rules = new DmRule[Conditions.Count];
            bool[] result = new bool[Conditions.Count];
            for (int i = 0; i < result.Length; i++)
                result[i] = false;
            int idx = 0;
            foreach (KeyValuePair<int, AvatarIfElseCondition> kvp in Conditions)
            {
                Parser parser = new Parser(entity.GetType());
                DmRule rule = new DmRule(kvp.Value.ToRuleString(),
                                  kvp.Key.ToString(),
                                  new DmCdStmt[] { 			                       	
			                       	new Assignment("this.IsNew", "true"),
			                       },
                                  new DmCdStmt[0]
                                 );
                rules[idx] = rule;


                DmRuleSet drs = new DmRuleSet();
                drs.RuleTypes.Add(new DmRuleTypeSet(entity.GetType(), new DmRule[] { rules[idx] }));
                drs.Eval(parser);
                drs.RunRules(entity);
                result[idx] = Convert.ToBoolean(ReflectionHelper.GetPropertyValue(entity, "IsNew"));

                idx++;
            }
            bool passed = true;
            foreach (bool b in result)
            {
                if (b == false)
                {
                    passed = false;
                    break;
                }
            }
            return passed;
        }
                
       private Dictionary<int, AvatarIfElseCondition> _conditions;
        public Dictionary<int, AvatarIfElseCondition> Conditions
        {
            get { return _conditions; }
            set { _conditions = value; }
        }          
    }

    public class CustomActivityConditionTypeConverter : TypeConverter
    {
        private Hashtable conditionDecls = new Hashtable();

        public CustomActivityConditionTypeConverter()
        {
            AddTypeToHashTable(typeof(RuleConditionReference));
            AddTypeToHashTable(typeof(CodeCondition));
            AddTypeToHashTable(typeof(CustomActivityCondition));
        }

        private void AddTypeToHashTable(Type typeToAdd)
        {
            string key = typeToAdd.FullName;
            object[] attributes = typeToAdd.GetCustomAttributes(typeof(DisplayNameAttribute), false);
            if (attributes != null && attributes.Length > 0 && attributes[0] is DisplayNameAttribute)
                key = ((DisplayNameAttribute)attributes[0]).DisplayName;
            this.conditionDecls.Add(key, typeToAdd);
        }

        public override bool CanConvertFrom(ITypeDescriptorContext context, Type sourceType)
        {
            if (sourceType == typeof(string))
                return true;
            return base.CanConvertFrom(context, sourceType);
        }

        public override object ConvertFrom(ITypeDescriptorContext context, CultureInfo culture, object value)
        {
            if (value is string)
            {
                if (((string)value).Length == 0 || ((string)value) == "(None)")
                    return null;
                else
                    return Activator.CreateInstance(this.conditionDecls[value] as Type);
            }

            return base.ConvertFrom(context, culture, value);
        }

        public override bool CanConvertTo(ITypeDescriptorContext context, Type destinationType)
        {
            if (destinationType == typeof(string))
                return true;
            else
                return base.CanConvertTo(context, destinationType);
        }

        public override object ConvertTo(ITypeDescriptorContext context, CultureInfo culture, object value, Type destinationType)
        {
            if (value == null)
                return "(None)";

            object convertedValue = null;
            if (destinationType == typeof(string) && value is ActivityCondition)
            {
                foreach (DictionaryEntry conditionTypeEntry in this.conditionDecls)
                {
                    if (value.GetType() == conditionTypeEntry.Value)
                    {
                        convertedValue = conditionTypeEntry.Key;
                        break;
                    }
                }
            }

            if (convertedValue == null)
                convertedValue = base.ConvertTo(context, culture, value, destinationType);

            return convertedValue;
        }

        public override StandardValuesCollection GetStandardValues(ITypeDescriptorContext context)
        {
            ArrayList conditionDeclList = new ArrayList();

            conditionDeclList.Add(null);
            foreach (object key in this.conditionDecls.Keys)
            {
                Type declType = this.conditionDecls[key] as Type;
                conditionDeclList.Add(Activator.CreateInstance(declType));
            }
            return new StandardValuesCollection((ActivityCondition[])conditionDeclList.ToArray(typeof(ActivityCondition)));
        }

        public override bool GetStandardValuesSupported(ITypeDescriptorContext context)
        {
            return true;
        }

        public override bool GetStandardValuesExclusive(ITypeDescriptorContext context)
        {
            return true;
        }

        public override PropertyDescriptorCollection GetProperties(ITypeDescriptorContext context, object value, Attribute[] attributes)
        {
            PropertyDescriptorCollection props = new PropertyDescriptorCollection(new PropertyDescriptor[] { });

            TypeConverter typeConverter = TypeDescriptor.GetConverter(value.GetType());
            if (typeConverter != null && typeConverter.GetType() != GetType() && typeConverter.GetPropertiesSupported())
            {
                return typeConverter.GetProperties(context, value, attributes);
            }

            return props;
        }

        public override bool GetPropertiesSupported(ITypeDescriptorContext context)
        {
            return true;
        }    
    }
}
