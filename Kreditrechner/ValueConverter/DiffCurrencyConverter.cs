using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace Kreditrechner.ValueConverter
{
  internal class DiffCurrencyConverter : IValueConverter
  {
    public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
    {
      decimal val = (decimal)value;

      if (val == 0)
      {
        return string.Empty;
      }

      if (val > 0)
      {
        return "+" + val.ToString("c");
      }

      return val.ToString("c");
    }

    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
    {
      string val = (string)value;

      val = val.Replace("€", "").Trim();

      decimal result;
      if (!decimal.TryParse(val, out result))
      {
        return 0;
      }

      return result;
    }
  }
}
