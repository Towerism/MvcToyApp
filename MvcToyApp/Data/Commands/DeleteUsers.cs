using System.Linq;
using Highway.Data;
using MvcToyApp.Data.Entities;

namespace MvcToyApp.Data.Commands
{
    public class DeleteUsers : Command
    {
        public DeleteUsers(string name)
        {
            ContextQuery = c =>
            {
                foreach (var user in c.AsQueryable<User>().Where(x => x.Name == name))
                    c.Remove(user);
                c.Commit();
            };
        }
    }

}