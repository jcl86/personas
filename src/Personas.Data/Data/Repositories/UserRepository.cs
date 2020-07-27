using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Personas.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Personas.Data.Repositories
{
    public class UserRepository : Repository, IUserRepository
    {
        public UserRepository(DataContext context) : base(context) { }

        public async Task<IEnumerable<Domain.User>> GetAll()
        {
            var allRoles = await context.Roles.ToListAsync();
            var userRoles  = await context.UserRoles.ToListAsync();
            var users = await context.Users.ToListAsync();

            return users.Select(x => Map(x, userRoles.Where(ur => ur.UserId.Equals(x.Id)), allRoles)).ToList();
        }

        public async Task<Domain.User> GetUser(Guid idUser)
        {
            var allRoles = await context.Roles.ToListAsync();
            var userRoles = await context.UserRoles.ToListAsync();
            var user = await context.Users.FindAsync(idUser.ToString());

            if (user is null)
            {
                return null;
            }

            return Map(user, userRoles.Where(ur => ur.UserId.Equals(user.Id)), allRoles);
        }

        public async Task<Domain.User> GetUser(UserName email)
        {
            var allRoles = await context.Roles.ToListAsync();
            var userRoles = await context.UserRoles.ToListAsync();
            var user = await context.Users.FirstOrDefaultAsync(x => x.NormalizedEmail.Equals(email.NormalizedEmail));

            if (user is null)
            {
                return null;
            }

            return Map(user, userRoles.Where(ur => ur.UserId.Equals(user.Id)), allRoles);
        }

        private Domain.User Map(User user, IEnumerable<IdentityUserRole<string>> userRoles, IEnumerable<IdentityRole<string>> allRoles)
        {
            var ids = userRoles.Select(x => x.RoleId);
            var rolesFromUser = allRoles.Where(x => ids.Contains(x.Id)).Select(x => x.Name);
            return new Domain.User(user.Id, user.UserName, rolesFromUser.ToArray());
        }
    }


}
