namespace BudgetCalculator.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _08April2015e : DbMigration
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
        }
        
        public override void Down()
        {
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
