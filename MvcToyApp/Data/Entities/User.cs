namespace MvcToyApp.Data.Entities
{
    public class User : BaseEntity
    {
        public string Name { get; set; }
        
        public User(string name = null)
        {
            Name = name;
        }
    }
}