using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Xml.Serialization;

namespace Project
{
    public static class CommonXmlSerializer<T>
    {
        public static void Serialize(T instance, string fileName)
        {
            XmlSerializer formatter = new XmlSerializer(typeof(T));
            using var fs = new FileStream(fileName, FileMode.OpenOrCreate);
            formatter.Serialize(fs, instance);
        }

        public static T DeSerialize(T instance, string fileName)
        {
            XmlSerializer formatter = new XmlSerializer(typeof(T));
            using var fs = new FileStream(fileName, FileMode.OpenOrCreate);
            return (T)formatter.Deserialize(fs);
        }
    }   
}

