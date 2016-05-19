using System;
using System.Collections.Generic;
using Highway.Data;
using MvcToyApp.Data.Commands;
using MvcToyApp.Data.Entities;
using System.Linq;

namespace MvcToyApp.Services
{
    public class AccountService
    {
        private readonly IRepository _repository;

        public AccountService(IRepository repository)
        {
            _repository = repository;
        }

        public void AddUser(string name)
        {
            _repository.Execute(new AddUser(name));
        }

        public User GetUser(string name)
        {
            return _repository.Find(new UserByName(name));
        }
        public object GetUser(int id)
        {
            return _repository.Find(new GetById<int, User>(id));
        }

        public IEnumerable<User> GetAllUsers()
        {
            var users = _repository.Find(new AllUsers());
            return users.ToList();
        }
    }
}