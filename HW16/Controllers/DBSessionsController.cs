using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using HW16.Models;
using System.IO;

namespace HW16.Controllers
{
    public class DBSessionsController : Controller
    {
        private SessionsModel db = new SessionsModel();

        // GET: DBSessions
        public ActionResult Index()
        {
            return View(db.DBSessions.ToList());
        }

        // GET: DBSessions/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DBSession dBSession = db.DBSessions.Find(id);
            if (dBSession == null)
            {
                return HttpNotFound();
            }
            return View(dBSession);
        }

        // GET: DBSessions/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: DBSessions/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "StudentID,StudentName,BirthOfDate,Addresses,Picture")] DBSession dBSession,HttpPostedFileBase file)
        {
            if (file.ContentLength > 0)
            {
                string _FileName = Path.GetFileName(file.FileName);
                string _path = Path.Combine(Server.MapPath("~/Image"), _FileName);
                file.SaveAs(_path);
            }
            if (ModelState.IsValid)
            {
                db.DBSessions.Add(dBSession);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(dBSession);
        }

        // GET: DBSessions/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DBSession dBSession = db.DBSessions.Find(id);
            if (dBSession == null)
            {
                return HttpNotFound();
            }
            return View(dBSession);
        }

        // POST: DBSessions/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "StudentID,StudentName,BirthOfDate,Addresses,Picture")] DBSession dBSession, HttpPostedFileBase file)
        {
            if (ModelState.IsValid)
            {
                db.Entry(dBSession).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(dBSession);
        }

        // GET: DBSessions/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DBSession dBSession = db.DBSessions.Find(id);
            if (dBSession == null)
            {
                return HttpNotFound();
            }
            return View(dBSession);
        }

        // POST: DBSessions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            DBSession dBSession = db.DBSessions.Find(id);
            db.DBSessions.Remove(dBSession);
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
