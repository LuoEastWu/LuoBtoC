using System;
using System.Linq;
using System.Text;

namespace SqlModel
{
    ///<summary>
    ///
    ///</summary>
    public partial class OrderForm
    {
           public OrderForm(){


           }
           /// <summary>
           /// Desc:ID
           /// Default:
           /// Nullable:False
           /// </summary>           
           public long ID {get;set;}

           /// <summary>
           /// Desc:会员ID
           /// Default:
           /// Nullable:True
           /// </summary>           
           public long? MemberId {get;set;}

           /// <summary>
           /// Desc:订单编号
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string OrderFormNo {get;set;}

           /// <summary>
           /// Desc:产品总价格
           /// Default:
           /// Nullable:True
           /// </summary>           
           public decimal? ProductTotalPrice {get;set;}

           /// <summary>
           /// Desc:购买人
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string Purchaser {get;set;}

           /// <summary>
           /// Desc:收货人
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string Consignee {get;set;}

           /// <summary>
           /// Desc:收货地址
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string LiveAddress {get;set;}

           /// <summary>
           /// Desc:邮编
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string ZipCode {get;set;}

           /// <summary>
           /// Desc:电话
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string Phone {get;set;}

           /// <summary>
           /// Desc:备注
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string Remark {get;set;}

           /// <summary>
           /// Desc:创建时间
           /// Default:
           /// Nullable:True
           /// </summary>           
           public DateTime? CreatDate {get;set;}

           /// <summary>
           /// Desc:排序
           /// Default:
           /// Nullable:True
           /// </summary>           
           public int? Sort {get;set;}

           /// <summary>
           /// Desc:是否删除
           /// Default:
           /// Nullable:True
           /// </summary>           
           public bool? IsDelete {get;set;}

    }
}
