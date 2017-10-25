using System;
using System.Linq;
using System.Text;

namespace SqlModel
{
    ///<summary>
    ///
    ///</summary>
    public partial class Review
    {
           public Review(){


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
           /// Desc:产品ID
           /// Default:
           /// Nullable:True
           /// </summary>           
           public int? ProductId {get;set;}

           /// <summary>
           /// Desc:商品名称
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string ProductName {get;set;}

           /// <summary>
           /// Desc:评论内容
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string ReviewContent {get;set;}

           /// <summary>
           /// Desc:回复内容
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string ReplyContent {get;set;}

           /// <summary>
           /// Desc:评论人
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string ReviewName {get;set;}

           /// <summary>
           /// Desc:评论时间
           /// Default:
           /// Nullable:True
           /// </summary>           
           public DateTime? ReviewDate {get;set;}

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
