using FUMiniHotelSystem.Business.Models;
using FUMiniHotelSystem.Data;
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
    /// Interaction logic for AddBooking.xaml
    /// </summary>
    public partial class AddBooking : Window
    {
        private readonly IBookingDetailRepository _repository;
        private readonly IBookingReservationRepository _bookingReservationRepository;
        public AddBooking(IBookingDetailRepository repository, IBookingReservationRepository bookingReservationRepository)
        {
            InitializeComponent();
            _repository = repository;
            _bookingReservationRepository = bookingReservationRepository;
            LoadRoomTypes();
        }
        private void LoadRoomTypes()
        {
            try
            {
                RoomRepository roomRepository = new RoomRepository();
                var roomTypes = roomRepository.RoomList();
                List<RoomInformation> roomInformation = new List<RoomInformation>();
                foreach (var room in roomTypes)
                {
                    if (room.RoomStatus == 1)
                    {
                        roomInformation.Add(room);
                    }
                }
                RoomTypeComboBox.ItemsSource = roomInformation;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred while loading room types: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            BookingDetailRepository bookingDetailRepository = new BookingDetailRepository();
            RoomRepository roomRepository = new RoomRepository();
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

            // Validate Room ID from ComboBox
            if (RoomTypeComboBox.SelectedValue == null || !int.TryParse(RoomTypeComboBox.SelectedValue.ToString(), out int roomId))
            {
                MessageBox.Show("Please select a valid Room ID.", "Validation Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            var _bookingDetail = bookingDetailRepository.GetExistBooking(reservationId, roomId);
            if (_bookingDetail != null)
            {
                MessageBox.Show("Booking existed", "Validation Error", MessageBoxButton.OK, MessageBoxImage.Error);
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

           

            var roomInformation = new RoomInformation();
            roomInformation = roomRepository.GetRoomById(roomId);
            decimal actualPrice = 0;
            if (roomInformation != null)
            {
                TimeSpan dateDifference = dpEndDate.SelectedDate.Value - dpStartDate.SelectedDate.Value;
                int numberOfDays = dateDifference.Days;
                if (numberOfDays > 0)
                {
                    actualPrice = (decimal)(roomInformation.RoomPricePerDay * numberOfDays);
                }
            } else
            {
                return;
            }
            decimal formattedActualPrice = Decimal.Parse(actualPrice.ToString());   


            // If all validations pass, create a new BookingDetail object
            var bookingDetail = new BookingDetail
            {
                BookingReservationId = reservationId,
                RoomId = roomId,
                StartDate = DateOnly.FromDateTime(dpStartDate.SelectedDate.Value),
                EndDate = DateOnly.FromDateTime(dpEndDate.SelectedDate.Value),
                ActualPrice = formattedActualPrice
            };

            _repository.Add(bookingDetail);
            MessageBox.Show("Added Successful!");
            this.Close();
        }
        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
