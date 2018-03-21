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
        //// Sample data before seed method implementation
        //public static AssetType SampleAssetType = new AssetType { AssetTypeId = 1, Name = "Code" };
        //public static AssetSubtype SampleAssetSubtype = new AssetSubtype { AssetSubtypeId = 1, Name = "Source" };
        //public static Contributor SampleContributor = new Contributor { ContributorId = 1, Name = "SampleContributor" };
        //public static Asset SampleAsset = new Asset { AssetId = 1, Title = "SampleTitle", TypeId = 1, SubtypeId = 1, ContributorId = 1, LastUpdateDateTime = DateTime.Now, Comment = "Sample comment" };
        //// REMOVE ABOVE AFTER SEED METHOD IMPLEMENTATION

        // GET: Asset
        public ActionResult Index()
        {
            using (var assetRepoContext = new AssetRepoContext())
            {
                var assetList = new AssetListViewModel
                {
                    //Convert each Asset to an AssetViewModel
                    Assets = assetRepoContext.Assets.Select(a => new AssetViewModel
                    {
                        AssetId = a.AssetId,
                        Title = a.Title,
                        Type = new AssetTypeViewModel
                        {
                            AssetTypeId = a.TypeId
                        },
                        Subtype = new AssetSubtypeViewModel
                        {
                            AssetSubtypeId = a.SubtypeId
                        },
                        Contributor = new ContributorViewModel
                        {
                            ContributorId = a.ContributorId
                        },
                        LastUpdateDateTime = a.LastUpdateDateTime,
                        Comment = a.Comment
                    }).ToList()
                };

                assetList.TotalAssets = assetList.Assets.Count;

                return View(assetList);
            }
        }

        public ActionResult AssetDetail(int id)
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
                        Type = new AssetTypeViewModel
                        {
                            AssetTypeId = asset.TypeId
                        },
                        Subtype = new AssetSubtypeViewModel
                        {
                            AssetSubtypeId = asset.SubtypeId
                        },
                        Contributor = new ContributorViewModel
                        {
                            ContributorId = asset.ContributorId
                        },
                        LastUpdateDateTime = asset.LastUpdateDateTime,
                        Comment = asset.Comment
                    };

                    return View(assetViewModel);
                }
            }

            return new HttpNotFoundResult();
        }

        public ActionResult AssetAdd()
        {
            using (var assetRepoContext = new AssetRepoContext())
            {
                ViewBag.AssetTypes = assetRepoContext.AssetTypes.Select(at => new SelectListItem
                {
                    Value = at.AssetTypeId.ToString(),
                    Text = at.Name
                }).ToList();

                ViewBag.AssetSubtypes = assetRepoContext.AssetSubtypes.Select(ast => new SelectListItem
                {
                    Value = ast.AssetSubtypeId.ToString(),
                    Text = ast.Name
                }).ToList();

                ViewBag.Contributors = assetRepoContext.Contributors.Select(c => new SelectListItem
                {
                    Value = c.ContributorId.ToString(),
                    Text = c.Name
                }).ToList();
            }

            var assetViewModel = new AssetViewModel();

            return View("AddEditAsset", assetViewModel);
        }

        [HttpPost]
        public ActionResult AddAsset(AssetViewModel assetViewModel)
        {
            if (!ModelState.IsValid)
            {
                using (var assetRepoContext = new AssetRepoContext())
                {
                    ViewBag.AssetTypes = assetRepoContext.AssetTypes.Select(at => new SelectListItem
                    {
                        Value = at.AssetTypeId.ToString(),
                        Text = at.Name
                    }).ToList();

                    ViewBag.AssetSubtypes = assetRepoContext.AssetSubtypes.Select(ast => new SelectListItem
                    {
                        Value = ast.AssetSubtypeId.ToString(),
                        Text = ast.Name
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
                    TypeId = assetViewModel.Type.AssetTypeId.Value,
                    SubtypeId = assetViewModel.Subtype.AssetSubtypeId.Value,
                    ContributorId = assetViewModel.Contributor.ContributorId.Value,
                    LastUpdateDateTime = assetViewModel.LastUpdateDateTime,
                    Comment = assetViewModel.Comment
                };

                assetRepoContext.Assets.Add(asset);
                assetRepoContext.SaveChanges();
            }

            return RedirectToAction("Index");
        }

        public ActionResult AssetEdit(int id)
        {
            using (var assetRepoContext = new AssetRepoContext())
            {
                ViewBag.AssetTypes = assetRepoContext.AssetTypes.Select(at => new SelectListItem
                {
                    Value = at.AssetTypeId.ToString(),
                    Text = at.Name
                }).ToList();

                ViewBag.AssetSubtypes = assetRepoContext.AssetSubtypes.Select(ast => new SelectListItem
                {
                    Value = ast.AssetSubtypeId.ToString(),
                    Text = ast.Name
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
                        Type = new AssetTypeViewModel
                        {
                            AssetTypeId = asset.TypeId,
                            Name = asset.Type.Name
                        },
                        Subtype = new AssetSubtypeViewModel
                        {
                            AssetSubtypeId = asset.SubtypeId,
                            Name = asset.Subtype.Name
                        },
                        Contributor = new ContributorViewModel
                        {
                            ContributorId = asset.ContributorId,
                            Name = asset.Contributor.Name
                        },
                        LastUpdateDateTime = asset.LastUpdateDateTime,
                        Comment = asset.Comment
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
                    ViewBag.AssetTypes = assetRepoContext.AssetTypes.Select(at => new SelectListItem
                    {
                        Value = at.AssetTypeId.ToString(),
                        Text = at.Name
                    }).ToList();

                    ViewBag.AssetSubtypes = assetRepoContext.AssetSubtypes.Select(ast => new SelectListItem
                    {
                        Value = ast.AssetSubtypeId.ToString(),
                        Text = ast.Name
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
                    asset.TypeId = assetViewModel.Type.AssetTypeId.Value;
                    asset.SubtypeId = assetViewModel.Subtype.AssetSubtypeId.Value;
                    asset.ContributorId = assetViewModel.Contributor.ContributorId.Value;
                    asset.LastUpdateDateTime = assetViewModel.LastUpdateDateTime;
                    asset.Comment = assetViewModel.Comment;
                    assetRepoContext.SaveChanges();

                    return RedirectToAction("Index");
                }
            }

            return new HttpNotFoundResult();
        }

        [HttpPost]
        public ActionResult DeleteAsset(AssetViewModel assetViewModel)
        {
            using (var assetRepoContext = new AssetRepoContext())
            {
                var asset = assetRepoContext.Assets.SingleOrDefault(a => a.AssetId == assetViewModel.AssetId);

                if (asset != null)
                {
                    assetRepoContext.Assets.Remove(asset);
                    assetRepoContext.SaveChanges();

                    return RedirectToAction("Index");
                }
            }

            return new HttpNotFoundResult();
        }

        //public ActionResult ManageFoodPreferences(int id)
        //{
        //    using (var assetRepoContext = new AssetRepoContext())
        //    {
        //        var person = assetRepoContext.People.Include("FoodPreferences").SingleOrDefault(p => p.PersonId == id);

        //        if (person == null)
        //            return new HttpNotFoundResult();

        //        var personViewModel = new PersonViewModel
        //        {
        //            PersonId = person.PersonId,
        //            LastName = person.LastName,
        //            FirstName = person.FirstName
        //        };

        //        //By adding .ToList() to assetRepoContext.Cuisines, we are forcing a single query to retrieve all cusines from the
        //        //database before we begin the loop. If we omit .ToList(), it may still work, but it will result in a seperate
        //        //round-trip to the database to get each cuisine.
        //        foreach (var cuisine in assetRepoContext.Cuisines.ToList())
        //        {
        //            //If no rating is found, currentRating will be null. "?." is inown as the null-conditional operator. It
        //            //keeps us from having to write more code to deal with null values.
        //            var currentRating = person.FoodPreferences.SingleOrDefault(fp => fp.CuisineId == cuisine.CuisineId)?.Rating;

        //            personViewModel.FoodPreferences.Add(new FoodPreferenceViewModel
        //            {
        //                Cuisine = new CuisineViewModel { CuisineId = cuisine.CuisineId, Name = cuisine.Name },
        //                //If currentRating is null, we will assign -1 to indicate that there is no rating. "??" is known as
        //                //the null-coalescing operator. It allows us to specify a different value if currentRating is null.
        //                Rating = currentRating ?? -1
        //            });
        //        }

        //        return View(personViewModel);
        //    }
        //}
    }
}