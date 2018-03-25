using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AssetRepo.Models
{
    public class Contributor
    {
        public int ContributorId { get; set; }
        [Required, StringLength(100)]
        public string Name { get; set; }

        public virtual ICollection<Asset> AssetsCreated { get; set; }
        public virtual ICollection<Asset> AssetsLastUpdated { get; set; }
        public virtual ICollection<Project> ProjectsCreated { get; set; }
        public virtual ICollection<Project> ProjectsLastUpdated { get; set; }
    }
}