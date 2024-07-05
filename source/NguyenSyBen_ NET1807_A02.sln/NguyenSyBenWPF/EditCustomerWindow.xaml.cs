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
            _customer.CustomerFullName = txtFullName.Text;
            _customer.Telephone = txtTelephone.Text;
            _customer.EmailAddress = txtEmail.Text;
            _customer.CustomerBirthday = dpBirthday.SelectedDate != null ? DateOnly.FromDateTime(dpBirthday.SelectedDate.Value.Date) : null;
            _customer.CustomerStatus = (byte?)(cbStatus.SelectedIndex == 0 ? 1 : 0);
            _customerRepository.UpdateCustomer(_customer);
            Close();
        }
        private void CancelButton_Click(Object sender, RoutedEventArgs e)
        {
            Close();
        }
    }

    }

