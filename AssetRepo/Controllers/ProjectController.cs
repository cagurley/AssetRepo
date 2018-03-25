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
                    }).ToList()
                };

                projectList.TotalProjects = projectList.Projects.Count;

                return View(projectList);
            }
        }

        public ActionResult ProjectDetail(int id)
        {
            using (var assetRepoContext = new AssetRepoContext())
            {
                var project = assetRepoContext.Projects.SingleOrDefault(p => p.ProjectId == id);
                if (project != null)
                {
                    var projectViewModel = new ProjectViewModel
                    {
                        ProjectId = project.ProjectId,
                        Title = project.Title,
                        Category = new ProjectCategoryViewModel
                        {
                            ProjectCategoryId = project.ProjectCategoryId,
                            Name = project.ProjectCategory.Name
                        },
                        Creator = new ContributorPopulatedViewModel
                        {
                            ContributorId = project.CreatorId,
                            Name = project.Creator.Name
                        },
                        CreationDateTime = project.CreationDateTime,
                        LastUpdater = new ContributorPopulatedViewModel
                        {
                            ContributorId = project.LastUpdaterId,
                            Name = project.LastUpdater.Name
                        },
                        LastUpdateDateTime = project.LastUpdateDateTime,
                        Description = project.Description
                    };

                    return View(projectViewModel);
                }
            }

            return new HttpNotFoundResult();
        }

        public ActionResult ProjectAdd()
        {
            using (var assetRepoContext = new AssetRepoContext())
            {
                ViewBag.ProjectCategories = assetRepoContext.ProjectCategories
                    .Select(pc => new SelectListItem
                    {
                        Value = pc.ProjectCategoryId.ToString(),
                        Text = pc.Name
                    })
                    // Miscellaneous and General Use project categories are excluded since they should have exactly one corresponding project instance.
                    .Where(pc => pc.Value != "1" && pc.Value != "2")
                    .ToList();

                ViewBag.Contributors = assetRepoContext.Contributors.Select(c => new SelectListItem
                {
                    Value = c.ContributorId.ToString(),
                    Text = c.Name
                }).ToList();
            }

            var projectViewModel = new ProjectViewModel();

            return View("AddEditProject", projectViewModel);
        }

        [HttpPost]
        public ActionResult AddProject(ProjectViewModel projectViewModel)
        {
            if (!ModelState.IsValid)
            {
                using (var assetRepoContext = new AssetRepoContext())
                {
                    ViewBag.ProjectCategories = assetRepoContext.ProjectCategories
                    .Select(pc => new SelectListItem
                    {
                        Value = pc.ProjectCategoryId.ToString(),
                        Text = pc.Name
                    })
                    // Miscellaneous and General Use project categories are excluded since they should have exactly one corresponding project instance.
                    .Where(pc => pc.Value != "1" && pc.Value != "2")
                    .ToList();

                    ViewBag.Contributors = assetRepoContext.Contributors.Select(c => new SelectListItem
                    {
                        Value = c.ContributorId.ToString(),
                        Text = c.Name
                    }).ToList();

                    return View("AddEditProject", projectViewModel);
                }
            }

            using (var assetRepoContext = new AssetRepoContext())
            {
                var project = new Project
                {
                    Title = projectViewModel.Title,
                    ProjectCategoryId = projectViewModel.Category.ProjectCategoryId.Value,
                    CreatorId = projectViewModel.Creator.ContributorId.Value,
                    // Automatically set to current system datetime
                    CreationDateTime = DateTime.Now,
                    // Set to Creator ID value since asset is new
                    LastUpdaterId = projectViewModel.Creator.ContributorId.Value,
                    // Automatically set to current system datetime
                    LastUpdateDateTime = DateTime.Now,
                    Description = projectViewModel.Description
                };

                assetRepoContext.Projects.Add(project);
                assetRepoContext.SaveChanges();
            }

            return RedirectToAction("Index");
        }

        public ActionResult ProjectEdit(int id)
        {
            using (var assetRepoContext = new AssetRepoContext())
            {
                if (id == 1 || id == 2)
                {
                    return View("EditNotAllowed");
                }
                ViewBag.ProjectCategories = assetRepoContext.ProjectCategories
                    .Select(pc => new SelectListItem
                    {
                        Value = pc.ProjectCategoryId.ToString(),
                        Text = pc.Name
                    })
                    // Miscellaneous and General Use project categories are excluded since they should have exactly one corresponding project instance.
                    .Where(pc => pc.Value != "1" && pc.Value != "2")
                    .ToList();

                ViewBag.Contributors = assetRepoContext.Contributors.Select(c => new SelectListItem
                {
                    Value = c.ContributorId.ToString(),
                    Text = c.Name
                }).ToList();

                var project = assetRepoContext.Projects.SingleOrDefault(p => p.ProjectId == id);
                if (project != null)
                {
                    var projectViewModel = new ProjectViewModel
                    {
                        ProjectId = project.ProjectId,
                        Title = project.Title,
                        Category = new ProjectCategoryViewModel
                        {
                            ProjectCategoryId = project.ProjectCategoryId,
                            Name = project.ProjectCategory.Name
                        },
                        Creator = new ContributorPopulatedViewModel
                        {
                            ContributorId = project.CreatorId,
                            Name = project.Creator.Name
                        },
                        CreationDateTime = project.CreationDateTime,
                        LastUpdater = new ContributorPopulatedViewModel
                        {
                            ContributorId = project.LastUpdaterId,
                            Name = project.LastUpdater.Name
                        },
                        LastUpdateDateTime = project.LastUpdateDateTime,
                        Description = project.Description
                    };

                    return View("AddEditProject", projectViewModel);
                }
            }

            return new HttpNotFoundResult();
        }

        [HttpPost]
        public ActionResult EditProject(ProjectViewModel projectViewModel)
        {
            if (!ModelState.IsValid)
            {
                using (var assetRepoContext = new AssetRepoContext())
                {
                    ViewBag.ProjectCategories = assetRepoContext.ProjectCategories
                    .Select(pc => new SelectListItem
                    {
                        Value = pc.ProjectCategoryId.ToString(),
                        Text = pc.Name
                    })
                    // Miscellaneous and General Use project categories are excluded since they should have exactly one corresponding project instance.
                    .Where(pc => pc.Value != "1" && pc.Value != "2")
                    .ToList();

                    ViewBag.Contributors = assetRepoContext.Contributors.Select(c => new SelectListItem
                    {
                        Value = c.ContributorId.ToString(),
                        Text = c.Name
                    }).ToList();

                    return View("AddEditProject", projectViewModel);
                }
            }

            using (var assetRepoContext = new AssetRepoContext())
            {
                var project = assetRepoContext.Projects.SingleOrDefault(p => p.ProjectId == projectViewModel.ProjectId);

                if (project != null)
                {
                    project.Title = projectViewModel.Title;
                    project.ProjectCategoryId = projectViewModel.Category.ProjectCategoryId.Value;
                    // CreatorId and CreationDateTime omitted so as to be set only during add
                    project.LastUpdaterId = projectViewModel.LastUpdater.ContributorId.Value;
                    // Automatically set to current system datetime
                    project.LastUpdateDateTime = DateTime.Now;
                    project.Description = projectViewModel.Description;
                    assetRepoContext.SaveChanges();

                    return RedirectToAction("Index");
                }
            }

            return new HttpNotFoundResult();
        }

        // Projects are not intended to be deleted by a user, so this functionality has been omitted.
    }
}