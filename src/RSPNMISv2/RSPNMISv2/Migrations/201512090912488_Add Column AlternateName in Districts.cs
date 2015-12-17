namespace RSPNMISv2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddColumnAlternateNameinDistricts : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Districts", "AlternateName", c => c.String(maxLength: 250));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Districts", "AlternateName");
        }
    }
}
