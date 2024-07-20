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
    /// Interaction logic for AddReservationWindow.xaml
    /// </summary>
    public partial class AddReservationWindow : Window
    {
        private readonly IBookingReservationRepository _reservationRepository;

        

        public AddReservationWindow(IBookingReservationRepository bookingReservation)
        {
            InitializeComponent();
            _reservationRepository = bookingReservation;
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                // Validate ReservationId
                if (string.IsNullOrWhiteSpace(ReservationId.Text) || !int.TryParse(ReservationId.Text, out int reservationId))
                {
                    MessageBox.Show("Please enter a valid Reservation ID.");
                    return;
                }

                // Check if ReservationId already exists
                if (_reservationRepository.GetById(reservationId) != null)
                {
                    MessageBox.Show("A reservation with this ID already exists. Please use a different ID.");
                    return;
                }

                // Validate CustomerId
                if (string.IsNullOrWhiteSpace(CustomerIdTextBox.Text) || !int.TryParse(CustomerIdTextBox.Text, out int customerId))
                {
                    MessageBox.Show("Please enter a valid Customer ID.");
                    return;
                }

                // Validate BookingDate
                if (!BookingDatePicker.SelectedDate.HasValue)
                {
                    MessageBox.Show("Please select a booking date.");
                    return;
                }
                var bookingDate = DateOnly.FromDateTime(BookingDatePicker.SelectedDate.Value);

                // Validate BookingStatus
                int status = int.Parse((StatusComboBox.SelectedItem as ComboBoxItem).Content.ToString());

                // Create and add the booking reservation
                var bookingReservation = new BookingReservation
                {
                    BookingReservationId = reservationId,
                    CustomerId = customerId,
                    BookingDate = bookingDate,
                    TotalPrice = 0,
                    BookingStatus = (byte?)status
                };
                _reservationRepository.Add(bookingReservation);
                MessageBox.Show("Added Successfully!");
                DialogResult = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message);
                DialogResult = false;
            }
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
            Close();
        }

    }
}
