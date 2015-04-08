namespace BudgetCalculator.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _08April2015c : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.CarExpenses", "TollChargeAmount", c => c.Double(nullable: false));
            AddColumn("dbo.CarExpenses", "CarExpenseOtherAmount", c => c.Double(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.CarExpenses", "CarExpenseOtherAmount");
            DropColumn("dbo.CarExpenses", "TollChargeAmount");
        }
    }
}
