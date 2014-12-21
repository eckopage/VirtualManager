using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using VM.DataAccessLayer.Common;
using VM.DataAccessLayer.EDM;
using VM.DataAccessLayer.EDM.Accounts;
using VM.DataAccessLayer.ViewModels.Accounts.Registration;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using System.Threading.Tasks;
using VirtualManager.Core.Image;
using System.IO;


namespace VirtualManager.Controllers.Accounts
{
    public class UserDetailsController : CommonController
    {
        private VirtualManagerDatabaseContainer db = new VirtualManagerDatabaseContainer();

        public ApplicationUserManager UserManager {
            get { return _userManager ?? this.HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>(); }
            private set { _userManager = value; }
        }
        private ApplicationUserManager _userManager;


        // GET: UserDetails
        public async Task<ActionResult> Index()
        {
            var userDetails = db.UserDetails.Include(u => u.AccountTable).Include(u => u.DepartmentTable).Include(u => u.WorkerGroupTable).Include(u => u.CountryZoneTable);
            return View(await userDetails.ToListAsync());
        }

        // GET: UserDetails/Details/5
        public async Task<ActionResult> Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UserDetails userDetails = await db.UserDetails.FindAsync(id);
            if (userDetails == null)
            {
                return HttpNotFound();
            }
            return View(userDetails);
        }

        // GET: UserDetails/Create
        public ActionResult Create()
        {
            ViewBag.UserId = new SelectList(db.AccountTable, "Id", "Email");
            ViewBag.Department = new SelectList(db.DepartmentTable, "Id", "DepartmentName");
            ViewBag.WorkersGroup = new SelectList(db.WorkerGroupTable, "Id", "Name");
            ViewBag.CountryZone = new SelectList(db.CountryZoneTable, "Id", "CountryZoneName");
            return View();
        }

        // POST: UserDetails/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "UserId,UserName,UserSurname,BornDate,PESEL,Country,CountryZone,Gmina,Street,NoHome,NoLocal,City,PostalCode,UrzadSkarbowyNazwa,SymbolUs,UserEmailContact,BankBillNo,NFZ_No,WorkersGroup,Department")] UserDetails userDetails, HttpPostedFileBase file)
        {
            if (ModelState.IsValid) {
                var imgProc = new ImageProcessor<ImageModel>();
                imgProc.ImageRepositoryPath = @"C:\Server\UserPicture\";
                if (file != null && file.ContentLength > 0) {

                    var imgT = Core.TextProcessor.ConvertStringToEnum(Path.GetExtension(file.FileName));
                    imgProc.ImageFullName = Core.TextProcessor.GenerateFileName(Path.GetFileNameWithoutExtension(file.FileName), imgT);
                    var fullPathFile = String.Concat(imgProc.ImageRepositoryPath, imgProc.ImageFullName);

                    var iModel = new ImageModel { Created = DateTime.Now, ImageName = imgProc.ImageFullName, ImgType = imgT, Size = file.ContentLength, ImagePath = fullPathFile };
                    file.SaveAs(fullPathFile);
                }
                var user = new AccountUserModel(userDetails.UserEmailContact);
                if (user != null) {
                    var password = "qwerty";
                    PasswordHasher ph = new PasswordHasher();
                    var pass = ph.HashPassword(password);
                    user.UserName = userDetails.UserEmailContact;
                    user.Email = userDetails.UserEmailContact;
                    user.PasswordHash = pass;
                    var res = UserManager.Create(user, user.PasswordHash);

                    if (res.Succeeded) {
                        db.SaveChanges();

                    }

                    string code = UserManager.GenerateEmailConfirmationToken(user.Id);
                    //var newPass = UserManager.AddPasswordAsync(user.Id, userDetails.UserEmailContact);
                    UserManager.ConfirmEmail(user.Id, code);
                    userDetails.UserId = user.Id;
                    db.UserDetails.Add(userDetails);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
            }


            ViewBag.UserId = new SelectList(db.AccountTable, "Id", "Email", userDetails.UserId);
            ViewBag.Department = new SelectList(db.DepartmentTable, "Id", "DepartmentName", userDetails.Department);
            ViewBag.WorkersGroup = new SelectList(db.WorkerGroupTable, "Id", "Name", userDetails.WorkersGroup);
            ViewBag.CountryZone = new SelectList(db.CountryZoneTable, "Id", "CountryZoneName", userDetails.CountryZone);
            return View(userDetails);
        }

        // GET: UserDetails/Edit/5
        public async Task<ActionResult> Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UserDetails userDetails = await db.UserDetails.FindAsync(id);
            if (userDetails == null)
            {
                return HttpNotFound();
            }
            ViewBag.UserId = new SelectList(db.AccountTable, "Id", "Email", userDetails.UserId);
            ViewBag.Department = new SelectList(db.DepartmentTable, "Id", "DepartmentName", userDetails.Department);
            ViewBag.WorkersGroup = new SelectList(db.WorkerGroupTable, "Id", "Name", userDetails.WorkersGroup);
            ViewBag.CountryZone = new SelectList(db.CountryZoneTable, "Id", "CountryZoneName", userDetails.CountryZone);
            return View(userDetails);
        }

        // POST: UserDetails/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "UserId,UserName,UserSurname,BornDate,PESEL,Country,CountryZone,Gmina,Street,NoHome,NoLocal,City,PostalCode,UrzadSkarbowyNazwa,SymbolUs,UserEmailContact,BankBillNo,NFZ_No,WorkersGroup,Department")] UserDetails userDetails)
        {
            if (ModelState.IsValid)
            {
                db.Entry(userDetails).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.UserId = new SelectList(db.AccountTable, "Id", "Email", userDetails.UserId);
            ViewBag.Department = new SelectList(db.DepartmentTable, "Id", "DepartmentName", userDetails.Department);
            ViewBag.WorkersGroup = new SelectList(db.WorkerGroupTable, "Id", "Name", userDetails.WorkersGroup);
            ViewBag.CountryZone = new SelectList(db.CountryZoneTable, "Id", "CountryZoneName", userDetails.CountryZone);
            return View(userDetails);
        }

        // GET: UserDetails/Delete/5
        public async Task<ActionResult> Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UserDetails userDetails = await db.UserDetails.FindAsync(id);
            if (userDetails == null)
            {
                return HttpNotFound();
            }
            return View(userDetails);
        }

        // POST: UserDetails/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(string id)
        {
            UserDetails userDetails = await db.UserDetails.FindAsync(id);
            db.UserDetails.Remove(userDetails);
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
