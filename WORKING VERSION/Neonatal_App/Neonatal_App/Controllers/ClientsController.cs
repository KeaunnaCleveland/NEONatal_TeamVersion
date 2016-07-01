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
    public class ClientsController : Controller
    {
        private Neonatal_App_DB db = new Neonatal_App_DB();

        // GET: Clients
        public ActionResult Index(string searchString)
        {
            var clients = db.Clients.Include(c => c.AspNetUser);
            clients = from m in db.Clients
                      orderby m.last_name, m.first_name
                      select m;
            if (!String.IsNullOrEmpty(searchString))
            {
                clients = clients.Where(s => s.first_name.Contains(searchString));
            }
            return View(clients);
        }

        // GET: Clients/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Client client = db.Clients.Find(id);
            if (client == null)
            {
                return HttpNotFound();
            }
            return View(client);
        }

        // GET: Clients/Create
        public ActionResult Create()
        {
            ViewBag.AspNetUsers_id = new SelectList(db.AspNetUsers, "Id", "Email");
            return PartialView();
        }

        // POST: Clients/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,pin,first_name,last_name,DOB,ethnicity,street_number,street_name,city,zip_code,county,ward,phone,email,AspNetUsers_id")] Client client)
        {
            if (ModelState.IsValid)
            {
                db.Clients.Add(client);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.AspNetUsers_id = new SelectList(db.AspNetUsers, "Id", "Email", client.AspNetUsers_id);
            return PartialView(client);
        }

        // GET: Clients/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Client client = db.Clients.Find(id);
            if (client == null)
            {
                return HttpNotFound();
            }
            ViewBag.AspNetUsers_id = new SelectList(db.AspNetUsers, "Id", "Email", client.AspNetUsers_id);
            return PartialView(client);
        }

        // POST: Clients/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,first_name,last_name,DOB,ethnicity,street_number,street_name,city,zip_code,county,ward,phone,email,AspNetUsers_id")] Client client)
        {
            if (ModelState.IsValid)
            {
                db.Entry(client).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.AspNetUsers_id = new SelectList(db.AspNetUsers, "Id", "Email", client.AspNetUsers_id);
            return PartialView(client);
        }

        // GET: Clients/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Client client = db.Clients.Find(id);
            if (client == null)
            {
                return HttpNotFound();
            }
            return View(client);
        }

        // POST: Clients/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Client client = db.Clients.Find(id);
            db.Clients.Remove(client);
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
