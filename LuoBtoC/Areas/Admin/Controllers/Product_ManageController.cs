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
                SelectList selList1 = new SelectList(bing_dd_type(), "idDepth", "TypeName");
                ViewBag.deptSelectItems = selList1;

                productM = BindDate(Request.QueryString["productname"], Request.QueryString["producttypeids"], Request.QueryString["Ids"]);
            }

            return View(productM);
        }

        private SqlModel.Home.ProductModel BindDate(string productname, string producttypeids, string Ids, string searchkey = "")
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
            if (productname != null && productname != "")
            {
                ViewBag.ProductName = productname;
                whereStr += " and productname like '%" + productname + "%'";
            }
            if (producttypeids != null && producttypeids != "")
            {
                ViewBag.ddlProductTypeValue = producttypeids;

                whereStr += " and ProductTypeId in(" + Ids + producttypeids.Split(new char[] { ',' })[0] + ")";
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
                SearchKeyWord = searchkey,
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

        BLL.ComDataList combll = new BLL.ComDataList();
        /// <summary>
        /// 一级菜单下拉框
        /// </summary>
        public List<LuoBtoC.Areas.Admin.Models.ProductTypeList> bing_dd_type()
        {
            try
            {
                List<LuoBtoC.Areas.Admin.Models.ProductTypeList> ddlProductType = new List<LuoBtoC.Areas.Admin.Models.ProductTypeList>();
                DataTable dt = new DataTable();
                if (Request.QueryString["TypeId"] == null || Request.QueryString["TypeId"] == "" || Request.QueryString["TypeId"] == "0")
                {

                    ddlProductType.Add(new Models.ProductTypeList() { TypeName = "所有商品类型", idDepth = "0,-1" });
                    dt = combll.GetComList<SqlModel.ProductType>(0, " id,TypeName,Depth ", " isdelete=0 and depth=0 and Fid=0 ", " Sort asc,id desc ");
                }
                else
                {
                    dt = combll.GetComList<SqlModel.ProductType>(0, " id,TypeName,Depth ", " isdelete=0 and id=" + Request.QueryString["TypeId"], " Sort asc,id desc ");
                }
                if (dt != null && dt.Rows.Count > 0)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        ddlProductType.Add(new Models.ProductTypeList()
                        {
                            TypeName = "╋" + dt.Rows[i]["TypeName"].ToString(),
                            idDepth = dt.Rows[i]["id"].ToString() + "," + dt.Rows[i]["Depth"].ToString()
                        });
                        ddlProductType.AddRange(BindChild(dt.Rows[i]["id"].ToString(), Convert.ToInt32(dt.Rows[i]["Depth"].ToString()) + 1));
                    }
                }
                return ddlProductType;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// 绑定子下拉框
        /// </summary>
        /// <param name="fatherid"></param>
        /// <param name="depth"></param>
        public List<LuoBtoC.Areas.Admin.Models.ProductTypeList> BindChild(string fatherid, int depth)
        {
            try
            {
                DataTable dt = combll.GetComList<SqlModel.ProductType>(0, " id,TypeName,Depth ", " isdelete=0 and Depth=" + depth + " and Fid=" + fatherid + " ", " Sort asc,id desc ");
                List<LuoBtoC.Areas.Admin.Models.ProductTypeList> weightList = new List<LuoBtoC.Areas.Admin.Models.ProductTypeList>();
                if (dt != null && dt.Rows.Count > 0)
                {

                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        string separator = "├──";
                        if (depth > 1)
                        {
                            for (int j = 2; j <= depth; j++)
                            {
                                separator += "──";
                            }
                        }
                        weightList.Add(new Models.ProductTypeList()
                        {
                            TypeName = separator + dt.Rows[i]["TypeName"].ToString(),
                            idDepth = dt.Rows[i]["id"].ToString() + "," + dt.Rows[i]["Depth"].ToString()
                        });
                        BindChild(dt.Rows[i]["id"].ToString(), Convert.ToInt32(dt.Rows[i]["Depth"].ToString()) + 1);
                    }

                }
                return weightList;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        string[] numstr = { "Page", "page", "productname", "producttypeids", "Ids" };

        [HttpPost]
        public ActionResult btnquery(string productname, string producttypeids)
        {

            string url = Request.Url.ToString();
            url = url.Substring(url.LastIndexOf('/') + 1);
            url = Collections.publicHandle.GetSubStr(numstr, url);
            getIds(producttypeids.Split(new char[] { ',' })[0]);
            SqlModel.Home.ProductModel productModel = new SqlModel.Home.ProductModel();
            productModel = BindDate(productname, producttypeids, Ids);
            //if (url.IndexOf('?') > -1)
            //{
            //    Response.Redirect(url + "&productname=" + productname + "&producttypeids=" + producttypeids + "&Ids=" + Ids);
            //}
            //else
            //{
            //    Response.Redirect(url + "?productname=" + productname + "&producttypeids=" + producttypeids + "&Ids=" + Ids);
            //}
            return PartialView(productModel);
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
