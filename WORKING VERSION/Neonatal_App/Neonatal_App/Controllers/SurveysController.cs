using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Neonatal_App.Models;

namespace Neonatal_App.Controllers
{
    public class SurveysController : Controller
    {
        private Neonatal_App_DB db = new Neonatal_App_DB();

        // GET: Surveys
        public ActionResult Index()
        {
            var surveys = db.Surveys.Include(s => s.Client);
            return View(surveys.ToList());
        }

        // GET: Surveys/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Survey survey = db.Surveys.Find(id);
            if (survey == null)
            {
                return HttpNotFound();
            }

            return View(survey);
        }

        // GET: Surveys/Create
        public ActionResult Create()
        {
            ViewBag.client_id = new SelectList(db.Clients, "id", "first_name");
            return View();
        }

        // POST: Surveys/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,client_id,risk_score,Q1_race,Q2_ward,Q3_first_child,Q4_prem_birth,Q5_obgyn,Q6_age,Q7_stress,Q8_smoker,Q9_fam_smoker,Q10_alcohol,Q11_fam_alcohol,Q12_fam_drug,Q13_drug,Q14_safe_nbhood,Q15_safe_home,Q16_illness,Q17_transport,Q18_internet,Q19_mob_internet,Q20_diet,Q21_gov_assist,Q22_rel_income,Q23_education,creation_date,update_date")] Survey survey)
        {
            if (ModelState.IsValid)
            {
                db.Surveys.Add(survey);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.client_id = new SelectList(db.Clients, "id", "first_name", survey.client_id);
            return View(survey);
        }

        // GET: Surveys/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Survey survey = db.Surveys.Find(id);
            if (survey == null)
            {
                return HttpNotFound();
            }
            ViewBag.client_id = new SelectList(db.Clients, "id", "first_name", survey.client_id);
            return View(survey);
        }

        // POST: Surveys/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,client_id,risk_score,Q1_race,Q2_ward,Q3_first_child,Q4_prem_birth,Q5_obgyn,Q6_age,Q7_stress,Q8_smoker,Q9_fam_smoker,Q10_alcohol,Q11_fam_alcohol,Q12_fam_drug,Q13_drug,Q14_safe_nbhood,Q15_safe_home,Q16_illness,Q17_transport,Q18_internet,Q19_mob_internet,Q20_diet,Q21_gov_assist,Q22_rel_income,Q23_education,creation_date,update_date")] Survey survey)
        {
            if (ModelState.IsValid)
            {
                db.Entry(survey).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.client_id = new SelectList(db.Clients, "id", "first_name", survey.client_id);
            return View(survey);
        }

        // GET: Surveys/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Survey survey = db.Surveys.Find(id);
            if (survey == null)
            {
                return HttpNotFound();
            }
            return View(survey);
        }

        // POST: Surveys/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Survey survey = db.Surveys.Find(id);
            db.Surveys.Remove(survey);
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
