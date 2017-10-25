using System;
using System.Linq;
using System.Text;

namespace SqlModel
{
    ///<summary>
    ///
    ///</summary>
    public partial class Collection
    {
           public Collection(){


           }
           /// <summary>
           /// Desc:ID
           /// Default:
           /// Nullable:False
           /// </summary>           
           public long ID {get;set;}

           /// <summary>
           /// Desc:产品ID
           /// Default:
           /// Nullable:True
           /// </summary>           
           public int? ProductId {get;set;}

           /// <summary>
           /// Desc:
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string ProductName {get;set;}

           /// <summary>
           /// Desc:会员ID
           /// Default:
           /// Nullable:True
           /// </summary>           
           public int? MemberId {get;set;}

           /// <summary>
           /// Desc:
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string MemberName {get;set;}

           /// <summary>
           /// Desc:收藏时间
           /// Default:
           /// Nullable:True
           /// </summary>           
           public DateTime? CollectionDate {get;set;}

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
