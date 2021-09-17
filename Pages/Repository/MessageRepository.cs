using ScoreStack.Pages.Entityes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ScoreStack.Pages.Repository
{
    public class MessageRepository
    {
        private static IList<Message> messages;
        static MessageRepository()
        {
            messages = new List<Message> {
                new Message{
                    Id=1,
                    Content="你因为登录获得系统随机分配给你的 帮帮豆 3 枚，可用于感谢赞赏等。",
                    CreateTime=DateTime.Now,

                },
                new Message{
                    Id=2,
                    Content="因为注册时使用了叶飞的邀请码，系统赠送给 tiantian123 ① 10点 帮帮点",
                    CreateTime=DateTime.Now.AddDays(-3),

                },
            };
        }
        public IList<Message> GetMin(bool OnlyNotRead=false)
        {
            //return messages;
            if (OnlyNotRead)
            {
                return messages.Where(m => !m.HasRead).ToList();
            }
            else
            {
                return messages;
            }
            
        }

        public Message Find(int id)
        {
            return messages.Where(m => m.Id == id).SingleOrDefault();
        }
    }
}
