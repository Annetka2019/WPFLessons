namespace Project.Database.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class IndicatorInCardreferencecolumnnames : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.IndicatorInCard", "CardEntity_Id", "dbo.Card");
            DropForeignKey("dbo.IndicatorInCard", "IndicatorEntity_Id", "dbo.Indicator");
            DropIndex("dbo.IndicatorInCard", new[] { "CardEntity_Id" });
            DropIndex("dbo.IndicatorInCard", new[] { "IndicatorEntity_Id" });
            DropColumn("dbo.IndicatorInCard", "CardId");
            DropColumn("dbo.IndicatorInCard", "IndicatorId");
            RenameColumn(table: "dbo.IndicatorInCard", name: "CardEntity_Id", newName: "CardId");
            RenameColumn(table: "dbo.IndicatorInCard", name: "IndicatorEntity_Id", newName: "IndicatorId");
            AlterColumn("dbo.IndicatorInCard", "CardId", c => c.Guid(nullable: false));
            AlterColumn("dbo.IndicatorInCard", "IndicatorId", c => c.Guid(nullable: false));
            CreateIndex("dbo.IndicatorInCard", "CardId");
            CreateIndex("dbo.IndicatorInCard", "IndicatorId");
            AddForeignKey("dbo.IndicatorInCard", "CardId", "dbo.Card", "Id", cascadeDelete: true);
            AddForeignKey("dbo.IndicatorInCard", "IndicatorId", "dbo.Indicator", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.IndicatorInCard", "IndicatorId", "dbo.Indicator");
            DropForeignKey("dbo.IndicatorInCard", "CardId", "dbo.Card");
            DropIndex("dbo.IndicatorInCard", new[] { "IndicatorId" });
            DropIndex("dbo.IndicatorInCard", new[] { "CardId" });
            AlterColumn("dbo.IndicatorInCard", "IndicatorId", c => c.Guid());
            AlterColumn("dbo.IndicatorInCard", "CardId", c => c.Guid());
            RenameColumn(table: "dbo.IndicatorInCard", name: "IndicatorId", newName: "IndicatorEntity_Id");
            RenameColumn(table: "dbo.IndicatorInCard", name: "CardId", newName: "CardEntity_Id");
            AddColumn("dbo.IndicatorInCard", "IndicatorId", c => c.Guid(nullable: false));
            AddColumn("dbo.IndicatorInCard", "CardId", c => c.Guid(nullable: false));
            CreateIndex("dbo.IndicatorInCard", "IndicatorEntity_Id");
            CreateIndex("dbo.IndicatorInCard", "CardEntity_Id");
            AddForeignKey("dbo.IndicatorInCard", "IndicatorEntity_Id", "dbo.Indicator", "Id");
            AddForeignKey("dbo.IndicatorInCard", "CardEntity_Id", "dbo.Card", "Id");
        }
    }
}
