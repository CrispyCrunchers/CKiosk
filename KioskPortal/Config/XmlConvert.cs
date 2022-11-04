using System;
using System.IO;
using System.Xml.Serialization;

public static class XmlConvert
{
    // XML serializers to read/write POCO's to XML
    public static string SerializeObject<T>(T dataObject)
    {
        if (dataObject == null)
        {
            return string.Empty;
        }
        try
        {
            using (StringWriter stringWriter = new System.IO.StringWriter())
            {
                var serializer = new XmlSerializer(typeof(T));
                serializer.Serialize(stringWriter, dataObject);
                return stringWriter.ToString();
            }
        }
        catch
        {
            return string.Empty;
        }
    }

    public static T DeserializeObject<T>(string xml)
         where T : new()
    {
        using (var stringReader = new StringReader(xml))
        {
            var serializer = new XmlSerializer(typeof(T));
            return (T)serializer.Deserialize(stringReader);
        }
    }
}