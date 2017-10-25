using System;
using System.Linq;
using System.Text;

namespace SqlModel
{
    ///<summary>
    ///
    ///</summary>
    public partial class Member
    {
           public Member(){


           }
           /// <summary>
           /// Desc:
           /// Default:
           /// Nullable:False
           /// </summary>           
           public long ID {get;set;}

           /// <summary>
           /// Desc:会员等级ID
           /// Default:
           /// Nullable:True
           /// </summary>           
           public int? MemberRankId {get;set;}

           /// <summary>
           /// Desc:会员名称
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string MemberName {get;set;}

           /// <summary>
           /// Desc:密码
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string Password {get;set;}

           /// <summary>
           /// Desc:E-mail
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string Email {get;set;}

           /// <summary>
           /// Desc:手机号
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string Phone {get;set;}

           /// <summary>
           /// Desc:QQ号
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string QQ {get;set;}

           /// <summary>
           /// Desc:地址
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string Address {get;set;}

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
           public DateTime? CreateDate {get;set;}

           /// <summary>
           /// Desc:是否删除
           /// Default:
           /// Nullable:True
           /// </summary>           
           public bool? IsDelete {get;set;}

    }
}
