using data.models.entities;
using data.models.viewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace business_logic.services.interfaces
{
    public interface IUserService
    {
        UserViewModel GetUsers();
        UserViewModel GetUserById(string id);
        UserViewModel GetUserByEmail(string email);

        UserViewModel Create(User user);

        UserViewModel Update(User user,string id);
    }
}
