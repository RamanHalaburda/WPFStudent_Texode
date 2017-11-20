using System;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;
using WPFStudent_Texode.Model;

namespace WPFStudent_Texode.ViewModel
{
    [Serializable()]
    [XmlRoot("Students")]
    public class XmlReader
    {
        public XmlReader()
        {
            Students = new List<Student>();
        }

        public XmlReader(StreamReader streamReader)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(XmlReader));
            XmlReader r = (XmlReader)(serializer.Deserialize(streamReader));
            Students = r.Students;
        }

        public void Save(StreamWriter writer)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(XmlReader));
            serializer.Serialize(writer, this);
        }

        [XmlElement("Student")]
        public List<Student> Students { get; set; }
    }
}
