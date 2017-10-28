using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Web.Mvc;


namespace SqlModel.Account
{

    public class RegisterModel
    {
        [Required(ErrorMessage = "请填写会员名！")]
        [Display(Name = "用户名")]
        public string UserName { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "{0} 必须至少包含 {2} 个字符。", MinimumLength = 6)]
        [RegularExpression(@"^(?![0-9]+$)(?![a-zA-Z]+$)[0-9a-zA-Z]+$", ErrorMessage = "密码由数字和英文字母组成！")]
        [DataType(DataType.Password)]
        [Display(Name = "密码")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "确认密码")]
        [Compare("Password", ErrorMessage = "密码和确认密码不匹配。")]
        public string ConfirmPassword { get; set; }

        [Display(Name = "E-mail")]
        [RegularExpression(@"\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*", ErrorMessage = "请输入正确的电子邮箱地址")]
        public string Email { get; set; }

        [Required(ErrorMessage = "联系方式必须填写！")]
        [Display(Name = "联系方式")]
        public string Phone { get; set; }

        [Display(Name = "QQ号")]
        [RegularExpression("[0-9]{5,10}", ErrorMessage = "QQ格式不正确，请核对后再输！")]
        public string QQ { get; set; }
        [Required(ErrorMessage = "请填写通讯地址！")]
        [Display(Name = "地址")]
        public string Address { get; set; }
    }

}
