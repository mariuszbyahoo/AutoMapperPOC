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
        DbSet<OrderEntity> Orders { get; set; }
        DbSet<LineEntity> Lines { get; set; }

        public POCContext()
            : base("name=AutoMapperPOCEntityFramework")
        {
        }
    }
}
