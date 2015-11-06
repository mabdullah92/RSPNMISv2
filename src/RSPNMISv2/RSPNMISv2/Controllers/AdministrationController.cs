using RSPNMISv2.Helpers;
using RSPNMISv2.Models;
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
            dynamic viewModel = new ExpandoObject();
            viewModel.POs = DbHelpers.getPartnerOrganizations();
            viewModel.Districts = DbHelpers.getDistricts();
            return View(viewModel);
        }

        [HttpPost]
        public ActionResult PartnerOrganizations(int poType, string title, string abbr, string description, string year, string color)
        {
            ApplicationDbContext db = new ApplicationDbContext();

            PartnerOrganization o = new PartnerOrganization();
            o.PartnerOrganizationType_ID = poType;
            o.Title = title;
            o.Abbr = abbr;
            o.Description = description;
            o.YearFounded = Convert.ToInt32(year);
            o.ColorCode = color;
            db.PartnerOrganizations.Add(o);
            db.SaveChanges();
            return View();
        }
        public ActionResult Sectors()
        {
            return View();
        }

        [HttpPost]
        public ActionResult PoDistricts(int poType, List<int> to)
        {
            ApplicationDbContext db = new ApplicationDbContext();

            PO_District o = new PO_District();
            o.PartnerOrganizationID = poType;
            foreach (int i in to) {
                o.Dist_Id = i;
                db.PO_Districts.Add(o);
                db.SaveChanges();
            }

            var action = (Request.UrlReferrer.Segments.Skip(2).Take(1).SingleOrDefault() ?? "Index").Trim('/');
            return RedirectToAction(action);
        }

    }
}