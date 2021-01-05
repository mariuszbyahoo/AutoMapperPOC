namespace AutoMapperPOC.DAL.EF.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class specifyfks : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.LineEntities", "OrderEntity_OID", "dbo.OrderEntities");
            DropIndex("dbo.LineEntities", new[] { "OrderEntity_OID" });
            RenameColumn(table: "dbo.LineEntities", name: "OrderEntity_OID", newName: "OrderId");
            AlterColumn("dbo.LineEntities", "OrderId", c => c.Int(nullable: false));
            CreateIndex("dbo.LineEntities", "OrderId");
            AddForeignKey("dbo.LineEntities", "OrderId", "dbo.OrderEntities", "OID", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.LineEntities", "OrderId", "dbo.OrderEntities");
            DropIndex("dbo.LineEntities", new[] { "OrderId" });
            AlterColumn("dbo.LineEntities", "OrderId", c => c.Int());
            RenameColumn(table: "dbo.LineEntities", name: "OrderId", newName: "OrderEntity_OID");
            CreateIndex("dbo.LineEntities", "OrderEntity_OID");
            AddForeignKey("dbo.LineEntities", "OrderEntity_OID", "dbo.OrderEntities", "OID");
        }
    }
}
