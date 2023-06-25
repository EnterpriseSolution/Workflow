using System;
using System.Collections.Generic;
using System.Xml.Serialization;
using System.Workflow.Activities.Rules;
using CodeDomExpParser;

namespace DmRules
{
	/// <summary>
	/// Holds a set of rules for a particular type.
	/// </summary>
	public class DmRuleTypeSet
	{
		private string _Type = string.Empty;
		private List<DmRule> _Rules = new List<DmRule>();
		
		[XmlAttribute("type")]
		public string Type
		{
			get { return _Type; }
			set { _Type = value; }
		}
		
		[XmlArray, XmlArrayItem(typeof(DmRule))]
		public List<DmRule> Rules
		{
			get { return _Rules; }
			set { _Rules = value; }
		}
		
		[XmlIgnore]
		public Type ParsedType
		{
			get 
			{
				return System.Type.GetType(_Type, false, true);
			}
		}
		
		public DmRuleTypeSet() {}
		
		public DmRuleTypeSet(string type, DmRule[] rules)
		{
			_Type = type;
			_Rules.AddRange(rules);
		}
		
		public DmRuleTypeSet(Type type, DmRule[] rules)
		{
			_Type = type.FullName + ", " + type.Assembly.GetName().Name;
			_Rules.AddRange(rules);
		}
		
		public RuleSet Eval(Parser parser)
		{
			RuleSet rs = new RuleSet();
			foreach (DmRule dr in _Rules)
				rs.Rules.Add(dr.Eval(parser));
			return rs;
		}
	}
}
