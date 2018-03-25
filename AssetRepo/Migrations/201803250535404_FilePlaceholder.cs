namespace AssetRepo.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FilePlaceholder : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Assets", "FilePlaceholder", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Assets", "FilePlaceholder");
        }
    }
}
