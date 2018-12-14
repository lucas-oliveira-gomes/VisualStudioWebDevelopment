using System.Web;
using System.Web.Mvc;

namespace AspNetVS2017.Capitulo03.Portfolio
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
