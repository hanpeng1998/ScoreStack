using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ScoreStack.Filters
{
    public class AutoModelValidationAttribute : Attribute, IPageFilter
    {
        public void OnPageHandlerExecuted(PageHandlerExecutedContext context)
        {
            
        }

        public void OnPageHandlerExecuting(PageHandlerExecutingContext context)
        {
            ///1,把modelstate中的错误信息装入tempdata
            if (true)//post
            {
                Dictionary<string, string> errors =
                   context.ModelState.Where(m => m.Value.Errors.Any())
                       .ToDictionary(
                           m => m.Key,
                           m => m.Value.Errors
                               .Select(s => s.ErrorMessage)
                               .FirstOrDefault(s => s != null));

                //2. 将Error信息存放到TempData
                ((PageModel)context.HandlerInstance).TempData[Keys.ErrorInfo] = errors;


                //如果有error重定向
                //想办法从context取
            }
            ///2.从tempdata取出modelstate中的错误信息
            else//get
            {                
                //Dictionary<string, string> errors = TempData[Keys.ErrorInfo] as Dictionary<string, string>;
                //if (errors != null)
                //{
                //    //4. 将Error信息添加到ModelState  foreach (var item in errors)
                //    ModelStateDictionary modelState = new ModelStateDictionary();
                //    foreach (var item in errors)
                //    {
                //        ModelState.AddModelError(item.Key, item.Value);
                //    }
                //    //5进行merge
                //    ModelState.Merge(modelState);
                //}
            }
        }

        public void OnPageHandlerSelected(PageHandlerSelectedContext context)
        {
            
        }
    }
}
