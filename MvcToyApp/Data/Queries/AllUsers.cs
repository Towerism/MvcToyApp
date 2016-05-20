using Highway.Data;
using MvcToyApp.Data.Entities;

namespace MvcToyApp.Data.Commands
{
    public class AllUsers : Query<User>
    {
        public AllUsers()
        {
            ContextQuery = c => c.AsQueryable<User>();
        }
    }
}