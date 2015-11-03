using System.Collections.Generic;
using System.Xml;
using System.Xml.Linq;
using System.Xml.XPath;
using Common.Logging;

namespace AdTools.Library.Common
{
    public class XmlHelper : IXmlHelper
    {
        private readonly ILog _logger;

        public XmlHelper(ILog logger)
        {
            _logger = logger;
        }

        public string RemoveNode(string xmlString, string xpath, Dictionary<string,string> nameSpaces)
        {
            var xDocument = XDocument.Parse(xmlString);
            var nameSpaceManager = new XmlNamespaceManager(new NameTable());
            foreach (var key in nameSpaces.Keys)
            {
                nameSpaceManager.AddNamespace(nameSpaces[key], key);
            }
            var xElement = xDocument.XPathSelectElement(xpath, nameSpaceManager);
            if (xElement != null)
            {
                xElement.Remove();
            }
            else
            {
                if(_logger.IsDebugEnabled) _logger.DebugFormat("Xml element '{0}' not found when trying to remove element.", xpath);
            }
            return xDocument.ToString(SaveOptions.None);
        }

        public string GetNodeValue(string xmlString, string xpath, Dictionary<string,string> nameSpaces)
        {
            var xDocument = XDocument.Parse(xmlString);
            var nameSpaceManager = new XmlNamespaceManager(new NameTable());
            foreach (var key in nameSpaces.Keys)
            {
                nameSpaceManager.AddNamespace(nameSpaces[key], key);
            }
            var xElement = xDocument.XPathSelectElement(xpath, nameSpaceManager);
            if (xElement != null)
            {
                return xElement.Value;
            }
            if(_logger.IsDebugEnabled) _logger.DebugFormat("Xml element '{0}' not found.", xpath);
            return null;
        }
    }
}