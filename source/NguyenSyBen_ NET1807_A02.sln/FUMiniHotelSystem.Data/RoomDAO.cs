using FUMiniHotelSystem.Business.Models;
using Microsoft.Identity.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FUMiniHotelSystem.Data
{
    public class RoomDAO
    {
        public static List<RoomInformation> RoomList()
        {
            List<RoomInformation> list = new List<RoomInformation>();
            try
            {
                using (var context = new FuminiHotelManagementContext())
                {
                    list = context.RoomInformations.ToList();
                }

            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return list;
        }
        public static void AddRoom(RoomInformation roomInformation)
        {
            try
            {
                using (var context = new FuminiHotelManagementContext())
                {
                    context.RoomInformations.Add(roomInformation);
                    context.SaveChanges();
                }

            } catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
        public static void UpdateRoom(RoomInformation roomInformation) {
            try
            {
                using (var context = new FuminiHotelManagementContext())
                {
                    context.RoomInformations.Update(roomInformation);
                    context.SaveChanges();
                }

            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
        public static void DeleteRoom(int id)
        {
            try
            {
                using (var context = new FuminiHotelManagementContext())
                {
                    RoomInformation room = context.RoomInformations.Find(id);
                    if (room != null)
                    {
                        context.RoomInformations.Remove(room);
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
