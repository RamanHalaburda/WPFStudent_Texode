using System;
using System.Reflection;
using System.ComponentModel;
using System.Windows.Data;
using WPFStudent_Texode.Model;

namespace WPFStudent_Texode.OtherLogic
{
    [ValueConversion(typeof(double), typeof(string))]
    class AgeConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            UInt16 age = (UInt16)(UInt16.Parse(value.ToString()) % 100);
            String end = "";
            if (age % 10 == 0 || age % 10 >= 5 || (age >= 10 && age <= 20))
            {
                end = "лет";
            }
            else
            {
                if (age % 10 == 1)
                {
                    end = "год";
                }
                else
                {
                    end = "года";
                }
            }

            return age + " " + end;
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
