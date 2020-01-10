using System;
using System.Collections.Generic;
using System.Text;

namespace SeafileClient.Common.Converters
{
    interface ISeafileValueConverter
    {
        object Convert(object value);
    }
    internal class BoolToIntConverter: ISeafileValueConverter
    {
        public object Convert(object value)
        {
            return ((bool)value) ? 1 : 0;
        }

    }

    internal class JoinStringsConverter: ISeafileValueConverter
    {
        public object Convert(object value)
        {
            return string.Join(",", value as IEnumerable<string>);
        }
    }
}
