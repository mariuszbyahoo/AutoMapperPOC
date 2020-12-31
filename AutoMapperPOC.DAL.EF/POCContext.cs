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
            return Orders.AsEnumerable();
        }
        public IEnumerable<LineEntity> GetLines()
        {
            return Lines.AsEnumerable();
        }
        public POCContext()
            : base("data source = DESKTOP-TS4FMKK\\INSERTGT; initial catalog = AutoMapperPOC;Integrated Security = true")
        {
        }
    }
}
