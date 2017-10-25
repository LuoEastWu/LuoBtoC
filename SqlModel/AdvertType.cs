using System;
using System.Linq;
using System.Text;

namespace SqlModel
{
    ///<summary>
    ///
    ///</summary>
    public partial class AdvertType
    {
           public AdvertType(){


           }
           /// <summary>
           /// Desc:ID
           /// Default:
           /// Nullable:False
           /// </summary>           
           public long ID {get;set;}

           /// <summary>
           /// Desc:类型名称
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string TypeName {get;set;}

           /// <summary>
           /// Desc:父类型ID
           /// Default:
           /// Nullable:True
           /// </summary>           
           public long? Fid {get;set;}

           /// <summary>
           /// Desc:排序值
           /// Default:
           /// Nullable:True
           /// </summary>           
           public long? Sort {get;set;}

           /// <summary>
           /// Desc:深度
           /// Default:
           /// Nullable:True
           /// </summary>           
           public long? Depth {get;set;}

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
