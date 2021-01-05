using DevExpress.Xpo;

namespace AutoMapperPOC.DAL.XPO
{
    [Persistent("LineEntities")]
    public class LineEntity : XPObject
    {
        public string Name { get; set; }
        public string Content { get; set; }

        OrderEntity fOrder;
        [Association("Orders-Lines")]
        public OrderEntity OrderId { 
            get { return fOrder;} 
            set { SetPropertyValue(nameof(OrderId), ref fOrder, value);} 
        }
    }
}