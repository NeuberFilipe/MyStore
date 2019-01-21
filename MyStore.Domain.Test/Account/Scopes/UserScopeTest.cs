using Microsoft.VisualStudio.TestTools.UnitTesting;
using MyStore.Domain.Account.Entites;
using MyStore.Domain.Account.Scopes;

namespace MyStore.Domain.Tests.Account
{
    [TestClass]
    public class UserScopeTest
    {
        [TestMethod]
        [TestCategory("User - Scopes")]
        public void RegisterUserScopeIsValid()
        {
            var user = new User("neuber.coelho@bnksystem.com", "neuber.coelho", "123456");

            Assert.AreEqual(true, user.RegisterScopeIsValid());
        }

        [TestMethod]
        [TestCategory("User - Scopes")]
        public void RegisterUserScopeIsInvalidWhenUsernameIsNull()
        {
            var user = new User("neuber.coelho@bnksystem.com", "", "123456");

            Assert.AreEqual(false, user.RegisterScopeIsValid());
        }

        [TestMethod]
        [TestCategory("User - Scopes")]
        public void VerificatinScopeInvalid()
        {
            var user = new User("neuber.coelho@bnksystem.com", "", "123456");
            var verificationCode = "12234";
            Assert.AreEqual(false, user.VerificationScopreIsValid(verificationCode));
        }

        [TestMethod]
        [TestCategory("User - Scopes")]
        public void VerificatinScopeValid()
        {
            var user = new User("neuber.coelho@bnksystem.com", "", "123456");
            var verificationCode = user.VerificationCode;
            Assert.AreEqual(false, user.VerificationScopreIsValid(verificationCode));
        }
    }
}
