namespace AutoMapperPOC.DAL.EF.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
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
                        OrderEntity_OID = c.Int(),
                    })
                .PrimaryKey(t => t.OID)
                .ForeignKey("dbo.OrderEntities", t => t.OrderEntity_OID)
                .Index(t => t.OrderEntity_OID);
            
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
            DropForeignKey("dbo.LineEntities", "OrderEntity_OID", "dbo.OrderEntities");
            DropIndex("dbo.LineEntities", new[] { "OrderEntity_OID" });
            DropTable("dbo.OrderEntities");
            DropTable("dbo.LineEntities");
        }
    }
}
