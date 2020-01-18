using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using WPFApp._2019._01._04.Model;
using System.Windows.Media;

namespace WPFApp._2019._01._04.Tools
{
    public class ColorBackgroundConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value == null)
            {
                return new SolidColorBrush(Colors.White);
            }
            switch (value.ToString())
            {
                case "English":
                    return new SolidColorBrush(Colors.Red);
                case "German":
                    return new SolidColorBrush(Colors.AliceBlue);
                case "Ukrainian":
                    return new SolidColorBrush(Colors.Chartreuse);
                case "Russian":
                    return new SolidColorBrush(Colors.BlueViolet);
                case "French":
                    return new SolidColorBrush(Colors.PaleVioletRed);
                case "Swedish":
                    return new SolidColorBrush(Colors.LightGoldenrodYellow);
                case "Poland":
                    return new SolidColorBrush(Colors.WhiteSmoke);
                default:
                    return new SolidColorBrush(Colors.White);
            }
            return new object();
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
