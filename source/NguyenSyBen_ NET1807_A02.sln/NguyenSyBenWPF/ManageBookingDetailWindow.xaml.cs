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
    /// Interaction logic for ManageBookingDetailWindow.xaml
    /// </summary>
    public partial class ManageBookingDetailWindow : Window
    {
        private readonly IBookingDetailRepository _repository;
        public ManageBookingDetailWindow(IBookingDetailRepository bookingDetailRepository)
        {
            InitializeComponent();
            _repository = bookingDetailRepository;
            LoadBookingDetail();
        }
        private void LoadBookingDetail()
        {
            List<BookingDetail> list = _repository.GetAll();
            lv.ItemsSource = list;
        }
        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            AdminWindow adminWindow = new AdminWindow();
            adminWindow.Show();
            Close();
        }
    }
}
