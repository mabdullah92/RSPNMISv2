using RSPNMISv2.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Web.Mvc;

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

    public class RSPDistrictsViewModel
    {
        public string Rsp { set; get; }
        public string DistrictsNames { set; get; }
        public string ColorCode { set; get; }
    }

    public class PartnerOrganizationViewModel
    {
        public int ID { set; get; }
        [Display(Name = "Partner Type")]
        public int PartnerOrganizationType_ID { set; get; }
        [Display(Name = "Abbreviation")]
        public string Abbr { set; get; }
        [Display(Name = "Title")]
        public string Title { set; get; }
        [Display(Name = "Description")]
        public string Description { set; get; }
        [Display(Name = "Year Founded")]

        public Nullable<int> YearFounded { set; get; }
        [Display(Name = "Color Code")]

        public string ColorCode { set; get; }
        [Display(Name = "Order Index")]

        public long OrderIndex { set; get; }
        public bool IsActive { set; get; }

        public IList<District> Districts { set; get; }
        public Array ProjectDistricts { set; get; }
        public IList<PartnerOrganization> PartnerOrganizations { set; get; }


        public Array DistrictID { set; get; }
        public Array SelectedDistrictID { set; get; }
        [Display(Name = "Partner Organization")]
        public int PartnerOrganizationID { set; get; }

    }

    public class IndicatorViewModel
    {

        [Display(Name = "Indicator Name")]
        public string IndicatorName { set; get; }
        
        [Display(Name = "Sub Indicator Name")]
        public string SubIndicatorName { set; get; }
        
        [Display(Name = "Order Index")]
        public long OrderIndex { set; get; }
       
        [Display(Name = "Is Active")]
        public bool IsActive { set; get; }

        public DateTime DateCreated { set; get; }
        public string CreatedBy { set; get; }
        public DateTime DateModified { set; get; }
        public string ModifiedBy { set; get; }
       
        [Display(Name = "Cumulative Data")]
        public bool IsCumulative { set; get; } // true if RSP Sends data cumulatively without Districts
      
        [Display(Name = "Show Variance in Reports")]
        public bool showVarianceInReports { set; get; } // if Variance is needed in Report

        public IList<Indicator> Indicators { set; get; }
    }
}