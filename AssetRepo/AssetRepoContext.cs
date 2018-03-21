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
    }
}