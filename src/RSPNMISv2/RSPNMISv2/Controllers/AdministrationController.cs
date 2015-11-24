using RSPNMISv2.Helpers;
using RSPNMISv2.Models;
using RSPNMISv2.ViewModels;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RSPNMISv2.Controllers
{
    public class AdministrationController : Controller
    {
        // GET: Administration
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult PartnerOrganizations()
        {
            PartnerOrganizationViewModel vm = new PartnerOrganizationViewModel();
            vm.PartnerOrganizations = DbHelpers.getPartnerOrganizations();
            vm.Districts = DbHelpers.getDistricts();
            vm.ProjectDistricts = DbHelpers.getRspDistricts();
            return View(vm);
        }

        [HttpPost]
        public ActionResult PartnerOrganizations(PartnerOrganizationViewModel model)
        {
            ApplicationDbContext db = new ApplicationDbContext();

            PartnerOrganization o = new PartnerOrganization();
            o.PartnerOrganizationType_ID = model.PartnerOrganizationType_ID;
            o.Title = model.Title;
            o.Abbr = model.Abbr;
            o.Description = model.Description;
            o.YearFounded = model.YearFounded;
            o.ColorCode = model.ColorCode;
            db.PartnerOrganizations.Add(o);
            db.SaveChanges();

            return View(model);
        }
        public ActionResult Sectors()
        {
            return View();
        }

        [HttpPost]
        public ActionResult PoDistricts(PartnerOrganizationViewModel model)
        {
            ApplicationDbContext db = new ApplicationDbContext();

            ProjectDistrict o = new ProjectDistrict();
            o.PartnerOrganizationID = model.PartnerOrganizationID;
            foreach (int i in model.SelectedDistrictID)
            {
                o.Dist_Id = i;
                db.ProjectDistricts.Add(o);
                db.SaveChanges();
            }

            var action = (Request.UrlReferrer.Segments.Skip(2).Take(1).SingleOrDefault() ?? "Index").Trim('/');
            return RedirectToAction(action);
        }

     

    }
}