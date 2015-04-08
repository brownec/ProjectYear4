namespace BudgetCalculator.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _08April2015f : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.HouseholdExpenses", "HouseholdInsuranceAmount", c => c.Double());
            AddColumn("dbo.HouseholdExpenses", "HouseholdMaintenanceAmount", c => c.Double());
            AlterColumn("dbo.HouseholdExpenses", "RentAmount", c => c.Double());
            AlterColumn("dbo.HouseholdExpenses", "GroceryAmount", c => c.Double());
            AlterColumn("dbo.HouseholdExpenses", "ClothingAmount", c => c.Double());
            AlterColumn("dbo.HouseholdExpenses", "EducationFeesAmount", c => c.Double());
            AlterColumn("dbo.HouseholdExpenses", "SchoolBooksAmount", c => c.Double());
            AlterColumn("dbo.HouseholdExpenses", "MedicalBillAmount", c => c.Double());
            AlterColumn("dbo.HouseholdExpenses", "HouseholdOtherAmount", c => c.Double());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.HouseholdExpenses", "HouseholdOtherAmount", c => c.Double(nullable: false));
            AlterColumn("dbo.HouseholdExpenses", "MedicalBillAmount", c => c.Double(nullable: false));
            AlterColumn("dbo.HouseholdExpenses", "SchoolBooksAmount", c => c.Double(nullable: false));
            AlterColumn("dbo.HouseholdExpenses", "EducationFeesAmount", c => c.Double(nullable: false));
            AlterColumn("dbo.HouseholdExpenses", "ClothingAmount", c => c.Double(nullable: false));
            AlterColumn("dbo.HouseholdExpenses", "GroceryAmount", c => c.Double(nullable: false));
            AlterColumn("dbo.HouseholdExpenses", "RentAmount", c => c.Double(nullable: false));
            DropColumn("dbo.HouseholdExpenses", "HouseholdMaintenanceAmount");
            DropColumn("dbo.HouseholdExpenses", "HouseholdInsuranceAmount");
        }
    }
}
