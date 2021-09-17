using ScoreStack.Pages.Entityes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ScoreStack.Pages.Repository
{
    public class UserRepository
    {
        public static IList<User> users; /*= new List<User>()*/
        static UserRepository()
        {
            users = new List<User>
            {
                new User
                {
                    Id=1,
                    Name="yezi",
                    PassWord="1234"
                }
           
            };
        }

        internal IList<User> Get(int pageIndex, int pageSize)
        {
            //skip跳过pageIndex*pageSize个数据，取Take，pageSize个数据
            return users
                .Skip((pageIndex - 1) * pageSize)
                .Take(pageSize)
                .ToList();
        }

        public User Find(int id)
        {
            User User = users.Where(a => a.Id == id).SingleOrDefault();
            return User;
        }

        public User GetByName(string name)
        {
            return users.Where(u => u.Name == name).SingleOrDefault();
        }

        public void Delete()
        {

        }

        public void Save(User User)
        {
            //save返回的id从哪里来？
            users.Add(User);
        }
    }



}
