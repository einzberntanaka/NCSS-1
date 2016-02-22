using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NCSS.Contracts.Components;
using NCSS.DataAccess.Users;
using NCSS.Contracts.DataAcess;
using NCSS.EntityModel.Entities;
using System.Web;
namespace NCSS.BusinessComponents.Components
{
    public class UsersManager : IUsersManager
    {
        private readonly IUserDAO UsersAccess;
        public UsersManager()
            :base()
        {
            this.UsersAccess = new UserDAO();
        }
        public USER LoginChecking(string username, string password)
        {
            USER user = UsersAccess.GetUser(username,password);

            return user;
        }
    }
}
