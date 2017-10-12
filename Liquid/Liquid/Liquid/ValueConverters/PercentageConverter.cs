using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace Liquid.ValueConverters
{
    public class PercentageConverter : IValueConverter
    {
        private int _decimals;
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value == null) return null;
            if (value.IsNumericType())
            {
                var percent = 100 * System.Convert.ToDouble(value);
                _decimals = parameter.IsNumericType() ? System.Convert.ToInt32(parameter) : 2;
                var form = string.Format("{{0:F{0}}}%", _decimals);
                return string.Format(form, percent);
            }
            throw new ArgumentException("Invalid value type for PercentageConverter: value is not a number.");
            //return value;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            //throw new NotImplementedException();
            if (value == null) return null;
            if (value is string)
            {
                value = value.ToString().Split(new char ['%'], StringSplitOptions.RemoveEmptyEntries)[0];
                var num = System.Convert.ToDouble(value) / 100;
                return targetType == null ? num : System.Convert.ChangeType(num, targetType);

            }
            throw new ArgumentException("Invalid value type for PercentageConverter: value is not a number.");
            //return value;
        }
    }
}
