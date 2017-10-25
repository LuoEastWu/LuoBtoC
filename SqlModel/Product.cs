using System;
using System.Linq;
using System.Text;

namespace SqlModel
{
    ///<summary>
    ///
    ///</summary>
    public partial class Product
    {
           public Product(){


           }
           /// <summary>
           /// Desc:ID
           /// Default:
           /// Nullable:False
           /// </summary>           
           public long ID {get;set;}

           /// <summary>
           /// Desc:产品分类ID
           /// Default:
           /// Nullable:True
           /// </summary>           
           public long? ProductTypeId {get;set;}

           /// <summary>
           /// Desc:产品编号
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string ProductNo {get;set;}

           /// <summary>
           /// Desc:产品名称
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string ProductName {get;set;}

           /// <summary>
           /// Desc:产品图片
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string ProductPic {get;set;}

           /// <summary>
           /// Desc:描述
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string Description {get;set;}

           /// <summary>
           /// Desc:品牌
           /// Default:
           /// Nullable:True
           /// </summary>           
           public int? Brand {get;set;}

           /// <summary>
           /// Desc:规格
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string Spec {get;set;}

           /// <summary>
           /// Desc:市场价格
           /// Default:
           /// Nullable:True
           /// </summary>           
           public decimal? MarketPrice {get;set;}

           /// <summary>
           /// Desc:本网站价格
           /// Default:
           /// Nullable:True
           /// </summary>           
           public decimal? WebsitePrice {get;set;}

           /// <summary>
           /// Desc:产品点击量
           /// Default:
           /// Nullable:True
           /// </summary>           
           public int? ProductClick {get;set;}

           /// <summary>
           /// Desc:数量
           /// Default:
           /// Nullable:True
           /// </summary>           
           public int? ProductNum {get;set;}

           /// <summary>
           /// Desc:产品总价
           /// Default:
           /// Nullable:True
           /// </summary>           
           public decimal? ProductTotal {get;set;}

           /// <summary>
           /// Desc:销售量
           /// Default:
           /// Nullable:True
           /// </summary>           
           public int? SalesVolume {get;set;}

           /// <summary>
           /// Desc:排序值
           /// Default:
           /// Nullable:True
           /// </summary>           
           public int? Sort {get;set;}

           /// <summary>
           /// Desc:创建时间
           /// Default:
           /// Nullable:True
           /// </summary>           
           public DateTime? CreateDate {get;set;}

           /// <summary>
           /// Desc:是否删除
           /// Default:
           /// Nullable:True
           /// </summary>           
           public bool? IsDelete {get;set;}

    }
}
