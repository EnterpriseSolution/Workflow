using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Xml.Serialization;
using CodeDomExpParser;

namespace DmCodeDom
{
	/// <summary>
	/// Represents an if/else statement
	/// </summary>
	[XmlInclude(typeof(Declaration))]
	[XmlInclude(typeof(Assignment))]
	[XmlInclude(typeof(ExprStmt))]
	[XmlInclude(typeof(IfElse))]
	[XmlInclude(typeof(ForLoop))]
	public class IfElse : DmCdStmt
	{
		private string _Cond = string.Empty;
		private List<DmCdStmt> _TrueStmts = new List<DmCdStmt>(), _FalseStmts = new List<DmCdStmt>();
		
		[XmlAttribute("cond")]
		public string Cond
		{
			get { return _Cond; }
			set { _Cond = value; }
		}
		
		[XmlArray, XmlArrayItem(typeof(DmCdStmt))]
		public List<DmCdStmt> TrueStmts
		{
			get { return _TrueStmts; }
			set { _TrueStmts = value; }
		}
		
		[XmlArray, XmlArrayItem(typeof(DmCdStmt))]
		public List<DmCdStmt> FalseStmts
		{
			get { return _FalseStmts; }
			set { _FalseStmts = value; }
		}
		
		public IfElse() {}
		
		public IfElse(string cond, DmCdStmt[] trueStmts, DmCdStmt[] falseStmts)
		{
			_Cond = cond;
			_TrueStmts.AddRange(trueStmts);
			_FalseStmts.AddRange(falseStmts);
		}
		
		public override CodeStatement EvalStmt(Parser parser)
		{
			CodeExpression ce;
			try
			{
				ce = parser.ParseExpression(_Cond);
			}
			catch (Exception exc)
			{
				throw new Exception("Error parsing condition statement for if/else: " + _Cond, exc);
			}
			CodeConditionStatement ccs = new CodeConditionStatement();
			ccs.Condition = ce;
			foreach (DmCdStmt dcs in _TrueStmts)
				ccs.TrueStatements.Add(dcs.EvalStmt(parser));
			foreach (DmCdStmt dcs in _FalseStmts)
				ccs.FalseStatements.Add(dcs.EvalStmt(parser));
			return ccs;
		}
	}
}
