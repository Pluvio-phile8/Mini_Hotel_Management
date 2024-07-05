using FUMiniHotelSystem.Business.Models;
using FUMiniHotelSystem.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.WebSockets;
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
    /// Interaction logic for ManageRoomWindow.xaml
    /// </summary>
    public partial class ManageRoomWindow : Window
    {
        private readonly IRoomRepository _roomRepository;
        
        public ManageRoomWindow(IRoomRepository roomRepository)
        {
            InitializeComponent();
            _roomRepository = roomRepository;
            LoadRooms();

        }

        public ManageRoomWindow()
        {
        }

        private void LoadRooms()
        {
            List<RoomInformation> rooms = _roomRepository.RoomList();
            lvRooms.ItemsSource = rooms;
        }
        private void AddRoomButton_Click(object sender, RoutedEventArgs e)
        {
            var addRoomWindow = new AddRoomWindow();
            if (addRoomWindow.ShowDialog() == true)
            {
                LoadRooms();
            }
        }
        private void EditRoom_Click(object sender, RoutedEventArgs e)
        {
            Button btn = sender as Button;
            RoomInformation room = btn.Tag as RoomInformation;
            if (room != null)
            {
                var editRoomWindow = new EditRoomWindow(room, _roomRepository);
                editRoomWindow.ShowDialog();
                LoadRooms();

            }

        }
        private void DeleteRoomButton_Click(object sender, RoutedEventArgs e)
        {
            if (sender is Button button && button.CommandParameter is RoomInformation room)
            {
                MessageBoxResult result = MessageBox.Show($"Are you sure you want to delete this room?",
                                                          "Confirm Delete",
                                                          MessageBoxButton.YesNo,
                                                          MessageBoxImage.Question);

                if (result == MessageBoxResult.Yes)
                {
                    try
                    {
                       _roomRepository.DeleteRoom(room.RoomId);
                        LoadRooms();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Error deleting customer: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                }
            }
        }
        private void BackButton_Click(Object sender, RoutedEventArgs e)
        {
            DialogResult = false;
            AdminWindow adminWindow = new AdminWindow();
            adminWindow.Show();
            Close();
        }

    }
}
