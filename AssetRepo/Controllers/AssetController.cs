using AssetRepo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AssetRepo.Controllers
{
    public class AssetController : Controller
    {
        // GET: Asset
        public ActionResult Index(int? projectId)
        {
            using (var assetRepoContext = new AssetRepoContext())
            {
                AssetListViewModel assetList;
                if (projectId == null)
                {
                    // Returns all assets
                    assetList = new AssetListViewModel
                    {
                        //Convert each Asset to an AssetViewModel
                        Assets = assetRepoContext.Assets.Select(a => new AssetViewModel
                        {
                            AssetId = a.AssetId,
                            Project = new ProjectPopulatedViewModel
                            {
                                ProjectId = a.ProjectId,
                                Title = a.Project.Title,
                                Category = new ProjectCategoryViewModel
                                {
                                    ProjectCategoryId = a.Project.ProjectCategoryId,
                                    Name = a.Project.ProjectCategory.Name
                                },
                                Creator = new ContributorPopulatedViewModel
                                {
                                    ContributorId = a.Project.CreatorId,
                                    Name = a.Project.Creator.Name
                                },
                                CreationDateTime = a.Project.CreationDateTime,
                                LastUpdater = new ContributorPopulatedViewModel
                                {
                                    ContributorId = a.Project.LastUpdaterId,
                                    Name = a.Project.LastUpdater.Name
                                },
                                LastUpdateDateTime = a.Project.LastUpdateDateTime,
                                Description = a.Project.Description
                            },
                            Title = a.Title,
                            TypeSubtypePairing = new AssetTypeSubtypePairingViewModel
                            {
                                AssetTypeSubtypePairingId = a.AssetTypeSubtypePairingId,
                                Type = new AssetTypeViewModel
                                {
                                    AssetTypeId = a.AssetTypeSubtypePairing.AssetTypeId,
                                    Name = a.AssetTypeSubtypePairing.AssetType.Name
                                },
                                Subtype = new AssetSubtypeViewModel
                                {
                                    AssetSubtypeId = a.AssetTypeSubtypePairing.AssetSubtypeId,
                                    Name = a.AssetTypeSubtypePairing.AssetSubtype.Name
                                }
                            },
                            Creator = new ContributorPopulatedViewModel
                            {
                                ContributorId = a.CreatorId,
                                Name = a.Creator.Name
                            },
                            CreationDateTime = a.CreationDateTime,
                            LastUpdater = new ContributorPopulatedViewModel
                            {
                                ContributorId = a.LastUpdaterId,
                                Name = a.LastUpdater.Name
                            },
                            LastUpdateDateTime = a.LastUpdateDateTime,
                            Comment = a.Comment,
                            FilePlaceholder = a.FilePlaceholder,
                            ProjectRouteId = projectId
                        }).ToList()
                    };
                }
                else
                {
                    //Returns all assets for a given project
                    assetList = new AssetListViewModel
                    {
                        //Convert each Asset to an AssetViewModel
                        Assets = assetRepoContext.Assets
                            .Select(a => new AssetViewModel
                            {
                                AssetId = a.AssetId,
                                Project = new ProjectPopulatedViewModel
                                {
                                    ProjectId = a.ProjectId,
                                    Title = a.Project.Title,
                                    Category = new ProjectCategoryViewModel
                                    {
                                        ProjectCategoryId = a.Project.ProjectCategoryId,
                                        Name = a.Project.ProjectCategory.Name
                                    },
                                    Creator = new ContributorPopulatedViewModel
                                    {
                                        ContributorId = a.Project.CreatorId,
                                        Name = a.Project.Creator.Name
                                    },
                                    CreationDateTime = a.Project.CreationDateTime,
                                    LastUpdater = new ContributorPopulatedViewModel
                                    {
                                        ContributorId = a.Project.LastUpdaterId,
                                        Name = a.Project.LastUpdater.Name
                                    },
                                    LastUpdateDateTime = a.Project.LastUpdateDateTime,
                                    Description = a.Project.Description
                                },
                                Title = a.Title,
                                TypeSubtypePairing = new AssetTypeSubtypePairingViewModel
                                {
                                    AssetTypeSubtypePairingId = a.AssetTypeSubtypePairingId,
                                    Type = new AssetTypeViewModel
                                    {
                                        AssetTypeId = a.AssetTypeSubtypePairing.AssetTypeId,
                                        Name = a.AssetTypeSubtypePairing.AssetType.Name
                                    },
                                    Subtype = new AssetSubtypeViewModel
                                    {
                                        AssetSubtypeId = a.AssetTypeSubtypePairing.AssetSubtypeId,
                                        Name = a.AssetTypeSubtypePairing.AssetSubtype.Name
                                    }
                                },
                                Creator = new ContributorPopulatedViewModel
                                {
                                    ContributorId = a.CreatorId,
                                    Name = a.Creator.Name
                                },
                                CreationDateTime = a.CreationDateTime,
                                LastUpdater = new ContributorPopulatedViewModel
                                {
                                    ContributorId = a.LastUpdaterId,
                                    Name = a.LastUpdater.Name
                                },
                                LastUpdateDateTime = a.LastUpdateDateTime,
                                Comment = a.Comment,
                                FilePlaceholder = a.FilePlaceholder,
                                ProjectRouteId = projectId
                            })
                            .Where(a => a.Project.ProjectId == projectId)
                            .ToList()
                    };
                    
                }

                assetList.ProjectRouteId = projectId;

                assetList.TotalAssets = assetList.Assets.Count;

                return View(assetList);
            }
        }

        public ActionResult AssetDetail(int id, int? projectId)
        {
            using (var assetRepoContext = new AssetRepoContext())
            {
                var asset = assetRepoContext.Assets.SingleOrDefault(a => a.AssetId == id);
                if (asset != null)
                {
                    var assetViewModel = new AssetViewModel
                    {
                        AssetId = asset.AssetId,
                        Title = asset.Title,
                        Project = new ProjectPopulatedViewModel
                        {
                            ProjectId = asset.ProjectId,
                            Title = asset.Project.Title,
                            Category = new ProjectCategoryViewModel
                            {
                                ProjectCategoryId = asset.Project.ProjectCategoryId,
                                Name = asset.Project.ProjectCategory.Name
                            },
                            Creator = new ContributorPopulatedViewModel
                            {
                                ContributorId = asset.Project.CreatorId,
                                Name = asset.Project.Creator.Name
                            },
                            CreationDateTime = asset.Project.CreationDateTime,
                            LastUpdater = new ContributorPopulatedViewModel
                            {
                                ContributorId = asset.Project.LastUpdaterId,
                                Name = asset.Project.LastUpdater.Name
                            },
                            LastUpdateDateTime = asset.Project.LastUpdateDateTime,
                            Description = asset.Project.Description
                        },
                        TypeSubtypePairing = new AssetTypeSubtypePairingViewModel
                        {
                            AssetTypeSubtypePairingId = asset.AssetTypeSubtypePairingId,
                            Type = new AssetTypeViewModel
                            {
                                AssetTypeId = asset.AssetTypeSubtypePairing.AssetTypeId,
                                Name = asset.AssetTypeSubtypePairing.AssetType.Name
                            },
                            Subtype = new AssetSubtypeViewModel
                            {
                                AssetSubtypeId = asset.AssetTypeSubtypePairing.AssetSubtypeId,
                                Name = asset.AssetTypeSubtypePairing.AssetSubtype.Name
                            }
                        },
                        Creator = new ContributorPopulatedViewModel
                        {
                            ContributorId = asset.CreatorId,
                            Name = asset.Creator.Name
                        },
                        CreationDateTime = asset.CreationDateTime,
                        LastUpdater = new ContributorPopulatedViewModel
                        {
                            ContributorId = asset.LastUpdaterId,
                            Name = asset.LastUpdater.Name
                        },
                        LastUpdateDateTime = asset.LastUpdateDateTime,
                        Comment = asset.Comment,
                        FilePlaceholder = asset.FilePlaceholder,
                        // Used for view filtering by project
                        ProjectRouteId = projectId
                    };
                    
                    return View(assetViewModel);
                }
            }

            return new HttpNotFoundResult();
        }

        public ActionResult AssetAdd(int? projectId)
        {
            using (var assetRepoContext = new AssetRepoContext())
            {
                if (projectId != null)
                {
                    ViewBag.Projects = assetRepoContext.Projects.Select(p => new SelectListItem
                    {
                        Value = p.ProjectId.ToString(),
                        Text = p.Title
                    }).Where(p => p.Value == projectId.ToString()).ToList();
                }
                else
                {
                    ViewBag.Projects = assetRepoContext.Projects.Select(p => new SelectListItem
                    {
                        Value = p.ProjectId.ToString(),
                        Text = p.Title
                    }).ToList();
                }
                ViewBag.AssetTypeSubtypePairings = assetRepoContext.AssetTypeSubtypePairings.Select(atsp => new SelectListItem
                {
                    Value = atsp.AssetTypeSubtypePairingId.ToString(),
                    Text = atsp.AssetType.Name + ": " + atsp.AssetSubtype.Name
                }).ToList();

                ViewBag.Contributors = assetRepoContext.Contributors.Select(c => new SelectListItem
                {
                    Value = c.ContributorId.ToString(),
                    Text = c.Name
                }).ToList();
            }

            var assetViewModel = new AssetViewModel() { ProjectRouteId = projectId };

            return View("AddEditAsset", assetViewModel);
        }

        [HttpPost]
        public ActionResult AddAsset(AssetViewModel assetViewModel)
        {
            if (!ModelState.IsValid)
            {
                using (var assetRepoContext = new AssetRepoContext())
                {
                    ViewBag.Projects = assetRepoContext.Projects.Select(p => new SelectListItem
                    {
                        Value = p.ProjectId.ToString(),
                        Text = p.Title
                    }).ToList();

                    ViewBag.AssetTypeSubtypePairings = assetRepoContext.AssetTypeSubtypePairings.Select(atsp => new SelectListItem
                    {
                        Value = atsp.AssetTypeSubtypePairingId.ToString(),
                        Text = atsp.AssetType.Name + ": " + atsp.AssetSubtype.Name
                    }).ToList();

                    ViewBag.Contributors = assetRepoContext.Contributors.Select(c => new SelectListItem
                    {
                        Value = c.ContributorId.ToString(),
                        Text = c.Name
                    }).ToList();

                    return View("AddEditAsset", assetViewModel);
                }
            }

            using (var assetRepoContext = new AssetRepoContext())
            {
                var asset = new Asset
                {
                    Title = assetViewModel.Title,
                    ProjectId = assetViewModel.Project.ProjectId.Value,
                    AssetTypeSubtypePairingId = assetViewModel.TypeSubtypePairing.AssetTypeSubtypePairingId.Value,
                    CreatorId = assetViewModel.Creator.ContributorId.Value,
                    // Automatically set to current system datetime
                    CreationDateTime = DateTime.Now,
                    // Set to Creator ID value since asset is new
                    LastUpdaterId = assetViewModel.Creator.ContributorId.Value,
                    // Automatically set to current system datetime
                    LastUpdateDateTime = DateTime.Now,
                    Comment = assetViewModel.Comment,
                    FilePlaceholder = assetViewModel.FilePlaceholder
                };

                // Updates last updated properties for respective project
                var project = assetRepoContext.Projects.SingleOrDefault(p => p.ProjectId == assetViewModel.Project.ProjectId);
                if (project != null)
                {
                    project.LastUpdaterId = assetViewModel.LastUpdater.ContributorId.Value;
                    project.LastUpdateDateTime = DateTime.Now;
                }

                assetRepoContext.Assets.Add(asset);
                assetRepoContext.SaveChanges();
            }

            return RedirectToAction("Index", new { projectId = assetViewModel.ProjectRouteId });
        }

        public ActionResult AssetEdit(int id, int? projectId)
        {
            using (var assetRepoContext = new AssetRepoContext())
            {
                ViewBag.Projects = assetRepoContext.Projects.Select(p => new SelectListItem
                {
                    Value = p.ProjectId.ToString(),
                    Text = p.Title
                }).ToList();

                ViewBag.AssetTypeSubtypePairings = assetRepoContext.AssetTypeSubtypePairings.Select(atsp => new SelectListItem
                {
                    Value = atsp.AssetTypeSubtypePairingId.ToString(),
                    Text = atsp.AssetType.Name + ": " + atsp.AssetSubtype.Name
                }).ToList();

                ViewBag.Contributors = assetRepoContext.Contributors.Select(c => new SelectListItem
                {
                    Value = c.ContributorId.ToString(),
                    Text = c.Name
                }).ToList();

                var asset = assetRepoContext.Assets.SingleOrDefault(a => a.AssetId == id);
                if (asset != null)
                {
                    var assetViewModel = new AssetViewModel
                    {
                        AssetId = asset.AssetId,
                        Title = asset.Title,
                        Project = new ProjectPopulatedViewModel
                        {
                            ProjectId = asset.ProjectId,
                            Title = asset.Project.Title,
                            Category = new ProjectCategoryViewModel
                            {
                                ProjectCategoryId = asset.Project.ProjectCategoryId,
                                Name = asset.Project.ProjectCategory.Name
                            },
                            Creator = new ContributorPopulatedViewModel
                            {
                                ContributorId = asset.Project.CreatorId,
                                Name = asset.Project.Creator.Name
                            },
                            CreationDateTime = asset.Project.CreationDateTime,
                            LastUpdater = new ContributorPopulatedViewModel
                            {
                                ContributorId = asset.Project.LastUpdaterId,
                                Name = asset.Project.LastUpdater.Name
                            },
                            LastUpdateDateTime = asset.Project.LastUpdateDateTime,
                            Description = asset.Project.Description
                        },
                        TypeSubtypePairing = new AssetTypeSubtypePairingViewModel
                        {
                            AssetTypeSubtypePairingId = asset.AssetTypeSubtypePairingId,
                            Type = new AssetTypeViewModel
                            {
                                AssetTypeId = asset.AssetTypeSubtypePairing.AssetTypeId,
                                Name = asset.AssetTypeSubtypePairing.AssetType.Name
                            },
                            Subtype = new AssetSubtypeViewModel
                            {
                                AssetSubtypeId = asset.AssetTypeSubtypePairing.AssetSubtypeId,
                                Name = asset.AssetTypeSubtypePairing.AssetSubtype.Name
                            }
                        },
                        Creator = new ContributorPopulatedViewModel
                        {
                            ContributorId = asset.CreatorId,
                            Name = asset.Creator.Name
                        },
                        CreationDateTime = asset.CreationDateTime,
                        LastUpdater = new ContributorPopulatedViewModel
                        {
                            ContributorId = asset.LastUpdaterId,
                            Name = asset.LastUpdater.Name
                        },
                        LastUpdateDateTime = asset.LastUpdateDateTime,
                        Comment = asset.Comment,
                        FilePlaceholder = asset.FilePlaceholder,
                        // Used for view filtering by project
                        ProjectRouteId = projectId
                    };

                    return View("AddEditAsset", assetViewModel);
                }
            }

            return new HttpNotFoundResult();
        }

        [HttpPost]
        public ActionResult EditAsset(AssetViewModel assetViewModel)
        {
            if (!ModelState.IsValid)
            {
                using (var assetRepoContext = new AssetRepoContext())
                {
                    ViewBag.Projects = assetRepoContext.Projects.Select(p => new SelectListItem
                    {
                        Value = p.ProjectId.ToString(),
                        Text = p.Title
                    }).ToList();

                    ViewBag.AssetTypeSubtypePairings = assetRepoContext.AssetTypeSubtypePairings.Select(atsp => new SelectListItem
                    {
                        Value = atsp.AssetTypeSubtypePairingId.ToString(),
                        Text = atsp.AssetType.Name + ": " + atsp.AssetSubtype.Name
                    }).ToList();

                    ViewBag.Contributors = assetRepoContext.Contributors.Select(c => new SelectListItem
                    {
                        Value = c.ContributorId.ToString(),
                        Text = c.Name
                    }).ToList();

                    return View("AddEditAsset", assetViewModel);
                }
            }

            using (var assetRepoContext = new AssetRepoContext())
            {
                var asset = assetRepoContext.Assets.SingleOrDefault(a => a.AssetId == assetViewModel.AssetId);

                if (asset != null)
                {
                    asset.Title = assetViewModel.Title;
                    asset.ProjectId = assetViewModel.Project.ProjectId.Value;
                    asset.AssetTypeSubtypePairingId = assetViewModel.TypeSubtypePairing.AssetTypeSubtypePairingId.Value;
                    // CreatorId and CreationDateTime omitted so as to be set only during add
                    asset.LastUpdaterId = assetViewModel.LastUpdater.ContributorId.Value;
                    // Automatically set to current system datetime
                    asset.LastUpdateDateTime = DateTime.Now;
                    asset.Comment = assetViewModel.Comment;
                    asset.FilePlaceholder = assetViewModel.FilePlaceholder;

                    // Updates last updated properties for respective project
                    var project = assetRepoContext.Projects.SingleOrDefault(p => p.ProjectId == assetViewModel.Project.ProjectId);
                    if (project != null)
                    {
                        project.LastUpdaterId = assetViewModel.LastUpdater.ContributorId.Value;
                        project.LastUpdateDateTime = DateTime.Now;
                    }

                    assetRepoContext.SaveChanges();

                    return RedirectToAction("Index", new { projectId = assetViewModel.ProjectRouteId });
                }
            }

            return new HttpNotFoundResult();
        }

        [HttpPost]
        public ActionResult DeleteAsset(AssetViewModel assetViewModel)
        {
            using (var assetRepoContext = new AssetRepoContext())
            {
                var projectRouteId = assetViewModel.ProjectRouteId;
                var asset = assetRepoContext.Assets.SingleOrDefault(a => a.AssetId == assetViewModel.AssetId);

                if (asset != null)
                {
                    assetRepoContext.Assets.Remove(asset);
                    assetRepoContext.SaveChanges();

                    return RedirectToAction("Index", new { projectId = projectRouteId });
                }
            }

            return new HttpNotFoundResult();
        }
    }
}