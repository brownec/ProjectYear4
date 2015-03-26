using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using BudgetCalculator.Models;
using ProjectYear4.Models;

namespace BudgetCalculator.Controllers
{
    public class UtilityBillExpensesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: UtilityBillExpenses
        public ActionResult Index()
        {
            var utilityBillExpenses = db.UtilityBillExpenses.Include(u => u.Budget);
            return View(utilityBillExpenses.ToList());
        }

        // GET: UtilityBillExpenses/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UtilityBillExpense utilityBillExpense = db.UtilityBillExpenses.Find(id);
            if (utilityBillExpense == null)
            {
                return HttpNotFound();
            }
            return View(utilityBillExpense);
        }

        // GET: UtilityBillExpenses/Create
        public ActionResult Create(int id)
        {
            // foreign key id attribute
            UtilityBillExpense ue = new UtilityBillExpense();
            ue.BudgetId = id;
            // ViewBag.BudgetId = new SelectList(db.Budgets, "BudgetId", "BudgetName");
            return View(ue);
        }

        // POST: UtilityBillExpenses/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "UtilityBillExpenseId,Electricity,Gas,RefuseCollection,IrishWater,TVLicenseAmount,PhoneBillAmount,BroadbandAmount,UtilityBillExpenseAmount,BudgetId")] UtilityBillExpense utilityBillExpense, int id)
        {
            // foreign key id attribute
            utilityBillExpense.BudgetId = id;
            if (ModelState.IsValid)
            {
                db.UtilityBillExpenses.Add(utilityBillExpense);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.BudgetId = new SelectList(db.Budgets, "BudgetId", "BudgetName", utilityBillExpense.BudgetId);
            return View(utilityBillExpense);
        }

        // GET: UtilityBillExpenses/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UtilityBillExpense utilityBillExpense = db.UtilityBillExpenses.Find(id);
            if (utilityBillExpense == null)
            {
                return HttpNotFound();
            }
            ViewBag.BudgetId = new SelectList(db.Budgets, "BudgetId", "BudgetName", utilityBillExpense.BudgetId);
            return View(utilityBillExpense);
        }

        // POST: UtilityBillExpenses/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "UtilityBillExpenseId,Electricity,Gas,RefuseCollection,IrishWater,TVLicenseAmount,PhoneBillAmount,BroadbandAmount,UtilityBillExpenseAmount,BudgetId")] UtilityBillExpense utilityBillExpense)
        {
            if (ModelState.IsValid)
            {
                db.Entry(utilityBillExpense).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.BudgetId = new SelectList(db.Budgets, "BudgetId", "BudgetName", utilityBillExpense.BudgetId);
            return View(utilityBillExpense);
        }

        // GET: UtilityBillExpenses/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UtilityBillExpense utilityBillExpense = db.UtilityBillExpenses.Find(id);
            if (utilityBillExpense == null)
            {
                return HttpNotFound();
            }
            return View(utilityBillExpense);
        }

        // POST: UtilityBillExpenses/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            UtilityBillExpense utilityBillExpense = db.UtilityBillExpenses.Find(id);
            db.UtilityBillExpenses.Remove(utilityBillExpense);
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
