using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MiaoliGym.Models;
using System.Web.Security;

namespace MiaoliGym.Controllers
{
    public class MemberController : Controller
    {
        private MiaoliContext db = new MiaoliContext(); 

        // 管理員列表
        public ActionResult Index()
        {
            return View();
        }

        // 登入 // TODO: 所有 Controller 都需要權限
        public ActionResult Login(string returnUrl)
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(string email, string pwd, string returnUrl)
        {
            if (ValidateUser(email, pwd))
            {
                FormsAuthentication.SetAuthCookie(email, false);

                if (String.IsNullOrEmpty(returnUrl))
                {
                    return RedirectToAction("Index", "GymRecord");
                }
                else
                {
                    return Redirect(returnUrl);
                }
            }

            return View();
        }

        private bool ValidateUser(string email, string pwd)
        {
            throw new NotImplementedException();
        }

        // 登出
        public ActionResult Logout()
        {
            // 清除表單驗證的 Cookie
            FormsAuthentication.SignOut();

            Session.Clear();
            return RedirectToAction("Index", "GymRecord");
        }

        // 匯入會員資料
        public ActionResult Import()
        {
            return View();
        }

        // 新增會員
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Member member)
        {
            return View();
        }

        // 編輯 會員
        public ActionResult Edit(int id)
        {
            return View();
        }

        [HttpPost]
        public ActionResult Edit(Member member)
        {
            return View();
        }
        
        // 移除會員
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
