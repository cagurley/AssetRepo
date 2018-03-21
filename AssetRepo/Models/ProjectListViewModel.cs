using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AssetRepo.Models
{
    public class ProjectListViewModel
    {
        public List<ProjectViewModel> Projects { get; set; }
        public int TotalProjects { get; set; }
    }
}