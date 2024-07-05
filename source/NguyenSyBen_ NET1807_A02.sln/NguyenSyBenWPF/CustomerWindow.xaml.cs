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
    /// Interaction logic for CustomerWindow.xaml
    /// </summary>
    public partial class CustomerWindow : Window
    {
        private readonly ICustomerRepository _customerRepository;
        public CustomerWindow(int id, ICustomerRepository customerRepository)
        {
            InitializeComponent();
            _customerRepository = customerRepository;
            Customer customer = LoadProfile(id);
            txtFullName.Text = customer.CustomerFullName;
            txtTelephone.Text = customer.Telephone;
            txtEmail.Text = customer.EmailAddress;
            if (customer.CustomerBirthday.HasValue)
            {
                dpBirthday.SelectedDate = customer.CustomerBirthday.Value.ToDateTime(TimeOnly.MinValue);
            }
            else
            {
                dpBirthday.SelectedDate = null;
            }

            if (dpBirthday.SelectedDate.HasValue)
            {
                customer.CustomerBirthday = DateOnly.FromDateTime(dpBirthday.SelectedDate.Value);
            }
            else
            {
                customer.CustomerBirthday = null;
            }
            txtCustomerId.Text = customer.CustomerId.ToString();
        }

        public CustomerWindow()
        {
        }

        private Customer LoadProfile(int id)
        {
            var customer = _customerRepository.GetById(id);
            return customer;
        }
        private void LogoutButton_Click(object sender, RoutedEventArgs e)
        {
            LoginWindow loginWindow = new LoginWindow();
            loginWindow.Show();
            Close();
        }
        public void ViewBookingHistoryButton_Click(Object sender, RoutedEventArgs e)
        {
            IBookingReservationRepository bookingReservationRepository = new BookingReservationRepository();
            int id = int.Parse(txtCustomerId.Text);
            ViewBookingHistoryWindow viewBookingHistoryWindow = new ViewBookingHistoryWindow(bookingReservationRepository, id);
            viewBookingHistoryWindow.Show();
        }

    }
}
