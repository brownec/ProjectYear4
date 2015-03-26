using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ProjectYear4.Models
{
    public class Budget
    {
        public int BudgetId { get; set; }

        public int BudgetUserId { get; set; }

        [Display(Name="Budget Name")]
        public String BudgetName { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-mm-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "Budget Year")]
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
    }
}