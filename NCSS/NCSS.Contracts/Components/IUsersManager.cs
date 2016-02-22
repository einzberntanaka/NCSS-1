using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NCSS.EntityModel.Entities;

namespace NCSS.Contracts.Components
{
    public interface IUsersManager
    {
        USER LoginChecking(string username, string password);
    }
}
