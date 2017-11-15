using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace LuoBtoC.Areas.Admin.Models
{
    public class ProductAddModel
    {
        [Required(ErrorMessage = "请输入商品名称！")]
        [Display(Name = "商品名称")]
        public string txtProductName { get; set; }


        public string ddlProductType { get; set; }

        public string hid { get; set; }

        public string txtDescription { get; set; }

        public string ddlBrand { get; set; }

        public string txtSort { get; set; }

        public string txtSpec { get; set; }

        public string txtMarketPrice { get; set; }

        public string txtWebsitePrice { get; set; }
    }
}