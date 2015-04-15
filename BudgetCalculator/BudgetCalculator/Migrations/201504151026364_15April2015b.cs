namespace BudgetCalculator.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _15April2015b : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.CarExpenses", "CarTax", c => c.Double());
            AlterColumn("dbo.CarExpenses", "CarInsurance", c => c.Double());
            AlterColumn("dbo.CarExpenses", "Maintenance", c => c.Double());
            AlterColumn("dbo.CarExpenses", "FuelAmount", c => c.Double());
            AlterColumn("dbo.CarExpenses", "NctAmount", c => c.Double());
            AlterColumn("dbo.CarExpenses", "TollChargeAmount", c => c.Double());
            AlterColumn("dbo.CarExpenses", "CarExpenseOtherAmount", c => c.Double());
            AlterColumn("dbo.HouseholdExpenses", "RentAmount", c => c.Double());
            AlterColumn("dbo.HouseholdExpenses", "GroceryAmount", c => c.Double());
            AlterColumn("dbo.HouseholdExpenses", "ClothingAmount", c => c.Double());
            AlterColumn("dbo.HouseholdExpenses", "EducationFeesAmount", c => c.Double());
            AlterColumn("dbo.HouseholdExpenses", "SchoolBooksAmount", c => c.Double());
            AlterColumn("dbo.HouseholdExpenses", "MedicalBillAmount", c => c.Double());
            AlterColumn("dbo.HouseholdExpenses", "HouseholdInsuranceAmount", c => c.Double());
            AlterColumn("dbo.HouseholdExpenses", "HouseholdMaintenanceAmount", c => c.Double());
            AlterColumn("dbo.HouseholdExpenses", "HouseholdOtherAmount", c => c.Double());
            AlterColumn("dbo.Incomes", "AdditionalIncomeAmount", c => c.Double());
            AlterColumn("dbo.PersonalExpenses", "SocialAmount", c => c.Double());
            AlterColumn("dbo.PersonalExpenses", "GymMembershipAmount", c => c.Double());
            AlterColumn("dbo.PersonalExpenses", "SportsFeeAmount", c => c.Double());
            AlterColumn("dbo.PersonalExpenses", "HolidayAmount", c => c.Double());
            AlterColumn("dbo.PersonalExpenses", "SavingsAmount", c => c.Double());
            AlterColumn("dbo.PersonalExpenses", "LoanRepaymentAmount", c => c.Double());
            AlterColumn("dbo.PersonalExpenses", "PersonalExpenseOther", c => c.Double());
            AlterColumn("dbo.TravelExpenses", "BusAmount", c => c.Double());
            AlterColumn("dbo.TravelExpenses", "LuasAmount", c => c.Double());
            AlterColumn("dbo.TravelExpenses", "TaxiAmount", c => c.Double());
            AlterColumn("dbo.TravelExpenses", "TrainAmount", c => c.Double());
            AlterColumn("dbo.TravelExpenses", "TravelOther", c => c.Double());
            AlterColumn("dbo.UtilityBillExpenses", "Electricity", c => c.Double());
            AlterColumn("dbo.UtilityBillExpenses", "Gas", c => c.Double());
            AlterColumn("dbo.UtilityBillExpenses", "RefuseCollection", c => c.Double());
            AlterColumn("dbo.UtilityBillExpenses", "IrishWater", c => c.Double());
            AlterColumn("dbo.UtilityBillExpenses", "TVAmount", c => c.Double());
            AlterColumn("dbo.UtilityBillExpenses", "PhoneBillAmount", c => c.Double());
            AlterColumn("dbo.UtilityBillExpenses", "BroadbandAmount", c => c.Double());
            AlterColumn("dbo.UtilityBillExpenses", "UtilityBillExpenseAmount", c => c.Double());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.UtilityBillExpenses", "UtilityBillExpenseAmount", c => c.Double(nullable: false));
            AlterColumn("dbo.UtilityBillExpenses", "BroadbandAmount", c => c.Double(nullable: false));
            AlterColumn("dbo.UtilityBillExpenses", "PhoneBillAmount", c => c.Double(nullable: false));
            AlterColumn("dbo.UtilityBillExpenses", "TVAmount", c => c.Double(nullable: false));
            AlterColumn("dbo.UtilityBillExpenses", "IrishWater", c => c.Double(nullable: false));
            AlterColumn("dbo.UtilityBillExpenses", "RefuseCollection", c => c.Double(nullable: false));
            AlterColumn("dbo.UtilityBillExpenses", "Gas", c => c.Double(nullable: false));
            AlterColumn("dbo.UtilityBillExpenses", "Electricity", c => c.Double(nullable: false));
            AlterColumn("dbo.TravelExpenses", "TravelOther", c => c.Double(nullable: false));
            AlterColumn("dbo.TravelExpenses", "TrainAmount", c => c.Double(nullable: false));
            AlterColumn("dbo.TravelExpenses", "TaxiAmount", c => c.Double(nullable: false));
            AlterColumn("dbo.TravelExpenses", "LuasAmount", c => c.Double(nullable: false));
            AlterColumn("dbo.TravelExpenses", "BusAmount", c => c.Double(nullable: false));
            AlterColumn("dbo.PersonalExpenses", "PersonalExpenseOther", c => c.Double(nullable: false));
            AlterColumn("dbo.PersonalExpenses", "LoanRepaymentAmount", c => c.Double(nullable: false));
            AlterColumn("dbo.PersonalExpenses", "SavingsAmount", c => c.Double(nullable: false));
            AlterColumn("dbo.PersonalExpenses", "HolidayAmount", c => c.Double(nullable: false));
            AlterColumn("dbo.PersonalExpenses", "SportsFeeAmount", c => c.Double(nullable: false));
            AlterColumn("dbo.PersonalExpenses", "GymMembershipAmount", c => c.Double(nullable: false));
            AlterColumn("dbo.PersonalExpenses", "SocialAmount", c => c.Double(nullable: false));
            AlterColumn("dbo.Incomes", "AdditionalIncomeAmount", c => c.Double(nullable: false));
            AlterColumn("dbo.HouseholdExpenses", "HouseholdOtherAmount", c => c.Double(nullable: false));
            AlterColumn("dbo.HouseholdExpenses", "HouseholdMaintenanceAmount", c => c.Double(nullable: false));
            AlterColumn("dbo.HouseholdExpenses", "HouseholdInsuranceAmount", c => c.Double(nullable: false));
            AlterColumn("dbo.HouseholdExpenses", "MedicalBillAmount", c => c.Double(nullable: false));
            AlterColumn("dbo.HouseholdExpenses", "SchoolBooksAmount", c => c.Double(nullable: false));
            AlterColumn("dbo.HouseholdExpenses", "EducationFeesAmount", c => c.Double(nullable: false));
            AlterColumn("dbo.HouseholdExpenses", "ClothingAmount", c => c.Double(nullable: false));
            AlterColumn("dbo.HouseholdExpenses", "GroceryAmount", c => c.Double(nullable: false));
            AlterColumn("dbo.HouseholdExpenses", "RentAmount", c => c.Double(nullable: false));
            AlterColumn("dbo.CarExpenses", "CarExpenseOtherAmount", c => c.Double(nullable: false));
            AlterColumn("dbo.CarExpenses", "TollChargeAmount", c => c.Double(nullable: false));
            AlterColumn("dbo.CarExpenses", "NctAmount", c => c.Double(nullable: false));
            AlterColumn("dbo.CarExpenses", "FuelAmount", c => c.Double(nullable: false));
            AlterColumn("dbo.CarExpenses", "Maintenance", c => c.Double(nullable: false));
            AlterColumn("dbo.CarExpenses", "CarInsurance", c => c.Double(nullable: false));
            AlterColumn("dbo.CarExpenses", "CarTax", c => c.Double(nullable: false));
        }
    }
}
