using System.Linq;
using Highway.Data;
using MvcToyApp.Data.Entities;

namespace MvcToyApp.Data.Commands
{
    internal class DeleteUserById : Command
    {
        public DeleteUserById(int id)
        {
            ContextQuery = c =>
            {
                var user = c.AsQueryable<User>().Single(x => x.Id == id);
                c.Remove(user);
                c.Commit();
            };
        }
    }
}