
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SqlSugar;
using System.Data;

namespace LuoBtoC.Controllers
{
    public class MemberController : Controller
    {
        //
        // GET: /Member/

        public ActionResult MemberInfo(SqlModel.MemberModel.Member model)
        {
            if (ModelState.IsValid)
            {
                if (Session["MemberID"] == null)
                {
                    string js = "<script language=javascript>alert('{0}');location.href ='{1}'</script>";
                    Response.Write(string.Format(js, "对不起，您没有登录，或登录时间过长，请重新登录！", "/Account/Login"));
                    Response.End();
                }
                else
                {
                    BLL.bll_Member member = new BLL.bll_Member();
                    model = member.GetModel(SqlSugar.SqlFunc.ToInt64(Session["MemberID"]));
                }
            }

            return View(model);

        }



        public ActionResult Collection(string index, string searchkey)
        {
            if (string.IsNullOrEmpty(index))
            {
                index = "1";
            }
            if (string.IsNullOrEmpty(searchkey))
            {
                searchkey = string.Empty;
            }
            BLL.Bll_Collection bllC = new BLL.Bll_Collection();
            SqlModel.MemberModel.CollectionModel totalList = new SqlModel.MemberModel.CollectionModel();
            string strWhere = "Collection.Isdelete=0 ";
            if (Session["MemberID"] != null)
            {
                strWhere += " and MemberId='" + Session["MemberID"] + "'";
            }
            totalList.CollectionList = bllC.getPape(strWhere, "Id desc");
            Collections.BasePageModel page = new Collections.BasePageModel()
            {
                SearchKeyWord = searchkey,
                CurrentIndex = Int32.Parse(index),
                TotalCount = totalList.CollectionList.Count,
                ActionName = "Collection"
            };
            SqlModel.MemberModel.CollectionModel pageList = new SqlModel.MemberModel.CollectionModel();
            pageList.CollectionList = totalList.CollectionList.Skip((page.CurrentIndex - 1) * page.PageSize).Take(page.PageSize).ToList();
            ViewData["pagemodel"] = page;
            return View(pageList);

        }



        Collections.BuyShopPing bsp = new Collections.BuyShopPing();
        public ActionResult Shoppingcart()
        {
            SqlModel.MemberModel.ShoppingcartModel spm = new SqlModel.MemberModel.ShoppingcartModel();
            if (ModelState.IsValid)
            {

                if (Request.QueryString["mode"] != "view")
                {
                    int pid = Request.QueryString["ProductID"].ObjToInt();
                    int num = Request.QueryString["num"].ObjToInt();
                    if (pid > 0)
                    {
                        BLL.bll_Product proBll = new BLL.bll_Product();
                        SqlModel.Product model = proBll.GetModel(Convert.ToInt64(System.Web.HttpContext.Current.Request["ProductID"]));
                        bsp.UpdateShoppingCart(model);
                    }
                    if (Request.QueryString["flag"] == "Clear")
                    {
                        if (Session["myCartTable"] != null)
                        {
                            DataTable nowTable2 = (DataTable)Session["myCartTable"];
                            nowTable2.Rows.Clear();
                            Session["myCartTable"] = nowTable2;
                        }
                    }
                }
                else
                {
                    if (!string.IsNullOrEmpty(Request.QueryString["Erroinfo"]))
                    {
                        string js = "<script language=javascript>alert('{0}');location.href ='{1}'</script>";
                        Response.Write(string.Format(js, Request.QueryString["Erroinfo"].ToString(), "/Home/index"));
                        Response.End();
                    }
                }



                if (Session["myCartTable"] != null)
                {

                    spm.proModel = Collections.ModelConvertHelper<SqlModel.Product>.ConvertToModel((DataTable)Session["myCartTable"]).ToList();

                }
                ViewBag.litSunMoney = bsp.GetCaculatorSum().ToString("￥0.00");


            }
            return View(spm);
        }

        public ActionResult Review(string index, string searchkey)
        {

            if (string.IsNullOrEmpty(index))
            {
                index = "1";
            }
            if (string.IsNullOrEmpty(searchkey)) 
            {
                searchkey = string.Empty;
            }
            SqlModel.MemberModel.ReviewModel revList = new SqlModel.MemberModel.ReviewModel();
            BLL.bll_Review bllRev = new BLL.bll_Review();
            string whereStr = "Review.Isdelete=0";
            if (Session["MemberID"] != null)
            {
                whereStr += " and MemberId=" + Session["MemberID"].ToString();
            }

            revList.RevieList = bllRev.getPage(whereStr, " Id desc ");
            Collections.BasePageModel page = new Collections.BasePageModel()
            {
                SearchKeyWord = searchkey,
                CurrentIndex = Int32.Parse(index),
                TotalCount = revList.RevieList.Count,
                ActionName = "Review"
            };
            SqlModel.MemberModel.ReviewModel revList2 = new SqlModel.MemberModel.ReviewModel();
            revList2.RevieList = revList.RevieList.Skip((page.CurrentIndex - 1) * page.PageSize).Take(page.PageSize).ToList();
            ViewData["pagemodel"] = page;
            return View(revList2);
        }


        public void lbnTuo()
        {
            Session["MemberID"] = null;
            Session["MemberName"] = null;
            Session["MemberRankId"] = null;
            string js = "<script language=javascript>alert('{0}');location.href ='{1}'</script>";
            Response.Write(string.Format(js, "安全退出成功！", "/Home/index"));
            Response.End();
        }

        public void CollectionDelete(long collectionID)
        {
            BLL.Bll_Collection bllColl = new BLL.Bll_Collection();
            SqlModel.Collection model = bllColl.GetModel(collectionID);
            model.IsDelete = true;
            bllColl.Update(model);
            string js = "<script language=javascript>alert('{0}');location.href ='{1}'</script>";
            Response.Write(string.Format(js, "成功！", "/Member/Collection"));
            Response.End();
        }
    }
}
