using FUMiniHotelSystem.Business.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FUMiniHotelSystem.Data
{
    public class BookingDetailDAO
    {
        public BookingDetailDAO() { }
        public static List<BookingDetail> GetBookingDetailList()
        {
            List<BookingDetail> list = new List<BookingDetail>();
            try
            {
                using (var context = new FuminiHotelManagementContext())
                {
                    list = context.BookingDetails.ToList();
                }

            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return list;


        }
        public static void Add(BookingDetail bookingDetail)
        {
            try
            {
                using (var context = new FuminiHotelManagementContext())
                {
                    context.BookingDetails.Add(bookingDetail);
                    context.SaveChanges();
                }

            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
        public static void Update(BookingDetail bookingDetail)
        {
            try
            {
                using (var context = new FuminiHotelManagementContext())
                {
                    context.BookingDetails.Update(bookingDetail);
                    context.SaveChanges();
                }

            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
        public static void Delete(int id)
        {
            try
            {
                using (var context = new FuminiHotelManagementContext())
                {
                    BookingDetail bookingDetail = context.BookingDetails.Find(id);
                    if (bookingDetail != null)
                    {
                        context.BookingDetails.Remove(bookingDetail);
                        context.SaveChanges();
                    }
                    
                }

            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
    }
}
