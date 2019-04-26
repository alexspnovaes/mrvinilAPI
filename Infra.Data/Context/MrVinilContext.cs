using Domain.Entities;
using Data.EntityConfig;
using System;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;

namespace Data.Context
{
    public class MrVinilContext : DbContext
    {
        public MrVinilContext() :
             base("Data Source='DESKTOP-KTTP6M2';Initial Catalog=mrvinil;Persist Security Info=True;User ID=mrvinil;Password=@2789hl123456;MultipleActiveResultSets=true")
        {
        }

        public DbSet<Client> Clients { get; set; }
        public DbSet<Disk> Disks { get; set; }
        public DbSet<OrderCashBack> OrderCashBacks { get; set; }
        public DbSet<OrderCashBackItem> OrderCashBackItems { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();


            modelBuilder.Properties<string>()
                .Configure(p => p.HasColumnType("varchar"));


            modelBuilder.Configurations.Add(new ClientMapping());
            modelBuilder.Configurations.Add(new DiskMapping());
            modelBuilder.Configurations.Add(new OrderCashBackMapping());
            modelBuilder.Configurations.Add(new OrderCashBackItemMapping());
            modelBuilder.Configurations.Add(new OrderMapping());
            modelBuilder.Configurations.Add(new OrderItemMapping());
            base.OnModelCreating(modelBuilder);
        }
    }
}
