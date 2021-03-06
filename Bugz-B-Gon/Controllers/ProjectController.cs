﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Bugz_B_Gon.Models;

namespace Bugz_B_Gon.Controllers
{
    public class ProjectController : Controller
    {
        private ProjectDBContext db = new ProjectDBContext();

        // GET: ProjectModels
        public ActionResult Index()
        {
            return View(db.Projects.ToList());
        }

        // GET: ProjectModels/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProjectModel projectModel = db.Projects.Find(id);
            if (projectModel == null)
            {
                return HttpNotFound();
            }
            return View(projectModel);
        }

        // GET: ProjectModels/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ProjectModels/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,ProjectName,Comments,Status,Date")] ProjectModel projectModel)
        {
            if (ModelState.IsValid)
            {
                db.Projects.Add(projectModel);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(projectModel);
        }

        // GET: ProjectModels/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProjectModel projectModel = db.Projects.Find(id);
            if (projectModel == null)
            {
                return HttpNotFound();
            }
            return View(projectModel);
        }

        // POST: ProjectModels/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,ProjectName,Comments,Status,Date")] ProjectModel projectModel)
        {
            if (ModelState.IsValid)
            {
                db.Entry(projectModel).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(projectModel);
        }

        // GET: ProjectModels/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProjectModel projectModel = db.Projects.Find(id);
            if (projectModel == null)
            {
                return HttpNotFound();
            }
            return View(projectModel);
        }

        // POST: ProjectModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ProjectModel projectModel = db.Projects.Find(id);
            db.Projects.Remove(projectModel);
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
