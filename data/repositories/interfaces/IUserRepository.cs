using data.models.entities;
using data.models.viewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace data.repositories.interfaces
{
    public interface IUserRepository
    {
        Task<UserViewModel> GetUsers();
        Task<UserViewModel> GetUserById(string id);
        Task<UserViewModel> GetUserByEmail(string email);

        Task<UserViewModel> Create(User user);

        Task<UserViewModel> Update(User user);

       
    }
}
