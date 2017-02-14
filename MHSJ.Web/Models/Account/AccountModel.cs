using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace MHSJ.Web.Models.Account
{
    public class LoginModel
    {
        [Required(ErrorMessage = "用户名不能为空")]
        [Display(Name = "用户名：")]
        public string Name { get; set; }

        [Required(ErrorMessage = "密码不能为空")]
        [Display(Name = "密  码：")]
        public string Password { get; set; }

        [Required(ErrorMessage = "验证码不能为空")]
        [Display(Name = "验证码：")]
        public string VerifyCode { get; set; }
    }

    public class RegisterModel
    {
        [Display(Name = "用户名：")]
        [Required(ErrorMessage = "用户名不能为空")]
        [StringLength(20, ErrorMessage = "必须至少包含 {2} 个字符。", MinimumLength = 3)]
        public string Name { get; set; }

        [Required(ErrorMessage = "密码不能为空")]
        [StringLength(20, ErrorMessage = "必须至少包含 {2} 个字符。", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "密  码：")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "确认密码：")]
        [Compare("Password", ErrorMessage = "密码和确认密码不匹配。")]
        public string ConfirmPassword { get; set; }

        [Required(ErrorMessage = "验证码不能为空")]
        [Display(Name = "验证码：")]
        public string VerifyCode { get; set; }
    }

    public class LocalPasswordModel
    {
        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "当前密码")]
        public string OldPassword { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "{0} 必须至少包含 {2} 个字符。", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "新密码")]
        public string NewPassword { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "确认新密码")]
        [Compare("NewPassword", ErrorMessage = "新密码和确认密码不匹配。")]
        public string ConfirmPassword { get; set; }
    }

    public class AccountModel
    {
        public int AccountId { get; set; }
        public int CollectionnNumber { get; set; }
        public int Integral { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "用户名")]
        public string Name { get; set; }

        [Required(ErrorMessage = "邮箱不能为空")]
        [StringLength(100, ErrorMessage = "必须至少包含 {2} 个字符。", MinimumLength = 6)]
        [Display(Name = "邮箱")]
        public string Email { get; set; }

        [Required(ErrorMessage = "手机不能为空")]
        [Display(Name = "手机")]
        public string Phone { get; set; }
    }
}