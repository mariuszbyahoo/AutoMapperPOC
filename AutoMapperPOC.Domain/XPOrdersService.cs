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
            var result = new List<Order>();
            List<OrderEntity> dbResponse = _session.Query<OrderEntity>().ToList(); 
            foreach (var order in dbResponse)
            {
                result.Add(_mapper.Map<Order>(order));
            }
            return result;
        }
    }
}
