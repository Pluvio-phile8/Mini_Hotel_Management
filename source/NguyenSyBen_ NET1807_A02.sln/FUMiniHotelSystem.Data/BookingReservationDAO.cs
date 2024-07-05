using FUMiniHotelSystem.Business.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FUMiniHotelSystem.Data
{
    public class BookingReservationDAO
    {
        public BookingReservationDAO() { }
        public static List<BookingReservation> GetBookingReservationList() {
            List<BookingReservation> list = new List<BookingReservation>();
            try
            {
                using (var context = new FuminiHotelManagementContext())
                {
                    list = context.BookingReservations.ToList();
                }

            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return list;

        }
        public static void Add(BookingReservation reservation)
        {
            try
            {
                using (var context = new FuminiHotelManagementContext())
                {
                    context.BookingReservations.Add(reservation);
                    context.SaveChanges();
                }

            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
        public static void Update(BookingReservation reservation)
        {
            try
            {
                using (var context = new FuminiHotelManagementContext())
                {
                    context.BookingReservations.Update(reservation);
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
                    BookingReservation reservation = context.BookingReservations.Find(id);
                    if (reservation != null)
                    {
                        context.BookingReservations.Remove(reservation);
                        context.SaveChanges();
                    }
                }

            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
        public static List<BookingReservation> GetBookingReservationsByCustomerId(int customerId)
        {
            try
            {
                using (var context = new FuminiHotelManagementContext())
                {
                    return context.BookingReservations
                       .Include(br => br.BookingDetails)
                       .Where(br => br.CustomerId == customerId)
                       .ToList();
                }

            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
    }
}
