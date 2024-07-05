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
using System.Windows.Forms.VisualStyles;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace NguyenSyBenWPF
{
    /// <summary>
    /// Interaction logic for AddRoomWindow.xaml
    /// </summary>
    public partial class AddRoomWindow : Window
    {
        private readonly IRoomRepository _roomRepository;
        public AddRoomWindow()
        {
            InitializeComponent();
            _roomRepository = new RoomRepository();
        }
        private void Add_Click(object sender, RoutedEventArgs e)
        {
            RoomInformation room = new RoomInformation();
            room.RoomNumber = txtRoomNumber.Text;
            room.RoomDetailDescription = txtDescription.Text;
            room.RoomMaxCapacity = int.Parse(txtMaxCapacity.Text);
            room.RoomTypeId = int.Parse(txtRoomTypeId.Text != null ? txtRoomTypeId.Text : "0");
            room.RoomStatus = 1;
            room.RoomPricePerDay = int.Parse(txtPricePerDay.Text);
            _roomRepository.AddRoom(room);
            DialogResult = true;

        }
        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
            
        }
    }
}
