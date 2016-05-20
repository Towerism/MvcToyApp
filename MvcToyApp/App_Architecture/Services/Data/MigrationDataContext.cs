using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using Highway.Data;

namespace MvcToyApp.App_Architecture.Services.Data
{
    public class MigrationContext : DataContext
    {
        public MigrationContext()
            : base(ConfigurationManager.AppSettings["EntityFramework.ConnectionString"],
                   new HighwayMappingConfiguration())
        { }

        public System.Data.Entity.DbSet<MvcToyApp.Data.Entities.User> Users { get; set; }
    }
}