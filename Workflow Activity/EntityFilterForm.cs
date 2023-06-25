using System;
using System.Collections.Generic;
using System.ComponentModel;
//using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using SimpleRuleEditor;
using System.Workflow.Activities.Rules;
using DmRules;
using CodeDomExpParser;
using DmCodeDom;
using CDC.BusinessLogic.EntityClasses;
using SD.LLBLGen.Pro.ORMSupportClasses;
using CRD.Common.Helper;
using CRD.Common;

namespace ActivityLibrary
{
    public partial class EntityFilterForm : Form
    {
        public EntityFilterForm()
        {
            InitializeComponent();
            //Conditions = new Dictionary<int, AvatarIfElseCondition>();
            Conditions = new AvatarIfElseConditionCollection();
        }
        int sequenceID = 0;
        //用dictionary在序列化时有问题
        //public Dictionary<int, AvatarIfElseCondition> Conditions = new Dictionary<int, AvatarIfElseCondition>();
        public AvatarIfElseConditionCollection Conditions = new AvatarIfElseConditionCollection();

        private void btnInsert_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            sequenceID++;
            this.panel.SuspendLayout();
            EntityFilter efc = new EntityFilter(sequenceID,"Entity");
            panel.Controls.Add(efc);
            this.panel.ResumeLayout(false);
            this.panel.PerformLayout();            
        }

        private void btbRemove_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.panel.SuspendLayout();

            Dictionary<int, bool> indices = new Dictionary<int, bool>();
            for(int i=0;i<panel.Controls.Count;i++)
            {
                EntityFilter efc = panel.Controls[i] as EntityFilter;  
               if(efc!=null)
                 indices.Add(i,efc.Checked);               
            }
            foreach (KeyValuePair<int, bool> kvp in indices)            
            {
                EntityFilter efc = panel.Controls[kvp.Key] as EntityFilter;
                if(kvp.Value)
                   panel.Controls.Remove(efc);
            }

            this.panel.PerformLayout();        
        }

        public void Add(AvatarIfElseCondition condition)
        {
            txtFormular.Clear();
            if (Conditions == null)
                //Conditions = new Dictionary<int, AvatarIfElseCondition>();
                Conditions = new AvatarIfElseConditionCollection();

            if (Conditions.Contains(condition))
            {
                //集合的序号少于
                AvatarIfElseCondition dic= Conditions[--condition.SequenceID];
                dic.ConditionType = "FieldValueCondition";
                dic.ObjectName = condition.ObjectName;
                dic.PropertyName = condition.PropertyName;
                dic.Operator = condition.Operator;
                dic.Value = condition.Value;              
            }
            else
            {
                Conditions.Add(condition);
            }

            foreach (AvatarIfElseCondition kvp in Conditions)
            {
                txtFormular.AppendText(kvp.ToString() + Environment.NewLine);
            }
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            if (Conditions != null)
            {
                this.panel.SuspendLayout();
                //foreach (KeyValuePair<int, AvatarIfElseCondition> kvp in Conditions)                    
                foreach (AvatarIfElseCondition kvp in Conditions)
                {
                    sequenceID++;
                    EntityFilter efc = new EntityFilter(sequenceID,"Entity");
                    BindCommboxHelper(efc.cmbTables,kvp.ObjectName);
                    BindCommboxHelper(efc.cmbFields, kvp.PropertyName);
                    BindCommboxHelper(efc.cmbOperator, kvp.Operator);
                    BindCommboxHelper(efc.cmbTables, kvp.ObjectName);                   
                    efc.cmbValue.Text = kvp.Value;
                    panel.Controls.Add(efc);                    
                }
                this.panel.ResumeLayout(false);
                this.panel.PerformLayout();
            }
        }

        void BindCommboxHelper(ComboBox cmb,string value)
        {
            int idx = cmb.FindString(value);
            //if (idx >= 0)
            //    cmb.SelectedItem = cmb.Items[idx];
            //cmb.SelectedText = value;
            cmb.SelectedIndex = idx;
        }
        private void btnValidation_Click(object sender, EventArgs e)
        {            
            //Dictionary<string,string> parseSubstitutions = new Dictionary<string, string>();
            //parseSubstitutions.Add("PRSBOM.", "ActivityLibrary.PRSBOM.");

            ////一般来说，只可能传递一个object进来，进行计算求值
            ////返回一个求值结果，以决定是否执行相应的条件
            //RuleParser parser = new RuleParser(typeof(PRSBOM), parseSubstitutions);
            //RuleSet ruleSet = new RuleSet();            
            //ruleSet.ChainingBehavior = RuleChainingBehavior.Full;
            ////通过传递对象，进行动态求值
            //bool pass = false;
            //foreach (KeyValuePair<int, AvatarIfElseCondition> kvp in Conditions)
            //{
            //    Rule rule = new Rule(kvp.Key.ToString(),
            //         parser.ParseCondition(kvp.Value.ToRuleString()),
            //         parser.ParseStatementList("OK=true"));
            //    rule.Priority = kvp.Key;
            //    ruleSet.Rules.Add(rule);              
            //}
           
            //PRSBOM bom = new PRSBOM();
            //bom.BOM_NO = "abc";
            //RuleValidation validation = new RuleValidation(typeof(PRSBOM), null);
            //RuleExecution execution = new RuleExecution(validation, bom);
            //ruleSet.Execute(execution);
            //pass = bom.OK;

            //SalesOrder order = new SalesOrder("order", 10);
            //BomEntity bom = new BomEntity();
            //bom.IsDirty

            //每一条rule的对象可能不一样
            //IEntity2 entity = ReflectionHelper.CreateObjectInstance(ApplicationAssembly.BusinessLogic, kvp.Value.ObjectName) as IEntity2;
            //ReflectionHelper.SetPropertyValue(entity, "BomNo", "bom");
            BomEntity entity = new BomEntity();
            entity.BomNo = "123";
            entity.StdOutput = 7;
            //IsDirty 有赋值动作，肯定会让对象变
            entity.IsNew = false;

            DmRule[] rules = new DmRule[Conditions.Count] ;
            bool[] result =new bool[Conditions.Count];
            for(int i=0;i<result.Length;i++)
                result[i] = false;
            int idx = 0;
            //foreach (KeyValuePair<int, AvatarIfElseCondition> kvp in Conditions)
            foreach (AvatarIfElseCondition kvp in Conditions)
            {              
                Parser parser = new Parser(entity.GetType());
                DmRule rule = new DmRule(kvp.ToRuleString(),
                                  kvp.ToString(),
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
            if (passed)
                MessageBox.Show("Passed");
            else MessageBox.Show("Failed");
        } 
    }
    //public class PRSBOM
    //{
    //    public string BOM_NO { get; set; }
    //    public int RECNUM { get; set; }

    //    public bool OK { get; set; }
    //}
}