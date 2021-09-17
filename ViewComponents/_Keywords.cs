using Microsoft.AspNetCore.Mvc;
using ScoreStack.Pages.Entityes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ScoreStack.ViewComponents
{
    public class _Keywords : ViewComponent
    {
        public IViewComponentResult Invoke(int amount)
        {
            IList<Keyword> Keywords = new List<Keyword> 
            { 
                new Keyword{Id = 1,Name = "c++"},
                new Keyword{Id = 2,Name = "css"},
                new Keyword{Id = 3,Name = "c#"},
            };
            //把Keywords这个model传递给View
            return View("~/Pages/Components/_Keywords.cshtml", Keywords.Take(amount).ToList());
        }
    }
}
