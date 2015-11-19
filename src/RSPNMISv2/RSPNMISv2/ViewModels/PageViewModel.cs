using RSPNMISv2.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace RSPNMISv2.ViewModels
{
    public class PageViewModel
    {

    }

    public class OutreachImportViewModel
    {
        public int IndicatorID { set; get; }
        public Nullable<DateTime> ReportingDate { set; get; }
        public Nullable<decimal> Value { set; get; }
        public int Dist_Id { set; get; }
        public Nullable<int> UC_Id { set; get; }
        public string IndicatorName { set; get; }
        public string DistrictName { set; get; }
        public int PartnerOrganizationId { set; get; }
        public string PartnerOrganizationName { set; get; }
        public string SubIndicatorName { set; get; }
    }
    public class PartnerOrganizationViewModel
    {

        public int ID { set; get; }
        public string Title { set; get; }
    }

    public class RSPDistrictsViewModel
    {
        public string Rsp { set; get; }
        public string DistrictsNames { set; get; }
        public string ColorCode { set; get; }
    }

    //   public class RSPGisViewModel
    //{
    //    public string Rsp { set; get; }
    //    public string DistrictName { set; get; }
    //    public string indicatorName { set; get; }
    //    public string subIndicatorName { set; get; }
    //    public Decimal value { set; get; }
    //}

}