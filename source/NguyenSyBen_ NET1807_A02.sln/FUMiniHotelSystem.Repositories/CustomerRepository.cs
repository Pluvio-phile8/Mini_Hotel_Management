using FUMiniHotelSystem.Business.Models;
using FUMiniHotelSystem.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FUMiniHotelSystem.Repositories
{
    public class CustomerRepository : ICustomerRepository
    {
        public void AddCustomer(Customer customer) => CustomerDAO.AddCustomer(customer);

        public void DeleteById(int id) => CustomerDAO.DeleteById(id);



        public List<Customer> CustomerList() => CustomerDAO.CustomerList();

        public Customer GetById(int id) => CustomerDAO.GetById(id);
       

        public void UpdateCustomer(Customer customer) => CustomerDAO.UpdateCustomer(customer);
    }
}
