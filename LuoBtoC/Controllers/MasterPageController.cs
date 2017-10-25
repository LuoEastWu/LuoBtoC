using SqlModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LuoBtoC.Controllers
{
    public class MasterPageController : Controller
    {
        //
        // GET: /MasterPage/

        public ActionResult Top(SqlModel.MasterPage.TopModels model)
        {
            if (ModelState.IsValid) 
            {
                BLL.Bll_ProductType bllPro = new BLL.Bll_ProductType();
                BLL.bll_InformationType bllInformation=new BLL.bll_InformationType();
                model.ProList = bllPro.GetListByPage(" IsDelete=0 and fid=0", " sort ", 0, 10);
                model.informationList=bllInformation.GetListByPage(" IsDelete=0 and fid=0", " sort ", 0, 10);
            }
            return PartialView(model);
        }

        public ActionResult Left(SqlModel.MasterPage.LeftModels model)
        {
            if (ModelState.IsValid) 
            {
                BLL.Bll_ProductType bllPro = new BLL.Bll_ProductType();
                model.ProList = bllPro.GetListByPage(" IsDelete=0 and fid=0", " sort ", 0, 6);
                BLL.bll_Product bllProduct = new BLL.bll_Product();
                model.ProductList = bllProduct.GetListByPage(" IsDelete=0", " sort", 0, 4);
            }
            return PartialView(model);
        }

        public ActionResult Foot()
        {
            return PartialView();
        }


        
    }
}
