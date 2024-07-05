using FUMiniHotelSystem.Repositories;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
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
    /// Interaction logic for AdminWindow.xaml
    /// </summary>
    public partial class AdminWindow : Window
    {
        public AdminWindow()
        {
            InitializeComponent();
           
        }
       
        private void ManageCustomersButton_Click(object sender, RoutedEventArgs e)
        {
            ICustomerRepository customerRepository = new CustomerRepository();
            ManageCustomersWindow manageCustomersWindow = new ManageCustomersWindow(customerRepository);
            manageCustomersWindow.ShowDialog();
            this.Close();
        }
        private void ManageRoomButton_Click(Object sender, RoutedEventArgs e)
        {
            IRoomRepository roomRepository = new RoomRepository();
            ManageRoomWindow manageRoomWindow = new ManageRoomWindow(roomRepository);
            manageRoomWindow.ShowDialog();
            this.Close();
        }
        private void ManageBookingReservation_Click(object sender, RoutedEventArgs e)
        {
            IBookingReservationRepository bookingReservationRepository = new BookingReservationRepository();
            ManageBookingReservationWindow manageBookingReservationWindow = new ManageBookingReservationWindow(bookingReservationRepository);
            manageBookingReservationWindow.ShowDialog();
            this.Close();
        }
        private void ManageBookingDetail_Click(object sender, RoutedEventArgs e)
        {
            IBookingDetailRepository bookingDetailRepository = new BookingDetailRepository();
            ManageBookingDetailWindow manageBookingDetailWindow = new ManageBookingDetailWindow(bookingDetailRepository);
            manageBookingDetailWindow.ShowDialog();
            this.Close();
        }


    }
}
