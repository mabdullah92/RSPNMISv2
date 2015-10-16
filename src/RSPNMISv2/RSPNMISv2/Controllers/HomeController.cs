using RSPNMISv2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RSPNMISv2.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                PartnerOrganization o = new PartnerOrganization();
                o.Title = "ABC";
                o.ID = 505;
                o.YearFounded = 2007;
                o.Description = "Some DES";
                o.ColorCode = "#009900";
                o.Abbr = "ABC";

                db.PartnerOrganizations.Add(o);
                db.SaveChanges();
            }
            return View();
        }
        [HttpPost]
        public ActionResult Index(HttpPostedFileBase rspFile)
        {
            
            return View();
        }
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}