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
            var surveys = new List<Survey>();
            /*var selectSurvey = from m in db.Surveys
                               where m.client_id == m.Client.id
                               select m;*/
            return View(db.Surveys.ToList());

        }

        //GET Surveys/RiskScore/5

        public ActionResult RiskScore(int? id)
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
                // ENTER RISK SCORE CODE HERE!!!

                //QUESTION 1 - RACE
                int risk_Score = 0;

                int race = Convert.ToInt32(survey.Q1_race);

                if (race == 1)
                {
                    risk_Score += 2;
                }
                else
                {
                    risk_Score += 0;
                }
                //QUESTION 2 - Ward
                int ward = Convert.ToInt32(survey.Q2_ward);
                {
                    if (ward == 1)
                    {
                        risk_Score += 53;
                    }
                    else if (ward == 2)
                    {
                        risk_Score += 17; ;
                    }
                    else if (ward == 3)
                    {
                        risk_Score += 18;
                    }
                    else if (ward == 4)
                    {
                        risk_Score += 16;
                    }
                    else if (ward == 5)
                    {
                        risk_Score += 37;
                    }
                    else if (ward == 6)
                    {
                        risk_Score += 15;
                    }
                    else if (ward == 7)
                    {
                        risk_Score += 19;
                    }
                    else if (ward == 8)
                    {
                        risk_Score += 15;
                    }
                    else if (ward == 9)
                    {
                        risk_Score += 33;
                    }
                    else if (ward == 10)
                    {
                        risk_Score += 32;
                    }
                    else if (ward == 11)
                    {
                        risk_Score += 20;
                    }
                    else if (ward == 12)
                    {
                        risk_Score += 21;
                    }
                    else if (ward == 13)
                    {
                        risk_Score += 16;
                    }
                    else if (ward == 14)
                    {
                        risk_Score += 21;
                    }
                    else if (ward == 15)
                    {
                        risk_Score += 38;
                    }
                    else if (ward == 16)
                    {
                        risk_Score += 31;
                    }
                    else if (ward == 17)
                    {
                        risk_Score += 10;
                    }

                    // QUESTION 3 - FIRST CHILD
                    int first_child = Convert.ToInt32(survey.Q3_first_child);

                    if (first_child == 1)
                    {
                        risk_Score += 5;
                    }
                    else
                    {
                        risk_Score += 0;
                    }

                    // QUESTION 4 - PREMATURE BIRTH
                    int prem_birth = Convert.ToInt32(survey.Q4_prem_birth);

                    if (prem_birth == 1)
                    {
                        risk_Score += 5;
                    }
                    else
                    {
                        risk_Score += 0;
                    }

                    // QUESTION 5 - SELF-ALCOHOL
                    int self_alcohol = Convert.ToInt32(survey.Q10_alcohol);

                    if (self_alcohol == 1)
                    {
                        risk_Score += 4;
                    }
                    else
                    {
                        risk_Score += 0;
                    }

                    //calculate risk score
                    survey.risk_score += risk_Score;

                    db.Surveys.Add(survey);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
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
                // ENTER RISK SCORE CODE HERE!!!

                //QUESTION 1 - RACE
                int risk_Score = 0;

                int race = Convert.ToInt32(survey.Q1_race);

                if (race == 1)
                {
                    risk_Score += 2;
                }
                else
                {
                    risk_Score += 0;
                }
                //QUESTION 2 - Ward
                int ward = Convert.ToInt32(survey.Q2_ward);
                {
                    if (ward == 1)
                    {
                        risk_Score += 53;
                    }
                    else if (ward == 2)
                    {
                        risk_Score += 17; ;
                    }
                    else if (ward == 3)
                    {
                        risk_Score += 18;
                    }
                    else if (ward == 4)
                    {
                        risk_Score += 16;
                    }
                    else if (ward == 5)
                    {
                        risk_Score += 37;
                    }
                    else if (ward == 6)
                    {
                        risk_Score += 15;
                    }
                    else if (ward == 7)
                    {
                        risk_Score += 19;
                    }
                    else if (ward == 8)
                    {
                        risk_Score += 15;
                    }
                    else if (ward == 9)
                    {
                        risk_Score += 33;
                    }
                    else if (ward == 10)
                    {
                        risk_Score += 32;
                    }
                    else if (ward == 11)
                    {
                        risk_Score += 20;
                    }
                    else if (ward == 12)
                    {
                        risk_Score += 21;
                    }
                    else if (ward == 13)
                    {
                        risk_Score += 16;
                    }
                    else if (ward == 14)
                    {
                        risk_Score += 21;
                    }
                    else if (ward == 15)
                    {
                        risk_Score += 38;
                    }
                    else if (ward == 16)
                    {
                        risk_Score += 31;
                    }
                    else if (ward == 17)
                    {
                        risk_Score += 10;
                    }

                    // QUESTION 3 - FIRST CHILD
                    int first_child = Convert.ToInt32(survey.Q3_first_child);

                    if (first_child == 1)
                    {
                        risk_Score += 5;
                    }
                    else
                    {
                        risk_Score += 0;
                    }

                    // QUESTION 4 - PREMATURE BIRTH
                    int prem_birth = Convert.ToInt32(survey.Q4_prem_birth);

                    if (prem_birth == 1)
                    {
                        risk_Score += 5;
                    }
                    else
                    {
                        risk_Score += 0;
                    }

                    // QUESTION 5 - SELF-ALCOHOL
                    int self_alcohol = Convert.ToInt32(survey.Q10_alcohol);

                    if (self_alcohol == 1)
                    {
                        risk_Score += 4;
                    }
                    else
                    {
                        risk_Score += 0;
                    }

                    //calculate risk score total
                    survey.risk_score += risk_Score;
                    db.Entry(survey).State = EntityState.Modified;
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
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