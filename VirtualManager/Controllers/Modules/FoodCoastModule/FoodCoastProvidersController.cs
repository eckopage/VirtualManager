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

namespace VirtualManager.Controllers.Modules.FoodCoastModule
{
    public class FoodCoastProvidersController : Controller
    {
        private VirtualManagerDatabaseContainer db = new VirtualManagerDatabaseContainer();

        // GET: FoodCoastProviders
        public async Task<ActionResult> Index()
        {
            return View(await db.ProviderFoodCoastTable.ToListAsync());
        }

        // GET: FoodCoastProviders/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProviderFoodCoastTable providerFoodCoastTable = await db.ProviderFoodCoastTable.FindAsync(id);
            if (providerFoodCoastTable == null)
            {
                return HttpNotFound();
            }
            return View(providerFoodCoastTable);
        }

        // GET: FoodCoastProviders/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: FoodCoastProviders/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id,CompanyName,ProviderName,ProviderSurname,City,CityCode,Street,No,BankAccountNo,Description")] ProviderFoodCoastTable providerFoodCoastTable)
        {
            if (ModelState.IsValid)
            {
                db.ProviderFoodCoastTable.Add(providerFoodCoastTable);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(providerFoodCoastTable);
        }

        // GET: FoodCoastProviders/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProviderFoodCoastTable providerFoodCoastTable = await db.ProviderFoodCoastTable.FindAsync(id);
            if (providerFoodCoastTable == null)
            {
                return HttpNotFound();
            }
            return View(providerFoodCoastTable);
        }

        // POST: FoodCoastProviders/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,CompanyName,ProviderName,ProviderSurname,City,CityCode,Street,No,BankAccountNo,Description")] ProviderFoodCoastTable providerFoodCoastTable)
        {
            if (ModelState.IsValid)
            {
                db.Entry(providerFoodCoastTable).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(providerFoodCoastTable);
        }

        // GET: FoodCoastProviders/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProviderFoodCoastTable providerFoodCoastTable = await db.ProviderFoodCoastTable.FindAsync(id);
            if (providerFoodCoastTable == null)
            {
                return HttpNotFound();
            }
            return View(providerFoodCoastTable);
        }

        // POST: FoodCoastProviders/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            ProviderFoodCoastTable providerFoodCoastTable = await db.ProviderFoodCoastTable.FindAsync(id);
            db.ProviderFoodCoastTable.Remove(providerFoodCoastTable);
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
