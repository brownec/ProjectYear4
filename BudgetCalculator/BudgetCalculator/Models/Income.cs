using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using BudgetCalculator.Models;

namespace BudgetCalculator.Models
{
    public class Income
    {
        public int IncomeId { get; set; }

        [Required(ErrorMessage="Must include Primary Income value!")]
        [Range(0, double.MaxValue, ErrorMessage = "The value must be greater than 0")]
        [DisplayFormat(DataFormatString = "{0:F2}", ApplyFormatInEditMode = true)]
        [Display(Name="Income Amount")]
        public double? PrimaryIncomeAmount { get; set; }

        [DisplayFormat(DataFormatString = "{0:F2}", ApplyFormatInEditMode = true)]
        [Range(0, double.MaxValue, ErrorMessage = "The value must be greater than 0")]
        [Display(Name = "Additional Income")]
        public double? AdditionalIncomeAmount { get; set; }

        public int BudgetId { get; set; }
        public virtual Budget Budget { get; set; }
    }
}