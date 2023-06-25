using System;
using System.IO;
using System.Configuration;
using System.Text;
using System.Xml;
using System.Xml.Serialization;
 
namespace DmRules.Configuration
{
	public class DmRulesConfigHandler : IConfigurationSectionHandler
	{
		public object Create(object parent, object configContext, XmlNode section)
		{
			string s = section.InnerXml;
			XmlSerializer xs = new XmlSerializer(typeof(DmRuleSet));
			DmRuleSet drs = xs.Deserialize(new StringReader(s)) as DmRuleSet;
			return drs;
		}
	}
}
