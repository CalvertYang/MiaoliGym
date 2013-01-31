using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MiaoliGym.Models;

namespace MiaoliGym.Controllers
{
    //【庫存】【體育器材】管理
    public class SportsStuffController : Controller
    {
        private MiaoliContext db = new MiaoliContext();

        // 器材列表
        public ActionResult Index()
        {
            return View();
        }

        // 新增器材
        public ActionResult Create()
        {
            return View();
        }

        public ActionResult Create(SportsStuff item)
        {
            return View();
        }

        // 編輯器材
        public ActionResult Edit(int id)
        {
            return View();
        }

        [HttpPost]
        public ActionResult Edit(SportsStuff item)
        {
            return View();
        }

        // 刪除器材
        [HttpDelete]
        public ActionResult Delete(int id)
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
