using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoMapperPOC.DAL.EF
{
    public class OrderEntity
    {
        public int ID { get; set; }
        public IEnumerable<LineEntity> Lines { get; set; }
    }
}
