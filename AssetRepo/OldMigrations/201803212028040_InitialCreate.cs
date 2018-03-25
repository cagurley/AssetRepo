namespace AssetRepo.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Assets",
                c => new
                    {
                        AssetId = c.Int(nullable: false, identity: true),
                        Title = c.String(nullable: false),
                        TypeId = c.Int(nullable: false),
                        SubtypeId = c.Int(nullable: false),
                        ContributorId = c.Int(nullable: false),
                        LastUpdateDateTime = c.DateTime(nullable: false),
                        Comment = c.String(),
                        Subtype_AssetSubtypeId = c.Int(),
                        Type_AssetTypeId = c.Int(),
                    })
                .PrimaryKey(t => t.AssetId)
                .ForeignKey("dbo.Contributors", t => t.ContributorId, cascadeDelete: true)
                .ForeignKey("dbo.AssetSubtypes", t => t.Subtype_AssetSubtypeId)
                .ForeignKey("dbo.AssetTypes", t => t.Type_AssetTypeId)
                .Index(t => t.ContributorId)
                .Index(t => t.Subtype_AssetSubtypeId)
                .Index(t => t.Type_AssetTypeId);
            
            CreateTable(
                "dbo.Contributors",
                c => new
                    {
                        ContributorId = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.ContributorId);
            
            CreateTable(
                "dbo.AssetSubtypes",
                c => new
                    {
                        AssetSubtypeId = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.AssetSubtypeId);
            
            CreateTable(
                "dbo.AssetTypes",
                c => new
                    {
                        AssetTypeId = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.AssetTypeId);
            
            CreateTable(
                "dbo.Projects",
                c => new
                    {
                        ProjectId = c.Int(nullable: false, identity: true),
                        Title = c.String(nullable: false),
                        Category = c.String(),
                        CreatorId = c.Int(nullable: false),
                        LastContributionId = c.Int(nullable: false),
                        LastContributionDateTime = c.DateTime(nullable: false),
                        Creator_ContributorId = c.Int(),
                        LastContribution_AssetId = c.Int(),
                    })
                .PrimaryKey(t => t.ProjectId)
                .ForeignKey("dbo.Contributors", t => t.Creator_ContributorId)
                .ForeignKey("dbo.Assets", t => t.LastContribution_AssetId)
                .Index(t => t.Creator_ContributorId)
                .Index(t => t.LastContribution_AssetId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Projects", "LastContribution_AssetId", "dbo.Assets");
            DropForeignKey("dbo.Projects", "Creator_ContributorId", "dbo.Contributors");
            DropForeignKey("dbo.Assets", "Type_AssetTypeId", "dbo.AssetTypes");
            DropForeignKey("dbo.Assets", "Subtype_AssetSubtypeId", "dbo.AssetSubtypes");
            DropForeignKey("dbo.Assets", "ContributorId", "dbo.Contributors");
            DropIndex("dbo.Projects", new[] { "LastContribution_AssetId" });
            DropIndex("dbo.Projects", new[] { "Creator_ContributorId" });
            DropIndex("dbo.Assets", new[] { "Type_AssetTypeId" });
            DropIndex("dbo.Assets", new[] { "Subtype_AssetSubtypeId" });
            DropIndex("dbo.Assets", new[] { "ContributorId" });
            DropTable("dbo.Projects");
            DropTable("dbo.AssetTypes");
            DropTable("dbo.AssetSubtypes");
            DropTable("dbo.Contributors");
            DropTable("dbo.Assets");
        }
    }
}
