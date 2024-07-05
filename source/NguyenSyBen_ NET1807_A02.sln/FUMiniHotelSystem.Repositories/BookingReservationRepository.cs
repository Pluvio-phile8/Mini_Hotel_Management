using FUMiniHotelSystem.Business.Models;
using FUMiniHotelSystem.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FUMiniHotelSystem.Repositories
{
    public class BookingReservationRepository : IBookingReservationRepository
    {
        public void Add(BookingReservation bookingReservation) => BookingReservationDAO.Add(bookingReservation);
       

        public void Delete(int id) => BookingReservationDAO.Delete(id);
       

        public List<BookingReservation> GetAll() => BookingReservationDAO.GetBookingReservationList();
       

        public void Update(BookingReservation bookingReservation) => BookingReservationDAO.Update(bookingReservation);
        public List<BookingReservation> GetBookingReservationsByCustomerId(int customerId) => BookingReservationDAO.GetBookingReservationsByCustomerId(customerId);

    }
}
