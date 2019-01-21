using MyStore.Domain.Account.Enuns;
using MyStore.Domain.Account.Scopes;
using System;

namespace MyStore.Domain.Account.Entites
{
    public class User
    {
        public User(string email, string username, string password)
        {
            Id = Guid.NewGuid();
            Email = email;
            Username = username;
            Password = password;
            Verified = false;
            Active = false;
            LastLoginDate = DateTime.Now;
            Role = ERole.User;
            VerificationCode = Guid.NewGuid().ToString().Substring(0, 6).ToUpper();
            ActivationCode = Guid.NewGuid().ToString().Substring(0, 4).ToUpper();
            AuthorizationCode = string.Empty;
            LastAutorizationCodeRequest = DateTime.Now.AddMinutes(5);
        }

        public Guid Id { get; private set; }
        public string Username { get; private set; }
        public string Password { get; private set; }
        public bool Verified { get; private set; }
        public bool Active { get; private set; }
        public string Email { get; set; }
        public DateTime LastLoginDate { get; private set; }
        public ERole Role { get; private set; }
        public string VerificationCode { get; private set; }
        public string ActivationCode { get; private set; }
        public string AuthorizationCode { get; private set; }
        public DateTime LastAutorizationCodeRequest { get; private set; }

        public void Register()
        {
            this.RegisterScopeIsValid();
            Password = EncriptyPassword(Password);
        }
        public void Verify(string verificationCode)
        {
            this.VerificationScopreIsValid(verificationCode);
            Verified = (verificationCode == VerificationCode);
            #region [+] Codigo feio removido
            //if (verificationCode == VerificationCode)
            //    Verified = true; 
            #endregion
        }
        public void Activate(string activationCode)
        {
            this.ActivationScopreIsValid(activationCode);
            Active = (activationCode == ActivationCode);
            #region [+] Codigo feio removido
            //if (!Verified)
            //    return;

            //if (activationCode == ActivationCode)
            //    Active = true;
            #endregion
        }
        public void RequestLogin(string username)
        {
            this.ResquestLoginScopreIsValid(username);
            AuthorizationCode = GenerateAutorizationCode();
            LastAutorizationCodeRequest = DateTime.Now;
            #region [+] Codigo feio removido
            //if (!Active)
            //    return;

            //if (!Verified)
            //    return;

            //if (username.ToUpper() != Username.ToUpper())
            //    return; 
            #endregion
        }
        public void Authenticate(string authorizationCode, string password)
        {
            this.LoginScopreIsValid(authorizationCode, password);
            LastLoginDate = DateTime.Now;
            #region [+] Codigo feio removido
            //if (!Active)
            //    return false;

            //if (!Verified)
            //    return false;

            //if (authorizationCode != AuthorizationCode || password != Password)
            //    return false;

            //return true;
            #endregion
        }
        public string GenerateAutorizationCode()
        {
            return Guid.NewGuid().ToString().Substring(0, 4).ToUpper();
        }
        public string EncriptyPassword(string pass)
        {
            if (!String.IsNullOrEmpty(Password))
            {
                var password = string.Empty;
                password = (pass += "|asdwwefefdfsfdsfdfdsf");
                System.Security.Cryptography.MD5 md5 = System.Security.Cryptography.MD5.Create();
                // byte[] adta = md5.ComputeHash(System.Text.Encoding.Default.GetBytes(new byte[])
                return string.Empty;
            }
            return string.Empty;
        }
        public void MakeAdmin()
        {
            Role = ERole.Admin;
        }
    }
}
