using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using VM.DataAccessLayer.EDM;

namespace VirtualManager.Controllers.Accounts
{
    public class UserAssociationController : Controller
    {
        private VirtualManagerDatabaseContainer db = new VirtualManagerDatabaseContainer();

        // GET: UserAssociation
        public async Task<ActionResult> Index()
        {
            return View(await db.UserAssociationTable.ToListAsync());
        }

        // GET: UserAssociation/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UserAssociationTable userAssociationTable = await db.UserAssociationTable.FindAsync(id);
            if (userAssociationTable == null)
            {
                return HttpNotFound();
            }
            return View(userAssociationTable);
        }

        // GET: UserAssociation/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: UserAssociation/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id,ChiefUserGuid,EmployeeGuid")] UserAssociationTable userAssociationTable)
        {
            if (ModelState.IsValid)
            {
                db.UserAssociationTable.Add(userAssociationTable);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(userAssociationTable);
        }

        // GET: UserAssociation/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UserAssociationTable userAssociationTable = await db.UserAssociationTable.FindAsync(id);
            if (userAssociationTable == null)
            {
                return HttpNotFound();
            }
            return View(userAssociationTable);
        }

        // POST: UserAssociation/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,ChiefUserGuid,EmployeeGuid")] UserAssociationTable userAssociationTable)
        {
            if (ModelState.IsValid)
            {
                db.Entry(userAssociationTable).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(userAssociationTable);
        }

        // GET: UserAssociation/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UserAssociationTable userAssociationTable = await db.UserAssociationTable.FindAsync(id);
            if (userAssociationTable == null)
            {
                return HttpNotFound();
            }
            return View(userAssociationTable);
        }

        // POST: UserAssociation/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            UserAssociationTable userAssociationTable = await db.UserAssociationTable.FindAsync(id);
            db.UserAssociationTable.Remove(userAssociationTable);
            await db.SaveChangesAsync();
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
