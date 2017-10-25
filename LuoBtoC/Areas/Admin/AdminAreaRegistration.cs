using System.Web.Mvc;

namespace LuoBtoC.Areas.Admin
{
    public class AdminAreaRegistration : AreaRegistration
    {
        public override string AreaName
        {
            get
            {
                return "Admin";
            }
        }


        public override void RegisterArea(AreaRegistrationContext context)
        {
            context.MapRoute(
                "Admin_default",
                "{controller}/{action}/{id}",
                new { action = "Login", id = UrlParameter.Optional }
                
            );
           
        }
    }
}
