using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LuoBtoC.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index(SqlModel.Home.IndexModel model)
        {
            BLL.bll_Product bllPro = new BLL.bll_Product();
            model.productList = bllPro.GetListByPage(" IsDelete=0", " sort", 0, 6);
            BLL.bll_Advert blladv = new BLL.bll_Advert();
            model.advertList = blladv.GetList(4, " isdelete=0 and AdvertTypeID=3 ", " sort asc,id desc");
            return View(model);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your app description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        #region 商品分类
        
       
        public ActionResult Products(string index, string searchkey)
        {
            if (Request.QueryString["ProductTypeId"] != null && Request.QueryString["ProductTypeId"] != "")
            {

                BLL.Bll_ProductType bllpt = new BLL.Bll_ProductType();
                SqlModel.ProductType modelpt = bllpt.GetModel(Convert.ToInt64(Request.QueryString["ProductTypeId"]));
                ViewBag.strTypeName = "<b>产品分类：</b>" + modelpt.TypeName;

            }
            else if (Request.QueryString["keyword"] != null && Request.QueryString["keyword"] != "")
            {
                ViewBag.strTypeName = Server.UrlDecode(Request.QueryString["keyword"]) + " 系列产品";
            }
            BLL.bll_Product BllPro = new BLL.bll_Product();
            string whereStr = "Product.Isdelete=0";
            if (Request.QueryString["ProductTypeId"] != null && Request.QueryString["ProductTypeId"] != "")
            {
                whereStr += " and ProductTypeId in (" + getProductTypeIds(Convert.ToInt64(Request.QueryString["ProductTypeId"])) + Request.QueryString["ProductTypeId"] + ")";
            }
            if (Request.QueryString["keyword"] != null && Request.QueryString["keyword"] != "")
            {
                whereStr += " and productName like '%" + Server.UrlDecode(Request.QueryString["keyword"]) + "%' ";
            }
            SqlModel.Home.ProductModel proLIst = new SqlModel.Home.ProductModel();
            proLIst.ProList= BllPro.GetPage(whereStr, "Id desc");
            if (string.IsNullOrEmpty(index))
            {
                index = "1";
            }
            if (string.IsNullOrEmpty(searchkey)) 
            {
                searchkey = string.Empty;
            }
            Collections.BasePageModel page = new Collections.BasePageModel()
            {
                SearchKeyWord = searchkey,
                CurrentIndex = Int32.Parse(index),
                TotalCount = proLIst.ProList.Count,
                ActionName = "Products"
            };
            SqlModel.Home.ProductModel proLIst2 = new SqlModel.Home.ProductModel();
            proLIst2.ProList = proLIst.ProList.Skip((page.CurrentIndex - 1) * page.PageSize).Take(page.PageSize).ToList();
            ViewData["pagemodel"] = page;
            return View(proLIst2);
        }


        /// <summary>
        /// 获取产品分类ID及所有子类ID
        /// </summary>
        /// <param name="ProductTypeId"></param>
        /// <returns></returns>
        private string getProductTypeIds(long ProductTypeId)
        {
            string strProductTypes = "";

            BLL.Bll_ProductType bllpt = new BLL.Bll_ProductType();
            List<SqlModel.ProductType> proList = bllpt.GetList(" isdelete=0 and fid=" + ProductTypeId);

            if (proList.Count > 0)
            {
                for (int i = 0; i < proList.Count; i++)
                {
                    strProductTypes += proList[i].ID + ",";

                    strProductTypes += getProductTypeIds(Convert.ToInt64(proList[i].ID));
                }

                //strProductTypes = strProductTypes.Substring(0, strProductTypes.Length - 1);
            }

            return strProductTypes;
        }

        #endregion

        #region 获取资讯
        
        
        public ActionResult Information(string index, string searchkey) 
        {
            if (Request.QueryString["InformationTypeId"] != null && Request.QueryString["InformationTypeId"] != "")
            {
                BLL.bll_InformationType bll = new BLL.bll_InformationType();
               SqlModel.InformationType model = bll.GetModel(Convert.ToInt64(Request.QueryString["InformationTypeId"]));
              ViewBag.strTypeName = model.TypeName;
            }
            if (string.IsNullOrEmpty(index))
            {
                index = "1";
            }
            if (string.IsNullOrEmpty(searchkey)) 
            {
                searchkey = string.Empty;
            }
            BLL.BLL_Information bllInf = new BLL.BLL_Information();
            SqlModel.Home.InformationModel infoList = new SqlModel.Home.InformationModel();
            SqlModel.Home.InformationModel infoList2 = new SqlModel.Home.InformationModel();
            string whereStr = "Information.Isdelete=0";
            if (Request.QueryString["InformationTypeId"] != null && Request.QueryString["InformationTypeId"] != "")
            {
                whereStr += " and InformationTypeId in (" + getInformationTypeIds(Convert.ToInt64(Request.QueryString["InformationTypeId"])) + Request.QueryString["InformationTypeId"] + ")";
            }
            infoList.infList = bllInf.GetPage(whereStr, "Id desc");
           Collections.BasePageModel page = new Collections.BasePageModel()
           {
               SearchKeyWord = searchkey,
               CurrentIndex = Int32.Parse(index),
               TotalCount = infoList.infList.Count,
               ActionName = "Information"
           };
           infoList2.infList = infoList.infList.Skip((page.CurrentIndex - 1) * page.PageSize).Take(page.PageSize).ToList();
           ViewData["pagemodel"] = page;
           return View(infoList2);
        }

        /// <summary>
        /// 获取资讯分类ID及所有子类ID
        /// </summary>
        /// <param name="ProductTypeId"></param>
        /// <returns></returns>
        private string getInformationTypeIds(long InformationTypeId)
        {
            string strInformationTypes = "";

            BLL.bll_InformationType bll = new BLL.bll_InformationType();
           List<SqlModel.InformationType> infList = bll.GetList(" isdelete=0 and fid=" + InformationTypeId);

           if (infList.Count > 0)
            {
                for (int i = 0; i < infList.Count; i++)
                {
                    strInformationTypes += infList[i].ID + ",";

                    strInformationTypes += getInformationTypeIds(Convert.ToInt64(infList[i].ID));
                }
            }

            return strInformationTypes;
        }

        /// <summary>
        /// 获取资讯类型名称
        /// </summary>
        /// <param name="infomationTypeID"></param>
        /// <returns></returns>
        public static string getInformationTypeName(long infomationTypeID)
        {
            BLL.bll_InformationType bll = new BLL.bll_InformationType();
            SqlModel.InformationType model = bll.GetModel(infomationTypeID);
            return model.TypeName;
        }
        #endregion

        #region 热销产品
        
        
        public ActionResult Productdetail(string index, string searchkey) 
        {
            BLL.bll_Product proBll = new BLL.bll_Product();
            SqlModel.Product model = proBll.GetModel(Convert.ToInt64(Request.QueryString["ID"]));
           ViewBag.strProductName = model.ProductName;
           ViewBag.strProductPic = model.ProductPic;
           ViewBag.strMarketPrice = model.MarketPrice.ToString();
           ViewBag.strWebsitePrice = model.WebsitePrice.ToString();
           ViewBag.strDescription = model.Description;
           BLL.Bll_Brand bllBra = new BLL.Bll_Brand();
           SqlModel.Brand brnModel = bllBra.GetModel(Convert.ToInt64(Request.QueryString["ID"]));
           ViewBag.strBrand = brnModel.BrandName;
           SqlModel.Home.ProductdetailModel pro = new SqlModel.Home.ProductdetailModel();
           SqlModel.Home.ProductdetailModel pro2 = new SqlModel.Home.ProductdetailModel();
          pro2.proList= getProductrelated(Convert.ToInt64(model.ProductTypeId));
          BLL.bll_Review BllRev = new BLL.bll_Review();
          if (string.IsNullOrEmpty(index))
          {
              index = "1";
          }
          if (string.IsNullOrEmpty(searchkey))
          {
              searchkey = string.Empty;
          }
          string whereStr = "Isdelete=0 and ProductId=" + Request.QueryString["ID"];

          pro.revList = BllRev.getPage(whereStr, "Id desc");
          Collections.BasePageModel page = new Collections.BasePageModel()
          {
              SearchKeyWord = searchkey,
              CurrentIndex = Int32.Parse(index),
              TotalCount = pro.revList.Count,
              ActionName = "Productdetail"
          };
          pro2.revList = pro.revList.Skip((page.CurrentIndex - 1) * page.PageSize).Take(page.PageSize).ToList();
          ViewData["pagemodel"] = page;
          return View(pro2);
        }

        /// <summary>
        /// 获取相关产品
        /// </summary>
        private List<SqlModel.Product> getProductrelated(long productTypeID)
        {

            BLL.bll_Product bll = new BLL.bll_Product();
           return bll.GetList(3, " IsDelete=0 and ProductTypeId=" + productTypeID + " and ID<>" + Request.QueryString["ID"], " ID DESC");
         
        }

        #endregion
    }
}
