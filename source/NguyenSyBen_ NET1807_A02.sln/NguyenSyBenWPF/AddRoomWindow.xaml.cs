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
            // Validate Room Number
            if (string.IsNullOrWhiteSpace(txtRoomNumber.Text))
            {
                MessageBox.Show("Room Number is required.", "Validation Error", MessageBoxButton.OK, MessageBoxImage.Error);
                txtRoomNumber.Focus();
                return;
            }

            // Validate Description
            if (string.IsNullOrWhiteSpace(txtDescription.Text))
            {
                MessageBox.Show("Description is required.", "Validation Error", MessageBoxButton.OK, MessageBoxImage.Error);
                txtDescription.Focus();
                return;
            }

            // Validate Max Capacity
            if (string.IsNullOrWhiteSpace(txtMaxCapacity.Text) || !int.TryParse(txtMaxCapacity.Text, out int maxCapacity))
            {
                MessageBox.Show("A valid Max Capacity is required.", "Validation Error", MessageBoxButton.OK, MessageBoxImage.Error);
                txtMaxCapacity.Focus();
                return;
            }

            // Validate Room Type ID
            if (string.IsNullOrWhiteSpace(txtRoomTypeId.Text) || !int.TryParse(txtRoomTypeId.Text, out int roomTypeId))
            {
                MessageBox.Show("A valid Room Type ID is required.", "Validation Error", MessageBoxButton.OK, MessageBoxImage.Error);
                txtRoomTypeId.Focus();
                return;
            }

            // Validate Price Per Day
            if (string.IsNullOrWhiteSpace(txtPricePerDay.Text) || !int.TryParse(txtPricePerDay.Text, out int pricePerDay))
            {
                MessageBox.Show("A valid Price Per Day is required.", "Validation Error", MessageBoxButton.OK, MessageBoxImage.Error);
                txtPricePerDay.Focus();
                return;
            }

            try
            {
                // Initialize a new room information object
                RoomInformation room = new RoomInformation
                {
                    RoomNumber = txtRoomNumber.Text,
                    RoomDetailDescription = txtDescription.Text,
                    RoomMaxCapacity = maxCapacity,
                    RoomTypeId = roomTypeId,
                    RoomStatus = 1, // Assuming 1 means 'Available' or similar
                    RoomPricePerDay = pricePerDay
                };

                // Attempt to add the room to the repository
                _roomRepository.AddRoom(room);
                MessageBox.Show("Room added successfully.", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
                DialogResult = true;
            }
            catch (Exception ex)
            {
                // Handle any exceptions that occur during the add operation
                MessageBox.Show($"An error occurred while adding the room: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                DialogResult = false;
            }
        }

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
        }

        // Helper method to validate if a string is a valid integer
        private bool IsValidInteger(string text)
        {
            return int.TryParse(text, out _);
        }

    }
}
