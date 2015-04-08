using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BudgetCalculator.Models
{
    public enum FuelType 
    { 
        Petrol, 
        Diesel, 
        Hybrid, 
        Other 
    };
    public enum NctTest
    {
        [Display(Name = "NCT")]
        NCT,
        [Display(Name = "Small Public Service Vehicles")]
        SPSV, 
        [Display(Name="CommercialVehicles")] 
        CVT,
        Other 
    };
    public class CarExpense
    {
        [Display(Name = "Car Expense ID")]
        public int CarExpenseId { get; set; }

        [DisplayFormat(DataFormatString="{0:F2}", ApplyFormatInEditMode=true)]
        [Display(Name="Car Tax")]
        public double? CarTax { get; set; }

        [DisplayFormat(DataFormatString = "{0:F2}", ApplyFormatInEditMode = true)]
        [Display(Name = "Car Insurance")]
        public double? CarInsurance { get; set; }

        [DisplayFormat(DataFormatString = "{0:F2}", ApplyFormatInEditMode = true)]
        public double? Maintenance { get; set; }

        [Display(Name = "Fuel Type")]
        public FuelType FuelType { get; set; }

        [DisplayFormat(DataFormatString = "{0:F2}", ApplyFormatInEditMode = true)]
        [Display(Name = "Fuel Amount")]
        public double? FuelAmount { get; set; }

        [Display(Name = "NCT Type")]
        public NctTest NctTest { get; set; }

        [DisplayFormat(DataFormatString = "{0:F2}", ApplyFormatInEditMode = true)]
        [Display(Name = "NCT Amount")]
        public double? NctAmount { get; set; }

        [DisplayFormat(DataFormatString = "{0:F2}", ApplyFormatInEditMode = true)]
        [Display(Name = "Toll Charges")]
        public double? TollChargeAmount { get; set; }

        [DisplayFormat(DataFormatString = "{0:F2}", ApplyFormatInEditMode = true)]
        [Display(Name = "Other")]
        public double? CarExpenseOtherAmount { get; set; }
        
        public int BudgetId { get; set; }
        public virtual Budget Budget { get; set; }
    }
}