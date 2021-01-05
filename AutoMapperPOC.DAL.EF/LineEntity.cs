using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoMapperPOC.DAL.EF
{
    public class LineEntity
    {
        [Key]
        public int OID { get; set; }
        public string Name { get; set; }
        public string Content { get; set; }
        public int OrderId { get; set; }
        public OrderEntity Order { get; set; }
    }
}
