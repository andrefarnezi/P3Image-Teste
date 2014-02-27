using System.Web;
using System.Web.Mvc;

namespace P3Image_Teste.Administracaoistracao
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}