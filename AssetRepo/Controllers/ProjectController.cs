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
                    //Convert each Project to a ProjectViewModel
                    Projects = assetRepoContext.Projects.Select(p => new ProjectViewModel
                    {
                        ProjectId = p.ProjectId,
                        Title = p.Title,
                        Category = new ProjectCategoryViewModel
                        {
                            ProjectCategoryId = p.ProjectCategoryId
                        },
                        Creator = new ContributorViewModel
                        {
                            ContributorId = p.CreatorId
                        },
                        CreationDateTime = p.CreationDateTime,
                        LastUpdater = new ContributorViewModel
                        {
                            ContributorId = p.LastUpdaterId
                        },
                        LastUpdateDateTime = p.LastUpdateDateTime,
                    }).ToList()
                };

                projectList.TotalProjects = projectList.Projects.Count;

                return View(projectList);
            }
        }
    }
}