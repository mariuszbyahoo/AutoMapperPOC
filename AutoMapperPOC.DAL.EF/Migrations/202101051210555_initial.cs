namespace AutoMapperPOC.DAL.EF.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.LineEntities",
                c => new
                    {
                        OID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Content = c.String(),
                        OrderId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.OID)
                .ForeignKey("dbo.OrderEntities", t => t.OrderId, cascadeDelete: true)
                .Index(t => t.OrderId);
            
            CreateTable(
                "dbo.OrderEntities",
                c => new
                    {
                        OID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.OID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.LineEntities", "OrderId", "dbo.OrderEntities");
            DropIndex("dbo.LineEntities", new[] { "OrderId" });
            DropTable("dbo.OrderEntities");
            DropTable("dbo.LineEntities");
        }
    }
}
