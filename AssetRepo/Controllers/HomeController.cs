using AssetRepo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AssetRepo.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            using (var assetRepoContext = new AssetRepoContext())
            {
                var lastUpdatedActiveProjects = new ProjectListViewModel
                {
                    Projects = assetRepoContext.Projects
                    .Where(p => p.IsActive == true)
                    .OrderByDescending(p => p.LastUpdateDateTime)
                    .Take(3)
                    .Select(p => new ProjectViewModel
                    {
                        ProjectId = p.ProjectId,
                        Title = p.Title,
                        Category = new ProjectCategoryViewModel
                        {
                            ProjectCategoryId = p.ProjectCategoryId
                        },
                        Creator = new ContributorPopulatedViewModel
                        {
                            ContributorId = p.Creator.ContributorId
                        },
                        CreationDateTime = p.CreationDateTime,
                        LastUpdater = new ContributorPopulatedViewModel
                        {
                            ContributorId = p.LastUpdaterId
                        },
                        LastUpdateDateTime = p.LastUpdateDateTime,
                        Description = p.Description,
                        IsActive = p.IsActive
                    })
                    .ToList()
                };

                return View(lastUpdatedActiveProjects);
            } 
        }

        public ActionResult EditNotAllowed()
        {
            return View();
        }
    }
}