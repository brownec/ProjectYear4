using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BudgetCalculator.Models
{
    public enum FuelType { Petrol, Diesel };
    public enum NctTest { [Display(Name = "NCT Full")] Full, [Display(Name = "NCT Retest")] Retest };
    public class CarExpense
    {
        [Display(Name = "Car Expense ID")]
        public int CarExpenseId { get; set; }

        [Display(Name="Car Tax")]
        public double CarTax { get; set; }

        [Display(Name = "Car Insurance")]
        public double CarInsurance { get; set; }

        public double Maintenance { get; set; }

        [Display(Name = "Fuel Type")]
        public FuelType FuelType { get; set; }

        [Display(Name = "Fuel Amount")]
        public double FuelAmount { get; set; }

        [Display(Name = "NCT Type")]
        public NctTest NctTest { get; set; }

        [Display(Name = "NCT Amount")]
        public double NctAmount { get; set; }

        public int BudgetId { get; set; }
        public virtual Budget Budget { get; set; }
    }
}