﻿namespace MyStore.Domain.Account.Commands.UserCommands
{
  public  class RegisterUserCommand
    {
        public string Email { get; set; }

        public string UserName { get; set; }

        public string Password { get; set; }

        public RegisterUserCommand(string email, string username, string password)
        {
            Email = email;
            UserName = username;
            Password = password;
        }
    }
}
