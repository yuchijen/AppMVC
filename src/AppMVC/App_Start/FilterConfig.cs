using AppMVC.Filter;
using System.Web;
using System.Web.Mvc;

namespace AppMVC
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            //filters.Add(new HandleErrorAttribute());
            filters.Add(new AuthorizeAttribute());//New Line
            //filters.Add(new HandleErrorAttribute());//ExceptionFilter
            filters.Add(new CustomExceptionFilter());
            
        }
    }
}
