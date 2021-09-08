using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using E = ScoreStack.Pages.Entityes;

namespace ScoreStack.Pages.Repository
{
    public class ArticleRepository
    {
        public static IList<E.Article> articles; /*= new List<Article>()*/
        static ArticleRepository()
        {
            articles = new List<E.Article>
            {
                new E.Article
                {
                    Id=8,
                    Title=@"1-Java：Stream：转化 / Lambda参数 / collect() / 常用方法",
                    Body=@"函数式编程 / 回调函数 / 重用",
                    Author = new E.User{Id=23,Name="大飞哥"},
                    PublishTime = new DateTime(2021,9,7,8,54,3)
                },
                new E.Article
                {
                    Id=9,
                    Title=@"2-Java：集合：List / Map / for循环 / steam",
                    Body=@"J&C：集合概述 / 迭代器模式 Java中所有常用集合都在java.util包下，所以可以import java.util.*;ListJava中List本身是一个泛型接口，继承自Collection，最常用的实现类是ArrayList。",
                    Author = new E.User{Id=25,Name="韩鹏"},
                    PublishTime = new DateTime(2021,10,7,6,14,3)
                },
                new E.Article
                {
                    Id=10,
                    Title=@"3-Java：Stream：转化 / Lambda参数 / collect() / 常用方法",
                    Body=@"函数式编程 / 回调函数 / 重用",
                    Author = new E.User{Id=23,Name="大飞哥"},
                    PublishTime = new DateTime(2021,9,7,8,54,3)
                },
                new E.Article
                {
                    Id=11,
                    Title=@"4-Java：集合：List / Map / for循环 / steam",
                    Body=@"J&C：集合概述 / 迭代器模式 Java中所有常用集合都在java.util包下，所以可以import java.util.*;ListJava中List本身是一个泛型接口，继承自Collection，最常用的实现类是ArrayList。",
                    Author = new E.User{Id=25,Name="韩鹏"},
                    PublishTime = new DateTime(2021,10,7,6,14,3)
                },
                new E.Article
                {
                    Id=12,
                    Title=@"5-Java：Stream：转化 / Lambda参数 / collect() / 常用方法",
                    Body=@"函数式编程 / 回调函数 / 重用",
                    Author = new E.User{Id=23,Name="大飞哥"},
                    PublishTime = new DateTime(2021,9,7,8,54,3)
                },
                new E.Article
                {
                    Id=13,
                    Title=@"6-Java：集合：List / Map / for循环 / steam",
                    Body=@"J&C：集合概述 / 迭代器模式 Java中所有常用集合都在java.util包下，所以可以import java.util.*;ListJava中List本身是一个泛型接口，继承自Collection，最常用的实现类是ArrayList。",
                    Author = new E.User{Id=25,Name="韩鹏"},
                    PublishTime = new DateTime(2021,10,7,6,14,3)
                },
                new E.Article
                {
                    Id=14,
                    Title=@"7-Java：集合：List / Map / for循环 / steam",
                    Body=@"J&C：集合概述 / 迭代器模式 Java中所有常用集合都在java.util包下，所以可以import java.util.*;ListJava中List本身是一个泛型接口，继承自Collection，最常用的实现类是ArrayList。",
                    Author = new E.User{Id=25,Name="韩鹏"},
                    PublishTime = new DateTime(2021,10,7,6,14,3)
                }
            };
        }

        internal IList<E.Article> Get(int pageIndex,int pageSize)
        {
            //skip跳过pageIndex*pageSize个数据，取Take，pageSize个数据
            return articles
                .Skip((pageIndex-1)*pageSize)
                .Take(pageSize)
                .ToList();
        }

        public E.Article Find(int id)
        {
            E.Article article = articles.Where(a => a.Id == id).SingleOrDefault();
            return article;
        }

        public void Delete()
        {

        }

        //public int Save(Article article)
        //{
        ////save返回的id从哪里来？
        //    articles.Add(article);
        //}
    }
}
