using System.Linq;
using Highway.Data;
using MvcToyApp.Data.Entities;

namespace MvcToyApp.Data.Commands
{
    internal class UpdateUserName : Command
    {
        public UpdateUserName(int id, string newName)
        {
            ContextQuery = c =>
            {
                var user = c.AsQueryable<User>().Single(x => x.Id == id);
                user.Name = newName;
                c.Commit();
            };
        }
    }
}