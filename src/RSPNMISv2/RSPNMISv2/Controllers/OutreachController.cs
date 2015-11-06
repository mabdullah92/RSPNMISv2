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
using System.Drawing;
using OfficeOpenXml.Style;

namespace RSPNMISv2.Controllers
{
    public class OutreachController : Controller
    {

        public ActionResult Index()
        {
            return View();
        }
        public ActionResult DataUpload()
        {

            ApplicationDbContext db = new ApplicationDbContext();
            dynamic viewModel = new ExpandoObject();
            viewModel.OutReachData = OutreachCache.GetAll();
            viewModel.PartnerOrganizations = DbHelpers.getPartnerOrganizations();
            return View(viewModel);
        }
        [HttpPost]
        public ActionResult DataUpload(HttpPostedFileBase rspFile)
        {
            // store the file inside ~/App_Data/uploads folder
            string fileName = User.Identity.Name + "-" + DateTime.UtcNow + "-" + Path.GetFileName(rspFile.FileName);


            var path = Path.Combine(Server.MapPath("~/App_Data/uploads"), fileName);
            rspFile.SaveAs(path);
            //end store file
            var viewData = new List<OutreachImportViewModel>();
            //reading file
            var existingFile = new FileInfo(path);
            // Open and read the XlSX file.

            ApplicationDbContext db = new ApplicationDbContext();

            //Get Indicators and Districts
            List<Indicator> Indicators = DbHelpers.getIndicators();
            List<District> Districts = DbHelpers.getDistricts();
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


                                OutreachImportViewModel vm = new OutreachImportViewModel();
                                if (value != String.Empty)
                                    vm.Value = Convert.ToDecimal(value);
                                else
                                    vm.Value = null;


                                vm.Dist_Id = District[0].Dist_Id;
                                vm.IndicatorID = Indicator[0].ID;
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
            viewModel.PartnerOrganizations = DbHelpers.getPartnerOrganizations();
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
            //var controller = Request.UrlReferrer.Segments.Skip(1).Take(1).SingleOrDefault() ?? "Home").Trim('/'); 
            // Home is default controller

            var action = (Request.UrlReferrer.Segments.Skip(2).Take(1).SingleOrDefault() ?? "Index").Trim('/');
            return RedirectToAction(action);
        }
        [HttpPost]
        public ActionResult EmptyUserCache()
        {
            OutreachCache.RemoveUserData(User.Identity.Name);
            return RedirectToAction("DataUpload");
        }

        public ActionResult DataForm()
        {
            dynamic viewModel = new ExpandoObject();
            viewModel.PartnerOrganizations = DbHelpers.getPartnerOrganizations();
            viewModel.Districts = DbHelpers.getDistricts();
            viewModel.Indicators = DbHelpers.getIndicators();
            viewModel.OutReachData = OutreachCache.GetAll();
            return View(viewModel);
        }
        [HttpPost]
        public ActionResult DataForm(int partnerOrganization, string district, DateTime reportingDate, List<string> indicator, List<decimal> kpiValue)
        {
            //OutreachCache.RemoveUserData(User.Identity.Name);
            string[] districtInfo = district.Split(new[] { "$#" }, StringSplitOptions.None);


            OutreachImportViewModel vm = new OutreachImportViewModel();
            vm.Dist_Id = Convert.ToInt32(districtInfo[0]);
            vm.DistrictName = districtInfo[1];
            vm.ReportingDate = reportingDate;
            int i = 0;
            foreach (string d in indicator)
            {
                string[] indicatorInfo = d.Split(new[] { "$#" }, StringSplitOptions.None);
                vm.IndicatorID = Convert.ToInt32(indicatorInfo[0]);
                vm.IndicatorName = indicatorInfo[1];
                vm.SubIndicatorName = indicatorInfo[2];
                vm.Value = kpiValue[i];
                ++i;
                OutreachCache.Add(User.Identity.Name, vm);
            }

            dynamic viewModel = new ExpandoObject();
            viewModel.PartnerOrganizations = DbHelpers.getPartnerOrganizations();
            viewModel.Districts = DbHelpers.getDistricts();
            viewModel.Indicators = DbHelpers.getIndicators();
            viewModel.OutReachData = OutreachCache.GetAll();
            return View(viewModel);
        }

