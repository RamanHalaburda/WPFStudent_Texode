using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using WPFStudent_Texode.ViewModel;
using WPFStudent_Texode.Model;

namespace WPFStudent_Texode.View
{
    /// <summary>
    /// Логика взаимодействия для StudentView.xaml
    /// </summary>
    public partial class StudentView : Window
    {
        String filter = "Xml Files (*.xml)|*.xml|All files (*.*)|*.*";
        public StudentView()
        {
            InitializeComponent();
            DataContext = new XmlParser();
        }

        private void ListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var data = (XmlParser)DataContext;
            if (data.SelectedStudent == null)
            {
                firstname.Text = "";
                firstname.IsEnabled = false;
                last.Text = "";
                last.IsEnabled = false;
                age.Text = "";
                age.IsEnabled = false;
                sex.SelectedIndex = -1;
                sex.IsEnabled = false;
                removeButton.IsEnabled = false;
            }
            else
            {
                firstname.IsEnabled = true;
                last.IsEnabled = true;
                age.IsEnabled = true;
                sex.IsEnabled = true;
                removeButton.IsEnabled = true;
            }
        }

        private void Open_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog()
            {
                InitialDirectory = Directory.GetCurrentDirectory(),
                Filter = filter,
                RestoreDirectory = true
            };

            if (openFileDialog.ShowDialog() == true)
            {
                DataContext = new XmlParser(openFileDialog.FileName);
            }
        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            var dialog = new WPFStudent_Texode.View.StudentAdd();
            if (dialog.ShowDialog().HasValue)
            {
                var student = dialog.AddedStudent;
                if (student != null)
                {
                    var students = (XmlParser)DataContext;
                    student.Id = (UInt64)students.Students.Count;
                    students.Students.Add(student);
                    students.SelectedStudent = student;
                }
            }
        }

        protected void Remove_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Вы уверены?", "Да", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                var students = (XmlParser)DataContext;
                var selected = new List<Student>();

                foreach (Student student in studentList.SelectedItems)
                {
                    selected.Add(student);
                }

                selected.ForEach(x => students.Students.Remove(x));
            }
        }

        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog()
            {
                InitialDirectory = Directory.GetCurrentDirectory(),
                Filter = filter,
                RestoreDirectory = true
            };
            if (saveFileDialog.ShowDialog() == true)
            {
                var students = (XmlParser)DataContext;
                students.SaveData(saveFileDialog.FileName);
            }
        }        
    }
}
