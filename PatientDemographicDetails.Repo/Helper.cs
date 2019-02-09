using System;
using System.IO;
using System.Xml.Serialization;

namespace PatientDemographicDetails.Repo.Helper
{
    public static class Serializer
    {
        //Deserialize XML string to Object
        public static T Deserialize<T>(this string input) where T : class
        {
            try
            {
                XmlSerializer ser = new XmlSerializer(typeof(T));
                using (StringReader sr = new StringReader(input))
                {
                    return (T)ser.Deserialize(sr);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        //Serialize Object to XML string
        public static string Serialize<T>(T ObjectToSerialize) where T : class
        {
            try
            {
                XmlSerializerNamespaces ns = new XmlSerializerNamespaces();
                ns.Add("", "");
                XmlSerializer xmlSerializer = new XmlSerializer(ObjectToSerialize.GetType());
                using (StringWriter textWriter = new StringWriter())
                {
                    xmlSerializer.Serialize(textWriter, ObjectToSerialize, ns);
                    return textWriter.ToString();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}