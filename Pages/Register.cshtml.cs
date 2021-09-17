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
        /*[BindProperty]*///pagemodel�������Զ����ţ�����ÿһ�������϶���һ��[BindProperty]
        public User NewUser { get; set; }

        public string ConfirmPassWord { get; set; }//ȷ������

        [Url(ErrorMessage ="*��ַ��ʽ����ȷ")]
        public string HomeUrl { get; set; }

        [QQAttribute]
        public string QQ { get; set; }

        public string Captcha { get; set; }
        
        public void OnGet()
        {
            string captcha = "c4g5";
            //����ͼƬ

            HttpContext.Session.SetString("Captcha", captcha);
            
        }
        public void OnPost()
        {
            //��֤��
            if (Captcha == HttpContext.Session.GetString("Captcha"))
            {

            }

            if (ConfirmPassWord!=NewUser.PassWord)
            {
                ModelState.AddModelError(nameof(ConfirmPassWord), "������������벻һ��");
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
            NewUser.Register();//��ʮ�����
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
//        /*[BindProperty]*///pagemodel�������Զ����ţ�����ÿһ�������϶���һ��[BindProperty]
//        public User NewUser { get; set; }


//        public bool RemeberMe { get; set; }

//        public string BirthMonth { get; set; }

//        [BindProperty(Name = "id", SupportsGet = true)]
//        public int RegisterId { get; set; }

//        public IEnumerable<SelectListItem> AvailableMonths { get; set; }

//        public void OnGet()
//        {
//            ///http��������ִ��䷽ʽget��post�������get�������OnGet,post��OnPost
//            ///
//            AvailableMonths = new SelectList(new ArticleRepository().Get(1, 10)
//                , "Id", nameof(Entityes.Article.Title));
//            //AvailableMonths = new List<SelectListItem> {
//            //    new SelectListItem("һ��","1"),
//            //    new SelectListItem{Text="����",Value="2" },
//            //    new SelectListItem("����","3",true),
//            //    new SelectListItem("����","4"),
//            //    new SelectListItem("����","5"),
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