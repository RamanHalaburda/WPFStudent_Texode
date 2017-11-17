using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace WPFStudent_Texode
{
    public class DataManipulator
    {
        public IEnumerable<Student> ReadStudents(String _path)
        {
            using (var file = File.OpenRead(_path))
            {
                return ((Students)new XmlSerializer(typeof(Students)).Deserialize(file)).List;
            }
        }

        public void WriteStudents(String _path, ref IEnumerable<Student> _list)
        {
            using (var file = File.OpenWrite(_path))
            {
                new XmlSerializer(typeof(Students)).Serialize(file, (Students)_list);
            }
        }
    }
}
