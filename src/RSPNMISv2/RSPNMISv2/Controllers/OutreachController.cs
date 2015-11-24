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

            fileName = User.Identity.Name;
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

                                if (Indicator.Count > 0 && District.Count > 0)
                                {
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
                                else
                                {
                                    //exception Indicator or District Spelling mistake maybe 
                                    continue;
                                }

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

        public ActionResult TransposedUpload(HttpPostedFileBase rspFile)
        {
            // store the file inside ~/App_Data/uploads folder
            string fileName = "book3.xlsx";

            // fileName = User.Identity.Name;
            var path = Path.Combine(Server.MapPath("~/App_Data/uploads"), fileName);
            //  rspFile.SaveAs(path);
            //end store file
            var viewData = new List<OutreachImportViewModel>();
            //reading file
            var existingFile = new FileInfo(path);
            // Open and read the XlSX file.

            ApplicationDbContext db = new ApplicationDbContext();

            //Get Indicators and Districts
            List<Indicator> Indicators = DbHelpers.getIndicators();
            List<District> Districts = DbHelpers.getDistricts();
            List<PartnerOrganization> Partners = DbHelpers.getPartnerOrganizations();
            List<Indicator> Indicator;
            List<District> District;
            List<PartnerOrganization> PartnerOrganization;

            EmptyUserCache();
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

                                int[] indicatorId = new int[] { 1, 2, 4, 5, 39, 40, 41 };

                                //   string indicatorName = workSheet.Cells[row, 1].Text;
                                //      string subIndicatorName = workSheet.Cells[row, 2].Text;
                                int colStartIndex = 3;

                                string abbr = workSheet.Cells[row, 2].Text;
                                string districtName = workSheet.Cells[row, 1].Text;

                                // Indicator = (Indicators.Where(x => (x.IndicatorName == indicatorName) && (x.SubIndicatorName == subIndicatorName))).ToList();
                                District = (Districts.Where(x => (x.District_Name == districtName.ToUpper()))).ToList();
                                PartnerOrganization = (Partners.Where(x => (x.Abbr == abbr))).ToList();

                                if (PartnerOrganization.Count > 0 && District.Count > 0)
                                {

                                    OutreachImportViewModel vm = new OutreachImportViewModel();

                                    foreach (int i in indicatorId)
                                    {
                                        string value = workSheet.Cells[row, colStartIndex].Text;
                                        Indicator = (Indicators.Where(x => (x.ID == i))).ToList();

                                        if (value == "Yes")
                                            value = "1";
                                        else if (value == "No" || value=="")
                                            value = "0";

                                        if (value != String.Empty)
                                            vm.Value = Convert.ToDecimal(value);
                                        else
                                            vm.Value = null;

                                        vm.Dist_Id = District[0].Dist_Id;
                                        vm.IndicatorID = i;
                                        vm.PartnerOrganizationName = PartnerOrganization[0].Title;
                                        vm.PartnerOrganizationId = PartnerOrganization[0].ID;
                                        vm.ReportingDate = DateTime.UtcNow;
                                        vm.DistrictName = districtName;
                                        vm.Value = Convert.ToDecimal(value);
                                        vm.IndicatorName = Indicator[0].IndicatorName;
                                        vm.SubIndicatorName = Indicator[0].SubIndicatorName; ;
                                        OutreachCache.Add(User.Identity.Name, vm);
                                        colStartIndex++;
                                    }

                                }
                                else
                                {
                                    //exception Indicator or District Spelling mistake maybe 
                                    continue;
                                }

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
        public ActionResult SubmitTransposedData(DateTime reportingDate)
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

            o.UC_Id = 1;
            foreach (var d in rspCachedData)
            {
                o.IndicatorID = d.IndicatorID;
                o.Dist_Id = d.Dist_Id;
                o.Value = d.Value;
                o.PartnerOrganizationID =d.PartnerOrganizationId;
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
            IndicatorViewModel vm = new IndicatorViewModel();
            vm.Indicators = DbHelpers.getIndicators();
            return View(vm);
        }

        [HttpPost]
        public ActionResult Indicators(IndicatorViewModel model)
        {
            ApplicationDbContext db = new ApplicationDbContext();
            Indicator o = new Indicator();
            o.CreatedBy = User.Identity.Name;
            o.DateCreated = DateTime.UtcNow;
            o.DateModified = DateTime.UtcNow;
            o.ModifiedBy = User.Identity.Name;
            o.IndicatorName = model.IndicatorName;
            o.SubIndicatorName = model.SubIndicatorName;
            o.OrderIndex = model.OrderIndex;
            o.IsCumulative = model.IsCumulative;
            o.showVarianceInReports = model.showVarianceInReports;
            o.IsActive = true;
            db.Indicators.Add(o);
            db.SaveChanges();

            return View();
        }

        public ActionResult Reports()
        {

            return View();
        }

        [HttpPost]
        public ActionResult RspWiseCumulativeReport()
        {

            DateTime now = DateTime.Now;
            // Set the file name and get the output directory
            var fileName = "All-Outreach-Issue_" + DateTime.Now.ToString("yyyy-MM-dd--hh-mm-ss") + ".xlsx";
            var outputDir = Server.MapPath("~/App_Data/Reports/");
            char[] columns = { 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L', 'M', 'N', 'O', 'P', 'Q', 'R', 'S', 'T', 'U', 'V', 'W', 'X', 'Y', 'Z' };
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

                                worksheet.Cells[valueStartIndex, poStartIndex].Formula = "=SUM(" + columns[poStartIndex - 1] + Convert.ToString(valueStartIndex - mergeCellsCount - 1) + ":" + columns[poStartIndex - 1] + Convert.ToString(valueStartIndex - 1) + ")";
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
                while (indicatorStartIndex - 4 > 0)
                {
                    worksheet.Cells[valueStartIndex, poStartIndex].Formula = "=SUM(" + columns[poStartIndex - 2] + Convert.ToString(valueStartIndex) + ":" + columns[poStartIndex - poCount - 1] + Convert.ToString(valueStartIndex) + ")";
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

            return File(outputDir + fileName, "application/vnd.ms-excel", fileName);
        }

        [HttpPost]
        public ActionResult DistrictWiseReport()
        {
            DateTime lastMonth = DateTime.Now.AddMonths(-1);
            DateTime now = DateTime.Now;

            #region Initializing
            // Set the file name and get the output directory
            var fileName = "All-Outreach-Issue_Districts" + DateTime.Now.ToString("yyyy-MM-dd--hh-mm-ss") + ".xlsx";
            var outputDir = Server.MapPath("~/App_Data/Reports/");
            string[] columns = { "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z", "AA", "AB", "AC", "AD", "AE", "AF", "AG", "AH", "AI", "AJ", "AK", "AL", "AM", "AN", "AO", "AP", "AQ", "AR", "AS", "AT", "AU", "AV", "AW", "AX", "AY", "AZ", "BA", "BB", "BC", "BD", "BE" };
            // Create the file using the FileInfo object
            var file = new FileInfo(outputDir + fileName);
            // Create the package and make sure you wrap it in a using statement
            using (var package = new ExcelPackage(file))
            {
                // add a new worksheet to the empty workbook
                ExcelWorksheet worksheet = package.Workbook.Worksheets.Add("District Wise Report - " + DateTime.Now.ToShortDateString());

                // Starting Positions
                int districtStartIndex = 5;
                int indicatorHeaderCol = 3;
                int indicatorHeaderRow = 2;

                int indicatorDataRow = indicatorHeaderRow;
                int indicatorDataCol = indicatorHeaderCol;

                int srNo = 0;

                // --------- Data and styling goes here -------------- //
                // Add some formatting to the worksheet
                worksheet.TabColor = Color.Blue;
                worksheet.DefaultRowHeight = 12;
                worksheet.HeaderFooter.FirstFooter.LeftAlignedText = string.Format("Generated: {0}", DateTime.Now.ToShortDateString());
                worksheet.Row(1).Height = 20;
                worksheet.Row(2).Height = 18;

                // Start adding the header
                // First of all the first row

                worksheet.Cells[1, 1].Value = "Rural Support Programmes (RSPs) in Pakistan, District Wise Progress as of " + now.ToString("MMMM") + " " + now.ToString("yyyy");

                worksheet.Cells[2, 2].Value = "District Name";

                List<PartnerOrganization> poList = DbHelpers.getPartnerOrganizations();
                List<Indicator> indicatorsList = DbHelpers.getIndicators(true);
                List<RSPOutreach> outreachData = DbHelpers.getOutReachData(); // without passing True to get data for all Districts 
                List<Province> provincesList = DbHelpers.getProvinces();
                List<RSPOutreach> filteredReachData = new List<RSPOutreach>(); // without passing True to get data for all Districts 



                worksheet.Cells[districtStartIndex - 2, 2].Value = "Name Of District"; // row,col
                worksheet.Cells[districtStartIndex - 3, 1].Value = "S. No."; // row,col
                worksheet.Cells["A2:A3"].Merge = true;
                worksheet.Cells["B2:B3"].Merge = true;

            #endregion

                //temp now
                string currentDistrict;
                int overlappingDistricts = 0;
                DateTime date = DateTime.Now;
                int distId;
                int POId;
                foreach (Province p in provincesList)
                {
                    worksheet.Cells[districtStartIndex, 2].Value = p.PROVINCE;
                    worksheet.Cells[districtStartIndex, 2].Style.Font.Bold = true;
                    worksheet.Cells[districtStartIndex, 2].Style.Font.Bold = true;

                    worksheet.Cells[districtStartIndex, 2, districtStartIndex, 100].Style.Fill.PatternType = ExcelFillStyle.Solid;
                    worksheet.Cells[districtStartIndex, 2, districtStartIndex, 100].Style.Fill.BackgroundColor.SetColor(Color.LightGray);
                    indicatorDataRow++;
                    districtStartIndex++;

                    Array districtsList = DbHelpers.getRspDistricts(-1, p.Prov_Id);
                    List<string> checkOverlap = new List<string>();

                    srNo = 0;
                    foreach (dynamic d in districtsList)
                    {


                        currentDistrict = d.DistrictName;
                        distId = d.ID;
                        POId = d.PO_ID;

                        if (checkOverlap.Contains(currentDistrict))
                        {
                            worksheet.Cells[districtStartIndex, 2].Value = currentDistrict + " - Overlapping";
                            overlappingDistricts++; // to be used when reports are combined
                        }
                        else
                        {
                            worksheet.Cells[districtStartIndex, 2].Value = currentDistrict;
                            srNo++;
                        }
                        worksheet.Cells[districtStartIndex, 1].Value = srNo;
                        checkOverlap.Add(currentDistrict);

                        // fill in the outreach data 
                        indicatorDataCol = 5;

                        foreach (Indicator i in indicatorsList)
                        {
                            filteredReachData = outreachData.Where(x => (x.Dist_Id == distId) && (x.PartnerOrganizationID == POId) && (x.IndicatorID == i.ID)).ToList();

                            decimal value;
                            if (filteredReachData.Count != 0)
                                value = Convert.ToDecimal(filteredReachData[0].Value);
                            else
                                value = 0;

                            if (i.showVarianceInReports == true)
                            {

                                worksheet.Cells[indicatorDataRow + 3, indicatorDataCol - 2].Value = value;
                                indicatorDataCol += 2;
                            }
                            else
                            {
                                worksheet.Cells[indicatorDataRow + 3, indicatorDataCol - 2].Value = value;
                            }

                            indicatorDataCol++;

                        }


                        indicatorDataRow++;

                        //ended filling outreach data


                        districtStartIndex++;

                    }

                }


                foreach (Indicator i in indicatorsList)
                {

                    worksheet.Cells[indicatorHeaderRow, indicatorHeaderCol].Value = i.IndicatorName;
                    worksheet.Column(indicatorHeaderCol).AutoFit();

                    if (i.showVarianceInReports == true)
                    {
                        worksheet.Cells[indicatorHeaderRow + 1, indicatorHeaderCol].Value = "# as of " + lastMonth.ToString("MMMM") + " " + lastMonth.ToString("yyyy");
                        worksheet.Cells[indicatorHeaderRow + 1, indicatorHeaderCol + 1].Value = "% increase during " + now.ToString("MMMM") + " " + now.ToString("yyyy");
                        worksheet.Cells[indicatorHeaderRow + 1, indicatorHeaderCol + 2].Value = "% coverage as of " + now.ToString("MMMM") + " " + now.ToString("yyyy");

                        worksheet.Cells[indicatorHeaderRow + 1, indicatorHeaderCol].Style.WrapText = true;
                        worksheet.Cells[indicatorHeaderRow + 1, indicatorHeaderCol + 1].Style.WrapText = true;
                        worksheet.Cells[indicatorHeaderRow + 1, indicatorHeaderCol + 2].Style.WrapText = true;

                        string start = columns[indicatorHeaderCol - 1];
                        indicatorHeaderCol += 3;
                        string end = columns[indicatorHeaderCol - 2];
                        worksheet.Cells[start + "2" + ":" + end + "2"].Merge = true;
                    }
                    else
                    {
                        worksheet.Cells[indicatorHeaderRow, indicatorHeaderCol, indicatorHeaderRow + 1, indicatorHeaderCol].Merge = true; //[FromRow, FromColumn, ToRow, ToColumn]
                        indicatorHeaderCol++;
                    }

                }

                #region Styles And Authors
                worksheet.Column(2).AutoFit(); //Districts Column
                //Add some formatting to the sheets
                using (var range = worksheet.Cells[2, 1, 3, 100])
                {
                    range.Style.Fill.PatternType = ExcelFillStyle.Solid;
                    range.Style.Fill.BackgroundColor.SetColor(Color.LightGray);
                    range.Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                    range.Style.Font.Bold = true;
                    range.Style.Border.Bottom.Style = ExcelBorderStyle.Thin;
                    range.Style.Border.Top.Style = ExcelBorderStyle.Thin;
                    range.Style.Border.Left.Style = ExcelBorderStyle.Thin;
                    range.Style.Border.Right.Style = ExcelBorderStyle.Thin;
                    range.Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                    range.Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                }

                // Set some document properties
                package.Workbook.Properties.Title = "District Wise Progress Report";
                package.Workbook.Properties.Author = "Webmasters @ RSPN";
                package.Workbook.Properties.Company = "RSPN";

                #endregion

                // save our new workbook and we are done!
                package.Save();

            }

            return File(outputDir + fileName, "application/vnd.ms-excel", fileName);
            //return View();
        }

    }
}