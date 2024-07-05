using FUMiniHotelSystem.Business.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FUMiniHotelSystem.Repositories
{
    public interface IBookingReservationRepository
    {
        List<BookingReservation> GetAll();
        void Add(BookingReservation bookingReservation);
        void Update(BookingReservation bookingReservation);
        void Delete(int id);
        List<BookingReservation> GetBookingReservationsByCustomerId(int customerId);

    }
}
