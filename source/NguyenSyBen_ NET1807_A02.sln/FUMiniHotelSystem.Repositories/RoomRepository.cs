using FUMiniHotelSystem.Business.Models;
using FUMiniHotelSystem.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FUMiniHotelSystem.Repositories
{
    public class RoomRepository : IRoomRepository
    {
        public RoomRepository() { }

        public void AddRoom(RoomInformation room) => RoomDAO.AddRoom(room);
       

        public void DeleteRoom(int roomId) => RoomDAO.DeleteRoom(roomId);

        public List<RoomInformation> RoomList()  => RoomDAO.RoomList();
        

        public void UpdateRoom(RoomInformation room) => RoomDAO.UpdateRoom(room);
       
    }
}
