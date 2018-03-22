using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AssetRepo.Models
{
    public class Asset
    {
        public int AssetId { get; set; }
        [Required]
        public string Title { get; set; }
        public int ProjectId { get; set; }
        public int AssetTypeId { get; set; }
        public int AssetSubtypeId { get; set; }
        public int CreatorId { get; set; }
        public DateTime CreationDateTime { get; set; }
        public int LastUpdaterId { get; set; }
        public DateTime LastUpdateDateTime { get; set; }
        public string Comment { get; set; }

        public virtual Project Project { get; set; }
        public virtual AssetType Type { get; set; }
        public virtual AssetSubtype Subtype { get; set; }
        public virtual Contributor Creator { get; set; }
        public virtual Contributor LastUpdater { get; set; }
    }
}