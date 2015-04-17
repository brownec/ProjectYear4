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
    public class CarExpensesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: CarExpenses
        public ActionResult Index()
        {
            var carExpenses = db.CarExpenses.Include(c => c.Budget);
            return View(carExpenses.ToList());
        }

        // GET: CarExpenses/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CarExpense carExpense = db.CarExpenses.Find(id);
            if (carExpense == null)
            {
                return HttpNotFound();
            }
            return View(carExpense);
        }

        // GET: CarExpenses/Create
        public ActionResult Create(int id)
        {
            // foreign key id attribute
            CarExpense ce = new CarExpense();
            ce.BudgetId = id;
            // ViewBag.BudgetId = new SelectList(db.Budgets, "BudgetId", "BudgetName");
            return View(ce);
        }

        // POST: CarExpenses/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CarExpenseId,CarTax,CarInsurance,Maintenance,FuelType,FuelAmount,NctTest,NctAmount,TollChargeAmount,CarExpenseOtherAmount,TotalCarExpenses,BudgetId")] CarExpense carExpense, int id)
        {
            if (ModelState.IsValid)
            {
                // foreign key id attribute
               
                
                carExpense.BudgetId=id;
                carExpense.TotalCarExpenses = 0;
                db.CarExpenses.Add(carExpense);
                // carExpense.TotalCarExpenses = popoulateExpense(carExpense,id);
                db.SaveChanges();
                
                 return RedirectToAction("Index");
                //return RedirectToAction("popoulateExpense", carExpense);
            }

            ViewBag.BudgetId = new SelectList(db.Budgets, "BudgetId", "BudgetName", carExpense.BudgetId);
            return View(carExpense);
        }

        public double popoulateExpense(CarExpense carExpense)
        {
            CarExpense c = new CarExpense();
                c = carExpense;
            // c = db.CarExpenses.Where(car => car.BudgetId == id).SingleOrDefault();

            double totalCarExpenses = 0;

            // ---------- CarTax ----------
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

            // ---------- CarInsurance ----------
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

            // ---------- Maintenance ----------
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

            // ---------- FuelAmount ----------
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

            // ---------- NctAmount ----------
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

            // ---------- TollChargeAmount ----------
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

            // ---------- CarExpenseOtherAmount ----------
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
            c.TotalCarExpenses = (double)c.CarTax + (double)c.CarInsurance + (double)c.Maintenance +
                               (double)c.FuelAmount + (double)c.NctAmount + (double)c.TollChargeAmount +
                               (double)c.CarExpenseOtherAmount;

             return (double) c.TotalCarExpenses;
            //return RedirectToAction("Index");
        }

        // GET: CarExpenses/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CarExpense carExpense = db.CarExpenses.Find(id);
            if (carExpense == null)
            {
                return HttpNotFound();
            }
            ViewBag.BudgetId = new SelectList(db.Budgets, "BudgetId", "BudgetName", carExpense.BudgetId);
            return View(carExpense);
        }

        // POST: CarExpenses/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CarExpenseId,CarTax,CarInsurance,Maintenance,FuelType,FuelAmount,NctTest,NctAmount,TollChargeAmount,CarExpenseOtherAmount,TotalCarExpenses,BudgetId")] CarExpense carExpense)
        {
            if (ModelState.IsValid)
            {
                db.Entry(carExpense).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.BudgetId = new SelectList(db.Budgets, "BudgetId", "BudgetName", carExpense.BudgetId);
            return View(carExpense);
        }

        // GET: CarExpenses/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CarExpense carExpense = db.CarExpenses.Find(id);
            if (carExpense == null)
            {
                return HttpNotFound();
            }
            return View(carExpense);
        }

        // POST: CarExpenses/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CarExpense carExpense = db.CarExpenses.Find(id);
            db.CarExpenses.Remove(carExpense);
            db.SaveChanges();
            return RedirectToAction("Index");
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
