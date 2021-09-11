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
        [Required(ErrorMessage ="*用户名不能为空")]
        public string Name { get; set; }
        public string PassWord { get; set; }
        public User InvitedBy { get; set; }
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
