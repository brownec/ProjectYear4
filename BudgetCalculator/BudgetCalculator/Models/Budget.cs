using BudgetCalculator.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ProjectYear4.Models
{
    public class Budget
    {
        [Display(Name="Budget ID")]
        public int BudgetId { get; set; }

        [Display(Name="User ID")]
        public int BudgetUserId { get; set; }

        [Display(Name="Budget Name")]
        public String BudgetName { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "Budget Date")]
        public DateTime BudgetYear { get; set; }

        //public int CarExpenseId { get; set; }
        //public int UtilityBillExpenseId { get; set; }
        //public int HouseholdExpenseId { get; set; }
        //public int PersonalExpenseId { get; set; }

        // navigation properties
        public virtual BudgetUser BudgetUser { get; set; }

        public virtual ICollection<CarExpense> CarExpenses { get; set; }

        public virtual ICollection<HouseholdExpense> HouseholdExpense { get; set; }

        public virtual ICollection<PersonalExpense> PersonalExpense { get; set; }

        public virtual ICollection<UtilityBillExpense> UtilityBillExpenses { get; set; }

        public virtual ICollection<TravelExpense> TravelExpense { get; set; }

        public virtual ICollection<Income> Income { get; set; }

    }
}