using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ProjectYear4.Models;

namespace ProjectYear4.Controllers
{
    public class HouseholdExpensesController : Controller
    {
        private MyDBConnection db = new MyDBConnection();

        // GET: HouseholdExpenses
        public ActionResult Index()
        {
            var householdExpense = db.HouseholdExpense.Include(h => h.Budget);
            return View(householdExpense.ToList());
        }

        // GET: HouseholdExpenses/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HouseholdExpense householdExpense = db.HouseholdExpense.Find(id);
            if (householdExpense == null)
            {
                return HttpNotFound();
            }
            return View(householdExpense);
        }

        // GET: HouseholdExpenses/Create
        public ActionResult Create(int id)
        {
            // foreign key id attribute
            HouseholdExpense he = new HouseholdExpense();
            he.BudgetId = id;
            // ViewBag.BudgetId = new SelectList(db.Budget, "BudgetId", "BudgetId");
            return View(he);
        }

        // POST: HouseholdExpenses/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "HouseholdExpenseId,RentType,RentAmount,GroceryAmount,ClothingAmount,EducationFeesAmount,SchoolBooksAmount,MedicalBillAmount,HouseholdOtherAmount,BudgetId")] HouseholdExpense householdExpense, int id)
        {
            // foreign key id attribute
            householdExpense.BudgetId = id;
            if (ModelState.IsValid)
            {
                db.HouseholdExpense.Add(householdExpense);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.BudgetId = new SelectList(db.Budget, "BudgetId", "BudgetId", householdExpense.BudgetId);
            return View(householdExpense);
        }

        // GET: HouseholdExpenses/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HouseholdExpense householdExpense = db.HouseholdExpense.Find(id);
            if (householdExpense == null)
            {
                return HttpNotFound();
            }
            ViewBag.BudgetId = new SelectList(db.Budget, "BudgetId", "BudgetId", householdExpense.BudgetId);
            return View(householdExpense);
        }

        // POST: HouseholdExpenses/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "HouseholdExpenseId,RentType,RentAmount,GroceryAmount,ClothingAmount,EducationFeesAmount,SchoolBooksAmount,MedicalBillAmount,HouseholdOtherAmount,BudgetId")] HouseholdExpense householdExpense)
        {
            if (ModelState.IsValid)
            {
                db.Entry(householdExpense).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.BudgetId = new SelectList(db.Budget, "BudgetId", "BudgetId", householdExpense.BudgetId);
            return View(householdExpense);
        }

        // GET: HouseholdExpenses/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HouseholdExpense householdExpense = db.HouseholdExpense.Find(id);
            if (householdExpense == null)
            {
                return HttpNotFound();
            }
            return View(householdExpense);
        }

        // POST: HouseholdExpenses/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            HouseholdExpense householdExpense = db.HouseholdExpense.Find(id);
            db.HouseholdExpense.Remove(householdExpense);
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
