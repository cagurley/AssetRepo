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

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Asset>()
                .HasRequired(a => a.Creator)
                .WithMany(c => c.AssetsCreated)
                .HasForeignKey(a => a.CreatorId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Asset>()
                .HasRequired(a => a.LastUpdater)
                .WithMany(c => c.AssetsLastUpdated)
                .HasForeignKey(a => a.LastUpdaterId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Project>()
                .HasRequired(p => p.Creator)
                .WithMany(c => c.ProjectsCreated)
                .HasForeignKey(p => p.CreatorId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Project>()
                .HasRequired(p => p.LastUpdater)
                .WithMany(c => c.ProjectsLastUpdated)
                .HasForeignKey(p => p.LastUpdaterId)
                .WillCascadeOnDelete(false);
        }
    }
}