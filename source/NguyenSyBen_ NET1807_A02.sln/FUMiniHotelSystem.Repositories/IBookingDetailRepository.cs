using FUMiniHotelSystem.Business.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FUMiniHotelSystem.Repositories
{
    public interface IBookingDetailRepository
    {
        List<BookingDetail> GetAll();
        void Add(BookingDetail bookingDetail);
        void Update(BookingDetail bookingDetail);
        void Delete(int id);
    }
}
