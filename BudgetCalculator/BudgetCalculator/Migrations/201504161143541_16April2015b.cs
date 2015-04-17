namespace BudgetCalculator.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _16April2015b : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.CarExpenses", "TotalCarExpenses", c => c.Double());
            DropColumn("dbo.CarExpenses", "TotalCarExpense");
        }
        
        public override void Down()
        {
            AddColumn("dbo.CarExpenses", "TotalCarExpense", c => c.Double());
            DropColumn("dbo.CarExpenses", "TotalCarExpenses");
        }
    }
}
