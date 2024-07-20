using System;
using System.Globalization;
using System.Windows.Data;

namespace NguyenSyBenWPF
{
    public class RoomTypeConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value == null || !(value is int))
                return string.Empty;

            int roomTypeId = (int)value;

            return roomTypeId switch
            {
                1 => "Standard Room",
                2 => "Suite",
                3 => "Deluxe Room",
                4 => "Executive Room",
                5 => "Family Room",
                6 => "Connecting Room",
                7 => "Penthouse Suite",
                8 => "Bungalow",
                _ => "Unknown",
            };
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
