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
            if (Level())
            {
                // TODO: 有編輯權限的
                ViewBag.IsManager = true;
            }
            else
            { 
                // TODO: 沒有權限的
                ViewBag.IsManager = false;
            }
            

            var gyms = new List<Gym>(){ 
                new Gym{ Id = 1, Name="巨蛋體育館", Description="N/A", CreateOn=DateTime.Now},
                new Gym{ Id = 2, Name="縣立田徑場", Description="N/A", CreateOn=DateTime.Now},
                new Gym{ Id = 3, Name="縣立網球場", Description="N/A", CreateOn=DateTime.Now},
                new Gym{ Id = 4, Name="代管棒壘場-大倫", Description="N/A", CreateOn=DateTime.Now},
                new Gym{ Id = 5, Name="代管棒壘場-後龍高灘地", Description="N/A", CreateOn=DateTime.Now},
                new Gym{ Id = 6, Name="代管棒壘場-照南", Description="N/A", CreateOn=DateTime.Now}
            };


            var gym = new Gym { Id = 1, Name = "巨蛋體育館", Description = "N/A", CreateOn = DateTime.Now };
            var gymRecords = new List<GymRecord>(){
                new GymRecord{ Id=1, ApprovalNo="NO-98765432101", Contacter="AndyYou", ContactPhone="0911911911", CreateOn=DateTime.Now, Deleted=false, Event="巨星齊聚苗栗縣元宵節活動-測試", Gym = gyms.FirstOrDefault(), LastEditor="SuperUser", LastUpdateOn=DateTime.Now, LendDateEnd=DateTime.Parse("2013/12/31"), LendDateStart= DateTime.Parse("2013/1/1"), LendUnit="輝網資訊股份有限公司台灣分公司"  },
                new GymRecord{ Id=2, ApprovalNo="NO-98765432102", Contacter="Calvert", ContactPhone="0922922922", CreateOn=DateTime.Now, Deleted=false, Event="春節晚會", Gym = gyms.FirstOrDefault(), LastEditor="SuperUser", LastUpdateOn=DateTime.Now, LendDateEnd=DateTime.Parse("2013/12/31"), LendDateStart= DateTime.Parse("2013/1/1"), LendUnit="輝網資訊"  },
                new GymRecord{ Id=3, ApprovalNo="NO-98765432103", Contacter="AndyYou", ContactPhone="0911911911", CreateOn=DateTime.Now, Deleted=false, Event="巨星齊聚苗栗縣元宵節活動", Gym = gyms.FirstOrDefault(), LastEditor="SuperUser", LastUpdateOn=DateTime.Now, LendDateEnd=DateTime.Parse("2013/12/31"), LendDateStart= DateTime.Parse("2013/1/1"), LendUnit="輝網資訊"  },
                new GymRecord{ Id=4, ApprovalNo="NO-98765432105", Contacter="Calvert", ContactPhone="0922922922", CreateOn=DateTime.Now, Deleted=false, Event="春節晚會", Gym = gyms.FirstOrDefault(), LastEditor="SuperUser", LastUpdateOn=DateTime.Now, LendDateEnd=DateTime.Parse("2013/12/31"), LendDateStart= DateTime.Parse("2013/1/1"), LendUnit="輝網資訊"  },
                new GymRecord{ Id=5, ApprovalNo="NO-98765432101", Contacter="AndyYou", ContactPhone="0911911911", CreateOn=DateTime.Now, Deleted=false, Event="巨星齊聚苗栗縣元宵節活動", Gym = gyms.FirstOrDefault(), LastEditor="SuperUser", LastUpdateOn=DateTime.Now, LendDateEnd=DateTime.Parse("2013/12/31"), LendDateStart= DateTime.Parse("2013/1/1"), LendUnit="輝網資訊"  },
                new GymRecord{ Id=6, ApprovalNo="NO-98765432102", Contacter="Calvert", ContactPhone="0922922922", CreateOn=DateTime.Now, Deleted=false, Event="春節晚會", Gym = gyms.FirstOrDefault(), LastEditor="SuperUser", LastUpdateOn=DateTime.Now, LendDateEnd=DateTime.Parse("2013/12/31"), LendDateStart= DateTime.Parse("2013/1/1"), LendUnit="輝網資訊"  },
                new GymRecord{ Id=7, ApprovalNo="NO-98765432101", Contacter="AndyYou", ContactPhone="0911911911", CreateOn=DateTime.Now, Deleted=false, Event="巨星齊聚苗栗縣元宵節活動", Gym = gyms.FirstOrDefault(), LastEditor="SuperUser", LastUpdateOn=DateTime.Now, LendDateEnd=DateTime.Parse("2013/12/31"), LendDateStart= DateTime.Parse("2013/1/1"), LendUnit="輝網資訊"  },
                new GymRecord{ Id=8, ApprovalNo="NO-98765432102", Contacter="Calvert", ContactPhone="0922922922", CreateOn=DateTime.Now, Deleted=false, Event="春節晚會", Gym = gyms.FirstOrDefault(), LastEditor="SuperUser", LastUpdateOn=DateTime.Now, LendDateEnd=DateTime.Parse("2013/12/31"), LendDateStart= DateTime.Parse("2013/1/1"), LendUnit="輝網資訊"  },
                new GymRecord{ Id=9, ApprovalNo="NO-98765432101", Contacter="AndyYou", ContactPhone="0911911911", CreateOn=DateTime.Now, Deleted=false, Event="巨星齊聚苗栗縣元宵節活動", Gym = gyms.FirstOrDefault(), LastEditor="SuperUser", LastUpdateOn=DateTime.Now, LendDateEnd=DateTime.Parse("2013/12/31"), LendDateStart= DateTime.Parse("2013/1/1"), LendUnit="輝網資訊"  },
                new GymRecord{ Id=10, ApprovalNo="NO-98765432102", Contacter="Calvert", ContactPhone="0922922922", CreateOn=DateTime.Now, Deleted=false, Event="春節晚會", Gym = gyms.FirstOrDefault(), LastEditor="SuperUser", LastUpdateOn=DateTime.Now, LendDateEnd=DateTime.Parse("2013/12/31"), LendDateStart= DateTime.Parse("2013/1/1"), LendUnit="輝網資訊"  },
                new GymRecord{ Id=11, ApprovalNo="NO-98765432101", Contacter="AndyYou", ContactPhone="0911911911", CreateOn=DateTime.Now, Deleted=false, Event="巨星齊聚苗栗縣元宵節活動", Gym = gyms.FirstOrDefault(), LastEditor="SuperUser", LastUpdateOn=DateTime.Now, LendDateEnd=DateTime.Parse("2013/12/31"), LendDateStart= DateTime.Parse("2013/1/1"), LendUnit="輝網資訊"  },
                new GymRecord{ Id=12, ApprovalNo="NO-98765432102", Contacter="Calvert", ContactPhone="0922922922", CreateOn=DateTime.Now, Deleted=false, Event="春節晚會", Gym = gyms.FirstOrDefault(), LastEditor="SuperUser", LastUpdateOn=DateTime.Now, LendDateEnd=DateTime.Parse("2013/12/31"), LendDateStart= DateTime.Parse("2013/1/1"), LendUnit="輝網資訊"  },
                new GymRecord{ Id=13, ApprovalNo="NO-98765432101", Contacter="AndyYou", ContactPhone="0911911911", CreateOn=DateTime.Now, Deleted=false, Event="巨星齊聚苗栗縣元宵節活動", Gym = gyms.FirstOrDefault(), LastEditor="SuperUser", LastUpdateOn=DateTime.Now, LendDateEnd=DateTime.Parse("2013/12/31"), LendDateStart= DateTime.Parse("2013/1/1"), LendUnit="輝網資訊"  },
                new GymRecord{ Id=14, ApprovalNo="NO-98765432102", Contacter="Calvert", ContactPhone="0922922922", CreateOn=DateTime.Now, Deleted=false, Event="春節晚會", Gym = gyms.FirstOrDefault(), LastEditor="SuperUser", LastUpdateOn=DateTime.Now, LendDateEnd=DateTime.Parse("2013/12/31"), LendDateStart= DateTime.Parse("2013/1/1"), LendUnit="輝網資訊"  },
                new GymRecord{ Id=15, ApprovalNo="NO-98765432101", Contacter="AndyYou", ContactPhone="0911911911", CreateOn=DateTime.Now, Deleted=false, Event="巨星齊聚苗栗縣元宵節活動", Gym = gyms.FirstOrDefault(), LastEditor="SuperUser", LastUpdateOn=DateTime.Now, LendDateEnd=DateTime.Parse("2013/12/31"), LendDateStart= DateTime.Parse("2013/1/1"), LendUnit="輝網資訊"  },
                new GymRecord{ Id=16, ApprovalNo="NO-98765432102", Contacter="Calvert", ContactPhone="0922922922", CreateOn=DateTime.Now, Deleted=false, Event="春節晚會", Gym = gyms.FirstOrDefault(), LastEditor="SuperUser", LastUpdateOn=DateTime.Now, LendDateEnd=DateTime.Parse("2013/12/31"), LendDateStart= DateTime.Parse("2013/1/1"), LendUnit="輝網資訊"  },
                new GymRecord{ Id=17, ApprovalNo="NO-98765432101", Contacter="AndyYou", ContactPhone="0911911911", CreateOn=DateTime.Now, Deleted=false, Event="巨星齊聚苗栗縣元宵節活動", Gym = gyms.FirstOrDefault(), LastEditor="SuperUser", LastUpdateOn=DateTime.Now, LendDateEnd=DateTime.Parse("2013/12/31"), LendDateStart= DateTime.Parse("2013/1/1"), LendUnit="輝網資訊"  },
                new GymRecord{ Id=18, ApprovalNo="NO-98765432102", Contacter="Calvert", ContactPhone="0922922922", CreateOn=DateTime.Now, Deleted=false, Event="春節晚會", Gym = gyms.FirstOrDefault(), LastEditor="SuperUser", LastUpdateOn=DateTime.Now, LendDateEnd=DateTime.Parse("2013/12/31"), LendDateStart= DateTime.Parse("2013/1/1"), LendUnit="輝網資訊"  },
                new GymRecord{ Id=19, ApprovalNo="NO-98765432101", Contacter="AndyYou", ContactPhone="0911911911", CreateOn=DateTime.Now, Deleted=false, Event="巨星齊聚苗栗縣元宵節活動", Gym = gyms.FirstOrDefault(), LastEditor="SuperUser", LastUpdateOn=DateTime.Now, LendDateEnd=DateTime.Parse("2013/12/31"), LendDateStart= DateTime.Parse("2013/1/1"), LendUnit="輝網資訊"  },
                new GymRecord{ Id=20, ApprovalNo="NO-98765432102", Contacter="Calvert", ContactPhone="0922922922", CreateOn=DateTime.Now, Deleted=false, Event="春節晚會", Gym = gyms.FirstOrDefault(), LastEditor="SuperUser", LastUpdateOn=DateTime.Now, LendDateEnd=DateTime.Parse("2013/12/31"), LendDateStart= DateTime.Parse("2013/1/1"), LendUnit="輝網資訊"  },
                new GymRecord{ Id=21, ApprovalNo="NO-98765432101", Contacter="AndyYou", ContactPhone="0911911911", CreateOn=DateTime.Now, Deleted=false, Event="巨星齊聚苗栗縣元宵節活動", Gym = gyms.FirstOrDefault(), LastEditor="SuperUser", LastUpdateOn=DateTime.Now, LendDateEnd=DateTime.Parse("2013/12/31"), LendDateStart= DateTime.Parse("2013/1/1"), LendUnit="輝網資訊"  },
                new GymRecord{ Id=22, ApprovalNo="NO-98765432102", Contacter="Calvert", ContactPhone="0922922922", CreateOn=DateTime.Now, Deleted=false, Event="春節晚會", Gym = gyms.FirstOrDefault(), LastEditor="SuperUser", LastUpdateOn=DateTime.Now, LendDateEnd=DateTime.Parse("2013/12/31"), LendDateStart= DateTime.Parse("2013/1/1"), LendUnit="輝網資訊"  },
                new GymRecord{ Id=23, ApprovalNo="NO-98765432101", Contacter="AndyYou", ContactPhone="0911911911", CreateOn=DateTime.Now, Deleted=false, Event="巨星齊聚苗栗縣元宵節活動", Gym = gyms.FirstOrDefault(), LastEditor="SuperUser", LastUpdateOn=DateTime.Now, LendDateEnd=DateTime.Parse("2013/12/31"), LendDateStart= DateTime.Parse("2013/1/1"), LendUnit="輝網資訊"  },
                new GymRecord{ Id=24, ApprovalNo="NO-98765432102", Contacter="Calvert", ContactPhone="0922922922", CreateOn=DateTime.Now, Deleted=false, Event="春節晚會", Gym = gyms.FirstOrDefault(), LastEditor="SuperUser", LastUpdateOn=DateTime.Now, LendDateEnd=DateTime.Parse("2013/12/31"), LendDateStart= DateTime.Parse("2013/1/1"), LendUnit="輝網資訊"  },
                new GymRecord{ Id=25, ApprovalNo="NO-98765432101", Contacter="AndyYou", ContactPhone="0911911911", CreateOn=DateTime.Now, Deleted=false, Event="巨星齊聚苗栗縣元宵節活動", Gym = gyms.FirstOrDefault(), LastEditor="SuperUser", LastUpdateOn=DateTime.Now, LendDateEnd=DateTime.Parse("2013/12/31"), LendDateStart= DateTime.Parse("2013/1/1"), LendUnit="輝網資訊"  },
                new GymRecord{ Id=26, ApprovalNo="NO-98765432102", Contacter="Calvert", ContactPhone="0922922922", CreateOn=DateTime.Now, Deleted=false, Event="春節晚會", Gym = gyms.FirstOrDefault(), LastEditor="SuperUser", LastUpdateOn=DateTime.Now, LendDateEnd=DateTime.Parse("2013/12/31"), LendDateStart= DateTime.Parse("2013/1/1"), LendUnit="輝網資訊"  },new GymRecord{ Id=1, ApprovalNo="NO-98765432101", Contacter="AndyYou", ContactPhone="0911911911", CreateOn=DateTime.Now, Deleted=false, Event="巨星齊聚苗栗縣元宵節活動", Gym = gyms.FirstOrDefault(), LastEditor="SuperUser", LastUpdateOn=DateTime.Now, LendDateEnd=DateTime.Parse("2013/12/31"), LendDateStart= DateTime.Parse("2013/1/1"), LendUnit="輝網資訊"  },
                new GymRecord{ Id=27, ApprovalNo="NO-98765432102", Contacter="Calvert", ContactPhone="0922922922", CreateOn=DateTime.Now, Deleted=false, Event="春節晚會", Gym = gyms.FirstOrDefault(), LastEditor="SuperUser", LastUpdateOn=DateTime.Now, LendDateEnd=DateTime.Parse("2013/12/31"), LendDateStart= DateTime.Parse("2013/1/1"), LendUnit="輝網資訊"  },
                new GymRecord{ Id=28, ApprovalNo="NO-98765432101", Contacter="AndyYou", ContactPhone="0911911911", CreateOn=DateTime.Now, Deleted=false, Event="巨星齊聚苗栗縣元宵節活動", Gym = gyms.FirstOrDefault(), LastEditor="SuperUser", LastUpdateOn=DateTime.Now, LendDateEnd=DateTime.Parse("2013/12/31"), LendDateStart= DateTime.Parse("2013/1/1"), LendUnit="輝網資訊"  },
                new GymRecord{ Id=29, ApprovalNo="NO-98765432102", Contacter="Calvert", ContactPhone="0922922922", CreateOn=DateTime.Now, Deleted=false, Event="春節晚會", Gym = gyms.FirstOrDefault(), LastEditor="SuperUser", LastUpdateOn=DateTime.Now, LendDateEnd=DateTime.Parse("2013/12/31"), LendDateStart= DateTime.Parse("2013/1/1"), LendUnit="輝網資訊"  },
                new GymRecord{ Id=30, ApprovalNo="NO-98765432101", Contacter="AndyYou", ContactPhone="0911911911", CreateOn=DateTime.Now, Deleted=false, Event="巨星齊聚苗栗縣元宵節活動", Gym = gyms.FirstOrDefault(), LastEditor="SuperUser", LastUpdateOn=DateTime.Now, LendDateEnd=DateTime.Parse("2013/12/31"), LendDateStart= DateTime.Parse("2013/1/1"), LendUnit="輝網資訊"  },
                new GymRecord{ Id=31, ApprovalNo="NO-98765432102", Contacter="Calvert", ContactPhone="0922922922", CreateOn=DateTime.Now, Deleted=false, Event="春節晚會", Gym = gyms.FirstOrDefault(), LastEditor="SuperUser", LastUpdateOn=DateTime.Now, LendDateEnd=DateTime.Parse("2013/12/31"), LendDateStart= DateTime.Parse("2013/1/1"), LendUnit="輝網資訊"  }

            };

            ViewData["Gyms"] = new SelectList(gyms, "Id", "Name", "");
            ViewData.Model = gymRecords;

            return View();
        }

        private bool Level()
        {
            return true;
        }

        // 館場租借明細
        public ActionResult Detail()
        {
            return View();
        }

        // 新增館場租借明細
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(FormCollection form)
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

        // 下載 體育館借用紀錄報表 Excel
        public ActionResult DownLoadExcel()
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
