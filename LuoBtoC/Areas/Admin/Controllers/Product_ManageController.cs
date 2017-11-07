using System;
using System.Collections.Generic;
using System.Data;
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
            SqlModel.Home.ProductModel productM = new SqlModel.Home.ProductModel();
            if (ModelState.IsValid)
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
                productM= BindDate();
            }

            return View(productM);
        }

        private SqlModel.Home.ProductModel BindDate(string searchkey = "")
        {
            BLL.bll_Product bll_Product = new BLL.bll_Product();
           
            string whereStr;
            if (Request.QueryString["producttypeids"] != null && Request.QueryString["producttypeids"] != "")
            {
                whereStr = "  Product.IsDelete=0 ";
            }
            else
            {
                if (Request.QueryString["TypeId"] != null && Request.QueryString["TypeId"] != "")
                {
                    getIds(Request.QueryString["TypeId"]);
                    whereStr = "  Product.IsDelete=0 and ProductTypeId in(" + Ids + Request.QueryString["TypeId"] + ")";
                }
                else
                {
                    whereStr = "  Product.IsDelete=0 ";
                }
            }

            #region 按查询条件查询数据
            if (Request.QueryString["productname"] != null && Request.QueryString["productname"] != "")
            {
               ViewBag.ProductName = Request.QueryString["productname"].ToString();
                whereStr += " and productname like '%" + Request.QueryString["productname"] + "%'";
            }
            if (Request.QueryString["producttypeids"] != null && Request.QueryString["producttypeids"] != "")
            {
                ViewBag.ddlProductTypeValue = Request.QueryString["producttypeids"].ToString();
                string aa = Request.QueryString["Ids"];
                whereStr += " and ProductTypeId in(" + Request.QueryString["Ids"] + Request.QueryString["producttypeids"].Split(new char[] { ',' })[0] + ")";
            }
            #endregion
            SqlModel.Home.ProductModel proLIst = new SqlModel.Home.ProductModel();
            proLIst.ProList = bll_Product.GetPage(whereStr, "Id desc");
           
            if (string.IsNullOrEmpty(searchkey))
            {
                searchkey = string.Empty;
            }
            Collections.BasePageModel page = new Collections.BasePageModel()
            {
                SearchKeyWord= searchkey,
                CurrentIndex = Int32.Parse("1"),
                TotalCount = proLIst.ProList.Count,
                ActionName = "Product_Manage"
            };
            SqlModel.Home.ProductModel proLIst2 = new SqlModel.Home.ProductModel();
            proLIst2.ProList = proLIst.ProList.Skip((page.CurrentIndex - 1) * page.PageSize).Take(page.PageSize).ToList();
            ViewData["pagemodel"] = page;
            return proLIst2;
        }
        string Ids = "";
        /// <summary>
        /// 获取Ids
        /// </summary>
        /// <param name="fid"></param>
        private void getIds(string fid)
        {
            BLL.ComDataList comData = new BLL.ComDataList();
            DataTable dt11 = comData.GetComList<SqlModel.ProductType>(0, " id", "Fid=" + fid, "");
            if (dt11.Rows.Count > 0)
            {
                for (int i = 0; i < dt11.Rows.Count; i++)
                {
                    Ids += dt11.Rows[i][0].ToString() + ",";
                    getIds(dt11.Rows[i][0].ToString());
                }
            }
        }

        /// <summary>
        /// 删除
        /// </summary>
        public void clear()
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
                  
                    Response.Write(Collections.publicHandle.ShowMessage("删除成功！", "Product_Manage/Product_Manage"));
                    Response.End();
                }
            }
            catch (Exception ex)
            {
                Response.Write(Collections.publicHandle.ShowMessage(ex.Message, "Product_Manage/Product_Manage"));
                Response.End();
            }
        }

        /// <summary>
        /// 获取商品类型名称
        /// </summary>
        /// <param name="typeId"></param>
        /// <returns></returns>
        public static string getProductTypeName(string typeId)
        {
            BLL.Bll_ProductType ptbll = new BLL.Bll_ProductType();

            SqlModel.ProductType ptmodel = new SqlModel.ProductType();
            if (typeId != "0" && typeId != null && typeId != "")
            {
                ptmodel = ptbll.GetModel(Convert.ToInt64(typeId));
                if (ptmodel != null)
                {
                    return ptmodel.TypeName;
                }
                else
                {
                    return "";
                }
            }
            else
            {
                return "";
            }
        }
        /// <summary>
        /// 绑定品牌
        /// </summary>
        /// <param name="typeId"></param>
        /// <returns></returns>
        public static string getBrandName(string typeId)
        {
            BLL.Bll_Brand brbll = new BLL.Bll_Brand();
            SqlModel.Brand brmodel = new SqlModel.Brand();
            if (typeId != "0" && typeId != null && typeId != "")
            {
                brmodel = brbll.GetModel(Convert.ToInt64(typeId));
                if (brmodel != null)
                {
                    return brmodel.BrandName;
                }
                else
                {
                    return "";
                }
            }
            else
            {
                return "";
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
