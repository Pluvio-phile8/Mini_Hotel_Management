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
    /// Interaction logic for EditReservationWindow.xaml
    /// </summary>
    public partial class EditReservationWindow : Window
    {
        private BookingReservation currentReservation;
        public EditReservationWindow()
        {
            InitializeComponent();
        }

        internal void LoadReservation(BookingReservation reservation)
        {
            currentReservation = reservation;

            // Populate fields with reservation data
            txtId.Text = reservation.BookingReservationId.ToString();
            dpBookingDate.SelectedDate = reservation.BookingDate.Value.ToDateTime(TimeOnly.MinValue);
            txtPrice.Text = reservation.TotalPrice.ToString();
            txtCustomerId.Text = reservation.CustomerId.ToString();
            // Set selected status in ComboBox based on reservation status
            cmbStatus.SelectedIndex = (int)reservation.BookingStatus;
        }
        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                int id = int.Parse(txtId.Text); // Assuming txtId is for reservation Id
                decimal totalPrice = decimal.Parse(txtPrice.Text); // Assuming txtPrice is for total price
                int customerId = int.Parse(txtCustomerId.Text); // Assuming txtCustomerId is for customer Id

                // Get booking date from DatePicker
                DateOnly bookingDate = (DateOnly)(dpBookingDate.SelectedDate.HasValue ? DateOnly.FromDateTime(dpBookingDate.SelectedDate.Value.Date) : (DateOnly?)null);

                // Get status from ComboBox
                int status = cmbStatus.SelectedIndex;

                // Create or update BookingReservation object
                BookingReservation reservation = new BookingReservation
                {
                    BookingReservationId = id,
                    TotalPrice = totalPrice,
                    CustomerId = customerId,
                    BookingDate = bookingDate,
                    BookingStatus = (byte?)status
                    // Populate other fields as needed
                };

                // Update the reservation using your existing method
                IBookingReservationRepository bookingReservationRepository = new BookingReservationRepository();
                bookingReservationRepository.Update(reservation);

                // Optionally notify user of success
                MessageBox.Show("Reservation updated successfully!");

                // Close the window after saving
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error updating reservation: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
         private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            // Close the window without saving changes
            this.Close();
        }
    }
   
}
