
using System;
using System.Data.Entity.Migrations;
namespace Service.Migrations
{

    public partial class EmptyForSeedingDatabase : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Makes",
                c => new
                {
                    ID = c.Int(nullable: false, identity: true),
                    Name = c.String(),
                    Abrv = c.String(),
                })
                .PrimaryKey(t => t.ID);

            CreateTable(
                "dbo.Models",
                c => new
                {
                    ID = c.Int(nullable: false, identity: true),
                    Name = c.String(),
                    Abrv = c.String(),
                    Make_ID = c.Int(),
                })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Makes", t => t.Make_ID)
                .Index(t => t.Make_ID);

        }

        public override void Down()
        {
            DropForeignKey("dbo.Models", "Make_ID", "dbo.Makes");
            DropIndex("dbo.Models", new[] { "Make_ID" });
            DropTable("dbo.Models");
            DropTable("dbo.Makes");
        }
    }
}
