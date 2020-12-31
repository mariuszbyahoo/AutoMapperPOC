using System.Collections.Generic;

namespace AutoMapperPOC.Domain
{
    public interface IOrdersService
    {
        IList<Order> GetOrders();
    }
}