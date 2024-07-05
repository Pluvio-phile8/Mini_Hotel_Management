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
    /// Interaction logic for ManageBookingReservationWindow.xaml
    /// </summary>
    public partial class ManageBookingReservationWindow : Window
    {
        private readonly IBookingReservationRepository _repository;
        public ManageBookingReservationWindow(IBookingReservationRepository repo)
        {
            InitializeComponent();
            _repository = repo;
            LoadBookingReservations();
        }
        private void LoadBookingReservations()
        {
            List<BookingReservation> bookingReservations = new List<BookingReservation>();
            bookingReservations = _repository.GetAll();
            Reservaion.ItemsSource = bookingReservations;
        }
        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            AdminWindow adminWindow = new AdminWindow();
            adminWindow.Show();
            Close();
        }

    }
}
