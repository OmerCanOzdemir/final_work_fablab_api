using data.context;
using data.models.entities;
using data.models.viewModels;
using data.repositories.interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace data.repositories
{
    public class UserRepository : IUserRepository
    {
        public async  Task<UserViewModel> Create(User user)
        {
            using (var context = new Context(Context.Option.Options))
            {
                try
                {
                    await context.Users.AddAsync(user);
                    await context.SaveChangesAsync();
                    return new UserViewModel(HttpStatusCode.OK, user, null);
                }
                catch (Exception ex)
                {
                    return new UserViewModel(HttpStatusCode.InternalServerError, null, ex.InnerException!.Message);
                }
            }
        }

        public async Task<UserViewModel> GetUserByEmail(string email)
        {
            using (var context = new Context(Context.Option.Options))
            {
                try
                {
                    var user = await context.Users.FirstOrDefaultAsync(c => c.Email.Equals(email));


                    if (user == null)
                    {
                        return new UserViewModel(HttpStatusCode.NotFound, null, null);
                    }
                    return new UserViewModel(HttpStatusCode.OK, user, null);
                }
                catch (Exception ex)
                {
                    return new UserViewModel(HttpStatusCode.InternalServerError, null, ex.InnerException!.Message);
                }

            }
        }

        public async  Task<UserViewModel> GetUserById(string id)
        {
            using (var context = new Context(Context.Option.Options))
            {
                try
                {
                    var user = await context.Users.Include(u=> u.Interests).Include(u=> u.Created_Projects).Include(u => u.Joined_Projects).ThenInclude(pu => pu.Project).FirstOrDefaultAsync(c => c.Id.Equals(id));

                    if (user == null)
                    {
                        return new UserViewModel(HttpStatusCode.NotFound, null, null);
                    }
                    return new UserViewModel(HttpStatusCode.OK, user, null);
                }
                catch (Exception ex)
                {
                    return new UserViewModel(HttpStatusCode.InternalServerError, null, ex.InnerException!.Message);
                }
            }
        }

        public async Task<UserViewModel> GetUsers()
        {
            using (var context = new Context(Context.Option.Options))
            {
                try
                {

                    var users = await context.Users.Include(u => u.Interests).ThenInclude(uc => uc.Category).ToListAsync();
                    return new UserViewModel(users, HttpStatusCode.OK, null);
                }
                catch (Exception ex)
                {
                    return new UserViewModel(null, HttpStatusCode.InternalServerError, ex.InnerException!.Message);
                }
            }
        }

        public async Task<UserViewModel> Update(User user)
        {
            using (var context = new Context(Context.Option.Options))
            {
                try
                {
                    context.Users.Update(user);
                    await context.SaveChangesAsync();
                    return new UserViewModel(HttpStatusCode.OK, user, null);
                }
                catch (Exception ex)
                {
                    return new UserViewModel(HttpStatusCode.InternalServerError, null, ex.InnerException!.Message);
                }
            }
        }
    }
}
