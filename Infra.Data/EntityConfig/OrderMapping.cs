using Domain.Entities;
using System.Data.Entity.ModelConfiguration;

namespace Data.EntityConfig
{
    public class OrderMapping : EntityTypeConfiguration<Order>
    {
        public void OrderConfiguration()
        {
            ToTable("Order");
            HasKey(p => p.Id);
            Property(p => p.Date).IsRequired();
            Property(p => p.Number).HasColumnType("varchar(8)").IsRequired();
            HasMany(p => p.OrderItems);
            HasRequired(p => p.Client);
        }
    }
}
