using System.Web;
using System.Web.Mvc;

namespace Simple_Ajax_PagedList_And_Search_Mvc5
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
