using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace BudgetCalculator.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit http://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }
    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

        public System.Data.Entity.DbSet<ProjectYear4.Models.Budget> Budgets { get; set; }

        public System.Data.Entity.DbSet<ProjectYear4.Models.BudgetUser> BudgetUsers { get; set; }

        public System.Data.Entity.DbSet<ProjectYear4.Models.CarExpense> CarExpenses { get; set; }

        public System.Data.Entity.DbSet<ProjectYear4.Models.HouseholdExpense> HouseholdExpenses { get; set; }

        public System.Data.Entity.DbSet<ProjectYear4.Models.PersonalExpense> PersonalExpenses { get; set; }

        public System.Data.Entity.DbSet<ProjectYear4.Models.UtilityBillExpense> UtilityBillExpenses { get; set; }

        public System.Data.Entity.DbSet<BudgetCalculator.Models.Income> Incomes { get; set; }

        public System.Data.Entity.DbSet<BudgetCalculator.Models.TravelExpense> TravelExpenses { get; set; }
    }
}