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
    public class TravelExpensesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: TravelExpenses
        public ActionResult Index()
        {
            var travelExpenses = db.TravelExpenses.Include(t => t.Budget);
            return View(travelExpenses.ToList());
        }

        // GET: TravelExpenses/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TravelExpense travelExpense = db.TravelExpenses.Find(id);
            if (travelExpense == null)
            {
                return HttpNotFound();
            }
            return View(travelExpense);
        }

        // GET: TravelExpenses/Create
        public ActionResult Create(int id)
        {
            // foreign key id attribute
            TravelExpense te = new TravelExpense();
            te.BudgetId = id;
            // ViewBag.BudgetId = new SelectList(db.Budgets, "BudgetId", "BudgetName");
            return View(te);
        }

        // POST: TravelExpenses/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "TravelExpenseId,BusAmount,LuasAmount,TaxiAmount,TrainAmount,TravelOther,TotalTravelExpenses,BudgetId")] TravelExpense travelExpense, int id)
        {
            // foreign key id attribute
            travelExpense.BudgetId = id;
            if (ModelState.IsValid)
            {
                db.TravelExpenses.Add(travelExpense);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.BudgetId = new SelectList(db.Budgets, "BudgetId", "BudgetName", travelExpense.BudgetId);
            return View(travelExpense);
        }

        // GET: TravelExpenses/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TravelExpense travelExpense = db.TravelExpenses.Find(id);
            if (travelExpense == null)
            {
                return HttpNotFound();
            }
            ViewBag.BudgetId = new SelectList(db.Budgets, "BudgetId", "BudgetName", travelExpense.BudgetId);
            return View(travelExpense);
        }

        // POST: TravelExpenses/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "TravelExpenseId,BusAmount,LuasAmount,TaxiAmount,TrainAmount,TravelOther,TotalTravelExpenses,BudgetId")] TravelExpense travelExpense)
        {
            if (ModelState.IsValid)
            {
                db.Entry(travelExpense).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.BudgetId = new SelectList(db.Budgets, "BudgetId", "BudgetName", travelExpense.BudgetId);
            return View(travelExpense);
        }

        // GET: TravelExpenses/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TravelExpense travelExpense = db.TravelExpenses.Find(id);
            if (travelExpense == null)
            {
                return HttpNotFound();
            }
            return View(travelExpense);
        }

        // POST: TravelExpenses/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TravelExpense travelExpense = db.TravelExpenses.Find(id);
            db.TravelExpenses.Remove(travelExpense);
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
