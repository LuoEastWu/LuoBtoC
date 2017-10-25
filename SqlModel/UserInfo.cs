using System;
using System.Linq;
using System.Text;

namespace SqlModel
{
    ///<summary>
    ///
    ///</summary>
    public partial class UserInfo
    {
           public UserInfo(){


           }
           /// <summary>
           /// Desc:ID
           /// Default:
           /// Nullable:False
           /// </summary>           
           public long ID {get;set;}

           /// <summary>
           /// Desc:用户名
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string UserName {get;set;}

           /// <summary>
           /// Desc:密码
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string Password {get;set;}

           /// <summary>
           /// Desc:用户类型
           /// Default:
           /// Nullable:True
           /// </summary>           
           public int? UserType {get;set;}

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
