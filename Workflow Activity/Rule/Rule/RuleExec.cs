using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Reflection;
using System.Text;
using System.Workflow.Activities.Rules;
using System.Xml;
using System.Xml.Serialization;
using CodeDomExpParser;

namespace DmRules
{
	/// <summary>
	/// Rule execution class.
	/// </summary>
	public static class RuleExec
	{
		private static DmRuleSet _MainRuleSet;
		
		public static DmRuleSet MainRuleSet
		{
			get { return _MainRuleSet; }
			set { _MainRuleSet = value; }
		}
		
		static RuleExec()
		{
			_MainRuleSet = ConfigurationManager.GetSection("dmRulesConfig") as DmRuleSet;
			_MainRuleSet.Eval();
		}
		
		public static void ApplyRules(object obj)
		{
			ApplyRules(obj, obj.GetType());
		}
		
		public static void ApplyRules(object obj, Type t)
		{
			if (!_MainRuleSet.RuleSets.ContainsKey(t))
				throw new Exception("No such type: " + t.FullName);
			RuleSet rs = _MainRuleSet.RuleSets[t];
			RuleValidation rv = new RuleValidation(t, null);
			rs.Validate(rv);
			if (rv.Errors.Count > 0)
				throw new Exception(rv.Errors[0].ErrorText);
			RuleExecution re = new RuleExecution(rv, obj);
			rs.Execute(re);
		}
		
		public static void ReadRulesFromXml(string s)
		{
			XmlSerializer xs = new XmlSerializer(typeof(DmRuleSet));
			_MainRuleSet = xs.Deserialize(new StringReader(s)) as DmRuleSet;
		}
		
		public static string SerializeRules()
		{
			return SerializeRules(_MainRuleSet);
		}
		
		public static string SerializeRules(DmRuleSet drs)
		{
			XmlSerializer xs = new XmlSerializer(typeof(DmRuleSet));
			StringBuilder sb = new StringBuilder();
			XmlWriterSettings xws = new XmlWriterSettings();
			xws.Indent = true;
			xws.IndentChars = "   ";
			xws.OmitXmlDeclaration = true;
			XmlWriter xw = XmlWriter.Create(new StringWriter(sb), xws);
			xs.Serialize(xw, drs);
			return sb.ToString();
		}		
	}
}
