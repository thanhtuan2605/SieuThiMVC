using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SieuThiMVC.Models
{
    public class Advertisement
    {
        public string ImgLink;
        public string ImgTitle;
        static public TimeSpan PassTime = new TimeSpan(30,0,0,0,0);
        static public List<Advertisement> GetAdList()
        {
            var adbo = new AdvertisementDBO();
            return adbo.GetAdvertisement(DateTime.Today - PassTime);
        }
    }
}
