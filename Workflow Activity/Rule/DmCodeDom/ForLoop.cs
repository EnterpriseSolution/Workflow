using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Xml.Serialization;
using CodeDomExpParser;

namespace DmCodeDom
{
	/// <summary>
	/// Represents a simple for loop.
	/// </summary>
	[XmlInclude(typeof(Declaration))]
	[XmlInclude(typeof(Assignment))]
	[XmlInclude(typeof(ExprStmt))]
	[XmlInclude(typeof(IfElse))]
	[XmlInclude(typeof(ForLoop))]
	public class ForLoop : DmCdStmt
	{
		private DmCdStmt _InitStmt = null, _IncrStmt = null;
		private string _Cond = string.Empty;
		private List<DmCdStmt> _LoopStmts = new List<DmCdStmt>();
		
		[XmlElement]
		public DmCdStmt InitStmt
		{
			get { return _InitStmt; }
			set { _InitStmt = value; }
		}
		
		[XmlElement]
		public DmCdStmt IncrStmt
		{
			get { return _IncrStmt; }
			set { _IncrStmt = value; }
		}
		
		[XmlAttribute("cond")]
		public string Cond
		{
			get { return _Cond; }
			set { _Cond = value; }
		}
		
		[XmlArray, XmlArrayItem(typeof(DmCdStmt))]
		public List<DmCdStmt> LoopStmts
		{
			get { return _LoopStmts; }
			set { _LoopStmts = value; }
		}
		
		public ForLoop() {}
		
		public ForLoop(DmCdStmt initStmt, string cond, DmCdStmt incrStmt, DmCdStmt[] loopStmts)
		{
			_InitStmt = initStmt;
			_IncrStmt = incrStmt;
			_Cond = cond;
			_LoopStmts.AddRange(loopStmts);
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
				throw new Exception("Error parsing condition statement for loop: " + _Cond, exc);
			}
			CodeIterationStatement cis = new CodeIterationStatement();
			cis.InitStatement = _InitStmt.EvalStmt(parser);
			cis.IncrementStatement = _IncrStmt.EvalStmt(parser);
			cis.TestExpression = ce;
			foreach (DmCdStmt dcs in _LoopStmts)
				cis.Statements.Add(dcs.EvalStmt(parser));
			return cis;
		}
	}
}
