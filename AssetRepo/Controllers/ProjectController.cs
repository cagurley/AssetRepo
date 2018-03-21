using AssetRepo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AssetRepo.Controllers
{
    public class ProjectController : Controller
    {
        // GET: Project
        public ActionResult Index()
        {
            using (var assetRepoContext = new AssetRepoContext())
            {
                var projectList = new ProjectListViewModel
                {
                    //Convert each Asset to an AssetViewModel
                    Projects = assetRepoContext.Projects.Select(p => new ProjectViewModel
                    {
                        ProjectId = p.ProjectId,
                        Title = p.Title,
                        Category = p.Category,
                        Creator = new ContributorViewModel
                        {
                            ContributorId = p.CreatorId
                        },
                        LastContribution = new AssetViewModel
                        {
                            AssetId = p.LastContributionId
                        },
                        LastContributionDateTime = p.LastContributionDateTime,
                    }).ToList()
                };

                projectList.TotalProjects = projectList.Projects.Count;

                return View(projectList);
            }
        }
    }
}