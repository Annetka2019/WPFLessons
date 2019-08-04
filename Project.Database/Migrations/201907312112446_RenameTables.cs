namespace Project.Database.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RenameTables : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Card",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Number = c.String(nullable: false),
                        Name = c.String(nullable: false, maxLength: 500),
                        StartDate = c.DateTime(),
                        DueDate = c.DateTime(),
                        Assessment = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.IndicatorInCard",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        CardId = c.Guid(nullable: false),
                        IndicatorId = c.Guid(nullable: false),
                        Weight = c.Byte(nullable: false),
                        Assessment = c.String(maxLength: 50),
                        CardEntity_Id = c.Guid(),
                        IndicatorEntity_Id = c.Guid(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Card", t => t.CardEntity_Id)
                .ForeignKey("dbo.Indicator", t => t.IndicatorEntity_Id)
                .Index(t => t.CardEntity_Id)
                .Index(t => t.IndicatorEntity_Id);
            
            CreateTable(
                "dbo.Indicator",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Name = c.String(nullable: false, maxLength: 400),
                        Type = c.String(nullable: false, maxLength: 500),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.IndicatorInCard", "IndicatorEntity_Id", "dbo.Indicator");
            DropForeignKey("dbo.IndicatorInCard", "CardEntity_Id", "dbo.Card");
            DropIndex("dbo.IndicatorInCard", new[] { "IndicatorEntity_Id" });
            DropIndex("dbo.IndicatorInCard", new[] { "CardEntity_Id" });
            DropTable("dbo.Indicator");
            DropTable("dbo.IndicatorInCard");
            DropTable("dbo.Card");
        }
    }
}
