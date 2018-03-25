namespace AssetRepo.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Reinitialization : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Assets",
                c => new
                    {
                        AssetId = c.Int(nullable: false, identity: true),
                        Title = c.String(nullable: false),
                        ProjectId = c.Int(nullable: false),
                        AssetTypeSubtypePairingId = c.Int(nullable: false),
                        CreatorId = c.Int(nullable: false),
                        CreationDateTime = c.DateTime(nullable: false),
                        LastUpdaterId = c.Int(nullable: false),
                        LastUpdateDateTime = c.DateTime(nullable: false),
                        Comment = c.String(),
                    })
                .PrimaryKey(t => t.AssetId)
                .ForeignKey("dbo.AssetTypeSubtypePairings", t => t.AssetTypeSubtypePairingId, cascadeDelete: true)
                .ForeignKey("dbo.Projects", t => t.ProjectId, cascadeDelete: true)
                .ForeignKey("dbo.Contributors", t => t.CreatorId)
                .ForeignKey("dbo.Contributors", t => t.LastUpdaterId)
                .Index(t => t.ProjectId)
                .Index(t => t.AssetTypeSubtypePairingId)
                .Index(t => t.CreatorId)
                .Index(t => t.LastUpdaterId);
            
            CreateTable(
                "dbo.AssetTypeSubtypePairings",
                c => new
                    {
                        AssetTypeSubtypePairingId = c.Int(nullable: false, identity: true),
                        AssetTypeId = c.Int(nullable: false),
                        AssetSubtypeId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.AssetTypeSubtypePairingId)
                .ForeignKey("dbo.AssetSubtypes", t => t.AssetSubtypeId, cascadeDelete: true)
                .ForeignKey("dbo.AssetTypes", t => t.AssetTypeId, cascadeDelete: true)
                .Index(t => t.AssetTypeId)
                .Index(t => t.AssetSubtypeId);
            
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
                "dbo.Contributors",
                c => new
                    {
                        ContributorId = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.ContributorId);
            
            CreateTable(
                "dbo.Projects",
                c => new
                    {
                        ProjectId = c.Int(nullable: false, identity: true),
                        Title = c.String(nullable: false),
                        ProjectCategoryId = c.Int(nullable: false),
                        CreatorId = c.Int(nullable: false),
                        CreationDateTime = c.DateTime(nullable: false),
                        LastUpdaterId = c.Int(nullable: false),
                        LastUpdateDateTime = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.ProjectId)
                .ForeignKey("dbo.Contributors", t => t.CreatorId)
                .ForeignKey("dbo.Contributors", t => t.LastUpdaterId)
                .ForeignKey("dbo.ProjectCategories", t => t.ProjectCategoryId, cascadeDelete: true)
                .Index(t => t.ProjectCategoryId)
                .Index(t => t.CreatorId)
                .Index(t => t.LastUpdaterId);
            
            CreateTable(
                "dbo.ProjectCategories",
                c => new
                    {
                        ProjectCategoryId = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.ProjectCategoryId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Assets", "LastUpdaterId", "dbo.Contributors");
            DropForeignKey("dbo.Assets", "CreatorId", "dbo.Contributors");
            DropForeignKey("dbo.Projects", "ProjectCategoryId", "dbo.ProjectCategories");
            DropForeignKey("dbo.Projects", "LastUpdaterId", "dbo.Contributors");
            DropForeignKey("dbo.Projects", "CreatorId", "dbo.Contributors");
            DropForeignKey("dbo.Assets", "ProjectId", "dbo.Projects");
            DropForeignKey("dbo.AssetTypeSubtypePairings", "AssetTypeId", "dbo.AssetTypes");
            DropForeignKey("dbo.AssetTypeSubtypePairings", "AssetSubtypeId", "dbo.AssetSubtypes");
            DropForeignKey("dbo.Assets", "AssetTypeSubtypePairingId", "dbo.AssetTypeSubtypePairings");
            DropIndex("dbo.Projects", new[] { "LastUpdaterId" });
            DropIndex("dbo.Projects", new[] { "CreatorId" });
            DropIndex("dbo.Projects", new[] { "ProjectCategoryId" });
            DropIndex("dbo.AssetTypeSubtypePairings", new[] { "AssetSubtypeId" });
            DropIndex("dbo.AssetTypeSubtypePairings", new[] { "AssetTypeId" });
            DropIndex("dbo.Assets", new[] { "LastUpdaterId" });
            DropIndex("dbo.Assets", new[] { "CreatorId" });
            DropIndex("dbo.Assets", new[] { "AssetTypeSubtypePairingId" });
            DropIndex("dbo.Assets", new[] { "ProjectId" });
            DropTable("dbo.ProjectCategories");
            DropTable("dbo.Projects");
            DropTable("dbo.Contributors");
            DropTable("dbo.AssetTypes");
            DropTable("dbo.AssetSubtypes");
            DropTable("dbo.AssetTypeSubtypePairings");
            DropTable("dbo.Assets");
        }
    }
}
