using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using BudgetCalculator.Models;

namespace BudgetCalculator.Controllers
{
    public class BudgetsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Budgets
        public ActionResult Index()
        {
            var budgets = db.Budgets.Include(b => b.BudgetUser);
            return View(budgets.ToList());
        }

        // GET: Budgets/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Budget budget = db.Budgets.Find(id);
            if (budget == null)
            {
                return HttpNotFound();
            }
            return View(budget);
        }

        // GET: Budgets/Create
        public ActionResult Create(int id)
        {
            Budget b = new Budget();
            b.BudgetUserId = id;
            // ViewBag.BudgetUserId = new SelectList(db.BudgetUsers, "BudgetUserId", "LastName");
            return View(b);
        }

        // POST: Budgets/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "BudgetId,BudgetUserId,BudgetName,BudgetStartDate,BudgetEndDate")] Budget budget, int id)
        {
            budget.BudgetUserId = id;
            if (ModelState.IsValid)
            {
                db.Budgets.Add(budget);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.BudgetUserId = new SelectList(db.BudgetUsers, "BudgetUserId", "LastName", budget.BudgetUserId);
            return View(budget);
        }

        // GET: Budgets/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Budget budget = db.Budgets.Find(id);
            if (budget == null)
            {
                return HttpNotFound();
            }
            ViewBag.BudgetUserId = new SelectList(db.BudgetUsers, "BudgetUserId", "LastName", budget.BudgetUserId);
            return View(budget);
        }

        // POST: Budgets/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "BudgetId,BudgetUserId,BudgetName,BudgetStartDate,BudgetEndDate")] Budget budget)
        {
            if (ModelState.IsValid)
            {
                db.Entry(budget).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.BudgetUserId = new SelectList(db.BudgetUsers, "BudgetUserId", "LastName", budget.BudgetUserId);
            return View(budget);
        }

        // GET: Budgets/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Budget budget = db.Budgets.Find(id);
            if (budget == null)
            {
                return HttpNotFound();
            }
            return View(budget);
        }

        // POST: Budgets/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Budget budget = db.Budgets.Find(id);
            db.Budgets.Remove(budget);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        // Budget Summary View
        public ActionResult Summary(int? id)
        {
            // Calculation here
            Budget b = new Budget();
            b = db.Budgets.Where(p => p.BudgetId == id).SingleOrDefault();

            // ***************** INCOME *****************
            Income i = new Income();
            i = db.Incomes.Where(inc => inc.BudgetId == id).SingleOrDefault();

            double totalIncome = 0;

            ViewBag.PrimaryIncomeAmount = i.PrimaryIncomeAmount;
            // if AdditionalIncomeAmount is NULL
            if (i.AdditionalIncomeAmount == null)
            {
                // set initial amount to zero
                i.AdditionalIncomeAmount = 0;
                ViewBag.AdditionalIncomeAmount = i.AdditionalIncomeAmount;
            }
            else
            {
                // otherwise set AdditionalIncomeAmount to user input
                ViewBag.AdditionalIncomeAmount = i.AdditionalIncomeAmount;
            }

            // Calculate totalIncome (PrimaryIncomeAmount + AdditionalIncomeAmount)
            totalIncome = (double)i.PrimaryIncomeAmount; // set totalIncome = PrimaryIncome
            if (i.AdditionalIncomeAmount != null)
            {
                // If AdditionalIncomeAmount, execute
                totalIncome = (double)i.PrimaryIncomeAmount + (double)i.AdditionalIncomeAmount;
            }
            ViewBag.TotalIncome = totalIncome;
            //-----------------------------------------------------------------------------------------------
            //-----------------------------------------------------------------------------------------------
            //-----------------------------------------------------------------------------------------------

            // ***************** CAR EXPENSES *****************
            CarExpense c = new CarExpense();
            c = db.CarExpenses.Where(car => car.BudgetId == id).SingleOrDefault();

            double totalCarExpenses = 0;

            ViewBag.CarTax = c.CarTax;
            if (c.CarTax == null)
            {
                // set initial amount to zero
                c.CarTax = 0;
                ViewBag.CarTax = c.CarTax;
            }
            else
            {
                // otherwise set CarTax to user input
                ViewBag.CarTax = c.CarTax;
            }

            ViewBag.CarInsurance = c.CarInsurance;
            if (c.CarInsurance == null)
            {
                // set initial amount to zero
                c.CarInsurance = 0;
                ViewBag.CarInsurance = c.CarInsurance;
            }
            else
            {
                // otherwise set CarCarInsurance to user input
                ViewBag.CarCarInsurance = c.CarInsurance;
            }

            ViewBag.Maintenance = c.Maintenance;
            if (c.Maintenance == null)
            {
                // set initial amount to zero
                c.Maintenance = 0;
                ViewBag.Maintenance = c.Maintenance;
            }
            else
            {
                // otherwise set Maintenance to user input
                ViewBag.Maintenance = c.Maintenance;
            }

            ViewBag.FuelAmount = c.FuelAmount;
            if (c.FuelAmount == null)
            {
                // set initial amount to zero
                c.FuelAmount = 0;
                ViewBag.FuelAmount = c.FuelAmount;
            }
            else
            {
                // otherwise set FuelAmount to user input
                ViewBag.FuelAmount = c.FuelAmount;
            }

            ViewBag.NctAmount = c.NctAmount;
            if (c.NctAmount == null)
            {
                // set initial amount to zero
                c.NctAmount = 0;
                ViewBag.NctAmount = c.NctAmount;
            }
            else
            {
                // otherwise set NctAmount to user input
                ViewBag.NctAmount = c.NctAmount;
            }

            ViewBag.TollChargeAmount = c.TollChargeAmount;
            if (c.TollChargeAmount == null)
            {
                // set initial amount to zero
                c.TollChargeAmount = 0;
                ViewBag.TollChargeAmount = c.TollChargeAmount;
            }
            else
            {
                // otherwise set TollChargeAmount to user input
                ViewBag.TollChargeAmount = c.TollChargeAmount;
            }

            ViewBag.CarExpenseOtherAmount = c.CarExpenseOtherAmount;
            if (c.CarExpenseOtherAmount == null)
            {
                // set initial amount to zero
                c.CarExpenseOtherAmount = 0;
                ViewBag.CarExpenseOtherAmount = c.CarExpenseOtherAmount;
            }
            else
            {
                // otherwise set CarExpenseOtherAmount to user input
                ViewBag.CarExpenseOtherAmount = c.CarExpenseOtherAmount;
            }

            // Calculate totalCarExpenses
            totalCarExpenses = (double)c.CarTax + (double)c.CarInsurance + (double)c.Maintenance +
                               (double)c.FuelAmount + (double)c.NctAmount + (double)c.TollChargeAmount +
                               (double)c.CarExpenseOtherAmount;

            ViewBag.TotalCarExpenses = totalCarExpenses;
            //-----------------------------------------------------------------------------------------------
            //-----------------------------------------------------------------------------------------------
            //-----------------------------------------------------------------------------------------------

            // ***************** HOUSEHOLD EXPENSES *****************
            HouseholdExpense h = new HouseholdExpense();
            h = db.HouseholdExpenses.Where(house => house.BudgetId == id).SingleOrDefault();

            double totalHouseholdExpenses = 0;

            ViewBag.RentAmount = h.RentAmount;
            if (h.RentAmount == null)
            {
                // set initial amount to zero
                h.RentAmount = 0;
                ViewBag.RentAmount = h.RentAmount;
            }
            else
            {
                // otherwise set RentAmount to user input
                ViewBag.RentAmount = h.RentAmount;
            }

            ViewBag.GroceryAmount = h.GroceryAmount;
            if (h.GroceryAmount == null)
            {
                // set initial amount to zero
                h.GroceryAmount = 0;
                ViewBag.GroceryAmount = h.GroceryAmount;
            }
            else
            {
                // otherwise set GroceryAmount to user input
                ViewBag.GroceryAmount = h.GroceryAmount;
            }

            ViewBag.ClothingAmount = h.ClothingAmount;
            if (h.ClothingAmount == null)
            {
                // set initial amount to zero
                h.ClothingAmount = 0;
                ViewBag.ClothingAmount = h.ClothingAmount;
            }
            else
            {
                // otherwise set ClothingAmount to user input
                ViewBag.ClothingAmount = h.ClothingAmount;
            }

            ViewBag.EducationFeesAmount = h.EducationFeesAmount;
            if (h.EducationFeesAmount == null)
            {
                // set initial amount to zero
                h.EducationFeesAmount = 0;
                ViewBag.EducationFeesAmount = h.EducationFeesAmount;
            }
            else
            {
                // otherwise set EducationFeesAmount to user input
                ViewBag.EducationFeesAmount = h.EducationFeesAmount;
            }

            ViewBag.SchoolBooksAmount = h.SchoolBooksAmount;
            if (h.SchoolBooksAmount == null)
            {
                // set initial amount to zero
                h.SchoolBooksAmount = 0;
                ViewBag.SchoolBooksAmount = h.SchoolBooksAmount;
            }
            else
            {
                // otherwise set SchoolBooksAmount to user input
                ViewBag.SchoolBooksAmount = h.SchoolBooksAmount;
            }

            ViewBag.MedicalBillAmount = h.MedicalBillAmount;
            if (h.MedicalBillAmount == null)
            {
                // set initial amount to zero
                h.MedicalBillAmount = 0;
                ViewBag.MedicalBillAmount = h.MedicalBillAmount;
            }
            else
            {
                // otherwise set MedicalBillAmount to user input
                ViewBag.MedicalBillAmount = h.MedicalBillAmount;
            }

            ViewBag.HouseholdInsuranceAmount = h.HouseholdInsuranceAmount;
            if (h.HouseholdInsuranceAmount == null)
            {
                // set initial amount to zero
                h.HouseholdInsuranceAmount = 0;
                ViewBag.HouseholdInsuranceAmount = h.HouseholdInsuranceAmount;
            }
            else
            {
                // otherwise set HouseholdInsuranceAmount to user input
                ViewBag.HouseholdInsuranceAmount = h.HouseholdInsuranceAmount;
            }

            ViewBag.HouseholdMaintenanceAmount = h.HouseholdMaintenanceAmount;
            if (h.HouseholdMaintenanceAmount == null)
            {
                // set initial amount to zero
                h.HouseholdMaintenanceAmount = 0;
                ViewBag.HouseholdMaintenanceAmount = h.HouseholdMaintenanceAmount;
            }
            else
            {
                // otherwise set HouseholdMaintenanceAmount to user input
                ViewBag.HouseholdMaintenanceAmount = h.HouseholdMaintenanceAmount;
            }

            ViewBag.HouseholdOtherAmount = h.HouseholdOtherAmount;
            if (h.HouseholdOtherAmount == null)
            {
                // set initial amount to zero
                h.HouseholdOtherAmount = 0;
                ViewBag.HouseholdOtherAmount = h.HouseholdOtherAmount;
            }
            else
            {
                // otherwise set HouseholdOtherAmount to user input
                ViewBag.HouseholdOtherAmount = h.HouseholdOtherAmount;
            }

            // Calculate totalHouseholdExpenses
            totalHouseholdExpenses = (double)h.RentAmount + (double)h.GroceryAmount + (double)h.ClothingAmount +
                                     (double)h.EducationFeesAmount + (double)h.SchoolBooksAmount + (double)h.MedicalBillAmount +
                                     (double)h.HouseholdInsuranceAmount + (double)h.HouseholdMaintenanceAmount +
                                     (double)h.HouseholdOtherAmount;

            // Summary view for Household Expenses Subtotal
            ViewBag.TotalHouseholdExpenses = totalHouseholdExpenses;
            //-----------------------------------------------------------------------------------------------
            //-----------------------------------------------------------------------------------------------
            //-----------------------------------------------------------------------------------------------

            // ***************** PERSONAL EXPENSES *****************
            PersonalExpense pe = new PersonalExpense();
            pe = db.PersonalExpenses.Where(personal => personal.BudgetId == id).SingleOrDefault();

            double totalPersonalExpenses = 0;

            ViewBag.SocialAmount = pe.SocialAmount;
            if (pe.SocialAmount == null)
            {
                // set initial amount to zero
                pe.SocialAmount = 0;
                ViewBag.SocialAmount = pe.SocialAmount;
            }
            else
            {
                // otherwise set SocialAmount to user input
                ViewBag.SocialAmount = pe.SocialAmount;
            }

            ViewBag.GymMembershipAmount = pe.GymMembershipAmount;
            if (pe.GymMembershipAmount == null)
            {
                // set initial amount to zero
                pe.GymMembershipAmount = 0;
                ViewBag.GymMembershipAmount = pe.GymMembershipAmount;
            }
            else
            {
                // otherwise set GymMembershipAmount to user input
                ViewBag.GymMembershipAmount = pe.GymMembershipAmount;
            }

            ViewBag.SportsFeeAmount = pe.SportsFeeAmount;
            if (pe.SportsFeeAmount == null)
            {
                // set initial amount to zero
                pe.SportsFeeAmount = 0;
                ViewBag.SportsFeeAmount = pe.SportsFeeAmount;
            }
            else
            {
                // otherwise set SportsFeeAmount to user input
                ViewBag.SportsFeeAmount = pe.SportsFeeAmount;
            }

            ViewBag.HolidayAmount = pe.HolidayAmount;
            if (pe.HolidayAmount == null)
            {
                // set initial amount to zero
                pe.HolidayAmount = 0;
                ViewBag.HolidayAmount = pe.HolidayAmount;
            }
            else
            {
                // otherwise set HolidayAmount to user input
                ViewBag.HolidayAmount = pe.HolidayAmount;
            }

            ViewBag.SavingsAmount = pe.SavingsAmount;
            if (pe.SavingsAmount == null)
            {
                // set initial amount to zero
                pe.SavingsAmount = 0;
                ViewBag.SavingsAmount = pe.SavingsAmount;
            }
            else
            {
                // otherwise set SavingsAmount to user input
                ViewBag.SavingsAmount = pe.SavingsAmount;
            }

            ViewBag.LoanRepaymentAmount = pe.LoanRepaymentAmount;
            if (pe.LoanRepaymentAmount == null)
            {
                // set initial amount to zero
                pe.LoanRepaymentAmount = 0;
                ViewBag.LoanRepaymentAmount = pe.LoanRepaymentAmount;
            }
            else
            {
                // otherwise set LoanRepaymentAmount to user input
                ViewBag.LoanRepaymentAmount = pe.LoanRepaymentAmount;
            }

            ViewBag.PersonalExpenseOther = pe.PersonalExpenseOther;
            if (pe.PersonalExpenseOther == null)
            {
                // set initial amount to zero
                pe.PersonalExpenseOther = 0;
                ViewBag.PersonalExpenseOther = pe.PersonalExpenseOther;
            }
            else
            {
                // otherwise set PersonalExpenseOther to user input
                ViewBag.PersonalExpenseOther = pe.PersonalExpenseOther;
            }

            totalPersonalExpenses = (double)pe.SocialAmount + (double)pe.GymMembershipAmount + (double)pe.SportsFeeAmount +
                                    (double)pe.HolidayAmount + (double)pe.SavingsAmount + (double)pe.LoanRepaymentAmount +
                                    (double)pe.PersonalExpenseOther;


            // Summary view for Personal Expenses Subtotal
            ViewBag.TotalPersonalExpenses = totalPersonalExpenses;
            //-----------------------------------------------------------------------------------------------
            //-----------------------------------------------------------------------------------------------
            //-----------------------------------------------------------------------------------------------
            // ***************** TRAVEL EXPENSES *****************
            TravelExpense t = new TravelExpense();
            t = db.TravelExpenses.Where(travel => travel.BudgetId == id).SingleOrDefault();

            double totalTravelExpenses = 0;

            ViewBag.BusAmount = t.BusAmount;
            if (t.BusAmount == null)
            {
                // set initial amount to zero
                t.BusAmount = 0;
                ViewBag.BusAmount = t.BusAmount;
            }
            else
            {
                // otherwise set BusAmount to user input
                ViewBag.BusAmount = t.BusAmount;
            }

            ViewBag.LuasAmount = t.LuasAmount;
            if (t.LuasAmount == null)
            {
                // set initial amount to zero
                t.LuasAmount = 0;
                ViewBag.LuasAmount = t.LuasAmount;
            }
            else
            {
                // otherwise set LuasAmount to user input
                ViewBag.LuasAmount = t.LuasAmount;
            }

            ViewBag.TaxiAmount = t.TaxiAmount;
            if (t.TaxiAmount == null)
            {
                // set initial amount to zero
                t.TaxiAmount = 0;
                ViewBag.TaxiAmount = t.TaxiAmount;
            }
            else
            {
                // otherwise set TaxiAmount to user input
                ViewBag.TaxiAmount = t.TaxiAmount;
            }

            ViewBag.TrainAmount = t.TrainAmount;
            if (t.TrainAmount == null)
            {
                // set initial amount to zero
                t.TrainAmount = 0;
                ViewBag.TrainAmount = t.TrainAmount;
            }
            else
            {
                // otherwise set TrainAmount to user input
                ViewBag.TrainAmount = t.TrainAmount;
            }

            ViewBag.TravelOther = t.TravelOther;
            if (t.TravelOther == null)
            {
                // set initial amount to zero
                t.TravelOther = 0;
                ViewBag.TravelOther = t.TravelOther;
            }
            else
            {
                // otherwise set TravelOther to user input
                ViewBag.TravelOther = t.TravelOther;
            }

            totalTravelExpenses = (double)t.BusAmount + (double)t.LuasAmount + (double)t.TaxiAmount +
                                  (double)t.TrainAmount + (double)t.TravelOther;

            // Summary view for Travel Expenses Subtotal
            ViewBag.TotalTravelExpenses = totalTravelExpenses;
            //-----------------------------------------------------------------------------------------------
            //-----------------------------------------------------------------------------------------------
            //-----------------------------------------------------------------------------------------------

            // ***************** UTILITY BILL EXPENSES *****************
            UtilityBillExpense u = new UtilityBillExpense();
            u = db.UtilityBillExpenses.Where(utilityBill => utilityBill.BudgetId == id).SingleOrDefault();

            double totalUtilityBillExpenses = 0;

            ViewBag.Electricity = u.Electricity;
            if (u.Electricity == null)
            {
                // set initial amount to zero
                u.Electricity = 0;
                ViewBag.Electricity = u.Electricity;
            }
            else
            {
                // otherwise set Electricity to user input
                ViewBag.Electricity = u.Electricity;
            }

            ViewBag.Gas = u.Gas;
            if (u.Gas == null)
            {
                // set initial amount to zero
                u.Gas = 0;
                ViewBag.Gas = u.Gas;
            }
            else
            {
                // otherwise set Gas to user input
                ViewBag.Gas = u.Gas;
            }

            ViewBag.RefuseCollection = u.RefuseCollection;
            if (u.RefuseCollection == null)
            {
                // set initial amount to zero
                u.RefuseCollection = 0;
                ViewBag.RefuseCollection = u.RefuseCollection;
            }
            else
            {
                // otherwise set RefuseCollection to user input
                ViewBag.RefuseCollection = u.RefuseCollection;
            }

            ViewBag.IrishWater = u.IrishWater;
            if (u.IrishWater == null)
            {
                // set initial amount to zero
                u.IrishWater = 0;
                ViewBag.IrishWater = u.IrishWater;
            }
            else
            {
                // otherwise set IrishWater to user input
                ViewBag.IrishWater = u.IrishWater;
            }

            ViewBag.TVAmount = u.TVAmount;
            if (u.TVAmount == null)
            {
                // set initial amount to zero
                u.TVAmount = 0;
                ViewBag.TVAmount = u.TVAmount;
            }
            else
            {
                // otherwise set TVAmount to user input
                ViewBag.TVAmount = u.TVAmount;
            }

            ViewBag.PhoneBillAmount = u.PhoneBillAmount;
            if (u.PhoneBillAmount == null)
            {
                // set initial amount to zero
                u.PhoneBillAmount = 0;
                ViewBag.PhoneBillAmount = u.PhoneBillAmount;
            }
            else
            {
                // otherwise set PhoneBillAmount to user input
                ViewBag.PhoneBillAmount = u.PhoneBillAmount;
            }

            ViewBag.BroadbandAmount = u.BroadbandAmount;
            if (u.BroadbandAmount == null)
            {
                // set initial amount to zero
                u.BroadbandAmount = 0;
                ViewBag.BroadbandAmount = u.BroadbandAmount;
            }
            else
            {
                // otherwise set BroadbandAmount to user input
                ViewBag.BroadbandAmount = u.BroadbandAmount;
            }

            ViewBag.UtilityBillExpenseAmount = u.UtilityBillExpenseAmount;
            if (u.UtilityBillExpenseAmount == null)
            {
                // set initial amount to zero
                u.UtilityBillExpenseAmount = 0;
                ViewBag.UtilityBillExpenseAmount = u.UtilityBillExpenseAmount;
            }
            else
            {
                // otherwise set UtilityBillExpenseAmount to user input
                ViewBag.UtilityBillExpenseAmount = u.UtilityBillExpenseAmount;
            }

            totalUtilityBillExpenses = (double)u.Electricity + (double)u.Gas + (double)u.RefuseCollection +
                                       (double)u.IrishWater + (double)u.TVAmount + (double)u.PhoneBillAmount +
                                       (double)u.BroadbandAmount + (double)u.UtilityBillExpenseAmount;

            // Summary view for Utility Bill Subtotal
            ViewBag.TotalUtilityBillExpenses = totalUtilityBillExpenses;

            // SUBTOTAL CALCULATIONS
            // TotalIncome will be same as calculated above
            // TotalExpenses
            double totalExpenses = 0;
            totalExpenses = (double)totalCarExpenses + (double)totalHouseholdExpenses + (double)totalPersonalExpenses +
                (double)totalTravelExpenses + (double)totalUtilityBillExpenses;
            ViewBag.TotalExpenses = totalExpenses;

            // BUDGET BALANCE CALCULATION
            double budgetBalance = 0;
            budgetBalance = (double)totalIncome - (double)totalExpenses;
            ViewBag.BudgetBalance = budgetBalance;
            
            return View(b);
        }        


        // Budget Forecast View
        public ActionResult Forecast(int? id)
        {
            // Calculation here
            Budget b = new Budget();
            b = db.Budgets.Where(p => p.BudgetId == id).SingleOrDefault();
            


            return View();
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}