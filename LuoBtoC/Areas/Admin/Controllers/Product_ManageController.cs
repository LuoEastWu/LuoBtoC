using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LuoBtoC.Areas.Admin.Controllers
{
    public class Product_ManageController : Controller
    {
        //
        // GET: /Admin/Product_Manage/
        BLL.bll_Product bll_Product = new BLL.bll_Product();
        public ActionResult Product_Manage()
        {
           
            SqlModel.Product product = new SqlModel.Product();
            BLL.bll_ComDataList bll_ComData = new BLL.bll_ComDataList();
            Dictionary<string, string> dicFunctionList = new Dictionary<string, string>();
            string Ids = "";
            string[] numstr = { "Page", "page", "productname", "producttypeids", "Ids" };
            dicFunctionList.Add("添加", "false");
            dicFunctionList.Add("修改", "false");
            dicFunctionList.Add("删除", "false");
            string url = Request.Url.ToString();
            if (url.IndexOf("adminsys") > -1)
            {
                url = url.Replace("adminsys", "Adminsys");
            }
            url = url.Substring(url.IndexOf("Adminsys") + 9);
            url = Collections.publicHandle.GetSubStr(numstr, url);
            if (!ModelState.IsValid)
            {
                if (Request.QueryString["DeID"] != null)
                {
                    //得到需要删除的记录的编号（Id）
                    clear();
                }
                else
                {
                    Session["urlLink"] = Request.RawUrl;
                }
                //bing_dd_type();
                //BindDate();
            }
        
            return View();
        }

        /// <summary>
        /// 删除
        /// </summary>
        protected void clear()
        {
            try
            {
                long ID = Convert.ToInt64(Request.QueryString["DeID"].ToString());
               BLL.bll_Product bll1 = new BLL.bll_Product();
                if (bll_Product.Delete(ID))
                {
                    string strUrl = "Product_Manage.aspx";
                    if (Session["urlLink"] != null)
                    {
                        strUrl = Session["urlLink"].ToString();
                        Session["urlLink"] = null;
                    }
                    Content(Collections.publicHandle.ShowMessage("删除成功！", strUrl));
                 

                }
            }
            catch (Exception ex)
            {
                Content(Collections.publicHandle.ShowMessage(ex.Message));
            }
        }


        public ActionResult ProductType_Manage()
        {
            return View();
        }

        public ActionResult Product_Add()
        {
            return View();
        }

        public ActionResult Product_Update()
        {
            return View();
        }

        public ActionResult ProductType_Add()
        {
            return View();
        }

        public ActionResult ProductType_Update()
        {
            return View();
        }
    }
}
