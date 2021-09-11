using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using ScoreStack.Pages.Entityes;
using ScoreStack.Pages.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ScoreStack.Pages
{
    public class IndexModel : PageModel
    {
        public MessageRepository messageRepository;
        public IndexModel()
        {

            messageRepository = new MessageRepository();
        }

        [BindProperty]
        public IList<Message> Messages{ get; set; }

        public void OnGet()
        {
            Messages = messageRepository.GetMin();
        }
        public void OnPost()
        {
            foreach (var item in Messages)
            {
                if (item.Selected)
                {
                    messageRepository.Find(item.Id).Read();
                }
            }
        }
    }
}
