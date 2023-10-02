using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace Kreditrechner.ValueConverter
{
  internal class CurrencyConverter : IValueConverter
  {
    public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
    {
      decimal val = (decimal)value;

      return val.ToString("c");
    }

    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
    {
      string val = (string)value;

      val = val.Replace("€", "").Trim();
      val = val.Replace("$", "").Trim();

      decimal result;
      if (!decimal.TryParse(val, out result))
      {
        return 0;
      }

      return result;
    }
  }
}
