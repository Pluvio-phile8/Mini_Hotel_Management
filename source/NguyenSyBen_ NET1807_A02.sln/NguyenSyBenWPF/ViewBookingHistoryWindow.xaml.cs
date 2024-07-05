using FUMiniHotelSystem.Business.Models;
using FUMiniHotelSystem.Repositories;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
    /// Interaction logic for ViewBookingHistoryWindow.xaml
    /// </summary>
    public partial class ViewBookingHistoryWindow : Window
    {
        private readonly IBookingReservationRepository _reservationRepository;
        public ViewBookingHistoryWindow(IBookingReservationRepository bookingReservationRepository, int id)
        {
            InitializeComponent();
            _reservationRepository = bookingReservationRepository;
            ListBookingHistory(id);
        }
        private void ListBookingHistory(int id)
        {
            List<BookingReservation> list = _reservationRepository.GetBookingReservationsByCustomerId(id);
            lv.ItemsSource = list;
        }
    }
}
