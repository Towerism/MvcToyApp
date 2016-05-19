using Highway.Data;
using System;

namespace MvcToyApp.Data.Entities
{
    public class BaseEntity : IIdentifiable<int>
    {
        public int Id { get; set; }
    }
}