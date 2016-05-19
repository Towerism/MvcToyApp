using System;
using FluentAssertions;
using Highway.Data;
using Highway.Data.Contexts;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MvcToyApp.Data.Entities;
using MvcToyApp.Services;
using System.Collections.Generic;
using System.Linq;

namespace MvcToyApp.Tests
{
    [TestClass]
    public class AccountServiceTest
    {
        private IDataContext _context;

        [TestInitialize]
        public void Setup()
        {
            _context = new InMemoryDataContext();
        }

        [TestMethod]
        public void ShouldAddUserByName()
        {
            _context = new InMemoryDataContext();
            var service = new AccountService(new Repository(_context));

            service.AddUser("Martin");

            _context.AsQueryable<User>().Count(x => x.Name == "Martin").Should().Be(1);
        }

        [TestMethod]
        public void ShouldQueryUsersByName()
        {
            _context.Add(new User("Martin"));
            _context.Add(new User("Sean"));
            _context.Commit();
            var service = new AccountService(new Repository(_context));

            User user = service.GetUser("Martin");

            user.Should().NotBeNull();
        }

        [TestMethod]
        public void ShouldGetAllUsers()
        {
            _context.Add(new User("Martin"));
            _context.Add(new User("Sean"));
            _context.Add(new User("Austin"));
            _context.Commit();
            var service = new AccountService(new Repository(_context));

            var users = service.GetAllUsers();

            users.Count().Should().Be(3);
        }

        [TestMethod]
        public void ShouldQueryUsersById()
        {
            var userFixture = new User("Martin");
            userFixture.Id = 1;
            _context.Add(userFixture);
            _context.Commit();
            var service = new AccountService(new Repository(_context));

            var user = service.GetUser(1);

            user.Should().NotBeNull();
        }
    }
}
