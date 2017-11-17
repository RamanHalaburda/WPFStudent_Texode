using System;
using System.Collections.Generic;
using System.Xml;
using System.Xml.Serialization;

namespace WPFStudent_Texode
{
    public class Student
    {
        public UInt64 ID { get; set; }
        public String FirstName { get; set; }
        public String LastName { get; set; }
        public UInt16 Age { get; set; }
        public Boolean Gender { get; set; }
        
        //public Student(UInt64 _ID, String _FirstName, String _LastName, UInt16 _Age, Boolean _Gender)
        //{
        //    this.ID = _ID;
        //    this.FirstName = _FirstName;
        //    this.LastName = _LastName;
        //    this.Age = _Age;
        //    this.Gender = _Gender;
        //}
    }

    public class Students
    {
        [XmlElement("Student")]
        public List<Student> List { get; set; }
    }
}
