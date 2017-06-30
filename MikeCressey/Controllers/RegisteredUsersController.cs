﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MikeCressey.Models;

namespace MikeCressey.Controllers
{
    [Authorize(Roles = "Admin")]
    public class RegisteredUsersController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: RegisteredUsers
        public ActionResult Index()
        {
            var registeredUsers = db.RegisteredUsers.Include(r => r.User).OrderByDescending(c => c.RegisterDate);
            return View(registeredUsers.ToList());
        }

        // GET: RegisteredUsers/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RegisteredUser registeredUser = db.RegisteredUsers.Find(id);
            if (registeredUser == null)
            {
                return HttpNotFound();
            }
            return View(registeredUser);
        }

        // GET: RegisteredUsers/Create
        public ActionResult Create()
        {
           // ViewBag.ApplicationUserId = new SelectList(db.ApplicationUsers, "Id", "Email");
            return View();
        }

        // POST: RegisteredUsers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,FirstName,LastName,ApplicationUserId")] RegisteredUser registeredUser)
        {
            if (ModelState.IsValid)
            {
                //registeredUser.RegisterDate = DateTime.Now.ToUniversalTime();
                db.RegisteredUsers.Add(registeredUser);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

 //           ViewBag.ApplicationUserId = new SelectList(db.ApplicationUsers, "Id", "Email", registeredUser.ApplicationUserId);
            return View(registeredUser);
        }

        // GET: RegisteredUsers/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RegisteredUser registeredUser = db.RegisteredUsers.Find(id);
            if (registeredUser == null)
            {
                return HttpNotFound();
            }
//            ViewBag.ApplicationUserId = new SelectList(db.ApplicationUsers, "Id", "Email", registeredUser.ApplicationUserId);
            return View(registeredUser);
        }

        // POST: RegisteredUsers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,FirstName,LastName,ApplicationUserId")] RegisteredUser registeredUser)
        {
            if (ModelState.IsValid)
            {
                db.Entry(registeredUser).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
//            ViewBag.ApplicationUserId = new SelectList(db.ApplicationUsers, "Id", "Email", registeredUser.ApplicationUserId);
            return View(registeredUser);
        }

        // GET: RegisteredUsers/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RegisteredUser registeredUser = db.RegisteredUsers.Find(id);
            if (registeredUser == null)
            {
                return HttpNotFound();
            }
            return View(registeredUser);
        }

        // POST: RegisteredUsers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            RegisteredUser registeredUser = db.RegisteredUsers.Find(id);
            db.RegisteredUsers.Remove(registeredUser);
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
