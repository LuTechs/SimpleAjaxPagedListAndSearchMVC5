
using System.Data.Entity;


namespace Simple_Ajax_PagedList_And_Search_Mvc5.Models
{
    public class ApplicationDbContext:DbContext
    {
        public ApplicationDbContext()
            : base("DefaultConnection")
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

        public DbSet<Product> Products { get; set; }
    }
}