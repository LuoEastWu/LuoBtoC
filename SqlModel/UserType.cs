using System;
using System.Linq;
using System.Text;

namespace SqlModel
{
    ///<summary>
    ///
    ///</summary>
    public partial class UserType
    {
           public UserType(){


           }
           /// <summary>
           /// Desc:ID
           /// Default:
           /// Nullable:False
           /// </summary>           
           public long ID {get;set;}

           /// <summary>
           /// Desc:用户类型名称
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string UserTypeName {get;set;}

           /// <summary>
           /// Desc:备注
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string Remark {get;set;}

           /// <summary>
           /// Desc:是否删除
           /// Default:
           /// Nullable:True
           /// </summary>           
           public bool? IsDelete {get;set;}

    }
}
