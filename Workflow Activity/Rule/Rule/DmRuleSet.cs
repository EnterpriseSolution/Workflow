using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Reflection;
using System.Workflow.Activities.Rules;
using System.Xml.Serialization;
using CodeDomExpParser;

namespace DmRules
{
	/// <summary>
	/// Represents the entire RuleSet.
	/// </summary>
	[XmlInclude(typeof(DmRule))]
	[XmlInclude(typeof(DmRuleTypeSet))]
	public class DmRuleSet
	{
		private List<DmRuleTypeSet> _RuleTypes = new List<DmRuleTypeSet>();
		private Dictionary<Type, RuleSet> _RuleSets = new Dictionary<Type, RuleSet>();
		
		[XmlArray, XmlArrayItem(typeof(DmRuleTypeSet))]
		public List<DmRuleTypeSet> RuleTypes
		{
			get { return _RuleTypes; }
			set { _RuleTypes = value; }
		}
		
		[XmlIgnore]
		public Dictionary<Type, RuleSet> RuleSets
		{
			get { return _RuleSets; }
		}
		
		public DmRuleSet() {}
		
		public DmRuleSet(DmRuleTypeSet[] ruleTypes)
		{
			_RuleTypes.AddRange(ruleTypes);
		}
		
		public void Eval(Parser parser)
		{
			foreach (DmRuleTypeSet drts in _RuleTypes)
			{
				Type t = drts.ParsedType;
				if (t == null)
					throw new Exception("Could not parse type name: " + drts.Type);
				_RuleSets.Add(t, drts.Eval(parser));
			}
		}
		
		public void Eval()
		{
			foreach (DmRuleTypeSet drts in _RuleTypes)
			{
				Parser parser = new Parser();
				Type t = drts.ParsedType;
				if (t == null)
					throw new Exception("Could not parse type name: " + drts.Type);

                //自动添加对属性的引用
                //foreach (FieldInfo fi in t.GetFields(BindingFlags.FlattenHierarchy | BindingFlags.NonPublic | BindingFlags.Public
                //                                     | BindingFlags.Instance))
                //    parser.Fields.Add(fi.Name);

				foreach (Type t2 in t.Assembly.GetTypes())
				{
					if (t2.IsEnum)
						parser.Enums.Add(t2.Name, new CodeTypeReference(t2));
					else
						parser.RecognizedTypes.Add(t2.Name, new CodeTypeReference(t2));
				}
				_RuleSets.Add(t, drts.Eval(parser));
			}
		}
		
		public void RunRules(object obj)
		{
			Type t = obj.GetType();
			if (_RuleSets.ContainsKey(t))
			{
				RuleSet rs = _RuleSets[t];
				RuleValidation rv = new RuleValidation(t, null);
				rs.Validate(rv);
				RuleExecution re = new RuleExecution(rv, obj);
				rs.Execute(re);
			}
		}
	}
}
