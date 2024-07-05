using FUMiniHotelSystem.Business.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FUMiniHotelSystem.Repositories
{
    public interface ICustomerRepository
    {
        List<Customer> CustomerList();
        Customer GetById(int id);
        void AddCustomer(Customer customer);
        void UpdateCustomer(Customer customer);
        void DeleteById(int id);
    }
}
