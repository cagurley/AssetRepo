namespace AssetRepo.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class TypeSubtypeCategoryConstraints : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.AssetSubtypes", "Name", c => c.String(nullable: false, maxLength: 50));
            AlterColumn("dbo.AssetTypes", "Name", c => c.String(nullable: false, maxLength: 50));
            AlterColumn("dbo.ProjectCategories", "Name", c => c.String(nullable: false, maxLength: 50));
            CreateIndex("dbo.AssetSubtypes", "Name", unique: true);
            CreateIndex("dbo.AssetTypes", "Name", unique: true);
            CreateIndex("dbo.ProjectCategories", "Name", unique: true);
        }
        
        public override void Down()
        {
            DropIndex("dbo.ProjectCategories", new[] { "Name" });
            DropIndex("dbo.AssetTypes", new[] { "Name" });
            DropIndex("dbo.AssetSubtypes", new[] { "Name" });
            AlterColumn("dbo.ProjectCategories", "Name", c => c.String(nullable: false));
            AlterColumn("dbo.AssetTypes", "Name", c => c.String(nullable: false));
            AlterColumn("dbo.AssetSubtypes", "Name", c => c.String(nullable: false));
        }
    }
}
