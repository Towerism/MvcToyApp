using Highway.Data;
using MvcToyApp.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

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
    }
}