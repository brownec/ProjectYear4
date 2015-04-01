using ProjectYear4.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BudgetCalculator.Models
{
    public class TravelExpense
    {
        public int TravelExpenseId { get; set; }
        public double BusAmount { get; set; }
        public double LuasAmount { get; set; }
        public double TaxiAmount { get; set; }
        public double TrainAmount { get; set; }
        public double TravelOther { get; set; }

        public int BudgetId { get; set; }
        public virtual Budget Budget { get; set; }
    }
}