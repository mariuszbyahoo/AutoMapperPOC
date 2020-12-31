﻿using System;
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
        public int ID { get; set; }
        public string Name { get; set; }
        public IList<LineEntity> Lines { get; set; }
    }
}
