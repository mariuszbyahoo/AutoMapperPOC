using AutoMapper;
using AutoMapper.Extensions.ExpressionMapping;
using AutoMapperPOC.DAL.XPO;
using DevExpress.Xpo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoMapperPOC.Domain
{
    public class XPOrdersService : IOrdersService
    {
        private readonly Session _session;

        public XPOrdersService()
        {
            XpoDefault.ConnectionString = "data source = DESKTOP-TS4FMKK\\INSERTGT; initial catalog = AutoMapperPOC;Integrated Security = true";
            _session = XpoDefault.Session;
        }
        public IList<Order> GetOrders()
        {
            return _session.Query<OrderEntity>().UseAsDataSource(AutoMapperConfiguration.GetConfig()).For<Order>().ToList();
        }
    }
}
