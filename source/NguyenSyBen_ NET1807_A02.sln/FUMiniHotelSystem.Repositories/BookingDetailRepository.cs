using FUMiniHotelSystem.Business.Models;
using FUMiniHotelSystem.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FUMiniHotelSystem.Repositories
{
    public class BookingDetailRepository : IBookingDetailRepository
    {
        public void Add(BookingDetail bookingDetail) => BookingDetailDAO.Add(bookingDetail);
        

        public void Delete(int id) => BookingDetailDAO.Delete(id);
       

        public List<BookingDetail> GetAll() => BookingDetailDAO.GetBookingDetailList();


        public void Update(BookingDetail bookingDetail) => BookingDetailDAO.Update(bookingDetail);

    }
}
