using business_logic.services.interfaces;
using data.models.entities;
using data.models.viewModels;
using data.repositories.interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace business_logic.services
{
    public class UserService : IUserService
    {

        private readonly IUserRepository _userRepository;


        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        public UserViewModel Create(User user)
        {
           user.IsAdmin = false;
           user.User_Created_Time = DateTime.Now;
           return _userRepository.Create(user).Result;
        }

        public UserViewModel GetUserByEmail(string email)
        {
            return _userRepository.GetUserByEmail(email).Result;
        }

        public UserViewModel GetUserById(string id)
        {
            return _userRepository.GetUserById(id).Result;
        }

        public UserViewModel GetUsers()
        {
            return _userRepository.GetUsers().Result;
        }

        public UserViewModel Update(User user, string id)
        {
            var userViewModel = _userRepository.GetUserById(id).Result;

            if (userViewModel.User == null)
            {
                return userViewModel;
            }
            var dbUser = userViewModel.User;

            dbUser.IsAdmin = false;
            dbUser.Firstname = user.Firstname;
            dbUser.Lastname = user.Lastname;
            dbUser.Email = user.Email;

            return _userRepository.Update(dbUser).Result;

        }
    }
}
