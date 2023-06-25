using System;
using System.CodeDom;
using System.Xml.Serialization;
using CodeDomExpParser;

namespace DmCodeDom
{
	/// <summary>
	/// Represents a declaration statement.
	/// </summary>
	[XmlInclude(typeof(Declaration))]
	[XmlInclude(typeof(Assignment))]
	[XmlInclude(typeof(ExprStmt))]
	[XmlInclude(typeof(IfElse))]
	[XmlInclude(typeof(ForLoop))]
	public class Declaration : DmCdStmt
	{
		private string _Type = string.Empty, _VarName = string.Empty, _InitExp = string.Empty;
		
		[XmlAttribute("type")]
		public string Type
		{
			get { return _Type; }
			set { _Type = value; }
		}
		
		[XmlAttribute("varName")]
		public string VarName
		{
			get { return _VarName; }
			set { _VarName = value; }
		}
		
		[XmlAttribute("initExp")]
		public string InitExp
		{
			get { return _InitExp; }
			set { _InitExp = value; }
		}
		
		public Declaration() {}
		
		public Declaration(string type, string varName, string initExp)
		{
			_Type = type;
			_VarName = varName;
			_InitExp = initExp;
		}
		
		public override CodeStatement EvalStmt(Parser parser)
		{
			CodeTypeReference ctr;
			if (parser.RecognizedTypes.ContainsKey(_Type))
				ctr = parser.RecognizedTypes[_Type] as CodeTypeReference;
			else
				ctr = new CodeTypeReference(_Type);
			CodeVariableDeclarationStatement cvds;
			if (_InitExp == string.Empty)
				cvds = new CodeVariableDeclarationStatement(ctr, _VarName);
			else
			{
				CodeExpression ce;
				try 
				{
					ce = parser.ParseExpression(_InitExp);
				}
				catch (Exception exc)
				{
					throw new Exception("Error while parsing initialization expression:\n" + _Type + " " + _VarName + " = " + _InitExp, exc);
				}
				cvds = new CodeVariableDeclarationStatement(ctr, _VarName, ce);
			}
			return cvds;
		}
	}
}
