using System;
using System.Linq;
using System.Text;

namespace SqlModel
{
    ///<summary>
    ///
    ///</summary>
    public partial class Advert
    {
           public Advert(){


           }
           /// <summary>
           /// Desc:ID
           /// Default:
           /// Nullable:False
           /// </summary>           
           public long ID {get;set;}

           /// <summary>
           /// Desc:广告分类ID
           /// Default:
           /// Nullable:True
           /// </summary>           
           public long? AdvertTypeId {get;set;}

           /// <summary>
           /// Desc:广告类型
           /// Default:
           /// Nullable:True
           /// </summary>           
           public int? AdvertCategory {get;set;}

           /// <summary>
           /// Desc:广告名称
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string AdvertName {get;set;}

           /// <summary>
           /// Desc:广告图片
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string AdvertPic {get;set;}

           /// <summary>
           /// Desc:广告链接
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string AdvertUrl {get;set;}

           /// <summary>
           /// Desc:描述
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string Description {get;set;}

           /// <summary>
           /// Desc:高度
           /// Default:
           /// Nullable:True
           /// </summary>           
           public int? Height {get;set;}

           /// <summary>
           /// Desc:宽度
           /// Default:
           /// Nullable:True
           /// </summary>           
           public int? Width {get;set;}

           /// <summary>
           /// Desc:排序值
           /// Default:
           /// Nullable:True
           /// </summary>           
           public long? Sort {get;set;}

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
