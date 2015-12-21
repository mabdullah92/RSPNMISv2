using RSPNMISv2.Helpers;
using RSPNMISv2.Models;
using RSPNMISv2.ViewModels;
using System;
using System.Collections.Generic;
using System.Globalization;
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

            Array outreachList = DbHelpers.getGisKpis(districtName);

            return Json(outreachList);
        }
        //GET : PAST Trends for KPI
        public JsonResult GetTrends(int IndicatorId, DateTime ReportingDate, string[] districts = default(string[]), string[] Provinces = default(string[]), string[] PoIDs = default(string[]))
        {
            try
            {
                int[] partners = { -1 };
                if (PoIDs != null && PoIDs[0] != default(string))
                    partners = Array.ConvertAll(PoIDs, int.Parse);

                Array trends = DbHelpers.getTrends(IndicatorId, ReportingDate, districts, partners, Provinces);
                return Json(trends);
            }

            catch (Exception e)
            {
                return Json(e.ToString());
            }



        }
        public JsonResult GisProjectData(DateTime ReportingDate, string[] districts = default(string[]), string[] Provinces = default(string[]), string[] PoIDs = default(string[]))
        {
            try
            {
                int[] partners = { -1 };
                if (PoIDs != null && PoIDs[0] != default(string))
                    partners = Array.ConvertAll(PoIDs, int.Parse);

                Array outreachList = DbHelpers.getGisData(ReportingDate, districts, partners, Provinces);
                return Json(outreachList);
            }

            catch (Exception e)
            {
                return Json(e.ToString());
            }

        }

        public JsonResult RSPDistricts(int[] partners)
        {
            List<PartnerOrganization> poList = DbHelpers.getPartnerOrganizations();
            if (!partners.Contains(-1))
                poList = poList.Where(x => partners.Contains(x.ID)).ToList();


            var rspDistrictList = new List<RSPDistrictsViewModel>();

            foreach (PartnerOrganization p in poList)
            {


                string b = string.Empty;
                Array rspDistricts = DbHelpers.getRspDistricts(p.ID);
                foreach (dynamic a in rspDistricts)
                {
                    string c = a.DistrictName;
                    b = b + "," + CultureInfo.CurrentCulture.TextInfo.ToTitleCase(c.ToLower());
                }

                rspDistrictList.Add(new RSPDistrictsViewModel
                {
                    Rsp = p.Abbr,
                    DistrictsNames = b,
                    ColorCode = p.ColorCode
                });

            }


            return Json(rspDistrictList);
        }
        public JsonResult RSPDistrictList(int partnerId)
        {

            List<Array> data = new List<Array>();
           data.Add( DbHelpers.getRspDistricts(partnerId));
             data.Add(  DbHelpers.getIndicators(true).ToArray());
           
            return Json(data.ToArray());

        }
    }
}