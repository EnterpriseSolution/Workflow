using System;
using System.Collections.Generic;
using System.Workflow.Activities.Rules;
using System.Xml.Serialization;
using CodeDomExpParser;
using DmCodeDom;

namespace DmRules
{
	/// <summary>
	/// Encapsulates the Windows Workflow rules.
	/// </summary>
	public class DmRule
	{
		private string _Cond = string.Empty, _Name = string.Empty;
		private List<DmCdStmt> _ThenStmts = new List<DmCdStmt>(), _ElseStmts = new List<DmCdStmt>();
		private bool _HaltAfterThen = false, _HaltAfterElse = false;
		private int _Priority = 0;
		
		[XmlAttribute("cond")]
		public string Cond
		{
			get { return _Cond; }
			set { _Cond = value; }
		}
		
		[XmlAttribute("name")]
		public string Name
		{
			get { return _Name; }
			set { _Name = value; }
		}
		
		[XmlArray, XmlArrayItem(typeof(DmCdStmt))]
		public List<DmCdStmt> ThenStmts
		{
			get { return _ThenStmts; }
			set { _ThenStmts = value; }
		}
		
		[XmlArray, XmlArrayItem(typeof(DmCdStmt))]
		public List<DmCdStmt> ElseStmts
		{
			get { return _ElseStmts; }
			set { _ElseStmts = value; }
		}
		
		[XmlAttribute("haltAfterThen")]
		public bool HaltAfterThen
		{
			get { return _HaltAfterThen; }
			set { _HaltAfterThen = value; }
		}
		
		[XmlAttribute("haltAfterElse")]
		public bool HaltAfterElse 
		{
			get { return _HaltAfterElse; }
			set { _HaltAfterElse = value; }
		}
		
		[XmlAttribute("priority")]
		public int Priority
		{
			get { return _Priority; }
			set { _Priority = value; }
		}
		
		public DmRule() {}
		
		public DmRule(string cond, string name, DmCdStmt[] thenStmts, DmCdStmt[] elseStmts)
		{
			_Cond = cond;
			_Name = name;
			if (thenStmts != null)
				_ThenStmts.AddRange(thenStmts);
			if (elseStmts != null)
				_ElseStmts.AddRange(elseStmts);
		}
		
		public Rule Eval(Parser parser)
		{
			Rule r = new Rule(_Name);
			try 
			{
				r.Condition = new RuleExpressionCondition(parser.ParseExpression(_Cond));
			}
			catch (Exception exc)
			{
				throw new Exception("Error while parsing rule " + _Name + " condition: " + _Cond, exc);
			}
			foreach (DmCdStmt dcs in _ThenStmts)
				r.ThenActions.Add(new RuleStatementAction(dcs.EvalStmt(parser)));
			foreach (DmCdStmt dcs in _ElseStmts)
				r.ElseActions.Add(new RuleStatementAction(dcs.EvalStmt(parser)));
			if (_HaltAfterThen)
				r.ThenActions.Add(new RuleHaltAction());
			if (_HaltAfterElse)
				r.ElseActions.Add(new RuleHaltAction());
			r.Priority = _Priority;
			return r;
		}
	}
}
