namespace AssetRepo.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialMigration : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Assets", "ContributorId", "dbo.Contributors");
            DropForeignKey("dbo.Projects", "Creator_ContributorId", "dbo.Contributors");
            DropForeignKey("dbo.Projects", "LastContribution_AssetId", "dbo.Assets");
            DropForeignKey("dbo.Assets", "Subtype_AssetSubtypeId", "dbo.AssetSubtypes");
            DropForeignKey("dbo.Assets", "Type_AssetTypeId", "dbo.AssetTypes");
            DropIndex("dbo.Assets", new[] { "ContributorId" });
            DropIndex("dbo.Assets", new[] { "Subtype_AssetSubtypeId" });
            DropIndex("dbo.Assets", new[] { "Type_AssetTypeId" });
            DropIndex("dbo.Projects", new[] { "Creator_ContributorId" });
            DropIndex("dbo.Projects", new[] { "LastContribution_AssetId" });
            RenameColumn(table: "dbo.Assets", name: "Subtype_AssetSubtypeId", newName: "AssetSubtypeId");
            RenameColumn(table: "dbo.Assets", name: "Type_AssetTypeId", newName: "AssetTypeId");
            CreateTable(
                "dbo.ProjectCategories",
                c => new
                    {
                        ProjectCategoryId = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.ProjectCategoryId);
            
            AddColumn("dbo.Assets", "ProjectId", c => c.Int(nullable: false));
            AddColumn("dbo.Assets", "CreatorId", c => c.Int(nullable: false));
            AddColumn("dbo.Assets", "CreationDateTime", c => c.DateTime(nullable: false));
            AddColumn("dbo.Assets", "LastUpdaterId", c => c.Int(nullable: false));
            AddColumn("dbo.Projects", "ProjectCategoryId", c => c.Int(nullable: false));
            AddColumn("dbo.Projects", "CreationDateTime", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Assets", "AssetSubtypeId", c => c.Int(nullable: false));
            AlterColumn("dbo.Assets", "AssetTypeId", c => c.Int(nullable: false));
            CreateIndex("dbo.Assets", "ProjectId");
            CreateIndex("dbo.Assets", "AssetTypeId");
            CreateIndex("dbo.Assets", "AssetSubtypeId");
            CreateIndex("dbo.Projects", "ProjectCategoryId");
            AddForeignKey("dbo.Assets", "ProjectId", "dbo.Projects", "ProjectId", cascadeDelete: true);
            AddForeignKey("dbo.Projects", "ProjectCategoryId", "dbo.ProjectCategories", "ProjectCategoryId", cascadeDelete: true);
            AddForeignKey("dbo.Assets", "AssetSubtypeId", "dbo.AssetSubtypes", "AssetSubtypeId", cascadeDelete: true);
            AddForeignKey("dbo.Assets", "AssetTypeId", "dbo.AssetTypes", "AssetTypeId", cascadeDelete: true);
            DropColumn("dbo.Assets", "TypeId");
            DropColumn("dbo.Assets", "SubtypeId");
            DropColumn("dbo.Assets", "ContributorId");
            DropColumn("dbo.Projects", "Category");
            DropColumn("dbo.Projects", "Creator_ContributorId");
            DropColumn("dbo.Projects", "LastContribution_AssetId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Projects", "LastContribution_AssetId", c => c.Int());
            AddColumn("dbo.Projects", "Creator_ContributorId", c => c.Int());
            AddColumn("dbo.Projects", "Category", c => c.String());
            AddColumn("dbo.Assets", "ContributorId", c => c.Int(nullable: false));
            AddColumn("dbo.Assets", "SubtypeId", c => c.Int(nullable: false));
            AddColumn("dbo.Assets", "TypeId", c => c.Int(nullable: false));
            DropForeignKey("dbo.Assets", "AssetTypeId", "dbo.AssetTypes");
            DropForeignKey("dbo.Assets", "AssetSubtypeId", "dbo.AssetSubtypes");
            DropForeignKey("dbo.Projects", "ProjectCategoryId", "dbo.ProjectCategories");
            DropForeignKey("dbo.Assets", "ProjectId", "dbo.Projects");
            DropIndex("dbo.Projects", new[] { "ProjectCategoryId" });
            DropIndex("dbo.Assets", new[] { "AssetSubtypeId" });
            DropIndex("dbo.Assets", new[] { "AssetTypeId" });
            DropIndex("dbo.Assets", new[] { "ProjectId" });
            AlterColumn("dbo.Assets", "AssetTypeId", c => c.Int());
            AlterColumn("dbo.Assets", "AssetSubtypeId", c => c.Int());
            DropColumn("dbo.Projects", "CreationDateTime");
            DropColumn("dbo.Projects", "ProjectCategoryId");
            DropColumn("dbo.Assets", "LastUpdaterId");
            DropColumn("dbo.Assets", "CreationDateTime");
            DropColumn("dbo.Assets", "CreatorId");
            DropColumn("dbo.Assets", "ProjectId");
            DropTable("dbo.ProjectCategories");
            RenameColumn(table: "dbo.Assets", name: "AssetTypeId", newName: "Type_AssetTypeId");
            RenameColumn(table: "dbo.Assets", name: "AssetSubtypeId", newName: "Subtype_AssetSubtypeId");
            CreateIndex("dbo.Projects", "LastContribution_AssetId");
            CreateIndex("dbo.Projects", "Creator_ContributorId");
            CreateIndex("dbo.Assets", "Type_AssetTypeId");
            CreateIndex("dbo.Assets", "Subtype_AssetSubtypeId");
            CreateIndex("dbo.Assets", "ContributorId");
            AddForeignKey("dbo.Assets", "Type_AssetTypeId", "dbo.AssetTypes", "AssetTypeId");
            AddForeignKey("dbo.Assets", "Subtype_AssetSubtypeId", "dbo.AssetSubtypes", "AssetSubtypeId");
            AddForeignKey("dbo.Projects", "LastContribution_AssetId", "dbo.Assets", "AssetId");
            AddForeignKey("dbo.Projects", "Creator_ContributorId", "dbo.Contributors", "ContributorId");
            AddForeignKey("dbo.Assets", "ContributorId", "dbo.Contributors", "ContributorId", cascadeDelete: true);
        }
    }
}
