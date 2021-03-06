﻿using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoMapperPOC.Domain
{
    public class AutoMapperConfiguration
    {
        public static MapperConfiguration GetConfig()
        {
            return new MapperConfiguration(cfg =>
                {
                    cfg.CreateMap<DAL.XPO.OrderEntity, Order>();
                    cfg.CreateMap<Order, DAL.XPO.OrderEntity>();
                    cfg.CreateMap<DAL.XPO.LineEntity, OrderLine>();
                    cfg.CreateMap<OrderLine, DAL.XPO.LineEntity>();

                    cfg.CreateMap<DAL.EF.OrderEntity, Order>();
                    cfg.CreateMap<Order, DAL.EF.OrderEntity>();
                    cfg.CreateMap<DAL.EF.LineEntity, OrderLine>();
                    cfg.CreateMap<OrderLine, DAL.EF.LineEntity>();
                });
        }
    }
}
