using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace MvcToyApp.Data.Entities.Mappings
{
    public abstract class BaseMapping<T> : EntityTypeConfiguration<T> where T : BaseEntity
    {
        public BaseMapping()
        {
            this.HasKey(e => e.Id);
            this.Property(e => e.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
        }
    }
}