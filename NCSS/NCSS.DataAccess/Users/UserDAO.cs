using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NCSS.EntityModel.Entities;
using NCSS.Contracts.DataAcess;

namespace NCSS.DataAccess.Users
{
    public class UserDAO : IUserDAO
    {
        NCSSEntities NCSSentities = new NCSSEntities();
        public USER GetUser(string username, string password)
        {
            return NCSSentities.USERs.Where(p => p.Username == username && p.Password == password)
                .FirstOrDefault();
        }
    }
}
