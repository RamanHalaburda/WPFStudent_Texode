using System;
using System.Reflection;
using System.ComponentModel;
using System.Windows.Data;
using WPFStudent_Texode.Model;

namespace WPFStudent_Texode.OtherLogic
{
    [ValueConversion(typeof(Student.SexEnum), typeof(string))]
    class SexConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            Type type = typeof(Student.SexEnum);

            MemberInfo[] memberInfo = type.GetMember(value.ToString());
            if (memberInfo != null && memberInfo.Length > 0)
            {
                object[] customAttributes = memberInfo[0].GetCustomAttributes(typeof(DescriptionAttribute), false);

                if (customAttributes != null && customAttributes.Length > 0)
                {
                    return ((DescriptionAttribute)customAttributes[0]).Description;
                }
            }

            return value.ToString();
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
