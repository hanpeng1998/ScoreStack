using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ScoreStack.Pages.Repository;
using E=ScoreStack.Pages.Entityes;


namespace ScoreStack.Pages.Article
{
    public class IndexModel : PageModel
    {
        
        private ArticleRepository _articleRepository;
        public IndexModel()
        {
            _articleRepository = new ArticleRepository();
        }
        
        public IList<E.Article> Articles { get; set; }
        //public DateTime PublishTime { get; set; }
        public void OnGet()
        {
            //int pageIndex = Convert.ToInt32(Request.Query["pageIndex"][0]);
            int id = Convert.ToInt32(RouteData.Values["id"]);
            ViewData["Description"]= "飞哥的源栈培训：线上全程直播，免费收看；线下拎包入住，按周计费。本系列收录所有讲义（含视频录播地址）";
            Articles = _articleRepository.Get(id,2);
            //PublishTime = new DateTime(2020,5,6,10,6,6);
            
        }
    }
}

