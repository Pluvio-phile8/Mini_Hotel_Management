using FUMiniHotelSystem.Business.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FUMiniHotelSystem.Repositories
{
    public interface IAuthRepository
    {
        Customer ChekLogin(string email, string password);
    }
}
