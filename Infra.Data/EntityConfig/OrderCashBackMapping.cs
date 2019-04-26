using Domain.Entities;
using System.Data.Entity.ModelConfiguration;

namespace Data.EntityConfig
{
    public class OrderCashBackMapping : EntityTypeConfiguration<OrderCashBack>
    {
        public void OrderCashBackConfiguration()
        {
            ToTable("OrderCashBack");
            HasKey(p => p.Id);
            Property(p => p.OrderCashbackValue)
                .IsRequired()
                .HasColumnType("money");
            HasMany(p => p.OrderCashbacktems);
            HasRequired(p => p.Order);


        }
    }
}
