using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NCSS.EntityModel.Entities;
namespace NCSS.Contracts.DataAcess
{
    public interface IUserDAO
    {
        USER GetUser(string username, string password);
    }
}
