using System;
using System.Linq;
using System.Text;

namespace SqlModel
{
    ///<summary>
    ///
    ///</summary>
    public partial class Information
    {
           public Information(){


           }
           /// <summary>
           /// Desc:ID
           /// Default:
           /// Nullable:False
           /// </summary>           
           public long ID {get;set;}

           /// <summary>
           /// Desc:资讯分类ID
           /// Default:
           /// Nullable:True
           /// </summary>           
           public int? InformationTypeId {get;set;}

           /// <summary>
           /// Desc:资讯标题
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string InformationName {get;set;}

           /// <summary>
           /// Desc:资讯内容
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string InformationContent {get;set;}

           /// <summary>
           /// Desc:图片
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string InformationPic {get;set;}

           /// <summary>
           /// Desc:描述
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string Description {get;set;}

           /// <summary>
           /// Desc:创建时间
           /// Default:
           /// Nullable:True
           /// </summary>           
           public DateTime? CreateDate {get;set;}

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
