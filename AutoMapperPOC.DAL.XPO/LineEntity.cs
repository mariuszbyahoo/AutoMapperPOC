using DevExpress.Xpo;

namespace AutoMapperPOC.DAL.XPO
{
    public class LineEntity : XPObject
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Content { get; set; }
    }
}