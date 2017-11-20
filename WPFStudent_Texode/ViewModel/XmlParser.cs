using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Runtime.CompilerServices;
using WPFStudent_Texode.Model;

namespace WPFStudent_Texode.ViewModel
{
    class XmlParser
    {
        private Student Selected;
        private XmlReader Reader;

        public ObservableCollection<Student> Students { get; set; }
        public Student SelectedStudent
        {
            get { return Selected; }
            set
            {
                Selected = value;
                OnPropertyChanged("Selected");
            }
        }

        public XmlParser(string fileName)
        {
            using (var sr = new StreamReader(fileName))
            {
                Reader = new XmlReader(sr);
                Students = new ObservableCollection<Student>(Reader.Students);
            }
        }

        public void SaveData(string fileName)
        {
            Reader.Students = new List<Student>(Students);
            using (var streamWriter = new StreamWriter(fileName))
            {
                Reader.Save(streamWriter);
            }
        }

        public XmlParser()
        {
            Selected = null;
            Students = new ObservableCollection<Student>();
            Reader = new XmlReader();
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName]string prop = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }
    }
}
