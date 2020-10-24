using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TestAddress.Models;

namespace TestAddress.Controllers
{
    public class HomeController : Controller
    {
        DataTestAddressEntities db = new DataTestAddressEntities();
        public ActionResult Index()
        {
            return View();
        }
        public PartialViewResult dsProvince()
        {
            List<Province> dsTinh = db.Provinces.ToList();
            return PartialView(dsTinh);
        }
        public PartialViewResult dsDistrict(int? id)
        {
            List<District> dsHuyen = new List<District>();
            if (id == null)
            {
                dsHuyen = db.Districts.ToList();
            }
            else
            {
                dsHuyen = db.Districts.Where(n => n.province_id == id).ToList();
            }
            return PartialView(dsHuyen);
        }
        public PartialViewResult dsCommune(int? id)
        {
            List<Commune> dsXa = new List<Commune>();
            if(id == null)
            {
                dsXa = db.Communes.ToList();

            }
            else
            {
                dsXa = db.Communes.Where(n => n.district_id == id).ToList();
            }
            return PartialView(dsXa);
        }
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}