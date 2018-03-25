namespace AssetRepo.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class TestingManyToMany : DbMigration
    {
        public override void Up()
        {
            CreateIndex("dbo.Assets", "CreatorId");
            CreateIndex("dbo.Assets", "LastUpdaterId");
            CreateIndex("dbo.Projects", "CreatorId");
            CreateIndex("dbo.Projects", "LastUpdaterId");
            AddForeignKey("dbo.Projects", "CreatorId", "dbo.Contributors", "ContributorId");
            AddForeignKey("dbo.Projects", "LastUpdaterId", "dbo.Contributors", "ContributorId");
            AddForeignKey("dbo.Assets", "CreatorId", "dbo.Contributors", "ContributorId");
            AddForeignKey("dbo.Assets", "LastUpdaterId", "dbo.Contributors", "ContributorId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Assets", "LastUpdaterId", "dbo.Contributors");
            DropForeignKey("dbo.Assets", "CreatorId", "dbo.Contributors");
            DropForeignKey("dbo.Projects", "LastUpdaterId", "dbo.Contributors");
            DropForeignKey("dbo.Projects", "CreatorId", "dbo.Contributors");
            DropIndex("dbo.Projects", new[] { "LastUpdaterId" });
            DropIndex("dbo.Projects", new[] { "CreatorId" });
            DropIndex("dbo.Assets", new[] { "LastUpdaterId" });
            DropIndex("dbo.Assets", new[] { "CreatorId" });
        }
    }
}
