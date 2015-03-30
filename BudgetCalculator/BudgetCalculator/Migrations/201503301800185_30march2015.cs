namespace BudgetCalculator.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _30march2015 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Incomes",
                c => new
                    {
                        IncomeId = c.Int(nullable: false, identity: true),
                        IncomeAmount = c.Double(nullable: false),
                        BudgetId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.IncomeId)
                .ForeignKey("dbo.Budgets", t => t.BudgetId, cascadeDelete: true)
                .Index(t => t.BudgetId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Incomes", "BudgetId", "dbo.Budgets");
            DropIndex("dbo.Incomes", new[] { "BudgetId" });
            DropTable("dbo.Incomes");
        }
    }
}
