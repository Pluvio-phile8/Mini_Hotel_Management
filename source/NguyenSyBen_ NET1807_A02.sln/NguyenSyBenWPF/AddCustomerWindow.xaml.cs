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
            // Validate Full Name
            if (string.IsNullOrWhiteSpace(txtFullName.Text))
            {
                MessageBox.Show("Full Name is required.", "Validation Error", MessageBoxButton.OK, MessageBoxImage.Error);
                txtFullName.Focus();
                return;
            }

            // Validate Telephone
            if (string.IsNullOrWhiteSpace(txtTelephone.Text) || !IsValidTelephone(txtTelephone.Text))
            {
                MessageBox.Show("A valid Telephone number is required.", "Validation Error", MessageBoxButton.OK, MessageBoxImage.Error);
                txtTelephone.Focus();
                return;
            }

            // Validate Email Address
            if (string.IsNullOrWhiteSpace(txtEmailAddress.Text) || !IsValidEmail(txtEmailAddress.Text))
            {
                MessageBox.Show("A valid Email Address is required.", "Validation Error", MessageBoxButton.OK, MessageBoxImage.Error);
                txtEmailAddress.Focus();
                return;
            }

            // Validate Birthday
            if (dpBirthday.SelectedDate == null)
            {
                MessageBox.Show("Birthday is required.", "Validation Error", MessageBoxButton.OK, MessageBoxImage.Error);
                dpBirthday.Focus();
                return;
            }

            // Initialize a new customer object
            Customer customer = new Customer
            {
                CustomerFullName = txtFullName.Text,
                Telephone = txtTelephone.Text,
                EmailAddress = txtEmailAddress.Text,
                CustomerBirthday = DateOnly.FromDateTime(dpBirthday.SelectedDate.Value.Date),
                CustomerStatus = 1
            };

            try
            {
                // Attempt to add the customer to the repository
                _customerRepository.AddCustomer(customer);
                MessageBox.Show("Customer added successfully.", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
                DialogResult = true;
                Close();
            }
            catch (Exception ex)
            {
                // Handle any exceptions that occur during the add operation
                MessageBox.Show($"An error occurred while adding the customer: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        // Helper method to validate email
        private bool IsValidEmail(string email)
        {
            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
                return addr.Address == email;
            }
            catch
            {
                return false;
            }
        }

        // Helper method to validate telephone number (basic example)
        private bool IsValidTelephone(string telephone)
        {
            return telephone.All(char.IsDigit) && telephone.Length >= 10;
        }


    }
}
