using BudgetCalculator.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BudgetCalculator.Models
{
    public class TravelExpense
    {
        public int TravelExpenseId { get; set; }

        [Display(Name="Bus")]
        public double BusAmount { get; set; }

        [Display(Name = "Luas")]
        public double LuasAmount { get; set; }

        [Display(Name = "Taxi")]
        public double TaxiAmount { get; set; }

        [Display(Name = "Train")]
        public double TrainAmount { get; set; }

        [Display(Name = "Other")]
        public double TravelOther { get; set; }

        public int BudgetId { get; set; }
        public virtual Budget Budget { get; set; }
    }
}