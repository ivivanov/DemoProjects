namespace LinqTests.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class xx : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Bars", "OpenWeekDays", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Bars", "OpenWeekDays");
        }
    }
}
