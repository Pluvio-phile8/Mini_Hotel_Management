using FUMiniHotelSystem.Business.Models;
using FUMiniHotelSystem.Repositories;
using System.Windows;

namespace NguyenSyBenWPF
{
    /// <summary>
    /// Interaction logic for EditBookingWindow.xaml
    /// </summary>
    public partial class EditBookingWindow : Window
    {
        private readonly IBookingDetailRepository _repository;
        private readonly IBookingReservationRepository _bookingReservationRepository;

        public EditBookingWindow(BookingDetail bookingDetail, IBookingDetailRepository repository, IBookingReservationRepository bookingReservationRepository)
        {
            InitializeComponent();
            _repository = repository;
            _bookingReservationRepository = bookingReservationRepository;
            txtReservationId.Text = bookingDetail.BookingReservationId.ToString();
            txtBookingId.Text = bookingDetail.BookingReservationId.ToString();
            txtRoomId.Text = bookingDetail.RoomId.ToString();
            dpStartDate.SelectedDate = bookingDetail.StartDate.ToDateTime(TimeOnly.MinValue);    
            dpEndDate.SelectedDate = bookingDetail.EndDate.ToDateTime(TimeOnly.MinValue);
            txtActualPrice.Text = bookingDetail.ActualPrice.ToString();
        }

        public BookingDetail BookingDetail { get; }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            
            // Validate Reservation ID
            if (string.IsNullOrWhiteSpace(txtReservationId.Text) || !int.TryParse(txtReservationId.Text, out int reservationId))
            {
                MessageBox.Show("Please enter a valid Reservation ID.", "Validation Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            // Check if Reservation ID exists
            if (_bookingReservationRepository.GetById(reservationId) == null)
            {
                MessageBox.Show("Invalid Reservation ID.", "Validation Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            // Validate Room ID
            if (string.IsNullOrWhiteSpace(txtRoomId.Text) || !int.TryParse(txtRoomId.Text, out int roomId))
            {
                MessageBox.Show("Please enter a valid Room ID.", "Validation Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            // Validate Start Date
            if (!dpStartDate.SelectedDate.HasValue)
            {
                MessageBox.Show("Please select a valid Start Date.", "Validation Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            // Validate End Date
            if (!dpEndDate.SelectedDate.HasValue)
            {
                MessageBox.Show("Please select a valid End Date.", "Validation Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            // Ensure End Date is not before Start Date
            if (dpEndDate.SelectedDate.Value < dpStartDate.SelectedDate.Value)
            {
                MessageBox.Show("End Date cannot be before Start Date.", "Validation Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            // Validate Actual Price
            if (string.IsNullOrWhiteSpace(txtActualPrice.Text) || !decimal.TryParse(txtActualPrice.Text, out decimal actualPrice))
            {
                MessageBox.Show("Please enter a valid Actual Price.", "Validation Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            // If all validations pass, create a new BookingDetail object
            var bookingDetail = new BookingDetail
            {
                BookingReservationId = reservationId,
                RoomId = roomId,
                StartDate = DateOnly.FromDateTime(dpStartDate.SelectedDate.Value),
                EndDate = DateOnly.FromDateTime(dpEndDate.SelectedDate.Value),
                ActualPrice = actualPrice
            };

            // Save changes (assuming you have a method like Update in your repository)
            _repository.Update(bookingDetail);
            MessageBox.Show("Edit successful!");
            // Close the window
            this.Close();

        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
