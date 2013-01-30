using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MiaoliGym.Models;

namespace MiaoliGym.Controllers
{
    public class LeaseController : Controller
    {
        private MiaoliContext db = new MiaoliContext();

        // 首頁-定期租約紀錄
        public ActionResult Index()
        {
            return View();
        }

        // 定期租約紀錄的明細
        public ActionResult Detail(int id)
        {
            return View();
        }

        // 新增 定期租約
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Lease lease)
        {
            return View();
        }

        // 編輯 定期租約
        public ActionResult Edit(int id)
        {
            return View();
        }

        public ActionResult Edit(Lease lease)
        {
            return View();
        }

        // 刪除 定期租約
        public ActionResult Delete(int id)
        {
            return View();
        }

        // 下載Excel 定期租約報表
        public ActionResult DownExcel()
        {
            return View();
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }

    }
}
