using LuoBtoC.Areas.Admin.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LuoBtoC.Areas.Admin.Controllers
{
    public class AdminController : Controller
    {
        //
        // GET: /Admin/Admin/
        public ActionResult Login() 
        {
            return View();
           // F:\CSharpCode\GitHub\MvcBtc\LuoBtoC\LuoBtoC\Areas\Admin\Views\Shared\Admin_Layout.cshtml
        }

        public ActionResult LoginReset(LoginModel model)
        {
            model = new LoginModel();
            return View(model);
            // F:\CSharpCode\GitHub\MvcBtc\LuoBtoC\LuoBtoC\Areas\Admin\Views\Shared\Admin_Layout.cshtml
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult Login(LoginModel model, string returnUrl)
        {
            BLL.bll_UserInfo bll = new BLL.bll_UserInfo();
            string strSql = " UserName='" +model.UserName + "' and Password='" + model.Password + "' and isdelete=0";
            List<SqlModel.UserInfo> userInfo = bll.GetList(strSql);
            if (userInfo.Count > 0)
            {
                Session["UserName"] = userInfo[0].UserName;
                Session["UserType"] = userInfo[0].UserType;
                return RedirectToAction("Index");
            }
            else 
            {
                ModelState.AddModelError("", "用户名或密码不正确，请重新输入！");
                return View(model);
            }
           
        }




        public ActionResult Index()
        {
            if (Session["UserName"] == null)
            {
                return RedirectToAction("Login");
            }
            else 
            {
                return View();
            }
           
            // F:\CSharpCode\GitHub\MvcBtc\LuoBtoC\LuoBtoC\Areas\Admin\Views\Shared\Admin_Layout.cshtml
        }


        public ActionResult Top()
        {
            return View();
        }

        public ActionResult Left()
        {
            BLL.bll_MenuInfo bll_Menu = new BLL.bll_MenuInfo();
            MenuInfoModel list_Menu = new MenuInfoModel();
            list_Menu.listMenu= bll_Menu.GetList("IsDelete=0", "Sort asc");
            return View(list_Menu);
        }

        public ActionResult Down()
        {
            return View();
        }

        public ActionResult Exit() 
        {
            return View();
        }

    }
}
