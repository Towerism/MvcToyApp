using System.Linq;
using Highway.Data;
using MvcToyApp.Data.Entities;

namespace MvcToyApp.Data.Scalars
{
    public class UserByName : Scalar<User>
    {
        public UserByName(string name)
        {
            ContextQuery = c => c.AsQueryable<User>().SingleOrDefault(x => x.Name == name);
        }
    }
}