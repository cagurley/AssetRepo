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
                var lastUpdatedProjects = new ProjectListViewModel
                {
                    Projects = assetRepoContext.Projects
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
                        Description = p.Description
                    })
                    .ToList()
                };

                return View(lastUpdatedProjects);
            } 
                //foreach (Project project in lastUpdatedProjects)
                //{
                //    if (project != null)
                //    {
                //        var projectViewModel = new ProjectViewModel
                //        {
                //            ProjectId = project.ProjectId,
                //            Title = project.Title,
                //            Category = new ProjectCategoryViewModel
                //            {
                //                ProjectCategoryId = project.ProjectCategoryId,
                //                Name = project.ProjectCategory.Name
                //            },
                //            Creator = new ContributorPopulatedViewModel
                //            {
                //                ContributorId = project.CreatorId,
                //                Name = project.Creator.Name
                //            },
                //            CreationDateTime = project.CreationDateTime,
                //            LastUpdater = new ContributorPopulatedViewModel
                //            {
                //                ContributorId = project.LastUpdaterId,
                //                Name = project.LastUpdater.Name
                //            },
                //            LastUpdateDateTime = project.LastUpdateDateTime,
                //            Description = project.Description
                //        };
                //    }
                //}
        }
    }
}