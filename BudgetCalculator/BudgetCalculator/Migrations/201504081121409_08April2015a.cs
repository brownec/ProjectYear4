namespace BudgetCalculator.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _08April2015a : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Budgets", "BudgetStartDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.Budgets", "BudgetEndDate", c => c.DateTime(nullable: false));
            DropColumn("dbo.Budgets", "BudgetYear");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Budgets", "BudgetYear", c => c.DateTime(nullable: false));
            DropColumn("dbo.Budgets", "BudgetEndDate");
            DropColumn("dbo.Budgets", "BudgetStartDate");
        }
    }
}
