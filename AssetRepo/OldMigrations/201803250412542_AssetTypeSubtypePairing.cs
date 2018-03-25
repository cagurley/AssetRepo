namespace AssetRepo.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AssetTypeSubtypePairing : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Assets", "AssetSubtypeId", "dbo.AssetSubtypes");
            DropForeignKey("dbo.Assets", "AssetTypeId", "dbo.AssetTypes");
            DropIndex("dbo.Assets", new[] { "AssetTypeId" });
            DropIndex("dbo.Assets", new[] { "AssetSubtypeId" });
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
            
            AddColumn("dbo.Assets", "AssetTypeSubtypePairingId", c => c.Int(nullable: false));
            CreateIndex("dbo.Assets", "AssetTypeSubtypePairingId");
            AddForeignKey("dbo.Assets", "AssetTypeSubtypePairingId", "dbo.AssetTypeSubtypePairings", "AssetTypeSubtypePairingId", cascadeDelete: true);
            DropColumn("dbo.Assets", "AssetTypeId");
            DropColumn("dbo.Assets", "AssetSubtypeId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Assets", "AssetSubtypeId", c => c.Int(nullable: false));
            AddColumn("dbo.Assets", "AssetTypeId", c => c.Int(nullable: false));
            DropForeignKey("dbo.AssetTypeSubtypePairings", "AssetTypeId", "dbo.AssetTypes");
            DropForeignKey("dbo.AssetTypeSubtypePairings", "AssetSubtypeId", "dbo.AssetSubtypes");
            DropForeignKey("dbo.Assets", "AssetTypeSubtypePairingId", "dbo.AssetTypeSubtypePairings");
            DropIndex("dbo.AssetTypeSubtypePairings", new[] { "AssetSubtypeId" });
            DropIndex("dbo.AssetTypeSubtypePairings", new[] { "AssetTypeId" });
            DropIndex("dbo.Assets", new[] { "AssetTypeSubtypePairingId" });
            DropColumn("dbo.Assets", "AssetTypeSubtypePairingId");
            DropTable("dbo.AssetTypeSubtypePairings");
            CreateIndex("dbo.Assets", "AssetSubtypeId");
            CreateIndex("dbo.Assets", "AssetTypeId");
            AddForeignKey("dbo.Assets", "AssetTypeId", "dbo.AssetTypes", "AssetTypeId", cascadeDelete: true);
            AddForeignKey("dbo.Assets", "AssetSubtypeId", "dbo.AssetSubtypes", "AssetSubtypeId", cascadeDelete: true);
        }
    }
}
