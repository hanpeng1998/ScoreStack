using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ScoreStack.Pages.Entityes
{
    public class User : Entity
    {
        [Display(Name ="用户名")]
        [Required(ErrorMessage ="*用户名不能为空",AllowEmptyStrings =true)]
        public string Name { get; set; }

        [MinLength(4 ,ErrorMessage ="*密码长度至少4位")]
        public string PassWord { get; set; }
        

        public User InvitedBy { get; set; }

        [StringLength(4,MinimumLength =4, ErrorMessage = "*长度4位")]
        public string InviteCode { get; set; }
        public int Bcreadit { get;  set; }

        //public bool IsMail { get; set; }
        //public string Introduction { get; set; }


        public void Register()
        {
            InvitedBy.Bcreadit += 10;
        }

    }
}
