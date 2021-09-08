using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ScoreStack.Pages
{
    public class RegisterModel : PageModel
    {
        public string Name { get; set; }
        public void OnGet()
        {
            ///http请求的两种传输方式get，post，如果是get请求就走OnGet,post走OnPost
            ///
            Name = "韩鹏";
        }
        public void OnPost()
        {


        }
    }
}
