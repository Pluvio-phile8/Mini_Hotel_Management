using System;
using System.Globalization;
using System.Windows.Data;

namespace NguyenSyBenWPF
{
    public class RoomStatusConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value == null || !(value is byte))
                return string.Empty;

            byte status = (byte)value;

            return status switch
            {
                0 => "Booked",
                1 => "Available",
                _ => "Unknown",
            };
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
