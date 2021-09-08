using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ScoreStack.Pages.Entityes
{
    public class Article : Entity
    {
        public DateTime PublishTime { get; set; }
        public string Title { get; set; }
        public string Body { get; set; }
        public User Author { get; set; }
    }
}
