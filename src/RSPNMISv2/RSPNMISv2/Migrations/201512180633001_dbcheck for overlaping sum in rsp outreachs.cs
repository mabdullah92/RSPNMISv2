namespace RSPNMISv2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class dbcheckforoverlapingsuminrspoutreachs : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Indicators", "SumOverlapping", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Indicators", "SumOverlapping");
        }
    }
}
