using Highway.Data;
using MvcToyApp.Data.Entities;

namespace MvcToyApp.Data.Commands
{
    public class AddUser : Command
    {
        public AddUser(string name)
        {
            ContextQuery = c =>
            {
                c.Add(new User(name));
                c.Commit();
            };
        }

        public AddUser(User user)
        {
            ContextQuery = c =>
            {
                c.Add(user);
                c.Commit();
            };
        }
    }
}