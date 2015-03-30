using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;
using Simple_Ajax_PagedList_And_Search_Mvc5.Models;

namespace Simple_Ajax_PagedList_And_Search_Mvc5.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index(string currentFilter, string searchString, int page = 1)
        {
            int pageSize = 10;

            ApplicationDbContext dbContext = new ApplicationDbContext();

            var products = dbContext.Products.AsQueryable();

            if (!String.IsNullOrEmpty(searchString))
            {
                products = dbContext.Products.Where(p => p.Name.ToLower().Contains(searchString));
            }
            products = products.OrderBy(p => p.Id);


            return Request.IsAjaxRequest()
                ? (ActionResult)PartialView("ProductList", products.ToPagedList(page, pageSize))
                : View(products.ToPagedList(page, pageSize));
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