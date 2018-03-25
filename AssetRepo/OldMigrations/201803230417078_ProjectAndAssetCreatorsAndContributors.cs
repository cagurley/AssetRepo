namespace AssetRepo.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ProjectAndAssetCreatorsAndContributors : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Assets", "Creator_ContributorId", c => c.Int());
            AddColumn("dbo.Assets", "LastUpdater_ContributorId", c => c.Int());
            AddColumn("dbo.Projects", "LastUpdaterId", c => c.Int(nullable: false));
            AddColumn("dbo.Projects", "LastUpdateDateTime", c => c.DateTime(nullable: false));
            AddColumn("dbo.Projects", "Creator_ContributorId", c => c.Int());
            AddColumn("dbo.Projects", "LastUpdater_ContributorId", c => c.Int());
            CreateIndex("dbo.Assets", "Creator_ContributorId");
            CreateIndex("dbo.Assets", "LastUpdater_ContributorId");
            CreateIndex("dbo.Projects", "Creator_ContributorId");
            CreateIndex("dbo.Projects", "LastUpdater_ContributorId");
            AddForeignKey("dbo.Assets", "Creator_ContributorId", "dbo.Contributors", "ContributorId");
            AddForeignKey("dbo.Assets", "LastUpdater_ContributorId", "dbo.Contributors", "ContributorId");
            AddForeignKey("dbo.Projects", "Creator_ContributorId", "dbo.Contributors", "ContributorId");
            AddForeignKey("dbo.Projects", "LastUpdater_ContributorId", "dbo.Contributors", "ContributorId");
            DropColumn("dbo.Projects", "LastContributionId");
            DropColumn("dbo.Projects", "LastContributionDateTime");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Projects", "LastContributionDateTime", c => c.DateTime(nullable: false));
            AddColumn("dbo.Projects", "LastContributionId", c => c.Int(nullable: false));
            DropForeignKey("dbo.Projects", "LastUpdater_ContributorId", "dbo.Contributors");
            DropForeignKey("dbo.Projects", "Creator_ContributorId", "dbo.Contributors");
            DropForeignKey("dbo.Assets", "LastUpdater_ContributorId", "dbo.Contributors");
            DropForeignKey("dbo.Assets", "Creator_ContributorId", "dbo.Contributors");
            DropIndex("dbo.Projects", new[] { "LastUpdater_ContributorId" });
            DropIndex("dbo.Projects", new[] { "Creator_ContributorId" });
            DropIndex("dbo.Assets", new[] { "LastUpdater_ContributorId" });
            DropIndex("dbo.Assets", new[] { "Creator_ContributorId" });
            DropColumn("dbo.Projects", "LastUpdater_ContributorId");
            DropColumn("dbo.Projects", "Creator_ContributorId");
            DropColumn("dbo.Projects", "LastUpdateDateTime");
            DropColumn("dbo.Projects", "LastUpdaterId");
            DropColumn("dbo.Assets", "LastUpdater_ContributorId");
            DropColumn("dbo.Assets", "Creator_ContributorId");
        }
    }
}
