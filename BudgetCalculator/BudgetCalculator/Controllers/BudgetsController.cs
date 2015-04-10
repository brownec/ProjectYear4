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
            
            Income i = new Income();
            i = db.Incomes.Where(inc => inc.BudgetId == id).SingleOrDefault();
            //var total = b.Income.Where(t => t.IncomeId == id).SingleOrDefault();
            double totalIncome = 0;
            ViewBag.PrimaryIncomeAmount = i.PrimaryIncomeAmount;

            
            if(i.AdditionalIncomeAmount == null)
            {
                i.AdditionalIncomeAmount = 0;
                ViewBag.AdditionalIncomeAmount = i.AdditionalIncomeAmount;
            }
            else
            {
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

            CarExpense c = new CarExpense();
            c = db.CarExpenses.Where(car => car.BudgetId == id).SingleOrDefault();
            ViewBag.CarTax = c.CarTax;
            ViewBag.CarInsurance = c.CarInsurance;
            ViewBag.Maintenance = c.Maintenance;
            ViewBag.FuelAmount = c.FuelAmount;
            ViewBag.NctAmount = c.NctAmount;
            ViewBag.TollChargeAmount = c.TollChargeAmount;
            ViewBag.CarExpenseOtherAmount = c.CarExpenseOtherAmount;

            HouseholdExpense h = new HouseholdExpense();
            h = db.HouseholdExpenses.Where(house => house.BudgetId == id).SingleOrDefault();
            ViewBag.RentAmount = h.RentAmount;
            ViewBag.GroceryAmount = h.GroceryAmount;
            ViewBag.ClothingAmount = h.ClothingAmount;
            ViewBag.EducationFeesAmount = h.EducationFeesAmount;
            ViewBag.SchoolBooksAmount = h.SchoolBooksAmount;
            ViewBag.MedicalBillAmount = h.MedicalBillAmount;
            ViewBag.HouseholdInsuranceAmount = h.HouseholdInsuranceAmount;
            ViewBag.HouseholdMaintenanceAmount = h.HouseholdMaintenanceAmount;
            ViewBag.HouseholdOtherAmount = h.HouseholdOtherAmount;

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