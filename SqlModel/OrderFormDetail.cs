using System;
using System.Linq;
using System.Text;

namespace SqlModel
{
    ///<summary>
    ///
    ///</summary>
    public partial class OrderFormDetail
    {
           public OrderFormDetail(){


           }
           /// <summary>
           /// Desc:ID
           /// Default:
           /// Nullable:False
           /// </summary>           
           public long ID {get;set;}

           /// <summary>
           /// Desc:订单ID
           /// Default:
           /// Nullable:True
           /// </summary>           
           public long? OrderFormID {get;set;}

           /// <summary>
           /// Desc:订单编号
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string OrderFormNo {get;set;}

           /// <summary>
           /// Desc:产品ID
           /// Default:
           /// Nullable:True
           /// </summary>           
           public int? ProductID {get;set;}

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
           /// Desc:规格
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string Spec {get;set;}

           /// <summary>
           /// Desc:单价
           /// Default:
           /// Nullable:True
           /// </summary>           
           public decimal? Price {get;set;}

           /// <summary>
           /// Desc:数量
           /// Default:
           /// Nullable:True
           /// </summary>           
           public int? Number {get;set;}

           /// <summary>
           /// Desc:本网站价
           /// Default:
           /// Nullable:True
           /// </summary>           
           public decimal? WebsitePrice {get;set;}

           /// <summary>
           /// Desc:总金额
           /// Default:
           /// Nullable:True
           /// </summary>           
           public decimal? TotalPrice {get;set;}

           /// <summary>
           /// Desc:是否删除
           /// Default:
           /// Nullable:True
           /// </summary>           
           public bool? IsDelete {get;set;}

    }
}
