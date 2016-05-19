using Highway.Data;
using MvcToyApp.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcToyApp.Data.Commands
{
    public class UserByName : Scalar<User>
    {
        public UserByName(string name)
        {
            ContextQuery = c => c.AsQueryable<User>().Single(x => x.Name == name);
        }
    }
}