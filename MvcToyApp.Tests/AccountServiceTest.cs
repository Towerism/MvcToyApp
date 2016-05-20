﻿using FluentAssertions;
using Highway.Data;
using Highway.Data.Contexts;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MvcToyApp.Data.Entities;
using MvcToyApp.Services;
using System.Linq;

namespace MvcToyApp.Tests
{
    [TestClass]
    public class AccountServiceTest
    {
        private IDataContext _context;
        private AccountService _service;

        [TestInitialize]
        public void Setup()
        {
            _context = new InMemoryDataContext();
            _service = new AccountService(new Repository(_context));
        }

        [TestMethod]
        public void ShouldAddUserByName()
        {
            _service.AddUser("Martin");

            _context.AsQueryable<User>().Count(x => x.Name == "Martin").Should().Be(1);
        }

        [TestMethod]
        public void ShouldQueryUsersByName()
        {
            _context.Add(new User("Martin"));
            _context.Add(new User("Sean"));
            _context.Commit();

            User user = _service.GetUser("Martin");

            user.Should().NotBeNull();
        }

        [TestMethod]
        public void ShouldGetAllUsers()
        {
            _context.Add(new User("Martin"));
            _context.Add(new User("Sean"));
            _context.Add(new User("Austin"));
            _context.Commit();

            var users = _service.GetAllUsers();

            users.Count().Should().Be(3);
        }

        [TestMethod]
        public void ShouldQueryUsersById()
        {
            var userFixture = new User("Martin");
            userFixture.Id = 1;
            _context.Add(userFixture);
            _context.Commit();

            var user = _service.GetUser(1);

            user.Should().NotBeNull();
        }

        [TestMethod]
        public void ShouldDeleteUsersByName()
        {
            _context.Add(new User("Martin"));
            _context.Add(new User("Martin"));
            _context.Commit();

            _service.DeleteUsers("Martin");

            var users = _service.GetAllUsers();

            users.Should().BeEmpty();
        }

        [TestMethod]
        public void ShouldAddUser()
        {
            _service.AddUser(new User("Martin"));

            var user = _service.GetUser("Martin");

            user.Should().NotBeNull();
        }
    }
}
