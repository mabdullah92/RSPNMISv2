namespace RSPNMISv2.Migrations
{
    using RSPNMISv2.Models;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<RSPNMISv2.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(RSPNMISv2.Models.ApplicationDbContext context)
        {
         
            //IList<Province> defaultProvinces = new List<Province>();
            //defaultProvinces.Add(new Province() { Country = "Pakistan", Prov_Id = 1, PROVINCE = "Baluchistan" });
            //defaultProvinces.Add(new Province() { Country = "Pakistan", Prov_Id = 2, PROVINCE = "Sindh" });
            //defaultProvinces.Add(new Province() { Country = "Pakistan", Prov_Id = 3, PROVINCE = "Gilgit Baltistan" });
            //defaultProvinces.Add(new Province() { Country = "Pakistan", Prov_Id = 4, PROVINCE = "KPK" });
            //defaultProvinces.Add(new Province() { Country = "Pakistan", Prov_Id = 5, PROVINCE = "Punjab" });
            //defaultProvinces.Add(new Province() { Country = "Pakistan", Prov_Id = 6, PROVINCE = "AJK" });

            //foreach (Province p in defaultProvinces)
            //{
            //    context.Provinces.Add(p);
            //}

            //IList<Indicator> defaultIndicators = new List<Indicator>();

            //defaultIndicators.Add(new Indicator() { ID = 1, IndicatorName = "Total rural and peri-urban UCs in the District",IsCumulative=true, SubIndicatorName = String.Empty, IsActive = true, OrderIndex = 1000, CreatedBy = "Admin", DateCreated = DateTime.Now, DateModified = DateTime.Now, ModifiedBy = "Admin" });
            //defaultIndicators.Add(new Indicator() { ID = 2, IndicatorName = "# of rural union councils with RSP presence*", showVarianceInReports = true, IsCumulative = true, SubIndicatorName = String.Empty, IsActive = true, OrderIndex = 1000, CreatedBy = "Admin", DateCreated = DateTime.Now, DateModified = DateTime.Now, ModifiedBy = "Admin" });
            //defaultIndicators.Add(new Indicator() { ID = 3, IndicatorName = "Total Number of Villages", IsCumulative = true, SubIndicatorName = String.Empty, IsActive = true, OrderIndex = 1000, CreatedBy = "Admin", DateCreated = DateTime.Now, DateModified = DateTime.Now, ModifiedBy = "Admin" });
            //defaultIndicators.Add(new Indicator() { ID = 4, IndicatorName = "# of villages with RSPs presence", IsCumulative = true, SubIndicatorName = String.Empty, IsActive = true, OrderIndex = 1000, CreatedBy = "Admin", DateCreated = DateTime.Now, DateModified = DateTime.Now, ModifiedBy = "Admin" });
            //defaultIndicators.Add(new Indicator() { ID = 5, IndicatorName = "Total rural Households in District (1998 census)", IsCumulative = true, SubIndicatorName = String.Empty, IsActive = true, OrderIndex = 1000, CreatedBy = "Admin", DateCreated = DateTime.Now, DateModified = DateTime.Now, ModifiedBy = "Admin" });
            //defaultIndicators.Add(new Indicator() { ID = 6, IndicatorName = "# of Organized households", showVarianceInReports = true, IsCumulative = true, SubIndicatorName = String.Empty, IsActive = true, OrderIndex = 1000, CreatedBy = "Admin", DateCreated = DateTime.Now, DateModified = DateTime.Now, ModifiedBy = "Admin" });
            //defaultIndicators.Add(new Indicator() { ID = 7, IndicatorName = "# of Local Support Organizations (LSOs)", IsCumulative = true, SubIndicatorName = String.Empty, IsActive = true, OrderIndex = 1000, CreatedBy = "Admin", DateCreated = DateTime.Now, DateModified = DateTime.Now, ModifiedBy = "Admin" });
            //defaultIndicators.Add(new Indicator() { ID = 8, IndicatorName = "# of Community Organizations (COs) formed", showVarianceInReports = true, IsCumulative = true, SubIndicatorName = "Women COs", IsActive = true, OrderIndex = 1000, CreatedBy = "Admin", DateCreated = DateTime.Now, DateModified = DateTime.Now, ModifiedBy = "Admin" });
            //defaultIndicators.Add(new Indicator() { ID = 9, IndicatorName = "# of Community Organizations (COs) formed", showVarianceInReports = true, IsCumulative = true, SubIndicatorName = "Men COs", IsActive = true, OrderIndex = 1000, CreatedBy = "Admin", DateCreated = DateTime.Now, DateModified = DateTime.Now, ModifiedBy = "Admin" });
            //defaultIndicators.Add(new Indicator() { ID = 10, IndicatorName = "# of Community Organizations (COs) formed", showVarianceInReports = true, IsCumulative = true, SubIndicatorName = "Mix COs", IsActive = true, OrderIndex = 1000, CreatedBy = "Admin", DateCreated = DateTime.Now, DateModified = DateTime.Now, ModifiedBy = "Admin" });
            //defaultIndicators.Add(new Indicator() { ID = 11, IndicatorName = "# of CO members", SubIndicatorName = "Women", IsCumulative = true, IsActive = true, OrderIndex = 1000, CreatedBy = "Admin", DateCreated = DateTime.Now, DateModified = DateTime.Now, ModifiedBy = "Admin" });
            //defaultIndicators.Add(new Indicator() { ID = 12, IndicatorName = "# of CO members", SubIndicatorName = "Men", IsCumulative = true, IsActive = true, OrderIndex = 1000, CreatedBy = "Admin", DateCreated = DateTime.Now, DateModified = DateTime.Now, ModifiedBy = "Admin" });
            //defaultIndicators.Add(new Indicator() { ID = 13, IndicatorName = "Amount of savings of COs (Rs. Million)", SubIndicatorName = "Women", IsActive = true, OrderIndex = 1000, CreatedBy = "Admin", DateCreated = DateTime.Now, DateModified = DateTime.Now, ModifiedBy = "Admin" });
            //defaultIndicators.Add(new Indicator() { ID = 14, IndicatorName = "Amount of savings of COs (Rs. Million)", SubIndicatorName = "Men", IsActive = true, OrderIndex = 1000, CreatedBy = "Admin", DateCreated = DateTime.Now, DateModified = DateTime.Now, ModifiedBy = "Admin" });
            //defaultIndicators.Add(new Indicator() { ID = 15, IndicatorName = "# of community members trained", SubIndicatorName = "Women", IsActive = true, OrderIndex = 1000, CreatedBy = "Admin", DateCreated = DateTime.Now, DateModified = DateTime.Now, ModifiedBy = "Admin" });
            //defaultIndicators.Add(new Indicator() { ID = 16, IndicatorName = "# of community members trained", SubIndicatorName = "Men", IsActive = true, OrderIndex = 1000, CreatedBy = "Admin", DateCreated = DateTime.Now, DateModified = DateTime.Now, ModifiedBy = "Admin" });
            //defaultIndicators.Add(new Indicator() { ID = 17, IndicatorName = "Community Investment Fund (CIF)", SubIndicatorName = "# of LSOs managing CIF", IsActive = true, OrderIndex = 1000, CreatedBy = "Admin", DateCreated = DateTime.Now, DateModified = DateTime.Now, ModifiedBy = "Admin" });
            //defaultIndicators.Add(new Indicator() { ID = 18, IndicatorName = "Community Investment Fund (CIF)", SubIndicatorName = "# of VOs managing CIF", IsActive = true, OrderIndex = 1000, CreatedBy = "Admin", DateCreated = DateTime.Now, DateModified = DateTime.Now, ModifiedBy = "Admin" });
            //defaultIndicators.Add(new Indicator() { ID = 19, IndicatorName = "Community Investment Fund (CIF)", SubIndicatorName = "# of CIF borrowers", IsActive = true, OrderIndex = 1000, CreatedBy = "Admin", DateCreated = DateTime.Now, DateModified = DateTime.Now, ModifiedBy = "Admin" });
            //defaultIndicators.Add(new Indicator() { ID = 20, IndicatorName = "Community Investment Fund (CIF)", SubIndicatorName = "Total amount of CIF disbursed (Rs. million)", IsActive = true, OrderIndex = 1000, CreatedBy = "Admin", DateCreated = DateTime.Now, DateModified = DateTime.Now, ModifiedBy = "Admin" });
            //defaultIndicators.Add(new Indicator() { ID = 21, IndicatorName = "Amount of micro-credit disbursement (Rs. Million)", SubIndicatorName = "Women", IsActive = true, OrderIndex = 1000, CreatedBy = "Admin", DateCreated = DateTime.Now, DateModified = DateTime.Now, ModifiedBy = "Admin" });
            //defaultIndicators.Add(new Indicator() { ID = 22, IndicatorName = "Amount of micro-credit disbursement (Rs. Million)", SubIndicatorName = "Men", IsActive = true, OrderIndex = 1000, CreatedBy = "Admin", DateCreated = DateTime.Now, DateModified = DateTime.Now, ModifiedBy = "Admin" });
            //defaultIndicators.Add(new Indicator() { ID = 23, IndicatorName = "# of loans", SubIndicatorName = "Women", IsActive = true, OrderIndex = 1000, CreatedBy = "Admin", DateCreated = DateTime.Now, DateModified = DateTime.Now, ModifiedBy = "Admin" });
            //defaultIndicators.Add(new Indicator() { ID = 24, IndicatorName = "# of loans", SubIndicatorName = "Men", IsActive = true, OrderIndex = 1000, CreatedBy = "Admin", DateCreated = DateTime.Now, DateModified = DateTime.Now, ModifiedBy = "Admin" });
            //defaultIndicators.Add(new Indicator() { ID = 24, IndicatorName = "# of health micro insurance schemes", SubIndicatorName = "Women", IsActive = true, OrderIndex = 1000, CreatedBy = "Admin", DateCreated = DateTime.Now, DateModified = DateTime.Now, ModifiedBy = "Admin" });
            //defaultIndicators.Add(new Indicator() { ID = 25, IndicatorName = "# of health micro insurance schemes", SubIndicatorName = "Men", IsActive = true, OrderIndex = 1000, CreatedBy = "Admin", DateCreated = DateTime.Now, DateModified = DateTime.Now, ModifiedBy = "Admin" });
            //defaultIndicators.Add(new Indicator() { ID = 26, IndicatorName = "# of population insured", SubIndicatorName = "Women", IsActive = true, OrderIndex = 1000, CreatedBy = "Admin", DateCreated = DateTime.Now, DateModified = DateTime.Now, ModifiedBy = "Admin" });
            //defaultIndicators.Add(new Indicator() { ID = 27, IndicatorName = "# of population insured", SubIndicatorName = "Men", IsActive = true, OrderIndex = 1000, CreatedBy = "Admin", DateCreated = DateTime.Now, DateModified = DateTime.Now, ModifiedBy = "Admin" });
            //defaultIndicators.Add(new Indicator() { ID = 28, IndicatorName = "# of PPI/CPI schemes completed", SubIndicatorName = "", IsActive = true, OrderIndex = 1000, CreatedBy = "Admin", DateCreated = DateTime.Now, DateModified = DateTime.Now, ModifiedBy = "Admin" });
            //defaultIndicators.Add(new Indicator() { ID = 29, IndicatorName = "# of beneficiary households of completed CPIs", SubIndicatorName = "", IsActive = true, OrderIndex = 1000, CreatedBy = "Admin", DateCreated = DateTime.Now, DateModified = DateTime.Now, ModifiedBy = "Admin" });
            //defaultIndicators.Add(new Indicator() { ID = 30, IndicatorName = "Total cost of completed CPIs (Rs. Million)", SubIndicatorName = "", IsActive = true, OrderIndex = 1000, CreatedBy = "Admin", DateCreated = DateTime.Now, DateModified = DateTime.Now, ModifiedBy = "Admin" });
            //defaultIndicators.Add(new Indicator() { ID = 31, IndicatorName = "# of community schools established", SubIndicatorName = "", IsActive = true, OrderIndex = 1000, CreatedBy = "Admin", DateCreated = DateTime.Now, DateModified = DateTime.Now, ModifiedBy = "Admin" });
            //defaultIndicators.Add(new Indicator() { ID = 32, IndicatorName = "# of students enrolled", SubIndicatorName = "Girls", IsActive = true, OrderIndex = 1000, CreatedBy = "Admin", DateCreated = DateTime.Now, DateModified = DateTime.Now, ModifiedBy = "Admin" });
            //defaultIndicators.Add(new Indicator() { ID = 33, IndicatorName = "# of students enrolled", SubIndicatorName = "Boys", IsActive = true, OrderIndex = 1000, CreatedBy = "Admin", DateCreated = DateTime.Now, DateModified = DateTime.Now, ModifiedBy = "Admin" });
            //defaultIndicators.Add(new Indicator() { ID = 34, IndicatorName = "# of adults literated or graduated", SubIndicatorName = "Women", IsActive = true, OrderIndex = 1000, CreatedBy = "Admin", DateCreated = DateTime.Now, DateModified = DateTime.Now, ModifiedBy = "Admin" });
            //defaultIndicators.Add(new Indicator() { ID = 35, IndicatorName = "# of adults literated or graduated", SubIndicatorName = "Men", IsActive = true, OrderIndex = 1000, CreatedBy = "Admin", DateCreated = DateTime.Now, DateModified = DateTime.Now, ModifiedBy = "Admin" });
            //defaultIndicators.Add(new Indicator() { ID = 36, IndicatorName = "# of traditional birth attendants / health workers trained", SubIndicatorName = "Women", IsActive = true, OrderIndex = 1000, CreatedBy = "Admin", DateCreated = DateTime.Now, DateModified = DateTime.Now, ModifiedBy = "Admin" });
            //defaultIndicators.Add(new Indicator() { ID = 37, IndicatorName = "# of traditional birth attendants / health workers trained", SubIndicatorName = "Men", IsActive = true, OrderIndex = 1000, CreatedBy = "Admin", DateCreated = DateTime.Now, DateModified = DateTime.Now, ModifiedBy = "Admin" });

            //foreach (Indicator s in defaultIndicators)
            //{
            //    context.Indicators.Add(s);
            //}

            //IList<District> defaultDistricts = new List<District>();
            //defaultDistricts.Add(new District() { Country = "Pakistan", Dist_Id = 1, District_Name = "WASHUK", Prov_Id = 1, PROVINCE = "Baluchistan" });
            //defaultDistricts.Add(new District() { Country = "Pakistan", Dist_Id = 1, District_Name = "AWARAN", Prov_Id = 1, PROVINCE = "Baluchistan" });
            //defaultDistricts.Add(new District() { Country = "Pakistan", Dist_Id = 1, District_Name = "KACHHI", Prov_Id = 1, PROVINCE = "Baluchistan" });
            //defaultDistricts.Add(new District() { Country = "Pakistan", Dist_Id = 1, District_Name = "MASTUNG", Prov_Id = 1, PROVINCE = "Baluchistan" });
            //defaultDistricts.Add(new District() { Country = "Pakistan", Dist_Id = 1, District_Name = "DERA BUGTI", Prov_Id = 1, PROVINCE = "Baluchistan" });
            //defaultDistricts.Add(new District() { Country = "Pakistan", Dist_Id = 1, District_Name = "LORALAI", Prov_Id = 1, PROVINCE = "Baluchistan" });
            //defaultDistricts.Add(new District() { Country = "Pakistan", Dist_Id = 1, District_Name = "ZHOB", Prov_Id = 1, PROVINCE = "Baluchistan" });
            //defaultDistricts.Add(new District() { Country = "Pakistan", Dist_Id = 1, District_Name = "BOLAN", Prov_Id = 1, PROVINCE = "Baluchistan" });
            //defaultDistricts.Add(new District() { Country = "Pakistan", Dist_Id = 1, District_Name = "PANJGUR", Prov_Id = 1, PROVINCE = "Baluchistan" });
            //defaultDistricts.Add(new District() { Country = "Pakistan", Dist_Id = 1, District_Name = "JHAL MAGSI", Prov_Id = 1, PROVINCE = "Baluchistan" });
            //defaultDistricts.Add(new District() { Country = "Pakistan", Dist_Id = 1, District_Name = "KHARAN", Prov_Id = 1, PROVINCE = "Baluchistan" });
            //defaultDistricts.Add(new District() { Country = "Pakistan", Dist_Id = 1, District_Name = "HARNAI", Prov_Id = 1, PROVINCE = "Baluchistan" });
            //defaultDistricts.Add(new District() { Country = "Pakistan", Dist_Id = 1, District_Name = "JAFFARABAD", Prov_Id = 1, PROVINCE = "Baluchistan" });
            //defaultDistricts.Add(new District() { Country = "Pakistan", Dist_Id = 1, District_Name = "QUETTA", Prov_Id = 1, PROVINCE = "Baluchistan" });
            //defaultDistricts.Add(new District() { Country = "Pakistan", Dist_Id = 1, District_Name = "SIBBI", Prov_Id = 1, PROVINCE = "Baluchistan" });
            //defaultDistricts.Add(new District() { Country = "Pakistan", Dist_Id = 1, District_Name = "NASIRABAD", Prov_Id = 1, PROVINCE = "Baluchistan" });
            //defaultDistricts.Add(new District() { Country = "Pakistan", Dist_Id = 1, District_Name = "KILLA SAIFULLAH", Prov_Id = 1, PROVINCE = "Baluchistan" });
            //defaultDistricts.Add(new District() { Country = "Pakistan", Dist_Id = 1, District_Name = "LASBELA", Prov_Id = 1, PROVINCE = "Baluchistan" });
            //defaultDistricts.Add(new District() { Country = "Pakistan", Dist_Id = 1, District_Name = "SHEERANI", Prov_Id = 1, PROVINCE = "Baluchistan" });
            //defaultDistricts.Add(new District() { Country = "Pakistan", Dist_Id = 1, District_Name = "KHUZDAR", Prov_Id = 1, PROVINCE = "Baluchistan" });
            //defaultDistricts.Add(new District() { Country = "Pakistan", Dist_Id = 1, District_Name = "KECH", Prov_Id = 1, PROVINCE = "Baluchistan" });
            //defaultDistricts.Add(new District() { Country = "Pakistan", Dist_Id = 1, District_Name = "KILLA ABDULLAH", Prov_Id = 1, PROVINCE = "Baluchistan" });
            //defaultDistricts.Add(new District() { Country = "Pakistan", Dist_Id = 1, District_Name = "PISHIN", Prov_Id = 1, PROVINCE = "Baluchistan" });
            //defaultDistricts.Add(new District() { Country = "Pakistan", Dist_Id = 1, District_Name = "MUSAKHEL", Prov_Id = 1, PROVINCE = "Baluchistan" });
            //defaultDistricts.Add(new District() { Country = "Pakistan", Dist_Id = 1, District_Name = "NUSHKI", Prov_Id = 1, PROVINCE = "Baluchistan" });
            //defaultDistricts.Add(new District() { Country = "Pakistan", Dist_Id = 1, District_Name = "ZIARAT", Prov_Id = 1, PROVINCE = "Baluchistan" });
            //defaultDistricts.Add(new District() { Country = "Pakistan", Dist_Id = 1, District_Name = "KALAT", Prov_Id = 1, PROVINCE = "Baluchistan" });
            //defaultDistricts.Add(new District() { Country = "Pakistan", Dist_Id = 1, District_Name = "KOHLU", Prov_Id = 1, PROVINCE = "Baluchistan" });
            //defaultDistricts.Add(new District() { Country = "Pakistan", Dist_Id = 1, District_Name = "CHAGHI", Prov_Id = 1, PROVINCE = "Baluchistan" });
            //defaultDistricts.Add(new District() { Country = "Pakistan", Dist_Id = 1, District_Name = "BARKHAN", Prov_Id = 1, PROVINCE = "Baluchistan" });
            //defaultDistricts.Add(new District() { Country = "Pakistan", Dist_Id = 1, District_Name = "GWADAR", Prov_Id = 1, PROVINCE = "Baluchistan" });
            //defaultDistricts.Add(new District() { Country = "Pakistan", Dist_Id = 1, District_Name = "SHIKARPUR", Prov_Id = 2, PROVINCE = "Sindh" });
            //defaultDistricts.Add(new District() { Country = "Pakistan", Dist_Id = 1, District_Name = "MIRPUR KHAS", Prov_Id = 2, PROVINCE = "Sindh" });
            //defaultDistricts.Add(new District() { Country = "Pakistan", Dist_Id = 1, District_Name = "TANDO ALLAHYAR", Prov_Id = 2, PROVINCE = "Sindh" });
            //defaultDistricts.Add(new District() { Country = "Pakistan", Dist_Id = 1, District_Name = "THARPARKAR", Prov_Id = 2, PROVINCE = "Sindh" });
            //defaultDistricts.Add(new District() { Country = "Pakistan", Dist_Id = 1, District_Name = "SANGHAR", Prov_Id = 2, PROVINCE = "Sindh" });
            //defaultDistricts.Add(new District() { Country = "Pakistan", Dist_Id = 1, District_Name = "NAWAB SHAH", Prov_Id = 2, PROVINCE = "Sindh" });
            //defaultDistricts.Add(new District() { Country = "Pakistan", Dist_Id = 1, District_Name = "BADIN", Prov_Id = 2, PROVINCE = "Sindh" });
            //defaultDistricts.Add(new District() { Country = "Pakistan", Dist_Id = 1, District_Name = "UMER KOT", Prov_Id = 2, PROVINCE = "Sindh" });
            //defaultDistricts.Add(new District() { Country = "Pakistan", Dist_Id = 1, District_Name = "KARACHI", Prov_Id = 2, PROVINCE = "Sindh" });
            //defaultDistricts.Add(new District() { Country = "Pakistan", Dist_Id = 1, District_Name = "DADU", Prov_Id = 2, PROVINCE = "Sindh" });
            //defaultDistricts.Add(new District() { Country = "Pakistan", Dist_Id = 1, District_Name = "NAUSHAHRO FEROZE", Prov_Id = 2, PROVINCE = "Sindh" });
            //defaultDistricts.Add(new District() { Country = "Pakistan", Dist_Id = 1, District_Name = "TANDO MUHAMMAD KHAN", Prov_Id = 2, PROVINCE = "Sindh" });
            //defaultDistricts.Add(new District() { Country = "Pakistan", Dist_Id = 1, District_Name = "GHOTKI", Prov_Id = 2, PROVINCE = "Sindh" });
            //defaultDistricts.Add(new District() { Country = "Pakistan", Dist_Id = 1, District_Name = "JAMSHORO", Prov_Id = 2, PROVINCE = "Sindh" });
            //defaultDistricts.Add(new District() { Country = "Pakistan", Dist_Id = 1, District_Name = "KAMBER SHAHDADKOT", Prov_Id = 2, PROVINCE = "Sindh" });
            //defaultDistricts.Add(new District() { Country = "Pakistan", Dist_Id = 1, District_Name = "LARKANA", Prov_Id = 2, PROVINCE = "Sindh" });
            //defaultDistricts.Add(new District() { Country = "Pakistan", Dist_Id = 1, District_Name = "MATIARI", Prov_Id = 2, PROVINCE = "Sindh" });
            //defaultDistricts.Add(new District() { Country = "Pakistan", Dist_Id = 1, District_Name = "KASHMOR", Prov_Id = 2, PROVINCE = "Sindh" });
            //defaultDistricts.Add(new District() { Country = "Pakistan", Dist_Id = 1, District_Name = "THATTA", Prov_Id = 2, PROVINCE = "Sindh" });
            //defaultDistricts.Add(new District() { Country = "Pakistan", Dist_Id = 1, District_Name = "HYDERABAD", Prov_Id = 2, PROVINCE = "Sindh" });
            //defaultDistricts.Add(new District() { Country = "Pakistan", Dist_Id = 1, District_Name = "SUKKUR", Prov_Id = 2, PROVINCE = "Sindh" });
            //defaultDistricts.Add(new District() { Country = "Pakistan", Dist_Id = 1, District_Name = "JACOBABAD", Prov_Id = 2, PROVINCE = "Sindh" });
            //defaultDistricts.Add(new District() { Country = "Pakistan", Dist_Id = 1, District_Name = "KHAIRPUR", Prov_Id = 2, PROVINCE = "Sindh" });
            //defaultDistricts.Add(new District() { Country = "Pakistan", Dist_Id = 1, District_Name = "KHOLU", Prov_Id = 2, PROVINCE = "Sindh" });
            //defaultDistricts.Add(new District() { Country = "Pakistan", Dist_Id = 1, District_Name = "TANDO ALLAH YAR", Prov_Id = 2, PROVINCE = "Sindh" });
            //defaultDistricts.Add(new District() { Country = "Pakistan", Dist_Id = 1, District_Name = "GHANCHE", Prov_Id = 3, PROVINCE = "Gilgit Baltistan" });
            //defaultDistricts.Add(new District() { Country = "Pakistan", Dist_Id = 1, District_Name = "GILGIT", Prov_Id = 3, PROVINCE = "Gilgit Baltistan" });
            //defaultDistricts.Add(new District() { Country = "Pakistan", Dist_Id = 1, District_Name = "DIAMIR", Prov_Id = 3, PROVINCE = "Gilgit Baltistan" });
            //defaultDistricts.Add(new District() { Country = "Pakistan", Dist_Id = 1, District_Name = "BALTISTAN", Prov_Id = 3, PROVINCE = "Gilgit Baltistan" });
            //defaultDistricts.Add(new District() { Country = "Pakistan", Dist_Id = 1, District_Name = "GHIZER", Prov_Id = 3, PROVINCE = "Gilgit Baltistan" });
            //defaultDistricts.Add(new District() { Country = "Pakistan", Dist_Id = 1, District_Name = "HUNZA NAGAR", Prov_Id = 3, PROVINCE = "Gilgit Baltistan" });
            //defaultDistricts.Add(new District() { Country = "Pakistan", Dist_Id = 1, District_Name = "ASTORE", Prov_Id = 3, PROVINCE = "Gilgit Baltistan" });
            //defaultDistricts.Add(new District() { Country = "Pakistan", Dist_Id = 1, District_Name = "SKARDU", Prov_Id = 3, PROVINCE = "Gilgit Baltistan" });
            //defaultDistricts.Add(new District() { Country = "Pakistan", Dist_Id = 1, District_Name = "LAKKI MARWAT", Prov_Id = 4, PROVINCE = "KPK" });
            //defaultDistricts.Add(new District() { Country = "Pakistan", Dist_Id = 1, District_Name = "SWABI", Prov_Id = 4, PROVINCE = "KPK" });
            //defaultDistricts.Add(new District() { Country = "Pakistan", Dist_Id = 1, District_Name = "LOWER DIR", Prov_Id = 4, PROVINCE = "KPK" });
            //defaultDistricts.Add(new District() { Country = "Pakistan", Dist_Id = 1, District_Name = "BUNER", Prov_Id = 4, PROVINCE = "KPK" });
            //defaultDistricts.Add(new District() { Country = "Pakistan", Dist_Id = 1, District_Name = "TANK", Prov_Id = 4, PROVINCE = "KPK" });
            //defaultDistricts.Add(new District() { Country = "Pakistan", Dist_Id = 1, District_Name = "MALAKAND", Prov_Id = 4, PROVINCE = "KPK" });
            //defaultDistricts.Add(new District() { Country = "Pakistan", Dist_Id = 1, District_Name = "ABBOTTABAD", Prov_Id = 4, PROVINCE = "KPK" });
            //defaultDistricts.Add(new District() { Country = "Pakistan", Dist_Id = 1, District_Name = "SWAT", Prov_Id = 4, PROVINCE = "KPK" });
            //defaultDistricts.Add(new District() { Country = "Pakistan", Dist_Id = 1, District_Name = "SHANGLA", Prov_Id = 4, PROVINCE = "KPK" });
            //defaultDistricts.Add(new District() { Country = "Pakistan", Dist_Id = 1, District_Name = "CHARSADDA", Prov_Id = 4, PROVINCE = "KPK" });
            //defaultDistricts.Add(new District() { Country = "Pakistan", Dist_Id = 1, District_Name = "KARAK", Prov_Id = 4, PROVINCE = "KPK" });
            //defaultDistricts.Add(new District() { Country = "Pakistan", Dist_Id = 1, District_Name = "MARDAN", Prov_Id = 4, PROVINCE = "KPK" });
            //defaultDistricts.Add(new District() { Country = "Pakistan", Dist_Id = 1, District_Name = "KOHISTAN", Prov_Id = 4, PROVINCE = "KPK" });
            //defaultDistricts.Add(new District() { Country = "Pakistan", Dist_Id = 1, District_Name = "HANGU", Prov_Id = 4, PROVINCE = "KPK" });
            //defaultDistricts.Add(new District() { Country = "Pakistan", Dist_Id = 1, District_Name = "KOHAT", Prov_Id = 4, PROVINCE = "KPK" });
            //defaultDistricts.Add(new District() { Country = "Pakistan", Dist_Id = 1, District_Name = "HARIPUR", Prov_Id = 4, PROVINCE = "KPK" });
            //defaultDistricts.Add(new District() { Country = "Pakistan", Dist_Id = 1, District_Name = "BANNU", Prov_Id = 4, PROVINCE = "KPK" });
            //defaultDistricts.Add(new District() { Country = "Pakistan", Dist_Id = 1, District_Name = "CHITRAL", Prov_Id = 4, PROVINCE = "KPK" });
            //defaultDistricts.Add(new District() { Country = "Pakistan", Dist_Id = 1, District_Name = "D. I. KHAN", Prov_Id = 4, PROVINCE = "KPK" });
            //defaultDistricts.Add(new District() { Country = "Pakistan", Dist_Id = 1, District_Name = "MANSEHRA", Prov_Id = 4, PROVINCE = "KPK" });
            //defaultDistricts.Add(new District() { Country = "Pakistan", Dist_Id = 1, District_Name = "UPPER DIR", Prov_Id = 4, PROVINCE = "KPK" });
            //defaultDistricts.Add(new District() { Country = "Pakistan", Dist_Id = 1, District_Name = "BATAGRAM", Prov_Id = 4, PROVINCE = "KPK" });
            //defaultDistricts.Add(new District() { Country = "Pakistan", Dist_Id = 1, District_Name = "NOWSHERA", Prov_Id = 4, PROVINCE = "KPK" });
            //defaultDistricts.Add(new District() { Country = "Pakistan", Dist_Id = 1, District_Name = "PESHAWAR", Prov_Id = 4, PROVINCE = "KPK" });
            //defaultDistricts.Add(new District() { Country = "Pakistan", Dist_Id = 1, District_Name = "KURRUM AGENCY", Prov_Id = 5, PROVINCE = "FATA" });
            //defaultDistricts.Add(new District() { Country = "Pakistan", Dist_Id = 1, District_Name = "TRIBAL AREA ADJ KOHAT", Prov_Id = 5, PROVINCE = "FATA" });
            //defaultDistricts.Add(new District() { Country = "Pakistan", Dist_Id = 1, District_Name = "TRIBAL AREA ADJ PESHAWAR", Prov_Id = 5, PROVINCE = "FATA" });
            //defaultDistricts.Add(new District() { Country = "Pakistan", Dist_Id = 1, District_Name = "KHYBER AGENCY", Prov_Id = 5, PROVINCE = "FATA" });
            //defaultDistricts.Add(new District() { Country = "Pakistan", Dist_Id = 1, District_Name = "TRIBAL AREA ADJ D.I.KHAN", Prov_Id = 5, PROVINCE = "FATA" });
            //defaultDistricts.Add(new District() { Country = "Pakistan", Dist_Id = 1, District_Name = "ORAKZAI AGENCY", Prov_Id = 5, PROVINCE = "FATA" });

            //defaultDistricts.Add(new District() { Country = "Pakistan", Dist_Id = 1, District_Name = "BAJAUR AGENCY", Prov_Id = 5, PROVINCE = "FATA" });
            //defaultDistricts.Add(new District() { Country = "Pakistan", Dist_Id = 1, District_Name = "TRIBAL AREA ADJ BANNU", Prov_Id = 5, PROVINCE = "FATA" });
            //defaultDistricts.Add(new District() { Country = "Pakistan", Dist_Id = 1, District_Name = "SOUTH WAZIRISTAN AGENCY", Prov_Id = 5, PROVINCE = "FATA" });
            //defaultDistricts.Add(new District() { Country = "Pakistan", Dist_Id = 1, District_Name = "NORTH WAZIRISTAN AGENCY", Prov_Id = 5, PROVINCE = "FATA" });
            //defaultDistricts.Add(new District() { Country = "Pakistan", Dist_Id = 1, District_Name = "MOHMAND AGENCY", Prov_Id = 5, PROVINCE = "FATA" });
            //defaultDistricts.Add(new District() { Country = "Pakistan", Dist_Id = 1, District_Name = "TRIBAL AREA ADJ TANK", Prov_Id = 5, PROVINCE = "FATA" });
            //defaultDistricts.Add(new District() { Country = "Pakistan", Dist_Id = 1, District_Name = "ISLAMABAD", Prov_Id = 6, PROVINCE = "Islamabad" });
            //defaultDistricts.Add(new District() { Country = "Pakistan", Dist_Id = 1, District_Name = "MANDI BAHAUDDIN", Prov_Id = 7, PROVINCE = "Punjab" });
            //defaultDistricts.Add(new District() { Country = "Pakistan", Dist_Id = 1, District_Name = "FAISALABAD", Prov_Id = 7, PROVINCE = "Punjab" });
            //defaultDistricts.Add(new District() { Country = "Pakistan", Dist_Id = 1, District_Name = "RAHIM YAR KHAN", Prov_Id = 7, PROVINCE = "Punjab" });
            //defaultDistricts.Add(new District() { Country = "Pakistan", Dist_Id = 1, District_Name = "NANKANA SAHIB", Prov_Id = 7, PROVINCE = "Punjab" });
            //defaultDistricts.Add(new District() { Country = "Pakistan", Dist_Id = 1, District_Name = "SAHIWAL", Prov_Id = 7, PROVINCE = "Punjab" });
            //defaultDistricts.Add(new District() { Country = "Pakistan", Dist_Id = 1, District_Name = "JHELUM", Prov_Id = 7, PROVINCE = "Punjab" });
            //defaultDistricts.Add(new District() { Country = "Pakistan", Dist_Id = 1, District_Name = "BAHAWALNAGAR", Prov_Id = 7, PROVINCE = "Punjab" });
            //defaultDistricts.Add(new District() { Country = "Pakistan", Dist_Id = 1, District_Name = "SARGODHA", Prov_Id = 7, PROVINCE = "Punjab" });
            //defaultDistricts.Add(new District() { Country = "Pakistan", Dist_Id = 1, District_Name = "KHANEWAL", Prov_Id = 7, PROVINCE = "Punjab" });
            //defaultDistricts.Add(new District() { Country = "Pakistan", Dist_Id = 1, District_Name = "LAYYAH", Prov_Id = 7, PROVINCE = "Punjab" });
            //defaultDistricts.Add(new District() { Country = "Pakistan", Dist_Id = 1, District_Name = "OKARA", Prov_Id = 7, PROVINCE = "Punjab" });
            //defaultDistricts.Add(new District() { Country = "Pakistan", Dist_Id = 1, District_Name = "DERA GHAZI KHAN", Prov_Id = 7, PROVINCE = "Punjab" });
            //defaultDistricts.Add(new District() { Country = "Pakistan", Dist_Id = 1, District_Name = "JHANG", Prov_Id = 7, PROVINCE = "Punjab" });
            //defaultDistricts.Add(new District() { Country = "Pakistan", Dist_Id = 1, District_Name = "MULTAN", Prov_Id = 7, PROVINCE = "Punjab" });
            //defaultDistricts.Add(new District() { Country = "Pakistan", Dist_Id = 1, District_Name = "NAROWAL", Prov_Id = 7, PROVINCE = "Punjab" });
            //defaultDistricts.Add(new District() { Country = "Pakistan", Dist_Id = 1, District_Name = "ATTOCK", Prov_Id = 7, PROVINCE = "Punjab" });
            //defaultDistricts.Add(new District() { Country = "Pakistan", Dist_Id = 1, District_Name = "CHAKWAL", Prov_Id = 7, PROVINCE = "Punjab" });
            //defaultDistricts.Add(new District() { Country = "Pakistan", Dist_Id = 1, District_Name = "HAFIZABAD", Prov_Id = 7, PROVINCE = "Punjab" });
            //defaultDistricts.Add(new District() { Country = "Pakistan", Dist_Id = 1, District_Name = "VEHARI", Prov_Id = 7, PROVINCE = "Punjab" });
            //defaultDistricts.Add(new District() { Country = "Pakistan", Dist_Id = 1, District_Name = "GUJRANWALA", Prov_Id = 7, PROVINCE = "Punjab" });
            //defaultDistricts.Add(new District() { Country = "Pakistan", Dist_Id = 1, District_Name = "LAHORE", Prov_Id = 7, PROVINCE = "Punjab" });
            //defaultDistricts.Add(new District() { Country = "Pakistan", Dist_Id = 1, District_Name = "BHAKHAR", Prov_Id = 7, PROVINCE = "Punjab" });
            //defaultDistricts.Add(new District() { Country = "Pakistan", Dist_Id = 1, District_Name = "RAJANPUR", Prov_Id = 7, PROVINCE = "Punjab" });
            //defaultDistricts.Add(new District() { Country = "Pakistan", Dist_Id = 1, District_Name = "MUZAFFARGARH", Prov_Id = 7, PROVINCE = "Punjab" });
            //defaultDistricts.Add(new District() { Country = "Pakistan", Dist_Id = 1, District_Name = "MIANWALI", Prov_Id = 7, PROVINCE = "Punjab" });
            //defaultDistricts.Add(new District() { Country = "Pakistan", Dist_Id = 1, District_Name = "KHUSHAB", Prov_Id = 7, PROVINCE = "Punjab" });
            //defaultDistricts.Add(new District() { Country = "Pakistan", Dist_Id = 1, District_Name = "PAKPATTAN", Prov_Id = 7, PROVINCE = "Punjab" });
            //defaultDistricts.Add(new District() { Country = "Pakistan", Dist_Id = 1, District_Name = "SIALKOT", Prov_Id = 7, PROVINCE = "Punjab" });
            //defaultDistricts.Add(new District() { Country = "Pakistan", Dist_Id = 1, District_Name = "LODHRAN", Prov_Id = 7, PROVINCE = "Punjab" });
            //defaultDistricts.Add(new District() { Country = "Pakistan", Dist_Id = 1, District_Name = "GUJRAT", Prov_Id = 7, PROVINCE = "Punjab" });
            //defaultDistricts.Add(new District() { Country = "Pakistan", Dist_Id = 1, District_Name = "BAHAWALPUR", Prov_Id = 7, PROVINCE = "Punjab" });
            //defaultDistricts.Add(new District() { Country = "Pakistan", Dist_Id = 1, District_Name = "SHEIKHUPURA", Prov_Id = 7, PROVINCE = "Punjab" });
            //defaultDistricts.Add(new District() { Country = "Pakistan", Dist_Id = 1, District_Name = "TOBA TEK SINGH", Prov_Id = 7, PROVINCE = "Punjab" });
            //defaultDistricts.Add(new District() { Country = "Pakistan", Dist_Id = 1, District_Name = "CHINIOT", Prov_Id = 7, PROVINCE = "Punjab" });
            //defaultDistricts.Add(new District() { Country = "Pakistan", Dist_Id = 1, District_Name = "RAWALPINDI", Prov_Id = 7, PROVINCE = "Punjab" });
            //defaultDistricts.Add(new District() { Country = "Pakistan", Dist_Id = 1, District_Name = "KASUR", Prov_Id = 7, PROVINCE = "Punjab" });
            //defaultDistricts.Add(new District() { Country = "Pakistan", Dist_Id = 1, District_Name = "BAGH", Prov_Id = 8, PROVINCE = "AJK" });
            //defaultDistricts.Add(new District() { Country = "Pakistan", Dist_Id = 1, District_Name = "MIRPUR", Prov_Id = 8, PROVINCE = "AJK" });
            //defaultDistricts.Add(new District() { Country = "Pakistan", Dist_Id = 1, District_Name = "SUDHNOTI", Prov_Id = 8, PROVINCE = "AJK" });
            //defaultDistricts.Add(new District() { Country = "Pakistan", Dist_Id = 1, District_Name = "HATIAN", Prov_Id = 8, PROVINCE = "AJK" });
            //defaultDistricts.Add(new District() { Country = "Pakistan", Dist_Id = 1, District_Name = "MUZAFFARABAD", Prov_Id = 8, PROVINCE = "AJK" });
            //defaultDistricts.Add(new District() { Country = "Pakistan", Dist_Id = 1, District_Name = "HAVELI", Prov_Id = 8, PROVINCE = "AJK" });
            //defaultDistricts.Add(new District() { Country = "Pakistan", Dist_Id = 1, District_Name = "KOTLI", Prov_Id = 8, PROVINCE = "AJK" });
            //defaultDistricts.Add(new District() { Country = "Pakistan", Dist_Id = 1, District_Name = "POONCH", Prov_Id = 8, PROVINCE = "AJK" });
            //defaultDistricts.Add(new District() { Country = "Pakistan", Dist_Id = 1, District_Name = "NEELUM", Prov_Id = 8, PROVINCE = "AJK" });
            //defaultDistricts.Add(new District() { Country = "Pakistan", Dist_Id = 1, District_Name = "BHIMBER", Prov_Id = 8, PROVINCE = "AJK" });
            ////No change
            //foreach (District s in defaultDistricts)
            //{
            //    context.Districts.Add(s);
            //}

            //IList<UC> defaultUCs = new List<UC>();
            //defaultUCs.Add(new UC() { District = "LAKKI MARWAT", Teh_Id = 1, Thesil = "sample_Tehsile", UC_Id = 1, UC_Name = "sample_UC", Country = "Pakistan", Dist_Id = 1, Prov_Id = 1, PROVINCE = "KPK" });
            //defaultUCs.Add(new UC() { District = "LOWER DIR", Teh_Id = 1, Thesil = "sample_Tehsile", UC_Id = 1, UC_Name = "sample_UC", Country = "Pakistan", Dist_Id = 2, Prov_Id = 1, PROVINCE = "KPK" });
            //foreach (UC s in defaultUCs)
            //{
            //    context.UCs.Add(s);
            //}
            //IList<PartnerOrganization> defaultPartnerOrganizations = new List<PartnerOrganization>();
            //defaultPartnerOrganizations.Add(new PartnerOrganization() { Abbr = "AJKRSP", ColorCode = "#AFD814", Description = "Azad Jammu Kashmir Rural Support Programme", IsActive = true, OrderIndex = 1000, Title = "Azad Jammu Kashmir Rural Support Programme", YearFounded = 2000 });
            //defaultPartnerOrganizations.Add(new PartnerOrganization() { Abbr = "AKRSP", ColorCode = "#110990", Description = "Aga Khan Rural Support Programme", IsActive = true, OrderIndex = 1000, Title = "Aga Khan Rural Support Programme", YearFounded = 1982 });
            //defaultPartnerOrganizations.Add(new PartnerOrganization() { Abbr = "BRSP", ColorCode = "#BE78DA", Description = "Balochistan Rural Support Programme", IsActive = true, OrderIndex = 1000, Title = "Balochistan Rural Support Programme", YearFounded = 2001 });
            //defaultPartnerOrganizations.Add(new PartnerOrganization() { Abbr = "GBTI", ColorCode = "#110990", Description = "Ghazi Barotha Taraqiati Idara", IsActive = true, OrderIndex = 1000, Title = "Ghazi Barotha Taraqiati Idara", YearFounded = 1992 });

            //defaultPartnerOrganizations.Add(new PartnerOrganization() { Abbr = "NRSP", ColorCode = "#0931FF", Description = "National Rural Support Organization", IsActive = true, OrderIndex = 1000, Title = "National Rural Support Organization", YearFounded = 1992 });
            //defaultPartnerOrganizations.Add(new PartnerOrganization() { Abbr = "PRSP", ColorCode = "#110990", Description = "Punjab Rural Support Organization", IsActive = true, OrderIndex = 1000, Title = "Punjab Rural Support Organization", YearFounded = 1998 });
            //defaultPartnerOrganizations.Add(new PartnerOrganization() { Abbr = "SGA", ColorCode = "#000990", Description = "Sindh Graduates Association", IsActive = true, OrderIndex = 1000, Title = "Sindh Graduates Association", YearFounded = 2002 });
            //defaultPartnerOrganizations.Add(new PartnerOrganization() { Abbr = "SRSO", ColorCode = "#FFE200", Description = "Sindh Rural Support Organization", IsActive = true, OrderIndex = 1000, Title = "Sindh Rural Support Organization", YearFounded = 2003 });

            //defaultPartnerOrganizations.Add(new PartnerOrganization() { Abbr = "SRSP", ColorCode = "#000990", Description = "Sarhad Rural Support Organization", IsActive = true, OrderIndex = 1000, Title = "Sarhad Rural Support Organization", YearFounded = 1989 });
            //defaultPartnerOrganizations.Add(new PartnerOrganization() { Abbr = "TRDP", ColorCode = "#110990", Description = "Thardeep Rural Development Programme", IsActive = true, OrderIndex = 1000, Title = "Thardeep Rural Development Programme", YearFounded = 1997 });

            //foreach (PartnerOrganization s in defaultPartnerOrganizations)
            //{
            //    context.PartnerOrganizations.Add(s);
            //}
            base.Seed(context);
        }
    }
}
