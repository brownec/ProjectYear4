using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace ProjectYear4.Models
{
    public class MyDBConnection : DbContext
    {
        public DbSet<Budget> Budget { get; set; }
        public DbSet<BudgetUser> BudgetUser { get; set; }
        public DbSet<CarExpense> CarExpense { get; set; }
        public DbSet<UtilityBillExpense> UtilityBillExpense { get; set; }
        public DbSet<HouseholdExpense> HouseholdExpense { get; set; }
        public DbSet<PersonalExpense> PersonalExpense { get; set; }

    }
}

