using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AssetRepo.Models
{
    public class ContributorListViewModel
    {
        public List<ContributorViewModel> Contributors { get; set; }
        public int TotalContributors { get; set; }
    }
}