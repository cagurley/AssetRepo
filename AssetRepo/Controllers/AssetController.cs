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
    }
}