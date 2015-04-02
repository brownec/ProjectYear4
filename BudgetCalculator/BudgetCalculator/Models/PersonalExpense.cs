using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BudgetCalculator.Models
{
    public class PersonalExpense
    {
        [Display(Name = "Personal Expense ID")]
        public int PersonalExpenseId { get; set; }

        [Display(Name = "Social")]
        public double SocialAmount { get; set; }

        [Display(Name = "Gym Membership")]
        public double GymMembershipAmount { get; set; }

        [Display(Name = "Sports Membership")]
        public double SportsFeeAmount { get; set; }

        [Display(Name = "Holidays")]
        public double HolidayAmount { get; set; }

        [Display(Name = "Savings")]
        public double SavingsAmount { get; set; }

        [Display(Name = "Loan Repayment")]
        public double LoanRepaymentAmount { get; set; }

        [Display(Name = "Personal Other")]
        public double PersonalExpenseOther { get; set; }

        public int BudgetId { get; set; }
        public virtual Budget Budget { get; set; }
    }
}