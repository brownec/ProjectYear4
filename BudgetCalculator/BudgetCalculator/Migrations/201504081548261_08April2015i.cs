namespace BudgetCalculator.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _08April2015i : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.TravelExpenses", "BusAmount", c => c.Double());
            AlterColumn("dbo.TravelExpenses", "LuasAmount", c => c.Double());
            AlterColumn("dbo.TravelExpenses", "TaxiAmount", c => c.Double());
            AlterColumn("dbo.TravelExpenses", "TrainAmount", c => c.Double());
            AlterColumn("dbo.TravelExpenses", "TravelOther", c => c.Double());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.TravelExpenses", "TravelOther", c => c.Double(nullable: false));
            AlterColumn("dbo.TravelExpenses", "TrainAmount", c => c.Double(nullable: false));
            AlterColumn("dbo.TravelExpenses", "TaxiAmount", c => c.Double(nullable: false));
            AlterColumn("dbo.TravelExpenses", "LuasAmount", c => c.Double(nullable: false));
            AlterColumn("dbo.TravelExpenses", "BusAmount", c => c.Double(nullable: false));
        }
    }
}
