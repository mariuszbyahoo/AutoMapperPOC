using DevExpress.Xpo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoMapperPOC.DAL.XPO
{
    public class OrderEntity : XPObject
    {
        public int ID { get; set; }
        public XPCollection<LineEntity> Lines { get; set; }
    }
}
