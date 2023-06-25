using System;
using System.CodeDom;
using System.Xml.Serialization;
using CodeDomExpParser;

namespace DmCodeDom
{
	/// <summary>
	/// Represents an expression as a statement.
	/// </summary>
	[XmlInclude(typeof(Declaration))]
	[XmlInclude(typeof(Assignment))]
	[XmlInclude(typeof(ExprStmt))]
	[XmlInclude(typeof(IfElse))]
	[XmlInclude(typeof(ForLoop))]
	public class ExprStmt : DmCdStmt
	{
		private string _Expr;
		
		[XmlAttribute("expr")]
		public string Expr
		{
			get { return _Expr; }
			set { _Expr = value; }
		}
		
		public ExprStmt() {}
		
		public ExprStmt(string expr)
		{
			_Expr = expr;
		}
		
		public override CodeStatement EvalStmt(Parser parser)
		{
			CodeExpression ce;
			try
			{
				ce = parser.ParseExpression(_Expr);
			}
			catch (Exception exc)
			{
				throw new Exception("Error parsing expression statement: " + _Expr, exc);
			}
			return new CodeExpressionStatement(ce);
		}
	}
}
