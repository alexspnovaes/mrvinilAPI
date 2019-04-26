using Domain.Entities;
using System.Data.Entity.ModelConfiguration;

namespace Data.EntityConfig
{
    public class DiskMapping : EntityTypeConfiguration<Disk>
    {
        public void DiskConfiguration()
        {
            HasKey(p => p.Id);

            Property(o => o.Name)
                .HasColumnType("varchar(100)")
                .HasMaxLength(100)
                .IsRequired();

            Property(o => o.Description)
             .HasColumnType("varchar(1000)")
             .HasMaxLength(1000)
             .IsRequired();

            Property(o => o.Genre)
                .HasColumnName("Genre")
                .HasColumnType("integer")
                .IsRequired();

            Property(o => o.ImageURL)
                .HasColumnName("imageurl")
                .HasColumnType("varchar(1000)")
                .IsRequired();
        }
    }
}
