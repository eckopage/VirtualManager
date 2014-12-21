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
    public class ProjectUserAssociateController : Controller
    {
        private VirtualManagerDatabaseContainer db = new VirtualManagerDatabaseContainer();

        // GET: ProjectUserAssociate
        public async Task<ActionResult> Index()
        {
            var projectUserAssociateTable = db.ProjectUserAssociateTable.Include(p => p.AccountTable).Include(p => p.ProjectTable);
            return View(await projectUserAssociateTable.ToListAsync());
        }

        // GET: ProjectUserAssociate/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProjectUserAssociateTable projectUserAssociateTable = await db.ProjectUserAssociateTable.FindAsync(id);
            if (projectUserAssociateTable == null)
            {
                return HttpNotFound();
            }
            return View(projectUserAssociateTable);
        }

        // GET: ProjectUserAssociate/Create
        public ActionResult Create()
        {
            ViewBag.UserId = new SelectList(db.AccountTable, "Id", "Email");
            ViewBag.ProjectId = new SelectList(db.ProjectTable, "Id", "ProjectName");
            return View();
        }

        // POST: ProjectUserAssociate/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id,ProjectId,UserId,CreatedTime,RemovedTime,Locked,IsOwner")] ProjectUserAssociateTable projectUserAssociateTable)
        {
            if (ModelState.IsValid)
            {
                db.ProjectUserAssociateTable.Add(projectUserAssociateTable);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.UserId = new SelectList(db.AccountTable, "Id", "Email", projectUserAssociateTable.UserId);
            ViewBag.ProjectId = new SelectList(db.ProjectTable, "Id", "ProjectName", projectUserAssociateTable.ProjectId);
            return View(projectUserAssociateTable);
        }

        // GET: ProjectUserAssociate/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProjectUserAssociateTable projectUserAssociateTable = await db.ProjectUserAssociateTable.FindAsync(id);
            if (projectUserAssociateTable == null)
            {
                return HttpNotFound();
            }
            ViewBag.UserId = new SelectList(db.AccountTable, "Id", "Email", projectUserAssociateTable.UserId);
            ViewBag.ProjectId = new SelectList(db.ProjectTable, "Id", "ProjectName", projectUserAssociateTable.ProjectId);
            return View(projectUserAssociateTable);
        }

        // POST: ProjectUserAssociate/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,ProjectId,UserId,CreatedTime,RemovedTime,Locked,IsOwner")] ProjectUserAssociateTable projectUserAssociateTable)
        {
            if (ModelState.IsValid)
            {
                db.Entry(projectUserAssociateTable).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.UserId = new SelectList(db.AccountTable, "Id", "Email", projectUserAssociateTable.UserId);
            ViewBag.ProjectId = new SelectList(db.ProjectTable, "Id", "ProjectName", projectUserAssociateTable.ProjectId);
            return View(projectUserAssociateTable);
        }

        // GET: ProjectUserAssociate/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProjectUserAssociateTable projectUserAssociateTable = await db.ProjectUserAssociateTable.FindAsync(id);
            if (projectUserAssociateTable == null)
            {
                return HttpNotFound();
            }
            return View(projectUserAssociateTable);
        }

        // POST: ProjectUserAssociate/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            ProjectUserAssociateTable projectUserAssociateTable = await db.ProjectUserAssociateTable.FindAsync(id);
            db.ProjectUserAssociateTable.Remove(projectUserAssociateTable);
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
