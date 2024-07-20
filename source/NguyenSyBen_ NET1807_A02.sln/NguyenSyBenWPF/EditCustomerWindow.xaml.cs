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
    /// Interaction logic for EditCustomerWindow.xaml
    /// </summary>
    public partial class EditCustomerWindow : Window
    {
        private readonly ICustomerRepository _customerRepository;
        private Customer _customer;
        public EditCustomerWindow(ICustomerRepository customerRepository, Customer customer)
        {
            InitializeComponent();
            _customerRepository = customerRepository;
            _customer = customer;
            txtFullName.Text = customer.CustomerFullName;
            txtTelephone.Text = _customer.Telephone;
            txtEmail.Text = _customer.EmailAddress;

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

            cbStatus.SelectedItem = _customer.CustomerStatus == 1 ? "Active" : "Inactive";
        }
        private void SaveButton_Click(object sender, RoutedEventArgs e)
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
            if (string.IsNullOrWhiteSpace(txtEmail.Text) || !IsValidEmail(txtEmail.Text))
            {
                MessageBox.Show("A valid Email Address is required.", "Validation Error", MessageBoxButton.OK, MessageBoxImage.Error);
                txtEmail.Focus();
                return;
            }

            // Validate Birthday
            if (dpBirthday.SelectedDate == null)
            {
                MessageBox.Show("Birthday is required.", "Validation Error", MessageBoxButton.OK, MessageBoxImage.Error);
                dpBirthday.Focus();
                return;
            }

            try
            {
                // Update customer details
                _customer.CustomerFullName = txtFullName.Text;
                _customer.Telephone = txtTelephone.Text;
                _customer.EmailAddress = txtEmail.Text;
                _customer.CustomerBirthday = dpBirthday.SelectedDate.HasValue ? DateOnly.FromDateTime(dpBirthday.SelectedDate.Value.Date) : (DateOnly?)null;
                _customer.CustomerStatus = (byte?)(cbStatus.SelectedIndex == 0 ? 1 : 0);

                // Attempt to update the customer in the repository
                _customerRepository.UpdateCustomer(_customer);
                MessageBox.Show("Customer updated successfully.", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
                Close();
            }
            catch (Exception ex)
            {
                // Handle any exceptions that occur during the update operation
                MessageBox.Show($"An error occurred while updating the customer: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            Close();
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