        public ActionResult Indicators()
        {
            dynamic viewModel = new ExpandoObject();
            viewModel.Indicators = DbHelpers.getIndicators();
            return View(viewModel);
        }

        [HttpPost]
        public ActionResult Indicators(int orderIndex, string indicatorName, string subIndicatorName)
        {
            ApplicationDbContext db = new ApplicationDbContext();
            Indicator o = new Indicator();
            o.CreatedBy = User.Identity.Name;
            o.DateCreated = DateTime.UtcNow;
            o.DateModified = DateTime.UtcNow;
            o.ModifiedBy = User.Identity.Name;
            o.IndicatorName = indicatorName;
            o.SubIndicatorName = subIndicatorName;
            o.OrderIndex = orderIndex;
            o.IsActive = true;
            db.Indicators.Add(o);
            db.SaveChanges();

            return View();
        }

        public ActionResult Reports()
        {
            DateTime now = DateTime.Now;
            // Set the file name and get the output directory
            var fileName = "All-Outreach-Issue_" + DateTime.Now.ToString("yyyy-MM-dd--hh-mm-ss") + ".xlsx";
            var outputDir = Server.MapPath("~/App_Data/Reports/");
            char[] columns = { 'A', 'B', 'C','D','E','F','G','H','I','J','K','L','M','N','O','P','Q','R','S','T','U','V','W','X','Y','Z' };
            // Create the file using the FileInfo object
            var file = new FileInfo(outputDir + fileName);
            // Create the package and make sure you wrap it in a using statement
            using (var package = new ExcelPackage(file))
            {
                // add a new worksheet to the empty workbook
                ExcelWorksheet worksheet = package.Workbook.Worksheets.Add("Cumulative Report - " + DateTime.Now.ToShortDateString());

                // --------- Data and styling goes here -------------- //
                // Add some formatting to the worksheet
                worksheet.TabColor = Color.Blue;
                worksheet.DefaultRowHeight = 12;
                worksheet.HeaderFooter.FirstFooter.LeftAlignedText = string.Format("Generated: {0}", DateTime.Now.ToShortDateString());
                worksheet.Row(1).Height = 20;
                worksheet.Row(2).Height = 18;

                // Start adding the header
                // First of all the first row
                worksheet.Cells["A1:C1"].Merge = true;
                worksheet.Cells["A2:B2"].Merge = true;
                worksheet.Cells[1, 1].Value = "Rural Support Programmes (RSPs) in Pakistan, Cumulative Progress as of " + now.ToString("MMMM") + " " + now.ToString("yyyy");
                worksheet.Cells[2, 1].Value = "Indicators";

                int poStartIndex = 3; // 2nd Column 
                int indicatorStartIndex = 4; // 4rth Row
                int valueStartIndex = 4; // 3rd column
                string previousIndicator = "";
                string currentIndicator = "";
                int mergeCellsCount = 0;
                decimal subTotal = 0;
                decimal value = 0;
                List<PartnerOrganization> poList = DbHelpers.getPartnerOrganizations();
                List<Indicator> indicatorsList = DbHelpers.getIndicators();
                List<RSPOutreach> data = DbHelpers.getOutReachData();


                foreach (Indicator i in indicatorsList)
                {

                    currentIndicator = i.IndicatorName;


                    if (currentIndicator == previousIndicator)
                    {
                        ++mergeCellsCount;
                        worksheet.Cells[indicatorStartIndex, 1].Value = "";
                    }
                    else
                    {
                        if (mergeCellsCount > 0)
                        {
                            mergeCellsCount = 0;
                            worksheet.Cells[indicatorStartIndex, 2].Style.Fill.PatternType = ExcelFillStyle.Solid;
                            worksheet.Cells[indicatorStartIndex, 2].Style.Fill.BackgroundColor.SetColor(Color.LightGray);

                            worksheet.Cells[indicatorStartIndex, 2].Value = "Total ";
                            worksheet.Cells[indicatorStartIndex, 2].Style.Font.Bold = true;
                            ++indicatorStartIndex;
                        }

                        worksheet.Cells[indicatorStartIndex, 1].Value = i.IndicatorName;
                        previousIndicator = i.IndicatorName;
                    }


                    worksheet.Cells[indicatorStartIndex, 2].Value = i.SubIndicatorName; //[row,col]
                    ++indicatorStartIndex;
                }
                if (mergeCellsCount > 0)
                {
                    mergeCellsCount = 0;
                    worksheet.Cells[indicatorStartIndex, 2].Value = "Total ";
                    worksheet.Cells[indicatorStartIndex, 2].Style.Font.Bold = true;
                    ++indicatorStartIndex;
                }

                 previousIndicator = "";
                 currentIndicator = "";
             
                foreach (PartnerOrganization p in poList)
                {
                    mergeCellsCount = 0;
                    valueStartIndex = 4;
                    subTotal = 0;
                    worksheet.Cells[2, poStartIndex].Value = p.Abbr;
                    foreach (Indicator i in indicatorsList)
                    {

                        currentIndicator = i.IndicatorName;


                        if (currentIndicator == previousIndicator)
                        {
                            ++mergeCellsCount;
                            value = Convert.ToDecimal(data.Where(x => (x.PartnerOrganizationID == p.ID) && (x.IndicatorID == i.ID)).Sum(x => x.Value));
                            subTotal = subTotal + value;
                            worksheet.Cells[valueStartIndex, poStartIndex].Value = value;
                        }
                        else
                        {
                            if (mergeCellsCount > 0)
                            {
                                worksheet.Cells[valueStartIndex, poStartIndex].Style.Fill.PatternType = ExcelFillStyle.Solid;
                                worksheet.Cells[valueStartIndex, poStartIndex].Style.Fill.BackgroundColor.SetColor(Color.LightGray);

                                worksheet.Cells[valueStartIndex, poStartIndex].Formula = "=SUM(" + columns[poStartIndex-1] + Convert.ToString(valueStartIndex - mergeCellsCount - 1) + ":" + columns[poStartIndex-1] + Convert.ToString(valueStartIndex - 1) + ")";
                                subTotal = 0;
                                valueStartIndex++;
                                  
                            }
                            mergeCellsCount = 0;
                            worksheet.Cells[valueStartIndex, poStartIndex].Value = Convert.ToDecimal(data.Where(x => (x.PartnerOrganizationID == p.ID) && (x.IndicatorID == i.ID)).Sum(x => x.Value));
                            previousIndicator = i.IndicatorName;
                        }

                        valueStartIndex++;
                    }
                    worksheet.Cells[valueStartIndex, poStartIndex].Formula = "=SUM(" + columns[poStartIndex - 1] + Convert.ToString(valueStartIndex - mergeCellsCount - 1) + ":" + columns[poStartIndex - 1] + Convert.ToString(valueStartIndex - 1) + ")";
                    ++poStartIndex;

                }
                valueStartIndex = 4;
                int poCount = poList.Count();
                while (indicatorStartIndex-4 > 0)
                {
                    worksheet.Cells[valueStartIndex, poStartIndex].Formula = "=SUM(" + columns[poStartIndex - 2] + Convert.ToString(valueStartIndex) + ":" + columns[poStartIndex - poCount-1] + Convert.ToString(valueStartIndex) + ")";
                    valueStartIndex++;
                    indicatorStartIndex--;
                }
                worksheet.Cells[2, poStartIndex].Value = "Total ";
                worksheet.Cells[2, poStartIndex].Style.Font.Bold = true;
                // Fit the columns according to its content
                worksheet.Column(1).AutoFit();
                worksheet.Column(2).AutoFit();
                worksheet.Column(3).AutoFit();
                worksheet.Column(13).AutoFit();
                worksheet.View.FreezePanes(1, 2);
                worksheet.View.FreezePanes(3, 3);
                using (var range = worksheet.Cells[1, 1, 1, 13])
                {
                    range.Style.Font.Bold = true;
                    range.Style.Border.Bottom.Style = ExcelBorderStyle.Double;

                }

                using (var range = worksheet.Cells["A1:A1000,A2:O2"])
                {
                    range.Style.Font.Bold = true;
                }
                // Set some document properties
                package.Workbook.Properties.Title = "Overall Cumulative progress";
                package.Workbook.Properties.Author = "Webmasters @ RSPN";
                package.Workbook.Properties.Company = "RSPN";

                // save our new workbook and we are done!
                package.Save();

            }
            return View();
        }

    }
}