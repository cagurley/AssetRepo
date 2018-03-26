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
                    }).Where(c => c.ContributorId != 1).ToList()
                };

                contributorList.TotalContributors = contributorList.Contributors.Count;

                return View(contributorList);
            }
        }

        // Detail functionality omitted as all relevant information is displayed in the Index view.

        public ActionResult ContributorAdd()
        {
            var contributorViewModel = new ContributorViewModel();

            return View("AddEditContributor", contributorViewModel);
        }

        [HttpPost]
        public ActionResult AddContributor(ContributorViewModel contributorViewModel)
        {
            if (!ModelState.IsValid)
            {
                using (var assetRepoContext = new AssetRepoContext())
                {
                    return View("AddEditContributor", contributorViewModel);
                }
            }

            using (var assetRepoContext = new AssetRepoContext())
            {
                var contributor = new Contributor
                {
                    Name = contributorViewModel.Name
                };

                assetRepoContext.Contributors.Add(contributor);
                assetRepoContext.SaveChanges();
            }

            return RedirectToAction("Index");
        }

        public ActionResult ContributorEdit(int id)
        {
            using (var assetRepoContext = new AssetRepoContext())
            {
                if (id == 1)
                {
                    return RedirectToAction("EditNotAllowed", "Home");
                }

                var contributor = assetRepoContext.Contributors.SingleOrDefault(c => c.ContributorId == id);
                if (contributor != null)
                {
                    var contributorViewModel = new ContributorViewModel
                    {
                        ContributorId = contributor.ContributorId,
                        Name = contributor.Name
                    };

                    return View("AddEditContributor", contributorViewModel);
                }
            }

            return new HttpNotFoundResult();
        }

        [HttpPost]
        public ActionResult EditContributor(ContributorViewModel contributorViewModel)
        {
            if (!ModelState.IsValid)
            {
                using (var assetRepoContext = new AssetRepoContext())
                {
                    return View("AddEditContributor", contributorViewModel);
                }
            }

            using (var assetRepoContext = new AssetRepoContext())
            {
                var contributor = assetRepoContext.Contributors.SingleOrDefault(c => c.ContributorId == contributorViewModel.ContributorId);

                if (contributor != null)
                {
                    contributor.Name = contributorViewModel.Name;
                    assetRepoContext.SaveChanges();

                    return RedirectToAction("Index");
                }
            }

            return new HttpNotFoundResult();
        }

        // Contributors are not intended to be deleted by a user, so this functionality has been omitted.
    }
}