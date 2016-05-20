namespace MvcToyApp.Data.Entities
{
    public class User : BaseEntity
    {
        public string Name { get; set; }
        
        public User(string name)
        {
            Name = name;
        }

        public User()
        {
        }
    }
}