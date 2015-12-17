namespace RSPNMISv2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PartnerOganizationisNullableinOutreach : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.RSPOutreaches", "PartnerOrganizationID", "dbo.PartnerOrganizations");
            DropIndex("dbo.RSPOutreaches", new[] { "PartnerOrganizationID" });
            AlterColumn("dbo.RSPOutreaches", "PartnerOrganizationID", c => c.Int());
            CreateIndex("dbo.RSPOutreaches", "PartnerOrganizationID");
            AddForeignKey("dbo.RSPOutreaches", "PartnerOrganizationID", "dbo.PartnerOrganizations", "ID");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.RSPOutreaches", "PartnerOrganizationID", "dbo.PartnerOrganizations");
            DropIndex("dbo.RSPOutreaches", new[] { "PartnerOrganizationID" });
            AlterColumn("dbo.RSPOutreaches", "PartnerOrganizationID", c => c.Int(nullable: false));
            CreateIndex("dbo.RSPOutreaches", "PartnerOrganizationID");
            AddForeignKey("dbo.RSPOutreaches", "PartnerOrganizationID", "dbo.PartnerOrganizations", "ID", cascadeDelete: true);
        }
    }
}
