using System.Collections.Generic;
using System.Xml;

namespace AdTools.Library.Common
{
    public interface IXmlHelper
    {
        string RemoveNode(string xmlString, string xpath, Dictionary<string,string> nameSpaces);
        string GetNodeValue(string xmlString, string xpath, Dictionary<string,string> nameSpaces);
    }
}
