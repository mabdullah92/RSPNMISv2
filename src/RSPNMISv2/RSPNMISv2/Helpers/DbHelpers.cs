using RSPNMISv2.Models;
using RSPNMISv2.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RSPNMISv2.Helpers
{
    public class DbHelpers
    {
        //GET: Partner Organizations
        public static List<PartnerOrganization> getPartnerOrganizations()
        {
            ApplicationDbContext db = new ApplicationDbContext();
            List<PartnerOrganization> PartnerOrganizations = db.PartnerOrganizations.ToList();
            PartnerOrganizations = (PartnerOrganizations.Where(x => (x.IsActive == true))).ToList();
            return PartnerOrganizations;
        }

        // GET: Districts
        public static List<District> getDistricts(int provinceId = -1, string districtName = "-1")
        {
            ApplicationDbContext db = new ApplicationDbContext();
            IQueryable<District> Districts = db.Districts;

            if (provinceId != -1)
            {
                Districts = Districts.Where(x => (x.Prov_Id == provinceId));
            }
            if (districtName != "-1")
            {
                Districts = Districts.Where(x => (x.District_Name == districtName));
            }

            return Districts.ToList();
        }

        // GET: RSP Districts
        public static Array getRspDistricts(int po_id = -1, int provinceId = -1)
        {
            ApplicationDbContext db = new ApplicationDbContext();
            IEnumerable<District> districts = db.Districts;
            IEnumerable<PartnerOrganization> pos = db.PartnerOrganizations;
            IEnumerable<ProjectDistrict> poDistricts = db.ProjectDistricts;
            Array result = null;
            //var query;
            if (po_id == -1)
            {
                var query = from pd in poDistricts join dist in districts on pd.Dist_Id equals dist.Dist_Id join po in pos on pd.PartnerOrganizationID equals po.ID where (dist.Prov_Id == provinceId) orderby dist.District_Name ascending select new { PO_ID = po.ID, Color = po.ColorCode, DistrictName = dist.District_Name, ID = dist.Dist_Id, Rsp = po.Abbr, ProvId = dist.Prov_Id };
                result = query.ToArray();
            }
            if (po_id != -1 && provinceId == -1)
            {
                var query = from pd in poDistricts join dist in districts on pd.Dist_Id equals dist.Dist_Id join po in pos on pd.PartnerOrganizationID equals po.ID where (po.ID == po_id) select new { PO_ID = po.ID, DistrictName = dist.District_Name, ID = dist.Dist_Id, Rsp = po.Abbr, ProvId = dist.Prov_Id };
                result = query.ToArray();
            }

            //if (partners !=null)
            //{
            //    var query = from pd in poDistricts join dist in districts on pd.Dist_Id equals dist.Dist_Id join po in pos on pd.PartnerOrganizationID equals po.ID where (partners.Contains(po.ID)) orderby dist.District_Name ascending select new { PO_ID = po.ID, Color = po.ColorCode, DistrictName = dist.District_Name, ID = dist.Dist_Id, Rsp = po.Abbr, ProvId = dist.Prov_Id };
            //    result = query.ToArray();

            //}

            return result;
        }

        // GET: Indicators
        public static List<Indicator> getIndicators(bool isCumulative = false)
        {
            ApplicationDbContext db = new ApplicationDbContext();
            IQueryable<Indicator> Indicators = db.Indicators;
            if (isCumulative == true)
            {
                Indicators = Indicators.Where(x => (x.IsCumulative == true));
            }
            return Indicators.ToList();
        }

        // GET: Outreach
        public static List<RSPOutreach> getOutReachData(bool isCumulative = false)
        {
            ApplicationDbContext db = new ApplicationDbContext();
            IQueryable<RSPOutreach> rspData = db.RSPOutreachs;

            if (isCumulative == true)
            {
                rspData = rspData.Where(x => (x.IsCumulative == true));
            }
            return rspData.ToList();
        }

        // GET: Provinces
        public static List<Province> getProvinces()
        {
            ApplicationDbContext db = new ApplicationDbContext();
            List<Province> provinces = db.Provinces.ToList();
            return provinces;
        }

        // GET : DATA FOR DISTRICT IN GIS
        public static Array getGisKpis(string districtName)
        {
            ApplicationDbContext db = new ApplicationDbContext();
            IEnumerable<District> districts = db.Districts;
            IEnumerable<Indicator> indicators = db.Indicators;
            IEnumerable<RSPOutreach> rspOutreachs = db.RSPOutreachs;
            IEnumerable<PartnerOrganization> pos = db.PartnerOrganizations;
            //                                  /                                                       /                                                       /                                           /
            var query = from pd in rspOutreachs join indicator in indicators on pd.IndicatorID equals indicator.ID join dist in districts on pd.Dist_Id equals dist.Dist_Id join po in pos on pd.PartnerOrganizationID equals po.ID where (dist.District_Name == districtName.ToUpper()) select new { DistrictName = dist.District_Name, indicatorName = indicator.IndicatorName, subIndicatorName = indicator.SubIndicatorName, value = pd.Value, Rsp = po.Abbr };
            Array result = query.ToArray();

            return result;
        }

        // GET : DATA FOR DISTRICT IN GIS
        public static Array getGisData(DateTime ReportingDate,string[] dists = default(string[]), int[] PoIDs = default(int[]), string[] Provinces = default(string[]))
        {
            ApplicationDbContext db = new ApplicationDbContext();
            IEnumerable<District> districts = db.Districts;
            IEnumerable<Indicator> indicators = db.Indicators;
            IEnumerable<RSPOutreach> rspOutreachs = db.RSPOutreachs;
            IEnumerable<PartnerOrganization> pos = db.PartnerOrganizations;
            //                                  /                                                       /                                                       /                                           /
            var query = from pd in rspOutreachs join indicator in indicators on pd.IndicatorID equals indicator.ID join dist in districts on pd.Dist_Id equals dist.Dist_Id join po in pos on pd.PartnerOrganizationID equals po.ID where (pd.ReportingDate == ReportingDate) select new { PartnerOrganizationName = po.Title, PartnerOrganizationID = po.ID, DistrictName = dist.District_Name, Province = dist.PROVINCE, indicatorName = indicator.IndicatorName, subIndicatorName = indicator.SubIndicatorName, indicatorId = indicator.ID, value = pd.Value, Rsp = po.Abbr };
      
     

            if (dists!=null && dists.Count() > 0)
            {
                dists = dists.Select(m => m.ToUpper()).ToArray();
                query = query.Where(x => dists.Contains(x.DistrictName.ToUpper()));
            }
            if (Provinces!=null && Provinces.Count() > 0)
            {
                Provinces = Provinces.Select(m => m.ToUpper()).ToArray();
                query = query.Where(x => Provinces.Contains(x.Province.ToUpper()));
            }
            if (PoIDs!=null && !PoIDs.Contains(-1) && PoIDs.Count() > 0)
            {
                query = query.Where(x => PoIDs.Contains(x.PartnerOrganizationID));
            }



            Array result = query.GroupBy(u => u.indicatorId).Select(g => new { IndicatorName = g.First().indicatorName,IndicatorId=g.First().indicatorId, SubIndicatorName = g.First().subIndicatorName,value=g.Sum(v=>v.value) }).ToArray();
            return result;
        }

        // GET : KPI Trends For GIS
        public static Array getTrends(int IndicatorId,DateTime ReportingDate, string[] dists = default(string[]), int[] PoIDs = default(int[]), string[] Provinces = default(string[]))
        {
            ApplicationDbContext db = new ApplicationDbContext();
            IEnumerable<District> districts = db.Districts;
            IEnumerable<Indicator> indicators = db.Indicators;
            IEnumerable<RSPOutreach> rspOutreachs = db.RSPOutreachs;
            IEnumerable<PartnerOrganization> pos = db.PartnerOrganizations;
            //                                  /                                                       /                                                       /                                           /
            var query = from pd in rspOutreachs join indicator in indicators on pd.IndicatorID equals indicator.ID join dist in districts on pd.Dist_Id equals dist.Dist_Id join po in pos on pd.PartnerOrganizationID equals po.ID where (pd.IndicatorID == IndicatorId) orderby pd.ReportingDate ascending select new { PartnerOrganizationName = po.Title,ReportingDate=pd.ReportingDate, PartnerOrganizationID = po.ID, DistrictName = dist.District_Name, Province = dist.PROVINCE, indicatorName = indicator.IndicatorName, subIndicatorName = indicator.SubIndicatorName, indicatorId = indicator.ID, value = pd.Value, Rsp = po.Abbr };



            if (dists != null && dists.Count() > 0)
            {
                dists = dists.Select(m => m.ToUpper()).ToArray();
                query = query.Where(x => dists.Contains(x.DistrictName.ToUpper()));
            }
            if (Provinces != null && Provinces.Count() > 0)
            {
                Provinces = Provinces.Select(m => m.ToUpper()).ToArray();
                query = query.Where(x => Provinces.Contains(x.Province.ToUpper()));
            }
            if (PoIDs != null && !PoIDs.Contains(-1) && PoIDs.Count() > 0)
            {
                query = query.Where(x => PoIDs.Contains(x.PartnerOrganizationID));
            }



            Array result = query.GroupBy(u => u.ReportingDate).Select(g => new {ReportingDate=g.First().ReportingDate,IndicatorName = g.First().indicatorName, IndicatorId = g.First().indicatorId, SubIndicatorName = g.First().subIndicatorName, value = g.Sum(v => v.value) }).ToArray();
            return result;
        }

        // GET : Reporting Dates

        public static Array getReportingDates(){
              ApplicationDbContext db = new ApplicationDbContext();
              Array result = db.Database.SqlQuery<ReportingDates>("SELECT [ReportingDate],CONCAT(DATENAME(mm, [ReportingDate]),', ' ,DATENAME(YYYY, [ReportingDate]),'.') AS ReportingMonthYear FROM [RSPNMIS_DB].[dbo].[RSPOutreaches] GROUP BY [ReportingDate] ORDER BY ReportingDate DESC").ToArray();
              return result;
        }


    }
}