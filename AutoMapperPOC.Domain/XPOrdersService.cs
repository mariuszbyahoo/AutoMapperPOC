using AutoMapper;
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
        private readonly IMapper _mapper;

        public XPOrdersService()
        {
            XpoDefault.ConnectionString = "data source = DESKTOP-TS4FMKK\\INSERTGT; initial catalog = AutoMapperPOC;Integrated Security = true";
            _session = XpoDefault.Session;
            _mapper = AutoMapperConfiguration.GetConfig().CreateMapper();
        }
        public IList<Order> GetOrders()
        {
            return _mapper.Map<IList<Order>>(_session.Query<OrderEntity>());
        }
    }
}
