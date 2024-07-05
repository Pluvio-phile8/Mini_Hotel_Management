using FUMiniHotelSystem.Business.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FUMiniHotelSystem.Data
{
    public class CustomerDAO
    {
        public static List<Customer> CustomerList()
        {
            List<Customer> list = new List<Customer>();
            try
            {
                using (var context = new FuminiHotelManagementContext())
                {
                    list = context.Customers.ToList();
                }

            } catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return list;
        }
        //Customer GetById(int id);
        public static void AddCustomer(Customer customer)
        {
            try
            {
                using (var context = new FuminiHotelManagementContext())
                {
                    context.Customers.Add(customer);
                    context.SaveChanges();
                }

            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
        public static void UpdateCustomer(Customer customer)
        {
            try
            {
                using (var context = new FuminiHotelManagementContext())
                {
                    context.Customers.Update(customer);
                    context.SaveChanges();
                }

            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
        public static void DeleteById(int id)
        {
            try
            {
                using (var context = new FuminiHotelManagementContext())
                {
                    var customer = context.Customers.Find(id);
                    if (customer != null)
                    {
                        context.Customers.Remove(customer);
                        context.SaveChanges();
                    }
                }

            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public static Customer CheckLogin(string email, string password)
        {
            try
            {
                using (var context = new FuminiHotelManagementContext())
                {
                    var customer = context.Customers.SingleOrDefault(c => c.EmailAddress == email && c.Password == password);
                    return customer;
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
        public static Customer GetById(int id)
        {

            try
            {
                using (var context = new FuminiHotelManagementContext())
                {
                    var customer = context.Customers.Find(id);
                    return customer;
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
    }
}
