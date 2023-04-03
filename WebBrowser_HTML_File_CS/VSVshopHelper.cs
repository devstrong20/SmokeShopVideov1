using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmokeShopVideo
{
   public partial  class VSVshopHelper
    {
        public partial class DemoTbl
        {
            public Guid? Id { get; set; }
            public string Name { get; set; }
            public decimal? Salary { get; set; }
            public string Password { get; set; }
        }

        public class StatusCode

        {
            public int VsvaccountId { get; set; }
            public int Status { get; set; }
            public string Username { get; set; }
        }
        public class VSVShopVideos
        {
            public int? Evid { get; set; }
            public int? VidId { get; set; }
            public int? VSVAccountID { get; set; }
            public string Url { get; set; }
            public DateTime PlayTimeStamp { get; set; }
            public string VideoId { get; set; }
        }
        public class VSVShopEntertainmentVideoList
        {
            public int? Evid { get; set; }

        }
        public class VSVShopVideosDTO
        {
            public List<VSVShopVideos> VideosLists { get; set; }
            public bool LoopEnded { get; set; }
        }

    }
}
