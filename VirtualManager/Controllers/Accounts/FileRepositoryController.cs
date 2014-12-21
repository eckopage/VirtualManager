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
    public class FileRepositoryController : Controller
    {
        private VirtualManagerDatabaseContainer db = new VirtualManagerDatabaseContainer();

        // GET: FileRepository
        public async Task<ActionResult> Index()
        {
            return View(await db.FileRepositoryTable.ToListAsync());
        }

        // GET: FileRepository/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FileRepositoryTable fileRepositoryTable = await db.FileRepositoryTable.FindAsync(id);
            if (fileRepositoryTable == null)
            {
                return HttpNotFound();
            }
            return View(fileRepositoryTable);
        }

        // GET: FileRepository/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: FileRepository/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id,FileRepoName,FilesId")] FileRepositoryTable fileRepositoryTable)
        {
            if (ModelState.IsValid)
            {
                db.FileRepositoryTable.Add(fileRepositoryTable);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(fileRepositoryTable);
        }

        // GET: FileRepository/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FileRepositoryTable fileRepositoryTable = await db.FileRepositoryTable.FindAsync(id);
            if (fileRepositoryTable == null)
            {
                return HttpNotFound();
            }
            return View(fileRepositoryTable);
        }

        // POST: FileRepository/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,FileRepoName,FilesId")] FileRepositoryTable fileRepositoryTable)
        {
            if (ModelState.IsValid)
            {
                db.Entry(fileRepositoryTable).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(fileRepositoryTable);
        }

        // GET: FileRepository/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FileRepositoryTable fileRepositoryTable = await db.FileRepositoryTable.FindAsync(id);
            if (fileRepositoryTable == null)
            {
                return HttpNotFound();
            }
            return View(fileRepositoryTable);
        }

        // POST: FileRepository/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            FileRepositoryTable fileRepositoryTable = await db.FileRepositoryTable.FindAsync(id);
            db.FileRepositoryTable.Remove(fileRepositoryTable);
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
