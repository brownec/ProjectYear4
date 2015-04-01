namespace BudgetCalculator.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _01April2015b : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.TravelExpenses",
                c => new
                    {
                        TravelExpenseId = c.Int(nullable: false, identity: true),
                        BusAmount = c.Double(nullable: false),
                        LuasAmount = c.Double(nullable: false),
                        TaxiAmount = c.Double(nullable: false),
                        TrainAmount = c.Double(nullable: false),
                        TravelOther = c.Double(nullable: false),
                        BudgetId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.TravelExpenseId)
                .ForeignKey("dbo.Budgets", t => t.BudgetId, cascadeDelete: true)
                .Index(t => t.BudgetId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.TravelExpenses", "BudgetId", "dbo.Budgets");
            DropIndex("dbo.TravelExpenses", new[] { "BudgetId" });
            DropTable("dbo.TravelExpenses");
        }
    }
}
