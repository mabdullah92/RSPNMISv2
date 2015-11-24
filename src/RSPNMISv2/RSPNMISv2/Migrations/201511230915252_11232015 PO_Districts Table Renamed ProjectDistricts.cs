namespace RSPNMISv2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _11232015PO_DistrictsTableRenamedProjectDistricts : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.PO_District", newName: "ProjectDistricts");
        }
        
        public override void Down()
        {
            RenameTable(name: "dbo.ProjectDistricts", newName: "PO_District");
        }
    }
}
