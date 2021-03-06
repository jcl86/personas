﻿using System;
using System.Threading.Tasks;

namespace Personas.Domain
{
    public class PasswordChanger
    {
        private readonly IUserCommands userCommands;
        private readonly IUserRepository userRepository;

        public PasswordChanger(IUserCommands userCommands, IUserRepository userRepository)
        {
            this.userCommands = userCommands;
            this.userRepository = userRepository;
        }

        public async Task Change(Guid currentUser, string yourEmail, string currentPassword, string newPassword)
        {
            var username = new UserName(yourEmail);
            var user = await userRepository.GetUser(username);

            if (user is null)
            {
                throw new NotFoundException($"User with email {yourEmail} was not found");
            }

            if (user.Id != currentUser)
            {
                throw new UnauthorizedAccessException("Only the user can change its own password");
            }

            if (string.IsNullOrWhiteSpace(newPassword))
            {
                throw new DomainException("Password can not be empty");
            }

            await userCommands.UpdatePassword(user, currentPassword, newPassword);

        }
    }
}
