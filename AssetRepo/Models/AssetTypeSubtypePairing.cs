using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AssetRepo.Models
{
    public class AssetTypeSubtypePairing
    {
        public int AssetTypeSubtypePairingId { get; set; }
        public int AssetTypeId { get; set; }
        public int AssetSubtypeId { get; set; }

        public virtual AssetType AssetType { get; set; }
        public virtual AssetSubtype AssetSubtype { get; set; }
        public virtual ICollection<Asset> Assets { get; set; }
    }
}