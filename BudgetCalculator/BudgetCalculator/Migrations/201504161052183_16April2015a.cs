namespace BudgetCalculator.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _16April2015a : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.CarExpenses", "TotalCarExpense", c => c.Double());
            AddColumn("dbo.HouseholdExpenses", "TotalHouseholdExpenses", c => c.Double());
            AddColumn("dbo.Incomes", "TotalIncome", c => c.Double());
            AddColumn("dbo.PersonalExpenses", "TotalPersonalExpenses", c => c.Double());
            AddColumn("dbo.TravelExpenses", "TotalTravelExpenses", c => c.Double());
            AddColumn("dbo.UtilityBillExpenses", "TotalUtilityBillExpenses", c => c.Double());
        }
        
        public override void Down()
        {
            DropColumn("dbo.UtilityBillExpenses", "TotalUtilityBillExpenses");
            DropColumn("dbo.TravelExpenses", "TotalTravelExpenses");
            DropColumn("dbo.PersonalExpenses", "TotalPersonalExpenses");
            DropColumn("dbo.Incomes", "TotalIncome");
            DropColumn("dbo.HouseholdExpenses", "TotalHouseholdExpenses");
            DropColumn("dbo.CarExpenses", "TotalCarExpense");
        }
    }
}
