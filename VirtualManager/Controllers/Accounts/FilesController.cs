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
    public class FilesController : Controller
    {
        private VirtualManagerDatabaseContainer db = new VirtualManagerDatabaseContainer();

        // GET: Files
        public async Task<ActionResult> Index()
        {
            return View(await db.FileTable.ToListAsync());
        }

        // GET: Files/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FileTable fileTable = await db.FileTable.FindAsync(id);
            if (fileTable == null)
            {
                return HttpNotFound();
            }
            return View(fileTable);
        }

        // GET: Files/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Files/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id,FileName,Extension,FileSize,Created,Updated,UploadedByUserId,IsVisible,PathToFile,IsFolder")] FileTable fileTable)
        {
            if (ModelState.IsValid)
            {
                db.FileTable.Add(fileTable);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(fileTable);
        }

        // GET: Files/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FileTable fileTable = await db.FileTable.FindAsync(id);
            if (fileTable == null)
            {
                return HttpNotFound();
            }
            return View(fileTable);
        }

        // POST: Files/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,FileName,Extension,FileSize,Created,Updated,UploadedByUserId,IsVisible,PathToFile,IsFolder")] FileTable fileTable)
        {
            if (ModelState.IsValid)
            {
                db.Entry(fileTable).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(fileTable);
        }

        // GET: Files/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FileTable fileTable = await db.FileTable.FindAsync(id);
            if (fileTable == null)
            {
                return HttpNotFound();
            }
            return View(fileTable);
        }

        // POST: Files/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            FileTable fileTable = await db.FileTable.FindAsync(id);
            db.FileTable.Remove(fileTable);
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
