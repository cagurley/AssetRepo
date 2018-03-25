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
        [Required, StringLength(200)]
        public string Title { get; set; }
        public int ProjectId { get; set; }
        public int AssetTypeSubtypePairingId { get; set; }
        public int CreatorId { get; set; }
        public DateTime CreationDateTime { get; set; }
        public int LastUpdaterId { get; set; }
        public DateTime LastUpdateDateTime { get; set; }
        [StringLength(200)]
        public string Comment { get; set; }
        [Required]
        public string FilePlaceholder { get; set; }

        public virtual Project Project { get; set; }
        public virtual AssetTypeSubtypePairing AssetTypeSubtypePairing { get; set; }
        public virtual Contributor Creator { get; set; }
        public virtual Contributor LastUpdater { get; set; }
    }
}