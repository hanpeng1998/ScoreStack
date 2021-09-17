using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using ScoreStack.Filters;
using ScoreStack.ModelValidations;
using ScoreStack.Pages.Entityes;
using ScoreStack.Pages.Repository;

namespace ScoreStack.Pages
{
    //[ClearContextAttribute]
    [BindProperties]
    public class RegisterModel : PageModel
    {
        public UserRepository _userRepository;
        public RegisterModel()
        {
            _userRepository = new UserRepository();
        }
        /*[BindProperty]*///pagemodel所有属性都绑定着，不用每一个属性上都加一个[BindProperty]
        public User NewUser { get; set; }

        public string ConfirmPassWord { get; set; }//确认密码

        [Url(ErrorMessage ="*网址格式不正确")]
        public string HomeUrl { get; set; }

        [QQAttribute]
        public string QQ { get; set; }

        public string Captcha { get; set; }
        
        public void OnGet()
        {
            string captcha = "c4g5";
            //生成图片

            HttpContext.Session.SetString("Captcha", captcha);
            
        }
        public void OnPost()
        {
            //验证码
            if (Captcha == HttpContext.Session.GetString("Captcha"))
            {

            }

            if (ConfirmPassWord!=NewUser.PassWord)
            {
                ModelState.AddModelError(nameof(ConfirmPassWord), "两次输入的密码不一致");
            }

            
            if (!ModelState.IsValid)
            {
                return;
            }
            User invitedBy = _userRepository.GetByName(NewUser.InvitedBy.Name);
            //if (invitedBy ==null)
            //{

            //}
            //if (invitedBy.InviteCode!=NewUser.InvitedBy.InviteCode)
            //{

            //}
            NewUser.InvitedBy = invitedBy;
            NewUser.Register();//加十点帮帮点
            _userRepository.Save(NewUser);
            
        }
    }
}

#region MyRegion
//namespace ScoreStack.Pages
//{
//    [BindProperties]
//    public class RegisterModel : PageModel
//    {
//        /*[BindProperty]*///pagemodel所有属性都绑定着，不用每一个属性上都加一个[BindProperty]
//        public User NewUser { get; set; }


//        public bool RemeberMe { get; set; }

//        public string BirthMonth { get; set; }

//        [BindProperty(Name = "id", SupportsGet = true)]
//        public int RegisterId { get; set; }

//        public IEnumerable<SelectListItem> AvailableMonths { get; set; }

//        public void OnGet()
//        {
//            ///http请求的两种传输方式get，post，如果是get请求就走OnGet,post走OnPost
//            ///
//            AvailableMonths = new SelectList(new ArticleRepository().Get(1, 10)
//                , "Id", nameof(Entityes.Article.Title));
//            //AvailableMonths = new List<SelectListItem> {
//            //    new SelectListItem("一月","1"),
//            //    new SelectListItem{Text="二月",Value="2" },
//            //    new SelectListItem("三月","3",true),
//            //    new SelectListItem("四月","4"),
//            //    new SelectListItem("五月","5"),
//            //};

//        }
//        public void OnPost()
//        {

//            //string userName = Request.Form["NewUser.Name"];
//            //NewUser = new User { Name = userName };

//            ViewData["userName"] = Request.Form["NewUser.Name"];
//        }
//    }
//}

#endregion