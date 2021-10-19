using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Markup;

namespace evoFlix.WPF.State.Converter
{
    [MarkupExtensionReturnType(typeof(MultiValueConverter))]
    public class MultiValueConverter : MarkupExtension, IMultiValueConverter
    {
        public static MultiValueConverter converter = null;
        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            if (null == converter)
            {
                converter = new MultiValueConverter();
            }
            return converter;
        }
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            return values.ToList();
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }


    }
}
