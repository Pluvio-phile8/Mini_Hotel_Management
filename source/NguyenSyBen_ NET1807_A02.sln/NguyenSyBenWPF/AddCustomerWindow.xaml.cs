using FUMiniHotelSystem.Business.Models;
using FUMiniHotelSystem.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
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
    /// Interaction logic for AddCustomerWindow.xaml
    /// </summary>
    public partial class AddCustomerWindow : Window
    {
        private readonly ICustomerRepository _customerRepository;
        public AddCustomerWindow(ICustomerRepository customerRepository)
        {
            InitializeComponent();
            _customerRepository = customerRepository;
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            Customer customer = new Customer();
            customer.CustomerFullName = txtFullName.Text;
            customer.Telephone = txtTelephone.Text;
            customer.EmailAddress = txtEmailAddress.Text;
            customer.CustomerBirthday = dpBirthday.SelectedDate != null ? DateOnly.FromDateTime(dpBirthday.SelectedDate.Value.Date) : null;
            customer.CustomerStatus = 1;
            _customerRepository.AddCustomer(customer);
            DialogResult = true;
            Close();
        }
    }
}
