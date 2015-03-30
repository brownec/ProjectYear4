using ProjectYear4.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BudgetCalculator.Models
{
    public class Income
    {
        public int IncomeId { get; set; }
        public double IncomeAmount { get; set; }

        public int BudgetId { get; set; }
        public virtual Budget Budget { get; set; }
    }
}