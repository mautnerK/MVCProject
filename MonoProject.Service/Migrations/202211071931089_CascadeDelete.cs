namespace Service.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CascadeDelete : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Models", "Make_ID", "dbo.Makes");
            DropIndex("dbo.Models", new[] { "Make_ID" });
            AlterColumn("dbo.Models", "Make_ID", c => c.Int(nullable: false));
            CreateIndex("dbo.Models", "Make_ID");
            AddForeignKey("dbo.Models", "Make_ID", "dbo.Makes", "ID", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Models", "Make_ID", "dbo.Makes");
            DropIndex("dbo.Models", new[] { "Make_ID" });
            AlterColumn("dbo.Models", "Make_ID", c => c.Int());
            CreateIndex("dbo.Models", "Make_ID");
            AddForeignKey("dbo.Models", "Make_ID", "dbo.Makes", "ID");
        }
    }
}
