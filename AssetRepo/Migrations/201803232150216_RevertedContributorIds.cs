namespace AssetRepo.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RevertedContributorIds : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Assets", "Creator_ContributorId", "dbo.Contributors");
            DropForeignKey("dbo.Assets", "LastUpdater_ContributorId", "dbo.Contributors");
            DropForeignKey("dbo.Projects", "Creator_ContributorId", "dbo.Contributors");
            DropForeignKey("dbo.Projects", "LastUpdater_ContributorId", "dbo.Contributors");
            DropIndex("dbo.Assets", new[] { "Creator_ContributorId" });
            DropIndex("dbo.Assets", new[] { "LastUpdater_ContributorId" });
            DropIndex("dbo.Projects", new[] { "Creator_ContributorId" });
            DropIndex("dbo.Projects", new[] { "LastUpdater_ContributorId" });
            DropColumn("dbo.Assets", "Creator_ContributorId");
            DropColumn("dbo.Assets", "LastUpdater_ContributorId");
            DropColumn("dbo.Projects", "Creator_ContributorId");
            DropColumn("dbo.Projects", "LastUpdater_ContributorId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Projects", "LastUpdater_ContributorId", c => c.Int());
            AddColumn("dbo.Projects", "Creator_ContributorId", c => c.Int());
            AddColumn("dbo.Assets", "LastUpdater_ContributorId", c => c.Int());
            AddColumn("dbo.Assets", "Creator_ContributorId", c => c.Int());
            CreateIndex("dbo.Projects", "LastUpdater_ContributorId");
            CreateIndex("dbo.Projects", "Creator_ContributorId");
            CreateIndex("dbo.Assets", "LastUpdater_ContributorId");
            CreateIndex("dbo.Assets", "Creator_ContributorId");
            AddForeignKey("dbo.Projects", "LastUpdater_ContributorId", "dbo.Contributors", "ContributorId");
            AddForeignKey("dbo.Projects", "Creator_ContributorId", "dbo.Contributors", "ContributorId");
            AddForeignKey("dbo.Assets", "LastUpdater_ContributorId", "dbo.Contributors", "ContributorId");
            AddForeignKey("dbo.Assets", "Creator_ContributorId", "dbo.Contributors", "ContributorId");
        }
    }
}
