using AutoMapper;
using AutoMapperPOC.DAL.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoMapperPOC.Domain
{
    public class EFOrdersService : IOrdersService
    {
        private readonly POCContext _ctx;
        private readonly IMapper _mapper;
        public EFOrdersService()
        {
            _ctx = new POCContext();
            _mapper = AutoMapperConfiguration.GetConfig().CreateMapper();
        }
        public IList<Order> GetOrders()
        {
            var res = new List<Order>();
            foreach (var item in _ctx.GetOrders())
            {
                res.Add(_mapper.Map<Order>(item));
            }
            return res;
        }
    }
}
