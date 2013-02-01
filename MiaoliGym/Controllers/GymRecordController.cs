using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MiaoliGym.Models;
using PagedList;

namespace MiaoliGym.Controllers
{
    public class GymRecordController : Controller
    {
        private MiaoliContext db = new MiaoliContext();
        private List<Gym> gyms;
        private List<GymRecord> gymRecords;
        private List<PayItem> payItems;
        private List<FreeItem> freeItems;
        private List<SendbackItem> sendbackItems;

        public GymRecordController()
        {
            #region Dummy Data
            gyms = new List<Gym>(){ 
                new Gym{ Id = 1, Name="巨蛋體育館", Description="N/A", CreateOn=DateTime.Now},
                new Gym{ Id = 2, Name="縣立田徑場", Description="N/A", CreateOn=DateTime.Now},
                new Gym{ Id = 3, Name="縣立網球場", Description="N/A", CreateOn=DateTime.Now},
                new Gym{ Id = 4, Name="代管棒壘場-大倫", Description="N/A", CreateOn=DateTime.Now},
                new Gym{ Id = 5, Name="代管棒壘場-後龍高灘地", Description="N/A", CreateOn=DateTime.Now},
                new Gym{ Id = 6, Name="代管棒壘場-照南", Description="N/A", CreateOn=DateTime.Now}
            };

           

            gymRecords = new List<GymRecord>(){
                new GymRecord{ Id=1, ApprovalNo="NO-98765432101", Contacter="AndyYou", ContactPhone="0911911911", CreateOn=DateTime.Now, Deleted=false, Event="巨星齊聚苗栗縣元宵節活動", Gym = gyms.Find(x => x.Id == 1), LastEditor="SuperUser", LastUpdateOn=DateTime.Now, LendDateEnd=DateTime.Parse("2013/12/31"), LendDateStart= DateTime.Parse("2013/1/1"), LendUnit="輝網資訊股份有限公司台灣分公司", FreeItems=new List<FreeItem>(), SendbackItems=new List<SendbackItem>(), PayItems=new List<PayItem>() },
                new GymRecord{ Id=2, ApprovalNo="NO-98765432102", Contacter="Calvert", ContactPhone="0922922922", CreateOn=DateTime.Now, Deleted=false, Event="春節晚會", Gym =  gyms.Find(x => x.Id == 2), LastEditor="SuperUser", LastUpdateOn=DateTime.Now, LendDateEnd=DateTime.Parse("2013/12/31"), LendDateStart= DateTime.Parse("2013/1/1"), LendUnit="輝網資訊" , FreeItems=new List<FreeItem>(), SendbackItems=new List<SendbackItem>(), PayItems=new List<PayItem>() },
                new GymRecord{ Id=3, ApprovalNo="NO-98765432103", Contacter="AndyYou", ContactPhone="0911911911", CreateOn=DateTime.Now, Deleted=false, Event="霹靂好玩的活動-1", Gym = gyms.Find(x => x.Id == 3), LastEditor="SuperUser", LastUpdateOn=DateTime.Now, LendDateEnd=DateTime.Parse("2013/12/31"), LendDateStart= DateTime.Parse("2013/1/1"), LendUnit="輝網資訊", FreeItems=new List<FreeItem>(), SendbackItems=new List<SendbackItem>(), PayItems=new List<PayItem>()  },
                new GymRecord{ Id=4, ApprovalNo="NO-98765432105", Contacter="Calvert", ContactPhone="0922922922", CreateOn=DateTime.Now, Deleted=false, Event="霹靂好玩的活動-2", Gym =  gyms.Find(x => x.Id == 4), LastEditor="SuperUser", LastUpdateOn=DateTime.Now, LendDateEnd=DateTime.Parse("2013/12/31"), LendDateStart= DateTime.Parse("2013/1/1"), LendUnit="輝網資訊", FreeItems=new List<FreeItem>(), SendbackItems=new List<SendbackItem>(), PayItems=new List<PayItem>()  },
                new GymRecord{ Id=5, ApprovalNo="NO-98765432101", Contacter="AndyYou", ContactPhone="0911911911", CreateOn=DateTime.Now, Deleted=false, Event="霹靂好玩的活動-3", Gym = gyms.FirstOrDefault(), LastEditor="SuperUser", LastUpdateOn=DateTime.Now, LendDateEnd=DateTime.Parse("2013/12/31"), LendDateStart= DateTime.Parse("2013/1/1"), LendUnit="輝網資訊" , FreeItems=new List<FreeItem>(), SendbackItems=new List<SendbackItem>(), PayItems=new List<PayItem>() },
                new GymRecord{ Id=6, ApprovalNo="NO-98765432102", Contacter="Calvert", ContactPhone="0922922922", CreateOn=DateTime.Now, Deleted=false, Event="春節晚會", Gym =  gyms.Find(x => x.Id == 1), LastEditor="SuperUser", LastUpdateOn=DateTime.Now, LendDateEnd=DateTime.Parse("2013/12/31"), LendDateStart= DateTime.Parse("2013/1/1"), LendUnit="輝網資訊" , FreeItems=new List<FreeItem>(), SendbackItems=new List<SendbackItem>(), PayItems=new List<PayItem>() },
                new GymRecord{ Id=7, ApprovalNo="NO-98765432101", Contacter="AndyYou", ContactPhone="0911911911", CreateOn=DateTime.Now, Deleted=false, Event="巨星齊聚苗栗縣元宵節活動", Gym =gyms.Find(x => x.Id == 3), LastEditor="SuperUser", LastUpdateOn=DateTime.Now, LendDateEnd=DateTime.Parse("2013/12/31"), LendDateStart= DateTime.Parse("2013/1/1"), LendUnit="輝網資訊" , FreeItems=new List<FreeItem>(), SendbackItems=new List<SendbackItem>(), PayItems=new List<PayItem>() },
                new GymRecord{ Id=8, ApprovalNo="NO-98765432102", Contacter="Calvert", ContactPhone="0922922922", CreateOn=DateTime.Now, Deleted=false, Event="霹靂好玩的活動-4", Gym = gyms.FirstOrDefault(), LastEditor="SuperUser", LastUpdateOn=DateTime.Now, LendDateEnd=DateTime.Parse("2013/12/31"), LendDateStart= DateTime.Parse("2013/1/1"), LendUnit="輝網資訊" , FreeItems=new List<FreeItem>(), SendbackItems=new List<SendbackItem>(), PayItems=new List<PayItem>() },
                new GymRecord{ Id=9, ApprovalNo="NO-98765432101", Contacter="AndyYou", ContactPhone="0911911911", CreateOn=DateTime.Now, Deleted=false, Event="霹靂好玩的活動-5", Gym = gyms.FirstOrDefault(), LastEditor="SuperUser", LastUpdateOn=DateTime.Now, LendDateEnd=DateTime.Parse("2013/12/31"), LendDateStart= DateTime.Parse("2013/1/1"), LendUnit="輝網資訊", FreeItems=new List<FreeItem>(), SendbackItems=new List<SendbackItem>(), PayItems=new List<PayItem>()  },
                new GymRecord{ Id=10, ApprovalNo="NO-98765432102", Contacter="Calvert", ContactPhone="0922922922", CreateOn=DateTime.Now, Deleted=false, Event="霹靂好玩的活動-6", Gym = gyms.FirstOrDefault(), LastEditor="SuperUser", LastUpdateOn=DateTime.Now, LendDateEnd=DateTime.Parse("2013/12/31"), LendDateStart= DateTime.Parse("2013/1/1"), LendUnit="輝網資訊", FreeItems=new List<FreeItem>(), SendbackItems=new List<SendbackItem>(), PayItems=new List<PayItem>()  },
                new GymRecord{ Id=11, ApprovalNo="NO-98765432101", Contacter="AndyYou", ContactPhone="0911911911", CreateOn=DateTime.Now, Deleted=false, Event="霹靂好玩的活動-7", Gym = gyms.FirstOrDefault(), LastEditor="SuperUser", LastUpdateOn=DateTime.Now, LendDateEnd=DateTime.Parse("2013/12/31"), LendDateStart= DateTime.Parse("2013/1/1"), LendUnit="輝網資訊", FreeItems=new List<FreeItem>(), SendbackItems=new List<SendbackItem>(), PayItems=new List<PayItem>()  },
                new GymRecord{ Id=12, ApprovalNo="NO-98765432102", Contacter="Calvert", ContactPhone="0922922922", CreateOn=DateTime.Now, Deleted=false, Event="霹靂好玩的活動-8", Gym = gyms.FirstOrDefault(), LastEditor="SuperUser", LastUpdateOn=DateTime.Now, LendDateEnd=DateTime.Parse("2013/12/31"), LendDateStart= DateTime.Parse("2013/1/1"), LendUnit="輝網資訊" , FreeItems=new List<FreeItem>(), SendbackItems=new List<SendbackItem>(), PayItems=new List<PayItem>() },
                new GymRecord{ Id=13, ApprovalNo="NO-98765432101", Contacter="AndyYou", ContactPhone="0911911911", CreateOn=DateTime.Now, Deleted=false, Event="霹靂好玩的活動-9", Gym = gyms.FirstOrDefault(), LastEditor="SuperUser", LastUpdateOn=DateTime.Now, LendDateEnd=DateTime.Parse("2013/12/31"), LendDateStart= DateTime.Parse("2013/1/1"), LendUnit="輝網資訊", FreeItems=new List<FreeItem>(), SendbackItems=new List<SendbackItem>(), PayItems=new List<PayItem>()  },
                new GymRecord{ Id=14, ApprovalNo="NO-98765432102", Contacter="Calvert", ContactPhone="0922922922", CreateOn=DateTime.Now, Deleted=false, Event="霹靂好玩的活動-10", Gym = gyms.FirstOrDefault(), LastEditor="SuperUser", LastUpdateOn=DateTime.Now, LendDateEnd=DateTime.Parse("2013/12/31"), LendDateStart= DateTime.Parse("2013/1/1"), LendUnit="輝網資訊", FreeItems=new List<FreeItem>(), SendbackItems=new List<SendbackItem>(), PayItems=new List<PayItem>()  },
                new GymRecord{ Id=15, ApprovalNo="NO-98765432101", Contacter="AndyYou", ContactPhone="0911911911", CreateOn=DateTime.Now, Deleted=false, Event="巨星齊聚苗栗縣元宵節活動11", Gym = gyms.FirstOrDefault(), LastEditor="SuperUser", LastUpdateOn=DateTime.Now, LendDateEnd=DateTime.Parse("2013/12/31"), LendDateStart= DateTime.Parse("2013/1/1"), LendUnit="輝網資訊", FreeItems=new List<FreeItem>(), SendbackItems=new List<SendbackItem>(), PayItems=new List<PayItem>()  },
                new GymRecord{ Id=16, ApprovalNo="NO-98765432102", Contacter="Calvert", ContactPhone="0922922922", CreateOn=DateTime.Now, Deleted=false, Event="春節晚會12", Gym = gyms.FirstOrDefault(), LastEditor="SuperUser", LastUpdateOn=DateTime.Now, LendDateEnd=DateTime.Parse("2013/12/31"), LendDateStart= DateTime.Parse("2013/1/1"), LendUnit="輝網資訊" , FreeItems=new List<FreeItem>(), SendbackItems=new List<SendbackItem>(), PayItems=new List<PayItem>() },
                new GymRecord{ Id=17, ApprovalNo="NO-98765432101", Contacter="AndyYou", ContactPhone="0911911911", CreateOn=DateTime.Now, Deleted=false, Event="巨星齊聚苗栗縣元宵節活動13", Gym = gyms.FirstOrDefault(), LastEditor="SuperUser", LastUpdateOn=DateTime.Now, LendDateEnd=DateTime.Parse("2013/12/31"), LendDateStart= DateTime.Parse("2013/1/1"), LendUnit="輝網資訊", FreeItems=new List<FreeItem>(), SendbackItems=new List<SendbackItem>(), PayItems=new List<PayItem>()  },
                new GymRecord{ Id=18, ApprovalNo="NO-98765432102", Contacter="Calvert", ContactPhone="0922922922", CreateOn=DateTime.Now, Deleted=false, Event="春節晚會14", Gym = gyms.FirstOrDefault(), LastEditor="SuperUser", LastUpdateOn=DateTime.Now, LendDateEnd=DateTime.Parse("2013/12/31"), LendDateStart= DateTime.Parse("2013/1/1"), LendUnit="輝網資訊" , FreeItems=new List<FreeItem>(), SendbackItems=new List<SendbackItem>(), PayItems=new List<PayItem>() },
                new GymRecord{ Id=19, ApprovalNo="NO-98765432101", Contacter="AndyYou", ContactPhone="0911911911", CreateOn=DateTime.Now, Deleted=false, Event="巨星齊聚苗栗縣元宵節活動15", Gym = gyms.FirstOrDefault(), LastEditor="SuperUser", LastUpdateOn=DateTime.Now, LendDateEnd=DateTime.Parse("2013/12/31"), LendDateStart= DateTime.Parse("2013/1/1"), LendUnit="輝網資訊", FreeItems=new List<FreeItem>(), SendbackItems=new List<SendbackItem>(), PayItems=new List<PayItem>()  },
                new GymRecord{ Id=20, ApprovalNo="NO-98765432102", Contacter="Calvert", ContactPhone="0922922922", CreateOn=DateTime.Now, Deleted=false, Event="春節晚會16", Gym = gyms.FirstOrDefault(), LastEditor="SuperUser", LastUpdateOn=DateTime.Now, LendDateEnd=DateTime.Parse("2013/12/31"), LendDateStart= DateTime.Parse("2013/1/1"), LendUnit="輝網資訊" , FreeItems=new List<FreeItem>(), SendbackItems=new List<SendbackItem>(), PayItems=new List<PayItem>() },
                new GymRecord{ Id=21, ApprovalNo="NO-98765432101", Contacter="AndyYou", ContactPhone="0911911911", CreateOn=DateTime.Now, Deleted=false, Event="巨星齊聚苗栗縣元宵節活動17", Gym = gyms.FirstOrDefault(), LastEditor="SuperUser", LastUpdateOn=DateTime.Now, LendDateEnd=DateTime.Parse("2013/12/31"), LendDateStart= DateTime.Parse("2013/1/1"), LendUnit="輝網資訊" , FreeItems=new List<FreeItem>(), SendbackItems=new List<SendbackItem>(), PayItems=new List<PayItem>() },
                new GymRecord{ Id=22, ApprovalNo="NO-98765432102", Contacter="Calvert", ContactPhone="0922922922", CreateOn=DateTime.Now, Deleted=false, Event="春節晚會18", Gym = gyms.FirstOrDefault(), LastEditor="SuperUser", LastUpdateOn=DateTime.Now, LendDateEnd=DateTime.Parse("2013/12/31"), LendDateStart= DateTime.Parse("2013/1/1"), LendUnit="輝網資訊" , FreeItems=new List<FreeItem>(), SendbackItems=new List<SendbackItem>(), PayItems=new List<PayItem>() },
                new GymRecord{ Id=23, ApprovalNo="NO-98765432101", Contacter="AndyYou", ContactPhone="0911911911", CreateOn=DateTime.Now, Deleted=false, Event="巨星齊聚苗栗縣元宵節活動19", Gym = gyms.FirstOrDefault(), LastEditor="SuperUser", LastUpdateOn=DateTime.Now, LendDateEnd=DateTime.Parse("2013/12/31"), LendDateStart= DateTime.Parse("2013/1/1"), LendUnit="輝網資訊", FreeItems=new List<FreeItem>(), SendbackItems=new List<SendbackItem>(), PayItems=new List<PayItem>()  },
                new GymRecord{ Id=24, ApprovalNo="NO-98765432102", Contacter="Calvert", ContactPhone="0922922922", CreateOn=DateTime.Now, Deleted=false, Event="春節晚會20", Gym = gyms.FirstOrDefault(), LastEditor="SuperUser", LastUpdateOn=DateTime.Now, LendDateEnd=DateTime.Parse("2013/12/31"), LendDateStart= DateTime.Parse("2013/1/1"), LendUnit="輝網資訊", FreeItems=new List<FreeItem>(), SendbackItems=new List<SendbackItem>(), PayItems=new List<PayItem>()  },
                new GymRecord{ Id=25, ApprovalNo="NO-98765432101", Contacter="AndyYou", ContactPhone="0911911911", CreateOn=DateTime.Now, Deleted=false, Event="巨星齊聚苗栗縣元宵節活動21", Gym = gyms.FirstOrDefault(), LastEditor="SuperUser", LastUpdateOn=DateTime.Now, LendDateEnd=DateTime.Parse("2013/12/31"), LendDateStart= DateTime.Parse("2013/1/1"), LendUnit="輝網資訊", FreeItems=new List<FreeItem>(), SendbackItems=new List<SendbackItem>(), PayItems=new List<PayItem>()  },
                new GymRecord{ Id=26, ApprovalNo="NO-98765432102", Contacter="Calvert", ContactPhone="0922922922", CreateOn=DateTime.Now, Deleted=false, Event="春節晚會22", Gym = gyms.FirstOrDefault(), LastEditor="SuperUser", LastUpdateOn=DateTime.Now, LendDateEnd=DateTime.Parse("2013/12/31"), LendDateStart= DateTime.Parse("2013/1/1"), LendUnit="輝網資訊", FreeItems=new List<FreeItem>(), SendbackItems=new List<SendbackItem>(), PayItems=new List<PayItem>()  },
                new GymRecord{ Id=27, ApprovalNo="NO-98765432102", Contacter="Calvert", ContactPhone="0922922922", CreateOn=DateTime.Now, Deleted=false, Event="春節晚會23", Gym = gyms.FirstOrDefault(), LastEditor="SuperUser", LastUpdateOn=DateTime.Now, LendDateEnd=DateTime.Parse("2013/12/31"), LendDateStart= DateTime.Parse("2013/1/1"), LendUnit="輝網資訊", FreeItems=new List<FreeItem>(), SendbackItems=new List<SendbackItem>(), PayItems=new List<PayItem>()  },
                new GymRecord{ Id=28, ApprovalNo="NO-98765432101", Contacter="AndyYou", ContactPhone="0911911911", CreateOn=DateTime.Now, Deleted=false, Event="巨星齊聚苗栗縣元宵節活動24", Gym = gyms.FirstOrDefault(), LastEditor="SuperUser", LastUpdateOn=DateTime.Now, LendDateEnd=DateTime.Parse("2013/12/31"), LendDateStart= DateTime.Parse("2013/1/1"), LendUnit="輝網資訊", FreeItems=new List<FreeItem>(), SendbackItems=new List<SendbackItem>(), PayItems=new List<PayItem>()   },
                new GymRecord{ Id=29, ApprovalNo="NO-98765432102", Contacter="Calvert", ContactPhone="0922922922", CreateOn=DateTime.Now, Deleted=false, Event="春節晚會25", Gym = gyms.FirstOrDefault(), LastEditor="SuperUser", LastUpdateOn=DateTime.Now, LendDateEnd=DateTime.Parse("2013/12/31"), LendDateStart= DateTime.Parse("2013/1/1"), LendUnit="輝網資訊", FreeItems=new List<FreeItem>(), SendbackItems=new List<SendbackItem>(), PayItems=new List<PayItem>()   },
                new GymRecord{ Id=30, ApprovalNo="NO-98765432101", Contacter="AndyYou", ContactPhone="0911911911", CreateOn=DateTime.Now, Deleted=false, Event="巨星齊聚苗栗縣元宵節活動26", Gym = gyms.FirstOrDefault(), LastEditor="SuperUser", LastUpdateOn=DateTime.Now, LendDateEnd=DateTime.Parse("2013/12/31"), LendDateStart= DateTime.Parse("2013/1/1"), LendUnit="輝網資訊", FreeItems=new List<FreeItem>(), SendbackItems=new List<SendbackItem>(), PayItems=new List<PayItem>()   },
                new GymRecord{ Id=31, ApprovalNo="NO-98765432102", Contacter="Calvert", ContactPhone="0922922922", CreateOn=DateTime.Now, Deleted=false, Event="春節晚會End", Gym = gyms.FirstOrDefault(), LastEditor="SuperUser", LastUpdateOn=DateTime.Now, LendDateEnd=DateTime.Parse("2013/12/31"), LendDateStart= DateTime.Parse("2013/1/1"), LendUnit="輝網資訊" , FreeItems=new List<FreeItem>(), SendbackItems=new List<SendbackItem>(), PayItems=new List<PayItem>()  }

            };

             payItems = new List<PayItem>() { 
                new PayItem{ Id=1, Name="付費項目1", GymRecord = gymRecords.Find(i => i.Id == 1), Comment="N/A", CreateOn=DateTime.Now, Deleted=false, IsPaid=true, LastEditor="Andy", ReturnGovOn=DateTime.Now, ReceiptCreateOn=DateTime.Now, ReceiptNo="收據-12345678910", LastUpdateOn=DateTime.Now, PaidOn=DateTime.Now, PayableDate= DateTime.Parse("2013/1/10"), Price=2991234  },
                new PayItem{ Id=2, Name="付費項目2", GymRecord = gymRecords.Find(i => i.Id == 1), Comment="N/A", CreateOn=DateTime.Now, Deleted=false, IsPaid=true, LastEditor="Andy", ReturnGovOn=DateTime.Now, ReceiptCreateOn=DateTime.Now, ReceiptNo="收據-12345678910", LastUpdateOn=DateTime.Now, PaidOn=DateTime.Now, PayableDate= DateTime.Parse("2013/1/10"), Price=2991234  },
                new PayItem{ Id=3, Name="付費項目3", GymRecord = gymRecords.Find(i => i.Id == 1), Comment="N/A", CreateOn=DateTime.Now, Deleted=false, IsPaid=true, LastEditor="Andy", ReturnGovOn=DateTime.Now, ReceiptCreateOn=DateTime.Now, ReceiptNo="收據-12345678910", LastUpdateOn=DateTime.Now, PaidOn=DateTime.Now, PayableDate= DateTime.Parse("2013/1/10"), Price=2991234  },
                new PayItem{ Id=4, Name="付費項目4", GymRecord = gymRecords.Find(i => i.Id == 1), Comment="N/A", CreateOn=DateTime.Now, Deleted=false, IsPaid=true, LastEditor="Andy", ReturnGovOn=DateTime.Now, ReceiptCreateOn=DateTime.Now, ReceiptNo="收據-12345678910", LastUpdateOn=DateTime.Now, PaidOn=DateTime.Now, PayableDate= DateTime.Parse("2013/1/10"), Price=2991234  },
                new PayItem{ Id=5, Name="付費項目5", GymRecord = gymRecords.Find(i => i.Id == 1), Comment="N/A", CreateOn=DateTime.Now, Deleted=false, IsPaid=true, LastEditor="Andy", ReturnGovOn=DateTime.Now, ReceiptCreateOn=DateTime.Now, ReceiptNo="收據-12345678910", LastUpdateOn=DateTime.Now, PaidOn=DateTime.Now, PayableDate= DateTime.Parse("2013/1/10"), Price=2991234  },
                new PayItem{ Id=6, Name="付費項目6", GymRecord = gymRecords.Find(i => i.Id == 1), Comment="N/A", CreateOn=DateTime.Now, Deleted=false, IsPaid=true, LastEditor="Andy", ReturnGovOn=DateTime.Now, ReceiptCreateOn=DateTime.Now, ReceiptNo="收據-12345678910", LastUpdateOn=DateTime.Now, PaidOn=DateTime.Now, PayableDate= DateTime.Parse("2013/1/10"), Price=2991234  },
                new PayItem{ Id=7, Name="付費項目7", GymRecord = gymRecords.Find(i => i.Id == 1), Comment="N/A", CreateOn=DateTime.Now, Deleted=false, IsPaid=true, LastEditor="Andy", ReturnGovOn=DateTime.Now, ReceiptCreateOn=DateTime.Now, ReceiptNo="收據-12345678910", LastUpdateOn=DateTime.Now, PaidOn=DateTime.Now, PayableDate= DateTime.Parse("2013/1/10"), Price=2991234  },
                new PayItem{ Id=10, Name="付費項目8", GymRecord = gymRecords.Find(i => i.Id == 1), Comment="N/A", CreateOn=DateTime.Now, Deleted=false, IsPaid=true, LastEditor="Andy", ReturnGovOn=DateTime.Now, ReceiptCreateOn=DateTime.Now, ReceiptNo="收據-12345678910", LastUpdateOn=DateTime.Now, PaidOn=DateTime.Now, PayableDate= DateTime.Parse("2013/1/10"), Price=2991234  },
                new PayItem{ Id=11, Name="付費項目9", GymRecord = gymRecords.Find(i => i.Id == 1), Comment="N/A", CreateOn=DateTime.Now, Deleted=false, IsPaid=true, LastEditor="Andy", ReturnGovOn=DateTime.Now, ReceiptCreateOn=DateTime.Now, ReceiptNo="收據-12345678910", LastUpdateOn=DateTime.Now, PaidOn=DateTime.Now, PayableDate= DateTime.Parse("2013/1/10"), Price=2991234  },
                new PayItem{ Id=12, Name="付費項目10", GymRecord = gymRecords.Find(i => i.Id == 1), Comment="N/A", CreateOn=DateTime.Now, Deleted=false, IsPaid=true, LastEditor="Andy", ReturnGovOn=DateTime.Now, ReceiptCreateOn=DateTime.Now, ReceiptNo="收據-12345678910", LastUpdateOn=DateTime.Now, PaidOn=DateTime.Now, PayableDate= DateTime.Parse("2013/1/10"), Price=2991234  },
                new PayItem{ Id=13, Name="付費項目11", GymRecord = gymRecords.Find(i => i.Id == 1), Comment="N/A", CreateOn=DateTime.Now, Deleted=false, IsPaid=true, LastEditor="Andy", ReturnGovOn=DateTime.Now, ReceiptCreateOn=DateTime.Now, ReceiptNo="收據-12345678910", LastUpdateOn=DateTime.Now, PaidOn=DateTime.Now, PayableDate= DateTime.Parse("2013/1/10"), Price=2991234  },
                new PayItem{ Id=14, Name="付費項目12", GymRecord = gymRecords.Find(i => i.Id == 1), Comment="N/A", CreateOn=DateTime.Now, Deleted=false, IsPaid=true, LastEditor="Andy", ReturnGovOn=DateTime.Now, ReceiptCreateOn=DateTime.Now, ReceiptNo="收據-12345678910", LastUpdateOn=DateTime.Now, PaidOn=DateTime.Now, PayableDate= DateTime.Parse("2013/1/10"), Price=2991234  },
                new PayItem{ Id=15, Name="付費項目13", GymRecord = gymRecords.Find(i => i.Id == 1), Comment="N/A", CreateOn=DateTime.Now, Deleted=false, IsPaid=true, LastEditor="Andy", ReturnGovOn=DateTime.Now, ReceiptCreateOn=DateTime.Now, ReceiptNo="收據-12345678910", LastUpdateOn=DateTime.Now, PaidOn=DateTime.Now, PayableDate= DateTime.Parse("2013/1/10"), Price=2991234  },
                new PayItem{ Id=16, Name="付費項目14", GymRecord = gymRecords.Find(i => i.Id == 1), Comment="N/A", CreateOn=DateTime.Now, Deleted=false, IsPaid=true, LastEditor="Andy", ReturnGovOn=DateTime.Now, ReceiptCreateOn=DateTime.Now, ReceiptNo="收據-12345678910", LastUpdateOn=DateTime.Now, PaidOn=DateTime.Now, PayableDate= DateTime.Parse("2013/1/10"), Price=2991234  },
                new PayItem{ Id=17, Name="付費項目15", GymRecord = gymRecords.Find(i => i.Id == 1), Comment="N/A", CreateOn=DateTime.Now, Deleted=false, IsPaid=true, LastEditor="Andy", ReturnGovOn=DateTime.Now, ReceiptCreateOn=DateTime.Now, ReceiptNo="收據-12345678910", LastUpdateOn=DateTime.Now, PaidOn=DateTime.Now, PayableDate= DateTime.Parse("2013/1/10"), Price=2991234  },
                new PayItem{ Id=18, Name="付費項目16", GymRecord = gymRecords.Find(i => i.Id == 1), Comment="N/A", CreateOn=DateTime.Now, Deleted=false, IsPaid=true, LastEditor="Andy", ReturnGovOn=DateTime.Now, ReceiptCreateOn=DateTime.Now, ReceiptNo="收據-12345678910", LastUpdateOn=DateTime.Now, PaidOn=DateTime.Now, PayableDate= DateTime.Parse("2013/1/10"), Price=2991234  },
                new PayItem{ Id=19, Name="付費項目17", GymRecord = gymRecords.Find(i => i.Id == 1), Comment="N/A", CreateOn=DateTime.Now, Deleted=false, IsPaid=true, LastEditor="Andy", ReturnGovOn=DateTime.Now, ReceiptCreateOn=DateTime.Now, ReceiptNo="收據-12345678910", LastUpdateOn=DateTime.Now, PaidOn=DateTime.Now, PayableDate= DateTime.Parse("2013/1/10"), Price=2991234  },
                new PayItem{ Id=20, Name="付費項目18", GymRecord = gymRecords.Find(i => i.Id == 1), Comment="N/A", CreateOn=DateTime.Now, Deleted=false, IsPaid=true, LastEditor="Andy", ReturnGovOn=DateTime.Now, ReceiptCreateOn=DateTime.Now, ReceiptNo="收據-12345678910", LastUpdateOn=DateTime.Now, PaidOn=DateTime.Now, PayableDate= DateTime.Parse("2013/1/10"), Price=2991234  },
                new PayItem{ Id=21, Name="付費項目19", GymRecord = gymRecords.Find(i => i.Id == 1), Comment="N/A", CreateOn=DateTime.Now, Deleted=false, IsPaid=true, LastEditor="Andy", ReturnGovOn=DateTime.Now, ReceiptCreateOn=DateTime.Now, ReceiptNo="收據-12345678910", LastUpdateOn=DateTime.Now, PaidOn=DateTime.Now, PayableDate= DateTime.Parse("2013/1/10"), Price=2991234  },
                new PayItem{ Id=22, Name="付費項目20", GymRecord = gymRecords.Find(i => i.Id == 1), Comment="N/A", CreateOn=DateTime.Now, Deleted=false, IsPaid=true, LastEditor="Andy", ReturnGovOn=DateTime.Now, ReceiptCreateOn=DateTime.Now, ReceiptNo="收據-12345678910", LastUpdateOn=DateTime.Now, PaidOn=DateTime.Now, PayableDate= DateTime.Parse("2013/1/10"), Price=2991234  },
                new PayItem{ Id=23, Name="付費項目21", GymRecord = gymRecords.Find(i => i.Id == 1), Comment="N/A", CreateOn=DateTime.Now, Deleted=false, IsPaid=true, LastEditor="Andy", ReturnGovOn=DateTime.Now, ReceiptCreateOn=DateTime.Now, ReceiptNo="收據-12345678910", LastUpdateOn=DateTime.Now, PaidOn=DateTime.Now, PayableDate= DateTime.Parse("2013/1/10"), Price=2991234  },
                new PayItem{ Id=24, Name="付費項目22", GymRecord = gymRecords.Find(i => i.Id == 1), Comment="N/A", CreateOn=DateTime.Now, Deleted=false, IsPaid=true, LastEditor="Andy", ReturnGovOn=DateTime.Now, ReceiptCreateOn=DateTime.Now, ReceiptNo="收據-12345678910", LastUpdateOn=DateTime.Now, PaidOn=DateTime.Now, PayableDate= DateTime.Parse("2013/1/10"), Price=2991234  }
            };

             freeItems = new List<FreeItem>() { 
                new FreeItem{  Id=1, ApprovalNo="FreeNO-123456789-1", Comment="N/A", CreateOn=DateTime.Now, Deleted=false, GymRecord=gymRecords.Find(i => i.Id==1), LastEditor="Eddy", LastUpdateOn=DateTime.Now, Name="免費項目-1"},
                new FreeItem{  Id=2, ApprovalNo="FreeNO-123456789-2", Comment="N/A", CreateOn=DateTime.Now, Deleted=false, GymRecord=gymRecords.Find(i => i.Id==1), LastEditor="Eddy", LastUpdateOn=DateTime.Now, Name="免費項目-2"},
                new FreeItem{  Id=3, ApprovalNo="FreeNO-123456789-3", Comment="N/A", CreateOn=DateTime.Now, Deleted=false, GymRecord=gymRecords.Find(i => i.Id==1), LastEditor="Eddy", LastUpdateOn=DateTime.Now, Name="免費項目-3"},
                new FreeItem{  Id=4, ApprovalNo="FreeNO-123456789-4", Comment="N/A", CreateOn=DateTime.Now, Deleted=false, GymRecord=gymRecords.Find(i => i.Id==1), LastEditor="Eddy", LastUpdateOn=DateTime.Now, Name="免費項目-4"},
                new FreeItem{  Id=5, ApprovalNo="FreeNO-123456789-5", Comment="N/A", CreateOn=DateTime.Now, Deleted=false, GymRecord=gymRecords.Find(i => i.Id==1), LastEditor="Eddy", LastUpdateOn=DateTime.Now, Name="免費項目-5"},
                new FreeItem{  Id=6, ApprovalNo="FreeNO-123456789-6", Comment="N/A", CreateOn=DateTime.Now, Deleted=false, GymRecord=gymRecords.Find(i => i.Id==1), LastEditor="Eddy", LastUpdateOn=DateTime.Now, Name="免費項目-6"},
                new FreeItem{  Id=7, ApprovalNo="FreeNO-123456789-7", Comment="N/A", CreateOn=DateTime.Now, Deleted=false, GymRecord=gymRecords.Find(i => i.Id==1), LastEditor="Eddy", LastUpdateOn=DateTime.Now, Name="免費項目-7"},
                new FreeItem{  Id=8, ApprovalNo="FreeNO-123456789-8", Comment="N/A", CreateOn=DateTime.Now, Deleted=false, GymRecord=gymRecords.Find(i => i.Id==1), LastEditor="Eddy", LastUpdateOn=DateTime.Now, Name="免費項目-8"},
                new FreeItem{  Id=9, ApprovalNo="FreeNO-123456789-9", Comment="N/A", CreateOn=DateTime.Now, Deleted=false, GymRecord=gymRecords.Find(i => i.Id==1), LastEditor="Eddy", LastUpdateOn=DateTime.Now, Name="免費項目-9"},
                new FreeItem{  Id=10, ApprovalNo="FreeNO-123456789-10", Comment="N/A", CreateOn=DateTime.Now, Deleted=false, GymRecord=gymRecords.Find(i => i.Id==1), LastEditor="Eddy", LastUpdateOn=DateTime.Now, Name="免費項目-10"},
                new FreeItem{  Id=11, ApprovalNo="FreeNO-123456789-11", Comment="N/A", CreateOn=DateTime.Now, Deleted=false, GymRecord=gymRecords.Find(i => i.Id==1), LastEditor="Eddy", LastUpdateOn=DateTime.Now, Name="免費項目-11"},
                new FreeItem{  Id=12, ApprovalNo="FreeNO-123456789-12", Comment="N/A", CreateOn=DateTime.Now, Deleted=false, GymRecord=gymRecords.Find(i => i.Id==1), LastEditor="Eddy", LastUpdateOn=DateTime.Now, Name="免費項目-12"},
                new FreeItem{  Id=13, ApprovalNo="FreeNO-123456789-13", Comment="N/A", CreateOn=DateTime.Now, Deleted=false, GymRecord=gymRecords.Find(i => i.Id==1), LastEditor="Eddy", LastUpdateOn=DateTime.Now, Name="免費項目-13"},
                new FreeItem{  Id=14, ApprovalNo="FreeNO-123456789-14", Comment="N/A", CreateOn=DateTime.Now, Deleted=false, GymRecord=gymRecords.Find(i => i.Id==1), LastEditor="Eddy", LastUpdateOn=DateTime.Now, Name="免費項目-14"},
                new FreeItem{  Id=15, ApprovalNo="FreeNO-123456789-15", Comment="N/A", CreateOn=DateTime.Now, Deleted=false, GymRecord=gymRecords.Find(i => i.Id==1), LastEditor="Eddy", LastUpdateOn=DateTime.Now, Name="免費項目-15"},
                new FreeItem{  Id=16, ApprovalNo="FreeNO-123456789-16", Comment="N/A", CreateOn=DateTime.Now, Deleted=false, GymRecord=gymRecords.Find(i => i.Id==1), LastEditor="Eddy", LastUpdateOn=DateTime.Now, Name="免費項目-16"},
                new FreeItem{  Id=17, ApprovalNo="FreeNO-123456789-17", Comment="N/A", CreateOn=DateTime.Now, Deleted=false, GymRecord=gymRecords.Find(i => i.Id==1), LastEditor="Eddy", LastUpdateOn=DateTime.Now, Name="免費項目-17"},
                new FreeItem{  Id=18, ApprovalNo="FreeNO-123456789-18", Comment="N/A", CreateOn=DateTime.Now, Deleted=false, GymRecord=gymRecords.Find(i => i.Id==1), LastEditor="Eddy", LastUpdateOn=DateTime.Now, Name="免費項目-18"},
                new FreeItem{  Id=19, ApprovalNo="FreeNO-123456789-19", Comment="N/A", CreateOn=DateTime.Now, Deleted=false, GymRecord=gymRecords.Find(i => i.Id==1), LastEditor="Eddy", LastUpdateOn=DateTime.Now, Name="免費項目-19"},
                new FreeItem{  Id=20, ApprovalNo="FreeNO-123456789-20", Comment="N/A", CreateOn=DateTime.Now, Deleted=false, GymRecord=gymRecords.Find(i => i.Id==1), LastEditor="Eddy", LastUpdateOn=DateTime.Now, Name="免費項目-20"},
                new FreeItem{  Id=21, ApprovalNo="FreeNO-123456789-21", Comment="N/A", CreateOn=DateTime.Now, Deleted=false, GymRecord=gymRecords.Find(i => i.Id==1), LastEditor="Eddy", LastUpdateOn=DateTime.Now, Name="免費項目-21"},
                new FreeItem{  Id=22, ApprovalNo="FreeNO-123456789-22", Comment="N/A", CreateOn=DateTime.Now, Deleted=false, GymRecord=gymRecords.Find(i => i.Id==1), LastEditor="Eddy", LastUpdateOn=DateTime.Now, Name="免費項目-22"},
                new FreeItem{  Id=23, ApprovalNo="FreeNO-123456789-23", Comment="N/A", CreateOn=DateTime.Now, Deleted=false, GymRecord=gymRecords.Find(i => i.Id==1), LastEditor="Eddy", LastUpdateOn=DateTime.Now, Name="免費項目-23"}
             };

             sendbackItems = new List<SendbackItem>() { 
                 new SendbackItem{ Id=1, Name="繳回項目-1", CheckNo="支票號碼-10000112341", Comment="N/A", CreateOn=DateTime.Now, Deleted=false, GymRecord=gymRecords.Find(i => i.Id ==1), LastEditor="Ken", LastUpdateOn=DateTime.Now, Price=999999, ReturnDate=DateTime.Parse("2013/12/31")},
                 new SendbackItem{ Id=2, Name="繳回項目-2", CheckNo="支票號碼-10000112341", Comment="N/A", CreateOn=DateTime.Now, Deleted=false, GymRecord=gymRecords.Find(i => i.Id ==2), LastEditor="Ken", LastUpdateOn=DateTime.Now, Price=999999, ReturnDate=DateTime.Parse("2013/12/31")},
                 new SendbackItem{ Id=3, Name="繳回項目-3", CheckNo="支票號碼-10000112341", Comment="N/A", CreateOn=DateTime.Now, Deleted=false, GymRecord=gymRecords.Find(i => i.Id ==3), LastEditor="Ken", LastUpdateOn=DateTime.Now, Price=999999, ReturnDate=DateTime.Parse("2013/12/31")},
                 new SendbackItem{ Id=4, Name="繳回項目-4", CheckNo="支票號碼-10000112341", Comment="N/A", CreateOn=DateTime.Now, Deleted=false, GymRecord=gymRecords.Find(i => i.Id ==4), LastEditor="Ken", LastUpdateOn=DateTime.Now, Price=999999, ReturnDate=DateTime.Parse("2013/12/31")},
                 new SendbackItem{ Id=5, Name="繳回項目-5", CheckNo="支票號碼-10000112341", Comment="N/A", CreateOn=DateTime.Now, Deleted=false, GymRecord=gymRecords.Find(i => i.Id ==5), LastEditor="Ken", LastUpdateOn=DateTime.Now, Price=999999, ReturnDate=DateTime.Parse("2013/12/31")},
                 new SendbackItem{ Id=6, Name="繳回項目-6", CheckNo="支票號碼-10000112341", Comment="N/A", CreateOn=DateTime.Now, Deleted=false, GymRecord=gymRecords.Find(i => i.Id ==6), LastEditor="Ken", LastUpdateOn=DateTime.Now, Price=999999, ReturnDate=DateTime.Parse("2013/12/31")},
                 new SendbackItem{ Id=7, Name="繳回項目-7", CheckNo="支票號碼-10000112341", Comment="N/A", CreateOn=DateTime.Now, Deleted=false, GymRecord=gymRecords.Find(i => i.Id ==7), LastEditor="Ken", LastUpdateOn=DateTime.Now, Price=999999, ReturnDate=DateTime.Parse("2013/12/31")},
                 new SendbackItem{ Id=8, Name="繳回項目-8", CheckNo="支票號碼-10000112341", Comment="N/A", CreateOn=DateTime.Now, Deleted=false, GymRecord=gymRecords.Find(i => i.Id ==8), LastEditor="Ken", LastUpdateOn=DateTime.Now, Price=999999, ReturnDate=DateTime.Parse("2013/12/31")},
                 new SendbackItem{ Id=9, Name="繳回項目-9", CheckNo="支票號碼-10000112341", Comment="N/A", CreateOn=DateTime.Now, Deleted=false, GymRecord=gymRecords.Find(i => i.Id ==9), LastEditor="Ken", LastUpdateOn=DateTime.Now, Price=999999, ReturnDate=DateTime.Parse("2013/12/31")}
             };

            gymRecords.Find(i => i.Id == 1).FreeItems = freeItems;
            gymRecords.Find(i => i.Id == 1).PayItems = payItems;
            gymRecords.Find(i => i.Id == 1).SendbackItems = sendbackItems;

            foreach (var record in gymRecords)
            {
                record.PayItems.Add(new PayItem { Id = 1000, Price = 99, PayableDate = DateTime.Parse("2011/1/1"), PaidOn = DateTime.Now, LastUpdateOn = DateTime.Now, ReceiptNo = "迴圈測試-111", ReceiptCreateOn = DateTime.Now, ReturnGovOn = DateTime.Now, LastEditor = "Guest", IsPaid = true, Deleted = false, CreateOn = DateTime.Now, Comment = "N/a", GymRecord = record, Name = "迴圈付費項目" });
                record.FreeItems.Add(new FreeItem { Id = 1000, Name = "迴圈免費項目", LastUpdateOn = DateTime.Now, LastEditor = "Guest", GymRecord = record, Deleted = false, CreateOn = DateTime.Now, Comment = "N/a", ApprovalNo = "免繳文號-987654321" });
                record.SendbackItems.Add(new SendbackItem {  Id=1000, ReturnDate=DateTime.Now, Price=99, LastUpdateOn=DateTime.Now, LastEditor="Guest", GymRecord=record, Deleted=false, CreateOn=DateTime.Now, Comment="N/a", CheckNo="支票號碼", Name="歸還項目名稱"});
            }
            #endregion
        }
        
