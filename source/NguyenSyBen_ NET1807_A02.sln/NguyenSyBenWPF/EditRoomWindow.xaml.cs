using FUMiniHotelSystem.Business.Models;
using FUMiniHotelSystem.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace NguyenSyBenWPF
{
    /// <summary>
    /// Interaction logic for EditRoomWindow.xaml
    /// </summary>
    public partial class EditRoomWindow : Window
    {
        private readonly IRoomRepository _roomRepository;
        private RoomInformation _room;
        public EditRoomWindow(RoomInformation room, IRoomRepository roomRepository)
        {
            InitializeComponent();
            _room = room;
            _roomRepository = roomRepository;
            txtRoomNumber.Text = _room.RoomNumber;
            txtRoomDetailDescription.Text = _room.RoomDetailDescription;
            txtRoomMaxCapacity.Text = _room.RoomMaxCapacity?.ToString();
            txtRoomTypeId.Text = _room.RoomTypeId.ToString();
            txtRoomPricePerDay.Text = _room.RoomPricePerDay?.ToString();
        }
        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            _room.RoomNumber = txtRoomNumber.Text;
            _room.RoomDetailDescription = txtRoomDetailDescription.Text;

            int maxCapacity;
            if (int.TryParse(txtRoomMaxCapacity.Text, out maxCapacity))
            {
                _room.RoomMaxCapacity = maxCapacity;
            }
            else
            {
                // Handle invalid input for max capacity
                // You can show a message or handle it as per your application logic
            }

            int roomTypeId;
            if (int.TryParse(txtRoomTypeId.Text, out roomTypeId))
            {
                _room.RoomTypeId = roomTypeId;
            }
            else
            {
                // Handle invalid input for room type ID
            }

            decimal pricePerDay;
            if (decimal.TryParse(txtRoomPricePerDay.Text, out pricePerDay))
            {
                _room.RoomPricePerDay = pricePerDay;
            }
            else
            {
                // Handle invalid input for price per day
            }
            _roomRepository.UpdateRoom(_room);
            DialogResult = true;
        }
        private void CancelButton_Click( object sender, RoutedEventArgs e) {
            DialogResult = false;
        }

    }
}
