using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;
using System.IO;

namespace ElectricSunlightOrchestra
{
    // TODO: document, test and move to SoftwareNinjas.Core
    // TODO: maybe rename to something shorter/snappier
    /// <summary>
    /// Provides a strongly-typed XML (de-)serialization with compile-time checks. (instead of having to cast and
    /// still getting a run-time error about a missing parameterless constructor)
    /// </summary>
    public static class XmlSerializerExtensions
    {
        public static string SerializeToXml<T>(this T input) where T : new()
        {
            XmlSerializer serializer = new XmlSerializer(typeof(T));
            string result;
            using (StringWriter sw = new StringWriter())
            {
                serializer.Serialize(sw, input);
                sw.Flush();
                result = sw.ToString();
            }
            return result;
        }

        // TODO: add other overloads for streams, etc.
        public static T DeserializeFromXml<T>(this string xml) where T : new()
        {
            XmlSerializer serializer = new XmlSerializer(typeof(T));
            T result;
            using (StringReader sr = new StringReader(xml))
            {
                result = (T)serializer.Deserialize(sr);
            }
            return result;
        }
    }
}
