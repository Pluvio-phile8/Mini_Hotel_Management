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
    /// Interaction logic for LoginWindow.xaml
    /// </summary>
    public partial class LoginWindow : Window
    {
        private IConfigurationRoot _config;
        public LoginWindow()
        {
            InitializeComponent();
            InitializeConfiguration();
        }
        private void InitializeConfiguration()
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json");

            _config = builder.Build();
        }
        private void LoginButton_Click(object sender, RoutedEventArgs e)
        {
            string email = EmailTextBox.Text;
            string password = PasswordBox.Password;
            string IsAdmin_Email = _config["AdminCredentials:Email"];
            string IsAdmin_Password = _config["AdminCredentials:Password"];
            if (email.Equals(IsAdmin_Email) && password.Equals(IsAdmin_Password))
            {
                MessageBox.Show("Login Successful!");
                AdminWindow adminWindow = new AdminWindow();
                adminWindow.Show();
                this.Close();
            } else
            {
                IAuthRepository authRepository = new AuthRepository();
                var customer = authRepository.ChekLogin(email, password);
                if (customer != null)
                {
                    ICustomerRepository customerRepository = new CustomerRepository();
                    int id = customer.CustomerId;
                    CustomerWindow customerWindow = new CustomerWindow(id, customerRepository);
                    customerWindow.Show();
                    this.Close();
                } else
                {
                    {
                        MessageBox.Show("Login Failed");
                        LoginWindow loginWindow = new LoginWindow();
                        loginWindow.Show();
                    }
                    this.Close();
                }
            }
        }
    }
}
