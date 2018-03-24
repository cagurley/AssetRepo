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
                new AssetType { AssetTypeId = 1, Name = "Code" }
            );

            context.AssetSubtypes.AddOrUpdate(
                ast => ast.AssetSubtypeId,
                new AssetSubtype { AssetSubtypeId = 1, Name = "Source" }
            );

            context.Contributors.AddOrUpdate(
                c => c.ContributorId,
                new Contributor { ContributorId = 1, Name = "SampleContributor" }
            );

            context.ProjectCategories.AddOrUpdate(
                pc => pc.ProjectCategoryId,
                new ProjectCategory { ProjectCategoryId = 1, Name = "Public Project" }
            );

            context.SaveChanges();

            context.Projects.AddOrUpdate(
                p => p.ProjectId,
                new Project { ProjectId = 1, Title = "SampleProject", ProjectCategoryId = 1, CreatorId = 1, CreationDateTime = DateTime.Now, LastUpdaterId = 1, LastUpdateDateTime = DateTime.Now }
            );

            context.SaveChanges();

            context.Assets.AddOrUpdate(
                a => a.AssetId,
                new Asset { AssetId = 1, Title = "SampleTitle", ProjectId = 1, AssetTypeId = 1, AssetSubtypeId = 1, CreatorId = 1, CreationDateTime = DateTime.Now, LastUpdaterId = 1, LastUpdateDateTime = DateTime.Now, Comment = "Sample comment" }
            );
        }
    }
}
