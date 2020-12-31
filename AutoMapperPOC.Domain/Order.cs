using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoMapperPOC.Domain
{
    public class Order
    {
        public int OID { get; set; }
        public string Name { get; set; }
        public IList<OrderLine> Lines { get; set; }
    }
}
