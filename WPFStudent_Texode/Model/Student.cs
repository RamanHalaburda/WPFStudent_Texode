using System;
using System.Xml;
using System.Xml.Serialization;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace WPFStudent_Texode.Model
{
    public class Student : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName]string prop = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }

        private UInt64 id;
        private String first;
        private String last;
        private UInt16 age;
        private SexEnum sex;

        [XmlAttribute("Id")]
        public UInt64 Id
        {
            get { return id; }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Id must be equal or more then 0!");
                }
                id = value;
                OnPropertyChanged("Id");
            }
        }

        [XmlElement("FirstName")]
        public String FirstName
        {
            get { return first; }
            set
            {
                if (String.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("First Name is not filled!");
                }
                first = value;
                OnPropertyChanged("FirstName");
            }
        }

        [XmlElement("Last")]
        public string Last
        {
            get { return last; }
            set
            {
                if (String.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("Last Name is not filled!");
                }
                last = value;
                OnPropertyChanged("Last");
            }
        }

        [XmlElement("Age")]
        public UInt16 Age
        {
            get { return age; }
            set
            {
                if (value < 16 || value > 100)
                {
                    throw new ArgumentException("Значение параметра \"Возраст\" должно находится в диапозоне от 16 до 100 (включитльно)!");
                }
                age = value;
                OnPropertyChanged("Age");
            }
        }

        [XmlElement("Gender")]
        public SexEnum Sex
        {
            get { return sex; }
            set
            {
                sex = value;
                OnPropertyChanged("Gender");
            }
        }        

        public static UInt16 ParseAge(string _value)
        {
            if (!UInt16.TryParse(_value, out UInt16 result))
            {
                throw new ArgumentException("Значение не являетя числом!");
            }
            return result;
        }

        public enum SexEnum
        {
            [XmlEnum("0")]
            [Description("Мужчина")]
            Male,
            [XmlEnum("1")]
            [Description("Женщина")]
            Female
        }
    }
}
