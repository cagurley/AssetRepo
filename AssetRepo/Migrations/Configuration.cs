using AssetRepo.Models;
using System;
using System.Data.Entity.Migrations;

namespace AssetRepo.Migrations
{
    internal sealed class Configuration : DbMigrationsConfiguration<AssetRepoContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            ContextKey = "AssetRepo.AssetRepoContext";
        }

        protected override void Seed(AssetRepoContext context)
        {
            context.AssetTypes.AddOrUpdate(
                at => at.AssetTypeId,
                new AssetType { AssetTypeId = 1, Name = "Code" },
                new AssetType { AssetTypeId = 2, Name = "Story" },
                new AssetType { AssetTypeId = 3, Name = "Visual Art" },
                new AssetType { AssetTypeId = 4, Name = "Music" },
                new AssetType { AssetTypeId = 5, Name = "Mechanics" }
            );

            context.AssetSubtypes.AddOrUpdate(
                ast => ast.AssetSubtypeId,
                new AssetSubtype { AssetSubtypeId = 1, Name = "Miscellaneous" },
                new AssetSubtype { AssetSubtypeId = 2, Name = "Diagram" },
                new AssetSubtype { AssetSubtypeId = 3, Name = "Source" },
                new AssetSubtype { AssetSubtypeId = 4, Name = "Pseudo" },
                new AssetSubtype { AssetSubtypeId = 5, Name = "Character" },
                new AssetSubtype { AssetSubtypeId = 6, Name = "Setting" },
                new AssetSubtype { AssetSubtypeId = 7, Name = "Plot" },
                new AssetSubtype { AssetSubtypeId = 8, Name = "Sprite" },
                new AssetSubtype { AssetSubtypeId = 9, Name = "Scenery" },
                new AssetSubtype { AssetSubtypeId = 10, Name = "Track" },
                new AssetSubtype { AssetSubtypeId = 11, Name = "Effect" },
                new AssetSubtype { AssetSubtypeId = 12, Name = "Theme" }
            );

            context.Contributors.AddOrUpdate(
                c => c.ContributorId,
                new Contributor { ContributorId = 1, Name = "SampleContributor" }
            );

            context.ProjectCategories.AddOrUpdate(
                pc => pc.ProjectCategoryId,
                new ProjectCategory { ProjectCategoryId = 1, Name = "Miscellaneous" },
                new ProjectCategory { ProjectCategoryId = 2, Name = "General Use" },
                new ProjectCategory { ProjectCategoryId = 3, Name = "Blind Collab" },
                new ProjectCategory { ProjectCategoryId = 4, Name = "Public Project" }
            );

            context.SaveChanges();

            context.AssetTypeSubtypePairings.AddOrUpdate(
                atsp => atsp.AssetTypeSubtypePairingId,
                new AssetTypeSubtypePairing { AssetTypeSubtypePairingId = 1, AssetTypeId = 1, AssetSubtypeId = 3 },
                new AssetTypeSubtypePairing { AssetTypeSubtypePairingId = 2, AssetTypeId = 1, AssetSubtypeId = 4 },
                new AssetTypeSubtypePairing { AssetTypeSubtypePairingId = 3, AssetTypeId = 1, AssetSubtypeId = 2 },
                new AssetTypeSubtypePairing { AssetTypeSubtypePairingId = 4, AssetTypeId = 1, AssetSubtypeId = 1 },
                new AssetTypeSubtypePairing { AssetTypeSubtypePairingId = 5, AssetTypeId = 2, AssetSubtypeId = 5 },
                new AssetTypeSubtypePairing { AssetTypeSubtypePairingId = 6, AssetTypeId = 2, AssetSubtypeId = 6 },
                new AssetTypeSubtypePairing { AssetTypeSubtypePairingId = 7, AssetTypeId = 2, AssetSubtypeId = 7 },
                new AssetTypeSubtypePairing { AssetTypeSubtypePairingId = 8, AssetTypeId = 2, AssetSubtypeId = 2 },
                new AssetTypeSubtypePairing { AssetTypeSubtypePairingId = 9, AssetTypeId = 2, AssetSubtypeId = 1 },
                new AssetTypeSubtypePairing { AssetTypeSubtypePairingId = 10, AssetTypeId = 3, AssetSubtypeId = 8 },
                new AssetTypeSubtypePairing { AssetTypeSubtypePairingId = 11, AssetTypeId = 3, AssetSubtypeId = 9 },
                new AssetTypeSubtypePairing { AssetTypeSubtypePairingId = 12, AssetTypeId = 3, AssetSubtypeId = 1 },
                new AssetTypeSubtypePairing { AssetTypeSubtypePairingId = 13, AssetTypeId = 4, AssetSubtypeId = 10 },
                new AssetTypeSubtypePairing { AssetTypeSubtypePairingId = 14, AssetTypeId = 4, AssetSubtypeId = 11 },
                new AssetTypeSubtypePairing { AssetTypeSubtypePairingId = 15, AssetTypeId = 4, AssetSubtypeId = 12 },
                new AssetTypeSubtypePairing { AssetTypeSubtypePairingId = 16, AssetTypeId = 4, AssetSubtypeId = 1 },
                new AssetTypeSubtypePairing { AssetTypeSubtypePairingId = 17, AssetTypeId = 5, AssetSubtypeId = 2 },
                new AssetTypeSubtypePairing { AssetTypeSubtypePairingId = 18, AssetTypeId = 5, AssetSubtypeId = 1 }
            );

            context.SaveChanges();

            context.Projects.AddOrUpdate(
                p => p.ProjectId,
                new Project { ProjectId = 1, Title = "Miscellaneous", ProjectCategoryId = 1, CreatorId = 1, CreationDateTime = DateTime.Now, LastUpdaterId = 1, LastUpdateDateTime = DateTime.Now, Description = "This is the project containing miscellaneous assets not assigned a clear use. Please ask the respective contributor for use of an asset from this project/category!" },
                new Project { ProjectId = 2, Title = "General Use", ProjectCategoryId = 2, CreatorId = 1, CreationDateTime = DateTime.Now, LastUpdaterId = 1, LastUpdateDateTime = DateTime.Now, Description = "This is the project containing assorted assets intended for broad public use. Assets in this project/category are free for appropriation so long as credit is properly attributed." }
            );

            context.SaveChanges();

            context.Assets.AddOrUpdate(
                a => a.AssetId,
                new Asset { AssetId = 1, Title = "SampleTitle", ProjectId = 1, AssetTypeSubtypePairingId = 1, CreatorId = 1, CreationDateTime = DateTime.Now, LastUpdaterId = 1, LastUpdateDateTime = DateTime.Now, Comment = "Sample comment", FilePlaceholder = "Pretend file" }
            );

            context.SaveChanges();
        }
    }
}
