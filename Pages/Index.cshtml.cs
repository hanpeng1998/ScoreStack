using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using ScoreStack.Filters;
using ScoreStack.Pages.Entityes;
using ScoreStack.Pages.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ScoreStack.Pages
{
    //[AutoModelValidation]
    public class IndexModel : PageModel
    {
        [BindProperty(SupportsGet =true)]
        public int Id { get; set; }

        public MessageRepository messageRepository;
        public IndexModel()
        {

            messageRepository = new MessageRepository();
        }

        [BindProperty]
        public IList<Message> Messages{ get; set; }

        //public override void OnPageHandlerSelected(PageHandlerSelectedContext context)
        //{
            
        //    base.OnPageHandlerSelected(context);
        //}
        //public override void OnPageHandlerExecuting(PageHandlerExecutingContext context)
        //{
        //    if (string.IsNullOrEmpty(Request.Cookies[Keys.UserId]))
        //    {
        //        context.Result = new RedirectToPageResult("/Log/On");
        //    }            
        //    base.OnPageHandlerExecuting(context);
        //}
        //public override void OnPageHandlerExecuted(PageHandlerExecutedContext context)
        //{
        //    base.OnPageHandlerExecuted(context);
        //}
        //public override Task OnPageHandlerSelectionAsync(PageHandlerSelectedContext context)
        //{
        //    return base.OnPageHandlerSelectionAsync(context);
        //}
        //public override Task OnPageHandlerExecutionAsync(PageHandlerExecutingContext context, PageHandlerExecutionDelegate next)
        //{
        //    return base.OnPageHandlerExecutionAsync(context, next);
        //}
        
        
        public IActionResult OnGet()
        {
            //if (string.IsNullOrEmpty(Request.Cookies[Keys.UserId]))
            //{
            //    return RedirectToPage("/Log/On");
            //}
            Messages = messageRepository.GetMin(true);
            return Page();
        }
        public RedirectToPageResult OnPost()
        {           
            foreach (var item in Messages)
            {
                if (item.Selected)
                {
                    messageRepository.Find(item.Id).Read();
                    //messageRepository.remove(messageRepository.Find(item.Id))删除
                }
            }
            //Messages = messageRepository.GetMin(true);
            return RedirectToPage();
        }
    }
}
