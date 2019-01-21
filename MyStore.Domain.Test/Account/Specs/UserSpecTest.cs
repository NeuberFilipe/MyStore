using Microsoft.VisualStudio.TestTools.UnitTesting;
using MyStore.Domain.Account.Entites;
using MyStore.Domain.Account.Specs;
using System.Collections.Generic;
using System.Linq;

namespace MyStore.Domain.Test.Account.Specs
{
    [TestClass]
    public class UserSpecTest
    {
        private List<User> _users;

        public UserSpecTest()
        {
            _users = new List<User>();
            _users.Add(new User("neuber.coelho@bnksytem.com", "neuber.coelho", "123456"));
            _users.Add(new User("x1.coelho@bnksytem.com", "x1.coelho", "123456"));
            _users.Add(new User("x2.coelho@bnksytem.com", "x2.coelho", "123456"));
            _users.Add(new User("x3.coelho@bnksytem.com", "x3.coelho", "123456"));
            _users.Add(new User("x4.coelho@bnksytem.com", "x4.coelho", "123456"));
        }

        [TestMethod]
        [TestCategory("User - Specs")]
        public void GetByUserNameShouldReturnValue()
        {
            var user = _users
                .AsQueryable()
                .Where(UserSpecs.GetByUsername("neuber.coelho"))
                .FirstOrDefault();
            Assert.AreNotEqual(null, user);
        }

        [TestMethod]
        [TestCategory("User - Specs")]
        public void GetByUserNameShouldNotReturnValue()
        {
            var user = _users
                .AsQueryable()
                .Where(UserSpecs.GetByUsername("neuber.coelhoZZZZZZZ"))
                .FirstOrDefault();
            Assert.AreEqual(null, user);
        }
    }
}
