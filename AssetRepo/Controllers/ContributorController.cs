using AssetRepo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AssetRepo.Controllers
{
    public class ContributorController : Controller
    {
        // GET: Contributor
        public ActionResult Index()
        {
            using (var assetRepoContext = new AssetRepoContext())
            {
                var contributorList = new ContributorListViewModel
                {
                    //Convert each Contributor to a ContributorViewModel
                    Contributors = assetRepoContext.Contributors.Select(c => new ContributorViewModel
                    {
                        ContributorId = c.ContributorId,
                        Name = c.Name
                    }).ToList()
                };

                contributorList.TotalContributors = contributorList.Contributors.Count;

                return View(contributorList);
            }
        }
    }
}