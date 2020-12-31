﻿using DevExpress.Xpo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoMapperPOC.DAL.XPO
{
    [Persistent("OrderEntities")]
    public class OrderEntity : XPObject
    {
        public string Name { get; set; }
        public XPCollection<LineEntity> Lines { get; set; }

        public OrderEntity(Session session): base(session)
        {
        }
    }
}
