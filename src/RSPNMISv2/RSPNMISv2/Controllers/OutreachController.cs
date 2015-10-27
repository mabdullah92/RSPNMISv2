using OfficeOpenXml;
using RSPNMISv2.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using RSPNMISv2.Helpers;
using RSPNMISv2.ViewModels;
using System.Dynamic;
namespace RSPNMISv2.Controllers
{
    public class OutreachController : Controller
    {
        // GET PartnerOrganizations
        public List<PartnerOrganization> getPartnerOrganizations()
        {
            ApplicationDbContext db = new ApplicationDbContext();
            List<PartnerOrganization> PartnerOrganizations = db.PartnerOrganizations.ToList();

            return PartnerOrganizations;
        }

        // GET: Outreach

        public ActionResult Index()
        {
            return View();
        }
        public ActionResult DataUpload()
        {

            ApplicationDbContext db = new ApplicationDbContext();
            dynamic viewModel = new ExpandoObject();
            viewModel.OutReachData = OutreachCache.GetAll();
            viewModel.PartnerOrganizations = getPartnerOrganizations();
            return View(viewModel);
        }
        [HttpPost]
        public ActionResult DataUpload(HttpPostedFileBase rspFile)
        {
            // store the file inside ~/App_Data/uploads folder
            string fileName = Path.GetFileName(rspFile.FileName);


            var path = Path.Combine(Server.MapPath("~/App_Data/uploads"), fileName);
            rspFile.SaveAs(path);
            //end store file
            var viewData = new List<OutreachImportViewModel>();
            //reading file
            var existingFile = new FileInfo(path);
            // Open and read the XlSX file.

            ApplicationDbContext db = new ApplicationDbContext();

            //Get Indicators and Districts
            List<Indicator> Indicators = db.Indicators.ToList();
            List<District> Districts = db.Districts.ToList();
            List<Indicator> Indicator;
            List<District> District;


            using (var package = new ExcelPackage(existingFile))
            {
                // Get the work book in the file
                var workBook = package.Workbook;
                if (workBook != null)
                {
                    if (workBook.Worksheets.Count > 0)
                    {
                        // Get the first worksheet
                        var currentWorksheet = workBook.Worksheets.First();

                        // read some data
                        object col1Header = currentWorksheet.Cells[2, 2].Value;
                        // var Indicator_Id=0;
                        ExcelWorksheet workSheet = package.Workbook.Worksheets[1];
                        var start = workSheet.Dimension.Start;
                        var end = workSheet.Dimension.End;

                        for (int row = start.Row; row <= end.Row; row++)
                        { // Row by row...
                            if (row != 1)
                            {

                                string indicatorName = workSheet.Cells[row, 1].Text;
                                string subIndicatorName = workSheet.Cells[row, 2].Text;
                                string value = workSheet.Cells[row, 3].Text;
                                string districtName = workSheet.Cells[row, 4].Text;
                                Indicator = (Indicators.Where(x => (x.IndicatorName == indicatorName) && (x.SubIndicatorName == subIndicatorName))).ToList();
                                District = (Districts.Where(x => (x.District_Name == districtName))).ToList();

                                if (value == String.Empty)
                                    value = "0";

                                OutreachImportViewModel vm = new OutreachImportViewModel();
                                vm.Dist_Id = District[0].Dist_Id;
                                vm.IndicatorID = Indicator[0].ID;
                                vm.Value = Convert.ToDecimal(value);
                                vm.ReportingDate = DateTime.UtcNow;
                                vm.DistrictName = districtName;
                                vm.IndicatorName = indicatorName;
                                vm.SubIndicatorName = subIndicatorName;
                                OutreachCache.Add(User.Identity.Name, vm);

                            }

                        }


                    }
                }
            }
            dynamic viewModel = new ExpandoObject();
            viewModel.OutReachData = OutreachCache.GetAll();
            viewModel.PartnerOrganizations = getPartnerOrganizations();
            return View(viewModel);
        }

        [HttpPost]
        public ActionResult SubmitData(DateTime reportingDate, int partnerOrganizationID)
        {
            ApplicationDbContext db = new ApplicationDbContext();
            List<OutreachImportViewModel> rspCachedData = new List<OutreachImportViewModel>();
            rspCachedData = OutreachCache.GetAll();
            RSPOutreach o = new RSPOutreach();
            o.CreatedBy = User.Identity.Name;
            o.DateCreated = DateTime.Today;
            o.DateModified = DateTime.Today;
            o.ModifiedBy = User.Identity.Name;
            o.ReportingDate = reportingDate;
            o.PartnerOrganizationID = partnerOrganizationID;
            o.UC_Id = 1;
            foreach (var d in rspCachedData)
            {
                o.IndicatorID = d.IndicatorID;
                o.Dist_Id = d.Dist_Id;
                o.Value = d.Value;
                db.RSPOutreachs.Add(o);
                db.SaveChanges();
            }

            OutreachCache.RemoveUserData(User.Identity.Name);
            return RedirectToAction("DataUpload");
        }
        [HttpPost]
        public ActionResult EmptyUserCache()
        {
            OutreachCache.RemoveUserData(User.Identity.Name);
            return RedirectToAction("DataUpload");
        }
    }
}