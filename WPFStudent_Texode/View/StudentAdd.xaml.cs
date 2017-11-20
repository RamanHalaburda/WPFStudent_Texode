using System;
using System.Text;
using System.Windows;
using WPFStudent_Texode.Model;

namespace WPFStudent_Texode.View
{
    /// <summary>
    /// Логика взаимодействия для StudentAdd.xaml
    /// </summary>
    public partial class StudentAdd : Window
    {
        public StudentAdd()
        {
            InitializeComponent();
        }

        public Student AddedStudent { get; set; }

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            var stringBuilder = new StringBuilder();
            Student s = null;

            if (sex.SelectedValue == null)
            {
                stringBuilder.AppendLine("Выберите пол и повторите попытку снова!");
            }

            try
            {
                s = new Student()
                {
                    FirstName = firstName.Text,
                    Last = last.Text,
                    Age = Student.ParseAge(age.Text),
                    Sex = (Student.SexEnum)sex.SelectedValue
                };
            }
            catch (ArgumentException ex)
            {
                stringBuilder.AppendLine(ex.Message);
            }

            String answer = stringBuilder.ToString();

            if (!String.IsNullOrEmpty(answer))
            {
                MessageBox.Show(answer, "Ошибка добавления записи на стороне модели!");
            }
            else
            {
                AddedStudent = s;
                Close();
            }
        }
    }
}
