using System.Collections.Generic;
using System.Linq;

namespace AutoMapperPOC.Domain
{
    public interface IOrdersService
    {
        IQueryable<Order> GetOrders();
    }
}