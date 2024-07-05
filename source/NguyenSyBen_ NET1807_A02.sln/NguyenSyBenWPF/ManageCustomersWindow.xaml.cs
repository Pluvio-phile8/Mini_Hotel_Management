using FUMiniHotelSystem.Repositories;
using FUMiniHotelSystem.Business.Models;
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
    /// Interaction logic for ManageCustomersWindow.xaml
    /// </summary>
    public partial class ManageCustomersWindow : Window
    {
        private readonly ICustomerRepository _customerRepository;
        public ManageCustomersWindow(ICustomerRepository customerRepository)
        {

            InitializeComponent();
            _customerRepository = customerRepository;
            LoadCustomers();
        }
        private void LoadCustomers()
        {
            List<Customer> customers = _customerRepository.CustomerList();
            lvCustomers.ItemsSource = customers;
        }
        private void AddCustomerButton_Click(object sender, RoutedEventArgs e)
        {
            var addCustomerWindow = new AddCustomerWindow(_customerRepository);
            if (addCustomerWindow.ShowDialog() == true)
            {
                LoadCustomers();
            }
        }
        private void EditCustomerButton_Click(object sender, RoutedEventArgs e)
        {
            Button btn = sender as Button;
            Customer selectedCustomer = btn.Tag as Customer;
            if (selectedCustomer != null)
            {
                var editCustomerWindow = new EditCustomerWindow(_customerRepository, selectedCustomer);
                editCustomerWindow.ShowDialog();
                LoadCustomers();

            }
        }
        private void DeleteCustomerButton_Click(object sender, RoutedEventArgs e)
        {
            if (sender is Button button && button.CommandParameter is Customer customer)
            {
                MessageBoxResult result = MessageBox.Show($"Are you sure you want to delete customer {customer.CustomerFullName}?",
                                                          "Confirm Delete",
                                                          MessageBoxButton.YesNo,
                                                          MessageBoxImage.Question);

                if (result == MessageBoxResult.Yes)
                {
                    try
                    {
                        _customerRepository.DeleteById(customer.CustomerId);
                        LoadCustomers();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Error deleting customer: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                }
            }
        }
        private void BackButton_Click(Object sender, RoutedEventArgs e)
        {
            DialogResult = false;
            AdminWindow adminWindow = new AdminWindow();
            adminWindow.Show();
            Close();
        }
    }
}
