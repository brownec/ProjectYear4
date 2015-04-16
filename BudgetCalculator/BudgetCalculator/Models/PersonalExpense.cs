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

        [DisplayFormat(DataFormatString = "{0:F2}", ApplyFormatInEditMode = true)]
        [Range(0, double.MaxValue, ErrorMessage = "The value must be greater than 0")]
        [Display(Name = "Social")]
        public double? SocialAmount { get; set; }

        [DisplayFormat(DataFormatString = "{0:F2}", ApplyFormatInEditMode = true)]
        [Range(0, double.MaxValue, ErrorMessage = "The value must be greater than 0")]
        [Display(Name = "Gym Membership")]
        public double? GymMembershipAmount { get; set; }

        [DisplayFormat(DataFormatString = "{0:F2}", ApplyFormatInEditMode = true)]
        [Range(0, double.MaxValue, ErrorMessage = "The value must be greater than 0")]
        [Display(Name = "Sports Membership")]
        public double? SportsFeeAmount { get; set; }

        [DisplayFormat(DataFormatString = "{0:F2}", ApplyFormatInEditMode = true)]
        [Range(0, double.MaxValue, ErrorMessage = "The value must be greater than 0")]
        [Display(Name = "Holidays")]
        public double? HolidayAmount { get; set; }

        [DisplayFormat(DataFormatString = "{0:F2}", ApplyFormatInEditMode = true)]
        [Range(0, double.MaxValue, ErrorMessage = "The value must be greater than 0")]
        [Display(Name = "Savings")]
        public double? SavingsAmount { get; set; }

        [DisplayFormat(DataFormatString = "{0:F2}", ApplyFormatInEditMode = true)]
        [Range(0, double.MaxValue, ErrorMessage = "The value must be greater than 0")]
        [Display(Name = "Loan Repayment")]
        public double? LoanRepaymentAmount { get; set; }

        [DisplayFormat(DataFormatString = "{0:F2}", ApplyFormatInEditMode = true)]
        [Range(0, double.MaxValue, ErrorMessage = "The value must be greater than 0")]
        [Display(Name = "Personal Other")]
        public double? PersonalExpenseOther { get; set; }

        [DisplayFormat(DataFormatString = "{0:F2}", ApplyFormatInEditMode = true)]
        [Range(0, double.MaxValue, ErrorMessage = "The value must be greater than 0")]
        [Display(Name = "Total Personal Expenses")]
        public double? TotalPersonalExpenses { get; set; }

        public int BudgetId { get; set; }
        public virtual Budget Budget { get; set; }
    }
}