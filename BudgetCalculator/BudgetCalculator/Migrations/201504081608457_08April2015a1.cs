namespace BudgetCalculator.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _08April2015a1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Incomes", "PrimaryIncomeAmount", c => c.Double());
            AddColumn("dbo.Incomes", "AdditionalIncomeAmount", c => c.Double());
            DropColumn("dbo.Incomes", "IncomeAmount");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Incomes", "IncomeAmount", c => c.Double(nullable: false));
            DropColumn("dbo.Incomes", "AdditionalIncomeAmount");
            DropColumn("dbo.Incomes", "PrimaryIncomeAmount");
        }
    }
}