        // 首頁-館場租借紀錄列表
        public ActionResult Index(int g=0, int p = 1)
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

            ViewData["Gyms"] = new SelectList(gyms, "Id", "Name", "");

            List<SelectListItem> searchColumns= new List<SelectListItem>();
            searchColumns.Add(new SelectListItem() { Text = "借用事由", Value = "1", Selected = false });
            searchColumns.Add(new SelectListItem() { Text = "借用單位", Value = "2", Selected = false });
            SelectList sl = new SelectList(searchColumns, "Value", "Text");
            ViewData["SearchColumns"] = sl;

            var data = gymRecords.Find(i => i.Gym.Id == g);
            if (data == null)
            {
                return View(gymRecords.ToPagedList(pageNumber: p, pageSize: 20));
            }
            return View(gymRecords.Where(i => i.Gym.Id == g).ToPagedList(pageNumber: p, pageSize:20));
            
            //if (g == 0)
            //{
            //    ViewData.Model = gymRecords.ToPagedList(pageNumber: p, pageSize:20);
            //    RedirectToAction("Index");
            //}
            //else
            //{
            //    ViewData.Model = gymRecords.Where(i => i.Gym.Id == g).ToPagedList(pageNumber: p, pageSize:20);
            //}

            // ViewData.Model = gymRecords;
            return View();
        }


        private bool Level()
        {
            return true;
        }

        // 館場租借明細
        public ActionResult Detail(int id)
        {
            var data = gymRecords.Find(i => i.Id == id);
            return View(data);
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
