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
        public ActionResult Create([Bind(Include = "CarExpenseId,CarTax,CarInsurance,Maintenance,FuelType,FuelAmount,NctTest,NctAmount,TollChargeAmount,CarExpenseOtherAmount, BudgetId")] CarExpense carExpense, int id)
        {
            if (ModelState.IsValid)
            {
                // foreign key id attribute
                carExpense.BudgetId=id;
                db.CarExpenses.Add(carExpense);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.BudgetId = new SelectList(db.Budgets, "BudgetId", "BudgetName", carExpense.BudgetId);
            return View(carExpense);
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
        public ActionResult Edit([Bind(Include = "CarExpenseId,CarTax,CarInsurance,Maintenance,FuelType,FuelAmount,NctTest,NctAmount,TollChargeAmount,CarExpenseOtherAmount,BudgetId")] CarExpense carExpense)
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
