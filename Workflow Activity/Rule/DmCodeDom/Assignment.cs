using System;
using System.CodeDom;
using System.Xml.Serialization;
using CodeDomExpParser;

namespace DmCodeDom
{
	/// <summary>
	/// Represents an assignment statement.
	/// </summary>
	[XmlInclude(typeof(Declaration))]
	[XmlInclude(typeof(Assignment))]
	[XmlInclude(typeof(ExprStmt))]
	[XmlInclude(typeof(IfElse))]
	[XmlInclude(typeof(ForLoop))]
	public class Assignment : DmCdStmt
	{
		private string _Left = string.Empty, _Right = string.Empty;
		
		[XmlAttribute("left")]
		public string Left
		{
			get { return _Left; }
			set { _Left = value; }
		}
		
		[XmlAttribute("right")]
		public string Right
		{
			get { return _Right; }
			set { _Right = value; }
		}
		
		public Assignment() {}
		
		public Assignment(string left, string right)
		{
			_Left = left;
			_Right = right;
		}
		
		public override CodeStatement EvalStmt(Parser parser)
		{
			CodeExpression ceLeft, ceRight;
			try
			{
				ceLeft = parser.ParseExpression(_Left);
			}
			catch (Exception exc)
			{
				throw new Exception("Error while parsing left side of assignment:\n" + _Left + " = " + _Right, exc);
			}
			try
			{
				ceRight = parser.ParseExpression(_Right);
			}
			catch (Exception exc)
			{
				throw new Exception("Error while parsing right side of assignment:\n" + _Left + " = " + _Right, exc);
			}
			return new CodeAssignStatement(ceLeft, ceRight);
		}
	}
}
