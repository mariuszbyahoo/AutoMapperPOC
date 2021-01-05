using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoMapperPOC.DAL.EF
{
    public class OrderEntity
    {
        [Key]
        public int OID { get; set; }
        public string Name { get; set; }
        public ICollection<LineEntity> Lines { get; set; }
    }
}
