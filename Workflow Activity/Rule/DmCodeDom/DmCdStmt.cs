using System.CodeDom;
using System.IO;
using System.Text;
using System.Xml;
using System.Xml.Serialization;
using CodeDomExpParser;

namespace DmCodeDom
{
	/// <summary>
	/// Inheriting from this class means that the implementor evaluates to a <see cref="CodeStatement"/>.
	/// </summary>
	[XmlInclude(typeof(Declaration))]
	[XmlInclude(typeof(Assignment))]
	[XmlInclude(typeof(ExprStmt))]
	[XmlInclude(typeof(IfElse))]
	[XmlInclude(typeof(ForLoop))]
	public abstract class DmCdStmt
	{
		public abstract CodeStatement EvalStmt(Parser parser);
		
		public static string Serialize(DmCdStmt dcs)
		{
			XmlSerializer xs = new XmlSerializer(typeof(DmCdStmt));
			StringBuilder sb = new StringBuilder();
			XmlWriterSettings xws = new XmlWriterSettings();
			xws.Indent = true;
			xws.IndentChars = "   ";
			xws.OmitXmlDeclaration = true;
			XmlWriter xw = XmlWriter.Create(new StringWriter(sb), xws);
			xs.Serialize(xw, dcs);
			return sb.ToString();
		}
		
		public static DmCdStmt Deserialize(string s)
		{
			XmlSerializer xs = new XmlSerializer(typeof(DmCdStmt));
			DmCdStmt dcs = xs.Deserialize(new StringReader(s)) as DmCdStmt;
			return dcs;
		}
	}
}
