using OfficeOpenXml;
using RSPNMISv2.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RSPNMISv2.Controllers
{
    public class HomeController : Controller
    {

        public ActionResult Index()
        {
            //using (ApplicationDbContext db = new ApplicationDbContext())
            //{
            //    PartnerOrganization o = new PartnerOrganization();
            //    o.Title = "ABC";
            //    o.ID = 505;
            //    o.YearFounded = 2007;
            //    o.Description = "Some DES";
            //    o.ColorCode = "#009900";
            //    o.Abbr = "ABC";

            //    db.PartnerOrganizations.Add(o);
            //    db.SaveChanges();
            //}
            return View();
        }
        [HttpPost]
        public ActionResult Index(HttpPostedFileBase rspFile)
        {
            // store the file inside ~/App_Data/uploads folder
            string fileName = Path.GetFileName(rspFile.FileName);


            var path = Path.Combine(Server.MapPath("~/App_Data/uploads"), fileName);
            rspFile.SaveAs(path);
            //end store file

            //reading file
            var existingFile = new FileInfo(path);
            // Open and read the XlSX file.
            using (var package = new ExcelPackage(existingFile))
            {
                ApplicationDbContext db = new ApplicationDbContext();

                RSPOutreach o = new RSPOutreach();
                o.CreatedBy = "Abdullah";
                o.DateCreated = DateTime.Today;
                o.DateModified = DateTime.Today;
                o.ModifiedBy = "Abdullah";
                o.UC_Id = 1;
            

                o.ReportingDate = DateTime.Today;

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
                                if (workSheet.Cells[row, 3].Text != "")
                                {
                                    string indicatorName = workSheet.Cells[row, 1].Text;
                                    string subIndicatorName = workSheet.Cells[row, 2].Text;
                                    //Get Indicator Id
                                    IQueryable<Indicator> Indicators = db.Indicators.Where(x => (x.IndicatorName == indicatorName) && (x.SubIndicatorName == subIndicatorName));                          
                                    Indicator[] IndicatorsArray = Indicators.ToArray();
                                    o.IndicatorID = IndicatorsArray[0].ID;
                                    //Get District Id
                                    string districtName = workSheet.Cells[row, 4].Text;
                                    IQueryable<District> Districts = db.Districts.Where(x => x.District_Name == districtName);
                                    District[] DistrictsArray = Districts.ToArray();
                                    o.Dist_Id = DistrictsArray[0].Dist_Id;
                                    o.Value = Decimal.Parse(workSheet.Cells[row, 3].Text);
                                }
                                else
                                {
                                    o.Value = 0;
                                }
                                db.RSPOutreachs.Add(o);
                                db.SaveChanges();
                            }

                        }
                    }
                }
            }





            return View();
        }
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }


    }
}