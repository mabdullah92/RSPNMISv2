using RSPNMISv2.Helpers;
using RSPNMISv2.Models;
using RSPNMISv2.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RSPNMISv2.Controllers
{
    public class DataServiceController : Controller
    {
        // GET: DataService
        public ActionResult Index()
        {



            return View();
        }

        // GET KPI by clicking on any district in map
        public JsonResult GisKpis(string districtName)
        {
         
            Array  outreachList = DbHelpers.getGisKpis(districtName);

            return Json(outreachList);
        }



    }
}