using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MiaoliGym.Models;

namespace MiaoliGym.Controllers
{
    public class GymRecordController : Controller
    {
        private MiaoliContext db = new MiaoliContext();

        // 首頁-館場租借紀錄列表
        public ActionResult Index()
        {
            return View();
        }

        // 館場租借明細
        public ActionResult Detail()
        {
            return View();
        }

        // 新增館場租借明細
        public ActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Add(FormCollection form)
        {
            return View();
        }

        // 編輯館場租借明細
        public ActionResult Edit(int id)
        {
            return View();
        }

        [HttpPost]
        public ActionResult Edit(FormCollection form)
        {
            return View();
        }

        [HttpDelete]
        public ActionResult Delete(int id)
        {
            return View();
        }

        // 應繳項目列表
        public ActionResult PayItemList(int id)
        {
            return View();
        }

        // 新增 應繳項目
        public ActionResult PayItemAdd()
        {
            return View();
        }

        [HttpPost]
        public ActionResult PayItemAdd(PayItem payitem)
        {
            return View();
        }

        // 編輯 應繳項目
        public ActionResult PayItemEdit(int id)
        {
            return View();
        }

        [HttpPost]
        public ActionResult PayItemEdit(PayItem payitem)
        {
            return View();
        }

        // 刪除 應繳項目
        [HttpDelete]
        public ActionResult PayItemDelete(int id)
        {
            return View();
        }

        // 免繳項目列表
        public ActionResult FreeItemList(int id)
        {
            return View();
        }

        // 新增 免繳項目
        public ActionResult FreeItemAdd()
        {
            return View();
        }

        [HttpPost]
        public ActionResult FreeItemAdd(FreeItem item)
        {
            return View();
        }

        // 編輯 免繳項目
        public ActionResult FreeItemEdit(int id)
        {
            return View();
        }

        [HttpPost]
        public ActionResult FreeItemEdit(FreeItem item)
        {
            return View();
        }

        // 刪除 免繳項目
        [HttpDelete]
        public ActionResult FreeItemDelete(int id)
        {
            return View();
        }

        // 應歸還項目列表
        public ActionResult SendbackItemList(int id)
        {
            return View();
        }

        // 新增應歸還項目
        public ActionResult SendbackItemAdd()
        {
            return View();
        }

        [HttpPost]
        public ActionResult SendbackItemAdd(SendbackItem item)
        {
            return View();
        }

        // 編輯 應歸還項目
        public ActionResult SendbackItemEdit(int id)
        {
            return View();
        }

        [HttpPost]
        public ActionResult SendbackItemEdit(SendbackItem item)
        {
            return View();
        }

        // 刪除 應歸還項目
        [HttpDelete]
        public ActionResult SendbackItemDelete(int id)
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
