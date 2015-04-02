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
        [Display(Name="Income Amount")]
        public double IncomeAmount { get; set; }

        public int BudgetId { get; set; }
        public virtual Budget Budget { get; set; }
    }
}