using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MiaoliGym.Models;

namespace MiaoliGym.Controllers
{
    public class PurchaseRecordController : Controller
    {
        private MiaoliContext db = new MiaoliContext();

        // 首頁-工程採購紀錄
        public ActionResult Index()
        {
            return View(db.PurchaseRecords.ToList());
        }
      
        // 工程採購明細
        public ActionResult Details(int id = 0)
        {
            PurchaseRecord purchaserecord = db.PurchaseRecords.Find(id);
            if (purchaserecord == null)
            {
                return HttpNotFound();
            }
            return View(purchaserecord);
        }

        // 新增 工程採購明細
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(PurchaseRecord purchaserecord)
        {
            if (ModelState.IsValid)
            {
                db.PurchaseRecords.Add(purchaserecord);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(purchaserecord);
        }

        // 編輯 工程採購明細
        public ActionResult Edit(int id = 0)
        {
            PurchaseRecord purchaserecord = db.PurchaseRecords.Find(id);
            if (purchaserecord == null)
            {
                return HttpNotFound();
            }
            return View(purchaserecord);
        }

        [HttpPost]
        public ActionResult Edit(PurchaseRecord purchaserecord)
        {
            if (ModelState.IsValid)
            {
                db.Entry(purchaserecord).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(purchaserecord);
        }


        [HttpPost, ActionName("Delete")]
        public ActionResult Delete(int id)
        {
            PurchaseRecord purchaserecord = db.PurchaseRecords.Find(id);
            db.PurchaseRecords.Remove(purchaserecord);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}