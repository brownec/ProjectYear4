namespace BudgetCalculator.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Budgets",
                c => new
                    {
                        BudgetId = c.Int(nullable: false, identity: true),
                        BudgetUserId = c.Int(nullable: false),
                        BudgetName = c.String(),
                        BudgetYear = c.DateTime(nullable: false),
                        CarExpenseId = c.Int(nullable: false),
                        UtilityBillExpenseId = c.Int(nullable: false),
                        HouseholdExpenseId = c.Int(nullable: false),
                        PersonalExpenseId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.BudgetId)
                .ForeignKey("dbo.BudgetUsers", t => t.BudgetUserId, cascadeDelete: true)
                .Index(t => t.BudgetUserId);
            
            CreateTable(
                "dbo.BudgetUsers",
                c => new
                    {
                        BudgetUserId = c.Int(nullable: false, identity: true),
                        LastName = c.String(nullable: false, maxLength: 50),
                        FirstName = c.String(nullable: false, maxLength: 50),
                        DateOfBirth = c.DateTime(nullable: false),
                        AddressLine1 = c.String(nullable: false, maxLength: 50),
                        AddressLine2 = c.String(maxLength: 50),
                        Town = c.String(maxLength: 50),
                        County = c.String(maxLength: 50),
                        Country = c.String(maxLength: 50),
                        PostCode = c.String(),
                        ContactNo = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.BudgetUserId);
            
            CreateTable(
                "dbo.CarExpenses",
                c => new
                    {
                        CarExpenseId = c.Int(nullable: false, identity: true),
                        CarTax = c.Double(nullable: false),
                        CarInsurance = c.Double(nullable: false),
                        Maintenance = c.Double(nullable: false),
                        FuelType = c.Int(nullable: false),
                        FuelAmount = c.Double(nullable: false),
                        NctTest = c.Int(nullable: false),
                        NctAmount = c.Double(nullable: false),
                        BudgetId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.CarExpenseId)
                .ForeignKey("dbo.Budgets", t => t.BudgetId, cascadeDelete: true)
                .Index(t => t.BudgetId);
            
            CreateTable(
                "dbo.HouseholdExpenses",
                c => new
                    {
                        HouseholdExpenseId = c.Int(nullable: false, identity: true),
                        RentType = c.Int(nullable: false),
                        RentAmount = c.Double(nullable: false),
                        GroceryAmount = c.Double(nullable: false),
                        ClothingAmount = c.Double(nullable: false),
                        EducationFeesAmount = c.Double(nullable: false),
                        SchoolBooksAmount = c.Double(nullable: false),
                        MedicalBillAmount = c.Double(nullable: false),
                        HouseholdOtherAmount = c.Double(nullable: false),
                        BudgetId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.HouseholdExpenseId)
                .ForeignKey("dbo.Budgets", t => t.BudgetId, cascadeDelete: true)
                .Index(t => t.BudgetId);
            
            CreateTable(
                "dbo.PersonalExpenses",
                c => new
                    {
                        PersonalExpenseId = c.Int(nullable: false, identity: true),
                        SocialAmount = c.Double(nullable: false),
                        GymMembershipAmount = c.Double(nullable: false),
                        SportsFeeAmount = c.Double(nullable: false),
                        HolidayAmount = c.Double(nullable: false),
                        SavingsAmount = c.Double(nullable: false),
                        LoanRepaymentAmount = c.Double(nullable: false),
                        PersonalExpenseOther = c.Double(nullable: false),
                        BudgetId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.PersonalExpenseId)
                .ForeignKey("dbo.Budgets", t => t.BudgetId, cascadeDelete: true)
                .Index(t => t.BudgetId);
            
            CreateTable(
                "dbo.UtilityBillExpenses",
                c => new
                    {
                        UtilityBillExpenseId = c.Int(nullable: false, identity: true),
                        Electricity = c.Double(nullable: false),
                        Gas = c.Double(nullable: false),
                        RefuseCollection = c.Double(nullable: false),
                        IrishWater = c.Double(nullable: false),
                        TVLicenseAmount = c.Double(nullable: false),
                        PhoneBillAmount = c.Double(nullable: false),
                        BroadbandAmount = c.Double(nullable: false),
                        UtilityBillExpenseAmount = c.Double(nullable: false),
                        BudgetId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.UtilityBillExpenseId)
                .ForeignKey("dbo.Budgets", t => t.BudgetId, cascadeDelete: true)
                .Index(t => t.BudgetId);
            
            CreateTable(
                "dbo.AspNetRoles",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true, name: "RoleNameIndex");
            
            CreateTable(
                "dbo.AspNetUserRoles",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.AspNetRoles", t => t.RoleId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);
            
            CreateTable(
                "dbo.AspNetUsers",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Email = c.String(maxLength: 256),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.UserName, unique: true, name: "UserNameIndex");
            
            CreateTable(
                "dbo.AspNetUserClaims",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(nullable: false, maxLength: 128),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUserLogins",
                c => new
                    {
                        LoginProvider = c.String(nullable: false, maxLength: 128),
                        ProviderKey = c.String(nullable: false, maxLength: 128),
                        UserId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.LoginProvider, t.ProviderKey, t.UserId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropForeignKey("dbo.UtilityBillExpenses", "BudgetId", "dbo.Budgets");
            DropForeignKey("dbo.PersonalExpenses", "BudgetId", "dbo.Budgets");
            DropForeignKey("dbo.HouseholdExpenses", "BudgetId", "dbo.Budgets");
            DropForeignKey("dbo.CarExpenses", "BudgetId", "dbo.Budgets");
            DropForeignKey("dbo.Budgets", "BudgetUserId", "dbo.BudgetUsers");
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
            DropIndex("dbo.AspNetUsers", "UserNameIndex");
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.AspNetRoles", "RoleNameIndex");
            DropIndex("dbo.UtilityBillExpenses", new[] { "BudgetId" });
            DropIndex("dbo.PersonalExpenses", new[] { "BudgetId" });
            DropIndex("dbo.HouseholdExpenses", new[] { "BudgetId" });
            DropIndex("dbo.CarExpenses", new[] { "BudgetId" });
            DropIndex("dbo.Budgets", new[] { "BudgetUserId" });
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.AspNetRoles");
            DropTable("dbo.UtilityBillExpenses");
            DropTable("dbo.PersonalExpenses");
            DropTable("dbo.HouseholdExpenses");
            DropTable("dbo.CarExpenses");
            DropTable("dbo.BudgetUsers");
            DropTable("dbo.Budgets");
        }
    }
}
