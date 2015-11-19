using RSPNMISv2.Helpers;
using RSPNMISv2.Models;
using RSPNMISv2.ViewModels;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RSPNMISv2.Controllers
{
    public class GisController : Controller
    {
        // GET: Gis
        public ActionResult Index()
        {
            List<PartnerOrganization> poList = DbHelpers.getPartnerOrganizations();
            var rspDistrictList = new List<RSPDistrictsViewModel>();

            foreach (PartnerOrganization p in poList)
            {
                string b = string.Empty;
                Array rspDistricts = DbHelpers.getRspDistricts(p.ID);
                foreach (dynamic a in rspDistricts)
                {
                    string c = a.DistrictName;
                    b = b + "','" + CultureInfo.CurrentCulture.TextInfo.ToTitleCase(c.ToLower());
                }

                rspDistrictList.Add(new RSPDistrictsViewModel
           {
               Rsp = p.Abbr,
               DistrictsNames = b,
               ColorCode=p.ColorCode
           });

            }

            dynamic viewModel = new ExpandoObject();
            viewModel.RspDistricts = rspDistrictList;

            return View(viewModel);
        }

    }

}