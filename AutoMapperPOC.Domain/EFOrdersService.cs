using AutoMapper;
using AutoMapper.Extensions.ExpressionMapping;
using AutoMapperPOC.DAL.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace AutoMapperPOC.Domain
{
    public class EFOrdersService : IOrdersService
    {
        private readonly POCContext _ctx;
        public EFOrdersService()
        {
            _ctx = new POCContext();
        }
        public IList<Order> GetOrders()
        {
            return _ctx.Orders.UseAsDataSource(AutoMapperConfiguration.GetConfig()).For<Order>().ToList();
        }

        public void WygenerujWpisy()
        {
            var entities = new List<OrderEntity>();
            for (int i = 0; i < 15000; i++)
            {
                var orderEntity = new OrderEntity() { OID=(i+1), Name = $"Zamówienie nr. {i}", Lines = new List<LineEntity>() };
                for (int j = 0; j < 5; j++)
                {
                    orderEntity.Lines.Add(new LineEntity() { Name = $"Linia nr. {j}", Content = $"Content linii nr. {j} w zamówieniu nr. {i}", Order = orderEntity, OrderId = orderEntity.OID });
                }
                entities.Add(orderEntity);
            }
            _ctx.Orders.AddRange(entities);
            _ctx.SaveChanges();
        }
    }
}
