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

        [DisplayFormat(DataFormatString = "{0:F2}", ApplyFormatInEditMode = true)]
        [Range(0, double.MaxValue, ErrorMessage = "The value must be greater than 0")]
        [Display(Name = "Rent/Mortgage")]
        public double? RentAmount { get; set; }

        [DisplayFormat(DataFormatString = "{0:F2}", ApplyFormatInEditMode = true)]
        [Range(0, double.MaxValue, ErrorMessage = "The value must be greater than 0")]
        [Display(Name = "Groceries")]
        public double? GroceryAmount { get; set; }

        [DisplayFormat(DataFormatString = "{0:F2}", ApplyFormatInEditMode = true)]
        [Range(0, double.MaxValue, ErrorMessage = "The value must be greater than 0")]
        [Display(Name = "Clothing")]
        public double? ClothingAmount { get; set; }

        [DisplayFormat(DataFormatString = "{0:F2}", ApplyFormatInEditMode = true)]
        [Range(0, double.MaxValue, ErrorMessage = "The value must be greater than 0")]
        [Display(Name = "Education Fees")]
        public double? EducationFeesAmount { get; set; }

        [DisplayFormat(DataFormatString = "{0:F2}", ApplyFormatInEditMode = true)]
        [Range(0, double.MaxValue, ErrorMessage = "The value must be greater than 0")]
        [Display(Name = "School Supplies")]
        public double? SchoolBooksAmount { get; set; }

        [DisplayFormat(DataFormatString = "{0:F2}", ApplyFormatInEditMode = true)]
        [Range(0, double.MaxValue, ErrorMessage = "The value must be greater than 0")]
        [Display(Name = "Medical")]
        public double? MedicalBillAmount { get; set; }

        [DisplayFormat(DataFormatString = "{0:F2}", ApplyFormatInEditMode = true)]
        [Range(0, double.MaxValue, ErrorMessage = "The value must be greater than 0")]
        [Display(Name = "Insurance")]
        public double? HouseholdInsuranceAmount { get; set; }

        [DisplayFormat(DataFormatString = "{0:F2}", ApplyFormatInEditMode = true)]
        [Range(0, double.MaxValue, ErrorMessage = "The value must be greater than 0")]
        [Display(Name = "Maintenance")]
        public double? HouseholdMaintenanceAmount { get; set; }

        [DisplayFormat(DataFormatString = "{0:F2}", ApplyFormatInEditMode = true)]
        [Range(0, double.MaxValue, ErrorMessage = "The value must be greater than 0")]
        [Display(Name = "Other")]
        public double? HouseholdOtherAmount { get; set; }

        public int BudgetId { get; set; }
        public virtual Budget Budget { get; set; }
    }
}