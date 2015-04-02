using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BudgetCalculator.Models
{
    public enum RentType { Rent, Mortgage };
    public class HouseholdExpense
    {
        [Display(Name = "Household Expense ID")]
        public int HouseholdExpenseId { get; set; }

        [Display(Name = "Rent Type")]
        public RentType RentType { get; set; }

        [Display(Name = "Rent")]
        public double RentAmount { get; set; }

        [Display(Name = "Groceries")]
        public double GroceryAmount { get; set; }

        [Display(Name = "Clothes")]
        public double ClothingAmount { get; set; }

        [Display(Name = "Education Fees")]
        public double EducationFeesAmount { get; set; }

        [Display(Name = "School Books")]
        public double SchoolBooksAmount { get; set; }

        [Display(Name = "Medical")]
        public double MedicalBillAmount { get; set; }

        [Display(Name = "Household Other")]
        public double HouseholdOtherAmount { get; set; }

        public int BudgetId { get; set; }
        public virtual Budget Budget { get; set; }
    }
}