using System.Collections.Generic;
using MvcToyApp.Data.Commands;
using MvcToyApp.Data.Entities;
using System.Linq;
using Highway.Data;
using MvcToyApp.Data.Scalars;

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

        public void AddUser(User user)
        {
            _repository.Execute(new AddUser(user));
        }

        public User GetUser(string name)
        {
            return _repository.Find(new UserByName(name));
        }
        public User GetUser(int id)
        {
            return _repository.Find(new GetById<int, User>(id));
        }

        public IEnumerable<User> GetAllUsers()
        {
            var users = _repository.Find(new AllUsers());
            return users.ToList();
        }

        public void DeleteUsers(string name)
        {
            _repository.Execute(new DeleteUsers(name));
        }

        public void DeleteUserById(int id)
        {
            _repository.Execute(new DeleteUserById(id));
        }
    }
}