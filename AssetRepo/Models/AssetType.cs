using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace AssetRepo.Models
{
    public class AssetType
    {
        public int AssetTypeId { get; set; }
        [Required, StringLength(50), Index(IsUnique = true)]
        public string Name { get; set; }

        public virtual ICollection<AssetTypeSubtypePairing> AssetTypeSubtypePairings { get; set; }
    }
}