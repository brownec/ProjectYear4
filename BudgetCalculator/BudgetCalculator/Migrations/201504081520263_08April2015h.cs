namespace BudgetCalculator.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _08April2015h : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.PersonalExpenses", "SocialAmount", c => c.Double());
            AlterColumn("dbo.PersonalExpenses", "GymMembershipAmount", c => c.Double());
            AlterColumn("dbo.PersonalExpenses", "SportsFeeAmount", c => c.Double());
            AlterColumn("dbo.PersonalExpenses", "HolidayAmount", c => c.Double());
            AlterColumn("dbo.PersonalExpenses", "SavingsAmount", c => c.Double());
            AlterColumn("dbo.PersonalExpenses", "LoanRepaymentAmount", c => c.Double());
            AlterColumn("dbo.PersonalExpenses", "PersonalExpenseOther", c => c.Double());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.PersonalExpenses", "PersonalExpenseOther", c => c.Double(nullable: false));
            AlterColumn("dbo.PersonalExpenses", "LoanRepaymentAmount", c => c.Double(nullable: false));
            AlterColumn("dbo.PersonalExpenses", "SavingsAmount", c => c.Double(nullable: false));
            AlterColumn("dbo.PersonalExpenses", "HolidayAmount", c => c.Double(nullable: false));
            AlterColumn("dbo.PersonalExpenses", "SportsFeeAmount", c => c.Double(nullable: false));
            AlterColumn("dbo.PersonalExpenses", "GymMembershipAmount", c => c.Double(nullable: false));
            AlterColumn("dbo.PersonalExpenses", "SocialAmount", c => c.Double(nullable: false));
        }
    }
}
