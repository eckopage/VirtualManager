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
    public class ProjectController : Controller
    {
        private VirtualManagerDatabaseContainer db = new VirtualManagerDatabaseContainer();

        // GET: ProjectTables
        public async Task<ActionResult> Index()
        {
            var projectTable = db.ProjectTable.Include(p => p.FileRepositoryTable);
            return View(await projectTable.ToListAsync());
        }

        // GET: ProjectTables/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProjectTable projectTable = await db.ProjectTable.FindAsync(id);
            if (projectTable == null)
            {
                return HttpNotFound();
            }
            return View(projectTable);
        }

        // GET: ProjectTables/Create
        public ActionResult Create()
        {
            ViewBag.FileRepositoryId = new SelectList(db.FileRepositoryTable, "Id", "FileRepoName");
            return View();
        }

        // POST: ProjectTables/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id,ProjectName,ProjectDescription,Created,Removed,IsVisible,FileRepositoryId,AvailableModulesId")] ProjectTable projectTable)
        {
            if (ModelState.IsValid)
            {
                db.ProjectTable.Add(projectTable);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.FileRepositoryId = new SelectList(db.FileRepositoryTable, "Id", "FileRepoName", projectTable.FileRepositoryId);
            return View(projectTable);
        }

        // GET: ProjectTables/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProjectTable projectTable = await db.ProjectTable.FindAsync(id);
            if (projectTable == null)
            {
                return HttpNotFound();
            }
            ViewBag.FileRepositoryId = new SelectList(db.FileRepositoryTable, "Id", "FileRepoName", projectTable.FileRepositoryId);
            return View(projectTable);
        }

        // POST: ProjectTables/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,ProjectName,ProjectDescription,Created,Removed,IsVisible,FileRepositoryId,AvailableModulesId")] ProjectTable projectTable)
        {
            if (ModelState.IsValid)
            {
                db.Entry(projectTable).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.FileRepositoryId = new SelectList(db.FileRepositoryTable, "Id", "FileRepoName", projectTable.FileRepositoryId);
            return View(projectTable);
        }

        // GET: ProjectTables/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProjectTable projectTable = await db.ProjectTable.FindAsync(id);
            if (projectTable == null)
            {
                return HttpNotFound();
            }
            return View(projectTable);
        }

        // POST: ProjectTables/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            ProjectTable projectTable = await db.ProjectTable.FindAsync(id);
            db.ProjectTable.Remove(projectTable);
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
