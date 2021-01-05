using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoMapperPOC.DAL.EF
{
    public class POCContext : DbContext
    {
        public DbSet<OrderEntity> Orders { get; set; }
        public DbSet<LineEntity> Lines { get; set; }

        public IEnumerable<OrderEntity> GetOrders()
        {
            return Orders.Include(o => o.Lines).AsEnumerable();
        }
        public IEnumerable<LineEntity> GetLines()
        {
            return Lines.AsEnumerable();
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<LineEntity>()
                        .HasRequired<OrderEntity>(l => l.Order)
                        .WithMany(o => o.Lines)
                        .HasForeignKey<int>(l => l.OrderId);
        }

        public POCContext()
            : base("data source = DESKTOP-TS4FMKK\\INSERTGT; initial catalog = AutoMapperPOC;Integrated Security = true")
        {
        }
    }
}
