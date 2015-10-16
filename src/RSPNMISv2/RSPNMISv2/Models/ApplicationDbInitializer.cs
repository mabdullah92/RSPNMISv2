using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace RSPNMISv2.Models
{
    public class ApplicationDbInitializer : CreateDatabaseIfNotExists<ApplicationDbContext>
    {
        protected override void Seed(ApplicationDbContext context)
        {
            IList<Indicator> defaultIndicators = new List<Indicator>();

            defaultIndicators.Add(new Indicator() { ID=1, IndicatorName="Total rural and peri-urban UCs in the District",  SubIndicatorName=String.Empty, IsActive=true, OrderIndex=1000, CreatedBy="Admin", DateCreated=DateTime.Now, DateModified=DateTime.Now, ModifiedBy="Admin"  });
            defaultIndicators.Add(new Indicator() { ID = 2, IndicatorName = "# of rural union councils with RSP presence*", SubIndicatorName = String.Empty, IsActive = true, OrderIndex = 1000, CreatedBy = "Admin", DateCreated = DateTime.Now, DateModified = DateTime.Now, ModifiedBy = "Admin" });
            defaultIndicators.Add(new Indicator() { ID = 3, IndicatorName = "Total Number of Villages", SubIndicatorName = String.Empty, IsActive = true, OrderIndex = 1000, CreatedBy = "Admin", DateCreated = DateTime.Now, DateModified = DateTime.Now, ModifiedBy = "Admin" });
            defaultIndicators.Add(new Indicator() { ID = 4, IndicatorName = "# of villages with RSPs presence", SubIndicatorName = String.Empty, IsActive = true, OrderIndex = 1000, CreatedBy = "Admin", DateCreated = DateTime.Now, DateModified = DateTime.Now, ModifiedBy = "Admin" });
            defaultIndicators.Add(new Indicator() { ID = 5, IndicatorName = "Total rural Households in District (1998 census)", SubIndicatorName = String.Empty, IsActive = true, OrderIndex = 1000, CreatedBy = "Admin", DateCreated = DateTime.Now, DateModified = DateTime.Now, ModifiedBy = "Admin" });
            defaultIndicators.Add(new Indicator() { ID = 6, IndicatorName = "# of organised households", SubIndicatorName = String.Empty, IsActive = true, OrderIndex = 1000, CreatedBy = "Admin", DateCreated = DateTime.Now, DateModified = DateTime.Now, ModifiedBy = "Admin" });
            defaultIndicators.Add(new Indicator() { ID = 7, IndicatorName = "# of Local Support Organisations (LSOs)", SubIndicatorName = String.Empty, IsActive = true, OrderIndex = 1000, CreatedBy = "Admin", DateCreated = DateTime.Now, DateModified = DateTime.Now, ModifiedBy = "Admin" });
            defaultIndicators.Add(new Indicator() { ID = 8, IndicatorName = "# of Community Organisations (COs) formed", SubIndicatorName = "Women COs", IsActive = true, OrderIndex = 1000, CreatedBy = "Admin", DateCreated = DateTime.Now, DateModified = DateTime.Now, ModifiedBy = "Admin" });
            defaultIndicators.Add(new Indicator() { ID = 9, IndicatorName = "# of Community Organisations (COs) formed", SubIndicatorName = "Men COs", IsActive = true, OrderIndex = 1000, CreatedBy = "Admin", DateCreated = DateTime.Now, DateModified = DateTime.Now, ModifiedBy = "Admin" });
            defaultIndicators.Add(new Indicator() { ID = 10, IndicatorName = "# of Community Organisations (COs) formed", SubIndicatorName = "Mix COs", IsActive = true, OrderIndex = 1000, CreatedBy = "Admin", DateCreated = DateTime.Now, DateModified = DateTime.Now, ModifiedBy = "Admin" });
            defaultIndicators.Add(new Indicator() { ID = 11, IndicatorName = "# of CO members", SubIndicatorName = "Women", IsActive = true, OrderIndex = 1000, CreatedBy = "Admin", DateCreated = DateTime.Now, DateModified = DateTime.Now, ModifiedBy = "Admin" });
            defaultIndicators.Add(new Indicator() { ID = 12, IndicatorName = "# of CO members", SubIndicatorName = "Men", IsActive = true, OrderIndex = 1000, CreatedBy = "Admin", DateCreated = DateTime.Now, DateModified = DateTime.Now, ModifiedBy = "Admin" });
            defaultIndicators.Add(new Indicator() { ID = 13, IndicatorName = "Amount of savings of COs (Rs. Million)", SubIndicatorName = "Women", IsActive = true, OrderIndex = 1000, CreatedBy = "Admin", DateCreated = DateTime.Now, DateModified = DateTime.Now, ModifiedBy = "Admin" });
            defaultIndicators.Add(new Indicator() { ID = 14, IndicatorName = "Amount of savings of COs (Rs. Million)", SubIndicatorName = "Men", IsActive = true, OrderIndex = 1000, CreatedBy = "Admin", DateCreated = DateTime.Now, DateModified = DateTime.Now, ModifiedBy = "Admin" });
            defaultIndicators.Add(new Indicator() { ID = 15, IndicatorName = "# of community members trained", SubIndicatorName = "Women", IsActive = true, OrderIndex = 1000, CreatedBy = "Admin", DateCreated = DateTime.Now, DateModified = DateTime.Now, ModifiedBy = "Admin" });
            defaultIndicators.Add(new Indicator() { ID = 16, IndicatorName = "# of community members trained", SubIndicatorName = "Men", IsActive = true, OrderIndex = 1000, CreatedBy = "Admin", DateCreated = DateTime.Now, DateModified = DateTime.Now, ModifiedBy = "Admin" });
            defaultIndicators.Add(new Indicator() { ID = 17, IndicatorName = "Community Investment Fund (CIF)", SubIndicatorName = "# of LSOs managing CIF", IsActive = true, OrderIndex = 1000, CreatedBy = "Admin", DateCreated = DateTime.Now, DateModified = DateTime.Now, ModifiedBy = "Admin" });
            defaultIndicators.Add(new Indicator() { ID = 18, IndicatorName = "Community Investment Fund (CIF)", SubIndicatorName = "# of VOs managing CIF", IsActive = true, OrderIndex = 1000, CreatedBy = "Admin", DateCreated = DateTime.Now, DateModified = DateTime.Now, ModifiedBy = "Admin" });
            defaultIndicators.Add(new Indicator() { ID = 19, IndicatorName = "Community Investment Fund (CIF)", SubIndicatorName = "# of CIF borrowers", IsActive = true, OrderIndex = 1000, CreatedBy = "Admin", DateCreated = DateTime.Now, DateModified = DateTime.Now, ModifiedBy = "Admin" });
            defaultIndicators.Add(new Indicator() { ID = 20, IndicatorName = "Community Investment Fund (CIF)", SubIndicatorName = "Total amount of CIF disbursed (Rs. million)", IsActive = true, OrderIndex = 1000, CreatedBy = "Admin", DateCreated = DateTime.Now, DateModified = DateTime.Now, ModifiedBy = "Admin" });
            defaultIndicators.Add(new Indicator() { ID = 21, IndicatorName = "Amount of micro-credit disbursement (Rs. Million)", SubIndicatorName = "Women", IsActive = true, OrderIndex = 1000, CreatedBy = "Admin", DateCreated = DateTime.Now, DateModified = DateTime.Now, ModifiedBy = "Admin" });
            defaultIndicators.Add(new Indicator() { ID = 22, IndicatorName = "Amount of micro-credit disbursement (Rs. Million)", SubIndicatorName = "Men", IsActive = true, OrderIndex = 1000, CreatedBy = "Admin", DateCreated = DateTime.Now, DateModified = DateTime.Now, ModifiedBy = "Admin" });
            defaultIndicators.Add(new Indicator() { ID = 23, IndicatorName = "# of loans", SubIndicatorName = "Women", IsActive = true, OrderIndex = 1000, CreatedBy = "Admin", DateCreated = DateTime.Now, DateModified = DateTime.Now, ModifiedBy = "Admin" });
            defaultIndicators.Add(new Indicator() { ID = 24, IndicatorName = "# of loans", SubIndicatorName = "Men", IsActive = true, OrderIndex = 1000, CreatedBy = "Admin", DateCreated = DateTime.Now, DateModified = DateTime.Now, ModifiedBy = "Admin" });

            foreach (Indicator s in defaultIndicators)
            {
                context.Indicators.Add(s);
            }
            base.Seed(context);
        }
    }


}