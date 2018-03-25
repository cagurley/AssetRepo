namespace AssetRepo.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class StringLengthsProjectDescription : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Projects", "Description", c => c.String(nullable: false, maxLength: 2000));
            AlterColumn("dbo.Assets", "Title", c => c.String(nullable: false, maxLength: 200));
            AlterColumn("dbo.Assets", "Comment", c => c.String(maxLength: 200));
            AlterColumn("dbo.Contributors", "Name", c => c.String(nullable: false, maxLength: 100));
            AlterColumn("dbo.Projects", "Title", c => c.String(nullable: false, maxLength: 200));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Projects", "Title", c => c.String(nullable: false));
            AlterColumn("dbo.Contributors", "Name", c => c.String(nullable: false));
            AlterColumn("dbo.Assets", "Comment", c => c.String());
            AlterColumn("dbo.Assets", "Title", c => c.String(nullable: false));
            DropColumn("dbo.Projects", "Description");
        }
    }
}
