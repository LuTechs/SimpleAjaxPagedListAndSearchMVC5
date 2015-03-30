using System.Data.Entity;
using System.Data.Entity.Migrations;
using Simple_Ajax_PagedList_And_Search_Mvc5.Models;

namespace Simple_Ajax_PagedList_And_Search_Mvc5
{
    public class DbInit:CreateDatabaseIfNotExists<ApplicationDbContext>
    {
        protected override void Seed(ApplicationDbContext context)
        {
            base.Seed(context);
            for (int i = 0; i < 1000; i++)
            {
                context.Products.AddOrUpdate(p => p.Id, new Product
                {
                    Name = "Product " + i,
                    Price = 2 * i,
                    Qty = 3 * i
                });
            }
        }
    }
}