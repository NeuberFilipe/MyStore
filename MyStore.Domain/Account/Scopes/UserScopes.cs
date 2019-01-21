using DomainNotificationHelper.Validation;
using MyStore.Domain.Account.Entites;
using System;

namespace MyStore.Domain.Account.Scopes
{
    public static class UserScopes
    {
        public static bool RegisterScopeIsValid(this User user)
        {
            return AssertionConcern.IsSatisfiedBy
                (
                   AssertionConcern.AssertLength(user.Username, 6, 20, "O usuario deve conter entre 6 a 20 caracteres!"),
                   AssertionConcern.AssertLength(user.Password, 6, 20, "A Senha deve conter entre 6 a 20 caracteres!")
                );
        }

        public static bool VerificationScopreIsValid(this User user, string verificationCode)
        {
            return AssertionConcern.IsSatisfiedBy
                (
                   AssertionConcern.AssertNotNull(user, "Nenhum usuário enconrtado"),
                   AssertionConcern.AssertTrue(user.Verified == false, "Usuário já verificado"),
                   AssertionConcern.AssertAreEquals(user.VerificationCode, verificationCode, "O codigo de vericação não confere")
                );
        }

        public static bool ActivationScopreIsValid(this User user, string activationCode)
        {
            return AssertionConcern.IsSatisfiedBy
                (
                   AssertionConcern.AssertNotNull(user, "Nenhum usuário enconrtado"),
                   AssertionConcern.AssertTrue(user.Verified == true, "E-mail não verificado"),
                   AssertionConcern.AssertTrue(user.Active == false, "Cadastro já verificado"),
                   AssertionConcern.AssertAreEquals(user.VerificationCode, activationCode, "Código de ativação não confere")
                );
        }

        public static bool ResquestLoginScopreIsValid(this User user, string username)
        {
            return AssertionConcern.IsSatisfiedBy
                (
                   AssertionConcern.AssertNotNull(user, "Nenhum usuário enconrtado para este aluno"),
                   AssertionConcern.AssertTrue(user.Verified == true, "E-mail não verificado"),
                   AssertionConcern.AssertTrue(user.Active == true, "Cadastro não verificado"),
                   AssertionConcern.AssertAreEquals(user.Username.ToLower(), username.ToLower(), "Nome de usuário não confere"),
                   AssertionConcern.AssertAreEquals(DateTime.Compare(user.LastAutorizationCodeRequest.AddMinutes(5),
                                                                     DateTime.Now).ToString(),
                                                                     (-1).ToString(),
                                                                     "Um SMS já foi enviado. Aguarde 5 minutos para requisitar um novo login.")
                );
        }

        public static bool LoginScopreIsValid(this User user, string authorizationCode, string password)
        {
            return AssertionConcern.IsSatisfiedBy
                (
                   AssertionConcern.AssertNotNull(user, "Nenhum usuário enconrtado para este aluno"),
                   AssertionConcern.AssertTrue(user.Verified == true, "E-mail não verificado"),
                   AssertionConcern.AssertTrue(user.Active == true, "Cadastro não verificado"),
                   AssertionConcern.AssertAreEquals(user.AuthorizationCode.ToLower(), authorizationCode.ToLower(), "Código de autenticação invalido"),
                   AssertionConcern.AssertAreEquals(user.Password, password, "Usuário ou senha inválidos"),
                   AssertionConcern.AssertAreEquals(DateTime.Compare(user.LastAutorizationCodeRequest.AddMinutes(5),
                                                                     DateTime.Now).ToString(),
                                                                     (1).ToString(),
                                                                     "Código de autenticação expirado")
                );
        }
    }
}
