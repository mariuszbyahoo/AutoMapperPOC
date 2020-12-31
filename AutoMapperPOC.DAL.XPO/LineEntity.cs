using DevExpress.Xpo;

namespace AutoMapperPOC.DAL.XPO
{
    [Persistent("LineEntities")]
    public class LineEntity : XPObject
    {
        public int OID { get; set; }
        public string Name { get; set; }
        public string Content { get; set; }
    }
}