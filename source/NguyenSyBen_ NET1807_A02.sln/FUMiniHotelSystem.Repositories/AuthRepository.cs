using FUMiniHotelSystem.Business.Models;
using FUMiniHotelSystem.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FUMiniHotelSystem.Repositories
{
    public class AuthRepository : IAuthRepository
    {
        public Customer ChekLogin(string email, string password) => CustomerDAO.CheckLogin(email, password);
        
    }
}
