using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AssetRepo.Models
{
    public class AssetListViewModel
    {
        public List<AssetViewModel> Assets { get; set; }
        public int TotalAssets { get; set; }
    }
}