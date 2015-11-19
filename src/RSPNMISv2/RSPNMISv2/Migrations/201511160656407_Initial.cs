namespace RSPNMISv2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Districts",
                c => new
                    {
                        Dist_Id = c.Int(nullable: false, identity: true),
                        District_Name = c.String(maxLength: 250),
                        PROVINCE = c.String(maxLength: 250),
                        Prov_Id = c.Int(),
                        Country = c.String(maxLength: 250),
                    })
                .PrimaryKey(t => t.Dist_Id);
            
            CreateTable(
                "dbo.Indicators",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        IndicatorName = c.String(maxLength: 250),
                        SubIndicatorName = c.String(maxLength: 250),
                        OrderIndex = c.Long(nullable: false),
                        IsActive = c.Boolean(nullable: false),
                        DateCreated = c.DateTime(nullable: false),
                        CreatedBy = c.String(nullable: false, maxLength: 250),
                        DateModified = c.DateTime(nullable: false),
                        ModifiedBy = c.String(nullable: false, maxLength: 250),
                        IsCumulative = c.Boolean(nullable: false),
                        showVarianceInReports = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.PartnerOrganizations",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        PartnerOrganizationType_ID = c.Int(nullable: false),
                        Abbr = c.String(maxLength: 250),
                        Title = c.String(maxLength: 250),
                        Description = c.String(maxLength: 250),
                        YearFounded = c.Int(),
                        ColorCode = c.String(maxLength: 7),
                        OrderIndex = c.Long(nullable: false),
                        IsActive = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.PO_District",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        PartnerOrganizationID = c.Int(nullable: false),
                        Dist_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Districts", t => t.Dist_Id, cascadeDelete: true)
                .ForeignKey("dbo.PartnerOrganizations", t => t.PartnerOrganizationID, cascadeDelete: true)
                .Index(t => t.PartnerOrganizationID)
                .Index(t => t.Dist_Id);
            
            CreateTable(
                "dbo.Provinces",
                c => new
                    {
                        Prov_Id = c.Int(nullable: false, identity: true),
                        PROVINCE = c.String(maxLength: 250),
                        Country = c.String(maxLength: 250),
                    })
                .PrimaryKey(t => t.Prov_Id);
            
            CreateTable(
                "dbo.AspNetRoles",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true, name: "RoleNameIndex");
            
            CreateTable(
                "dbo.AspNetUserRoles",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.AspNetRoles", t => t.RoleId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);
            
            CreateTable(
                "dbo.RSPOutreaches",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        IndicatorID = c.Int(nullable: false),
                        ReportingDate = c.DateTime(),
                        Value = c.Decimal(precision: 18, scale: 2),
                        Dist_Id = c.Int(),
                        UC_Id = c.Int(),
                        DateCreated = c.DateTime(nullable: false),
                        CreatedBy = c.String(nullable: false, maxLength: 250),
                        DateModified = c.DateTime(nullable: false),
                        ModifiedBy = c.String(nullable: false, maxLength: 250),
                        PartnerOrganizationID = c.Int(nullable: false),
                        IsCumulative = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Districts", t => t.Dist_Id)
                .ForeignKey("dbo.Indicators", t => t.IndicatorID, cascadeDelete: true)
                .ForeignKey("dbo.PartnerOrganizations", t => t.PartnerOrganizationID, cascadeDelete: true)
                .ForeignKey("dbo.UCs", t => t.UC_Id)
                .Index(t => t.IndicatorID)
                .Index(t => t.Dist_Id, name: "Index_RSPOutreach_Dist_Id")
                .Index(t => t.UC_Id, name: "Index_RSPOutreach_UC_Id")
                .Index(t => t.PartnerOrganizationID);
            
            CreateTable(
                "dbo.UCs",
                c => new
                    {
                        UC_Id = c.Int(nullable: false, identity: true),
                        UC_Name = c.String(maxLength: 250),
                        Thesil = c.String(maxLength: 250),
                        District = c.String(maxLength: 250),
                        PROVINCE = c.String(maxLength: 250),
                        Prov_Id = c.Int(),
                        Country = c.String(maxLength: 250),
                        Dist_Id = c.Int(),
                        Teh_Id = c.Int(),
                    })
                .PrimaryKey(t => t.UC_Id);
            
            CreateTable(
                "dbo.AspNetUsers",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Email = c.String(maxLength: 256),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.UserName, unique: true, name: "UserNameIndex");
            
            CreateTable(
                "dbo.AspNetUserClaims",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(nullable: false, maxLength: 128),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUserLogins",
                c => new
                    {
                        LoginProvider = c.String(nullable: false, maxLength: 128),
                        ProviderKey = c.String(nullable: false, maxLength: 128),
                        UserId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.LoginProvider, t.ProviderKey, t.UserId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.RSPOutreaches", "UC_Id", "dbo.UCs");
            DropForeignKey("dbo.RSPOutreaches", "PartnerOrganizationID", "dbo.PartnerOrganizations");
            DropForeignKey("dbo.RSPOutreaches", "IndicatorID", "dbo.Indicators");
            DropForeignKey("dbo.RSPOutreaches", "Dist_Id", "dbo.Districts");
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropForeignKey("dbo.PO_District", "PartnerOrganizationID", "dbo.PartnerOrganizations");
            DropForeignKey("dbo.PO_District", "Dist_Id", "dbo.Districts");
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
            DropIndex("dbo.AspNetUsers", "UserNameIndex");
            DropIndex("dbo.RSPOutreaches", new[] { "PartnerOrganizationID" });
            DropIndex("dbo.RSPOutreaches", "Index_RSPOutreach_UC_Id");
            DropIndex("dbo.RSPOutreaches", "Index_RSPOutreach_Dist_Id");
            DropIndex("dbo.RSPOutreaches", new[] { "IndicatorID" });
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.AspNetRoles", "RoleNameIndex");
            DropIndex("dbo.PO_District", new[] { "Dist_Id" });
            DropIndex("dbo.PO_District", new[] { "PartnerOrganizationID" });
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.UCs");
            DropTable("dbo.RSPOutreaches");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.AspNetRoles");
            DropTable("dbo.Provinces");
            DropTable("dbo.PO_District");
            DropTable("dbo.PartnerOrganizations");
            DropTable("dbo.Indicators");
            DropTable("dbo.Districts");
        }
    }
}
