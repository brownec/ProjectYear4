namespace BudgetCalculator.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _26march2015a : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Budgets", "CarExpenseId");
            DropColumn("dbo.Budgets", "UtilityBillExpenseId");
            DropColumn("dbo.Budgets", "HouseholdExpenseId");
            DropColumn("dbo.Budgets", "PersonalExpenseId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Budgets", "PersonalExpenseId", c => c.Int(nullable: false));
            AddColumn("dbo.Budgets", "HouseholdExpenseId", c => c.Int(nullable: false));
            AddColumn("dbo.Budgets", "UtilityBillExpenseId", c => c.Int(nullable: false));
            AddColumn("dbo.Budgets", "CarExpenseId", c => c.Int(nullable: false));
        }
    }
}
