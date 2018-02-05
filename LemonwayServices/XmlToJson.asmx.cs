using System;
using System.ComponentModel;
using System.Text.RegularExpressions;
using System.Web.Services;
using System.Xml;
using Newtonsoft.Json;
using Formatting = Newtonsoft.Json.Formatting;

namespace ndeyeServices
{
    /// <summary>
    ///     Summary description for XmlToJson
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class XmlToJson : WebService
    {
        [WebMethod]
        public string Convert(string xml)
        {
            try
            {
                var doc = new XmlDocument();
                doc.LoadXml(xml);
                var jsonObject = JsonConvert.SerializeXmlNode(doc);
                var finalString = RemoveJsonNulls(jsonObject);
                return finalString;
            }
            catch (XmlException)
            {
                return "Bad Xml format";
            }
        }

        public static string RemoveJsonNulls(string str)
        {
            if (!string.IsNullOrEmpty(str))
            {
                Regex regex = new Regex("[\"][a-zA-Z0-9_]*[\"]:null[ ]*[,]?");
                string data = regex.Replace(str, string.Empty);
                regex = new Regex("\\[( *null *,? *)*]");
                return regex.Replace(data, "[]");
            }
            return null;
        }
    }
}