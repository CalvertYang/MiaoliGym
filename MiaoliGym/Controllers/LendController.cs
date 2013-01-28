using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MiaoliGym.Models;

namespace MiaoliGym.Controllers
{
    public class LendController : Controller
    {
        private MiaoliContext db = new MiaoliContext();

        // 器材借用紀錄
        public ActionResult Index()
        {
            return View();
        }

        // 借用項目與詳細資料
        public ActionResult Detail(int id)
        { 
            // TODO: Show LendItem and detail info.
            return View();
        }

        // 新增借用紀錄: 一筆紀錄底下包含很多借用項目
        public ActionResult LendHeaderCreate()
        {
            return View();
        }

        [HttpPost]
        public ActionResult LendHeaderCreate(LendHeader header)
        {
            return View();
        }

        // 編輯 借用紀錄
        public ActionResult LendHeaderEdit(int id)
        {
            return View();
        }

        [HttpPost]
        public ActionResult LendHeaderEdit(LendHeader header)
        {
            return View();
        }

        // 刪除 借用紀錄
        [HttpDelete]
        public ActionResult LendHeaderDelete(int id)
        {
            return View();
        }

        //新增 借用項目
        public ActionResult LendItemCreate()
        {
            return View();
        }

        public ActionResult LendItemCreate(LendItem item)
        {
            return View();
        }

        //編輯 借用項目
        public ActionResult LendItemEdit(int id)
        {
            return View();
        }

        [HttpPost]
        public ActionResult LendItemEdit(LendItem item)
        {
            return View();
        }

        // 刪除 借用項目
        [HttpDelete]
        public ActionResult Delete(int id)
        {
            return View();
        }

        // 歸還器材
        public ActionResult SendBack(int id, int amount)
        {
            LendTransaction tr = new LendTransaction(); //交易紀錄
            return View();
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}
