using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ScoreStack.Pages.Repository;
using E = ScoreStack.Pages.Entityes;

namespace ScoreStack.Pages.Article
{
    public class SingleModel : PageModel
    {
        private ArticleRepository _articleRepository;
        public SingleModel()
        {
            _articleRepository = new ArticleRepository();
        }
        public E.Article Article { get; set; }

        public void OnGet()
        {
            //Response
            //Request
            //var qid = Request.Query["id"];
            //int id = Convert.ToInt32(Request.Query["id"][0]);
            int id = Convert.ToInt32(RouteData.Values["id"]);

            Article = _articleRepository.Find(id);//写死了，可以传id

            ViewData["AgreeCount"] = 3;
        }
    }

    
    
}
