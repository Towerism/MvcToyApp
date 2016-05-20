namespace MvcToyApp.Data.Entities.Mappings
{
    public class UserMap : BaseMapping<User>
    {
        public UserMap()
        {
            ToTable("Users");
            Property(t => t.Name).HasColumnName("Name");
        }
    }
}