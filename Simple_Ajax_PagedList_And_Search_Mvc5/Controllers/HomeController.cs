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
        public ActionResult Index(string searchString, string sortOption, int page = 1)
        {
            int pageSize = 10;

            ApplicationDbContext dbContext = new ApplicationDbContext();

            var products = dbContext.Products.AsQueryable();

            if (!String.IsNullOrEmpty(searchString))
            {
                products = dbContext.Products.Where(p => p.Name.ToLower().Contains(searchString));
            }
            switch (sortOption)
            {
                case "name_acs":
                    products = products.OrderBy(p => p.Name);
                    break;
                case "name_desc":
                    products = products.OrderByDescending(p => p.Name);
                    break;
                case "price_acs":
                    products = products.OrderBy(p => p.Price);
                    break;
                case "price_desc":
                    products = products.OrderByDescending(p => p.Price);
                    break;

                case "qty_acs":
                    products = products.OrderBy(p => p.Qty);
                    break;
                case "qty_desc":
                    products = products.OrderByDescending(p => p.Qty);
                    break;
                default:
                    products = products.OrderBy(p => p.Id);
                    break;

            }


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