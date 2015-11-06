using RSPNMISv2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RSPNMISv2.Helpers
{
    public class DbHelpers
    {
        //GET Partner Organizations
        public static List<PartnerOrganization> getPartnerOrganizations()
        {
            ApplicationDbContext db = new ApplicationDbContext();
            List<PartnerOrganization> PartnerOrganizations = db.PartnerOrganizations.ToList();

            return PartnerOrganizations;
        }
        // GET Districts
        public static List<District> getDistricts()
        {
            ApplicationDbContext db = new ApplicationDbContext();
            List<District> Districts = db.Districts.ToList();

            return Districts;
        }

        // GET Indicators
        public static List<Indicator> getIndicators()
        {
            ApplicationDbContext db = new ApplicationDbContext();
            List<Indicator> Indicators = db.Indicators.ToList();

            return Indicators;
        }


        // GET: Outreach
        public static List<RSPOutreach> getOutReachData()
        {
            ApplicationDbContext db = new ApplicationDbContext();
            List<RSPOutreach> rspData = db.RSPOutreachs.ToList();
            return rspData;
        }
    }
}