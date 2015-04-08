using BudgetCalculator.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BudgetCalculator.Models
{
    public class Budget
    {
        [Display(Name="Budget ID")]
        public int BudgetId { get; set; }

        [Display(Name="User ID")]
        public int BudgetUserId { get; set; }

        [Display(Name="Budget Name")]
        public String BudgetName { get; set; }

        //[DataType(DataType.Date)]
        //[DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        //[Display(Name = "Budget Start Date")]
        //public DateTime BudgetYear { get; set; }

        // Budget Start Date - Nullable
        [Required]
        [DataType(DataType.Date, ErrorMessage = "Please enter a valid date in the format dd/mm/yyyy")]
        [Display(Name = "Budget Start Date")]
        public DateTime? BudgetStartDate { get; set; }

        // Budget End Date - Nullable
        [Required]
        [DataType(DataType.Date, ErrorMessage = "Please enter a valid date in the format dd/mm/yyyy")]
        [Display(Name = "Budget End Date")]
        public DateTime? BudgetEndDate { get; set; }

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