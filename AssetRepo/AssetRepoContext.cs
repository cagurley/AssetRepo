using AssetRepo.Models;
using System.Data.Entity;

namespace AssetRepo
{
    public class AssetRepoContext : DbContext
    {
        public AssetRepoContext() : base("name=AssetRepo") { }

        public virtual DbSet<Asset> Assets { get; set; }

        public virtual DbSet<AssetType> AssetTypes { get; set; }

        public virtual DbSet<AssetSubtype> AssetSubtypes { get; set; }

        public virtual DbSet<Contributor> Contributors { get; set; }

        public virtual DbSet<Project> Projects { get; set; }

        public virtual DbSet<ProjectCategory> ProjectCategories { get; set; }

        //protected override void OnModelCreating(DbModelBuilder modelBuilder)
        //{
        //    modelBuilder.Entity<Asset>()
        //        .HasRequired(a => a.Project)
        //        .WithMany(p => p.Assets)
        //        .HasForeignKey(a => a.ProjectId);

        //    modelBuilder.Entity<Project>()
        //        .HasOptional(p => p.LastContribution)
        //        .WithOptionalDependent()
        //        .Map
        //}
    }
}