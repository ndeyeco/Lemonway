using System;
using System.Diagnostics;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ndeyeServices;
using Newtonsoft.Json.Linq;

namespace FibonacciTest
{
    [TestClass]
    public class XmlToJsonTest
    {
        XmlToJson myService = new XmlToJson();


        [TestMethod]
        public void Convert_Should_Work_On_Simple_Xml()
        {
            var expected = "{ \"foo\": \"bar\" }";
            var calculated = myService.Convert("<foo>bar</foo>");

            JObject expectedJValue = JObject.Parse(expected);
            JObject calculatedJValue = JObject.Parse(calculated);

            Assert.IsTrue(JToken.DeepEquals(expectedJValue, calculatedJValue), $"expected = {expected}, actual = {calculated}");

        }

        [TestMethod]
        public void Convert_Should_Work_When_An_XML_element_Is_Null()
        {
            var expected = @"{'TRANS': {'HPAY': {'ID': '103','STATUS':'3','EXTRA': {'IS3DS': '0','AUTH': '031183'}, 'MLABEL': '501767XXXXXX6700', 'MTOKEN': 'project01'}}}";
            var calculated = myService.Convert("<TRANS><HPAY><ID>103</ID><STATUS>3</STATUS><EXTRA><IS3DS>0</IS3DS><AUTH>031183</AUTH></EXTRA><INT_MSG/><MLABEL>501767XXXXXX6700</MLABEL><MTOKEN>project01</MTOKEN></HPAY></TRANS>");

            JObject expectedJValue = JObject.Parse(expected);
            JObject calculatedJValue = JObject.Parse(calculated);

            Assert.IsTrue(JToken.DeepEquals(expectedJValue, calculatedJValue), $"expected = {expected}, actual = {calculated}");
            
        }

        [TestMethod]
        public void Convert_Should_Return_Bad_XML_Format_When_Input_Is_Bad_Formatted()
        {
            var expected = "Bad Xml format";
            var calculated = myService.Convert("<foo>hello</bar>");
            Assert.AreEqual(expected, calculated, $"Should return {expected}");
        }
    }
}
