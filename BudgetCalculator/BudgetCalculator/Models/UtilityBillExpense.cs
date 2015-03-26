using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ProjectYear4.Models
{
    public class UtilityBillExpense
    {
        [Display(Name = "Utility Bill Expense ID")]
        public int UtilityBillExpenseId { get; set; }

        public double Electricity { get; set; }

        public double Gas { get; set; }

        [Display(Name = "Refuse/Waste")]
        public double RefuseCollection { get; set; }

        [Display(Name = "Irish Water")]
        public double IrishWater { get; set; }

        [Display(Name = "TV")]
        public double TVLicenseAmount { get; set; }

        [Display(Name = "Phone")]
        public double PhoneBillAmount { get; set; }

        [Display(Name = "Broadband")]
        public double BroadbandAmount { get; set; }

        [Display(Name = "Utility Bill Other")]
        public double UtilityBillExpenseAmount { get; set; }

        public int BudgetId { get; set; }
        public virtual Budget Budget { get; set; }
    }
}