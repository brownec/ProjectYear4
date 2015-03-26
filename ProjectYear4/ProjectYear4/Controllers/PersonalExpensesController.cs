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
    public class PersonalExpensesController : Controller
    {
        private MyDBConnection db = new MyDBConnection();

        // GET: PersonalExpenses
        public ActionResult Index()
        {
            var personalExpense = db.PersonalExpense.Include(p => p.Budget);
            return View(personalExpense.ToList());
        }

        // GET: PersonalExpenses/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PersonalExpense personalExpense = db.PersonalExpense.Find(id);
            if (personalExpense == null)
            {
                return HttpNotFound();
            }
            return View(personalExpense);
        }

        // GET: PersonalExpenses/Create
        public ActionResult Create(int id)
        {
            // foreign key id attribute
            PersonalExpense pe = new PersonalExpense();
            pe.BudgetId = id;
            // ViewBag.BudgetId = new SelectList(db.Budget, "BudgetId", "BudgetId");
            return View(pe);
        }

        // POST: PersonalExpenses/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "PersonalExpenseId,SocialAmount,GymMembershipAmount,SportsFeeAmount,HolidayAmount,SavingsAmount,LoanRepaymentAmount,PersonalExpenseOther,BudgetId")] PersonalExpense personalExpense, int id)
        {
            // foreign key id attribute
            personalExpense.BudgetId = id;
            if (ModelState.IsValid)
            {
                db.PersonalExpense.Add(personalExpense);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.BudgetId = new SelectList(db.Budget, "BudgetId", "BudgetId", personalExpense.BudgetId);
            return View(personalExpense);
        }

        // GET: PersonalExpenses/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PersonalExpense personalExpense = db.PersonalExpense.Find(id);
            if (personalExpense == null)
            {
                return HttpNotFound();
            }
            ViewBag.BudgetId = new SelectList(db.Budget, "BudgetId", "BudgetId", personalExpense.BudgetId);
            return View(personalExpense);
        }

        // POST: PersonalExpenses/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "PersonalExpenseId,SocialAmount,GymMembershipAmount,SportsFeeAmount,HolidayAmount,SavingsAmount,LoanRepaymentAmount,PersonalExpenseOther,BudgetId")] PersonalExpense personalExpense)
        {
            if (ModelState.IsValid)
            {
                db.Entry(personalExpense).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.BudgetId = new SelectList(db.Budget, "BudgetId", "BudgetId", personalExpense.BudgetId);
            return View(personalExpense);
        }

        // GET: PersonalExpenses/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PersonalExpense personalExpense = db.PersonalExpense.Find(id);
            if (personalExpense == null)
            {
                return HttpNotFound();
            }
            return View(personalExpense);
        }

        // POST: PersonalExpenses/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            PersonalExpense personalExpense = db.PersonalExpense.Find(id);
            db.PersonalExpense.Remove(personalExpense);
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
