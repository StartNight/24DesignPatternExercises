using System;
using System.Collections;

namespace 享元模式
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            WebSiteFactory f = new WebSiteFactory();

            WebSite fx = f.GetWebSiteCategory("产品展示");
            fx.Use(new User("小菜"));

            WebSite fy = f.GetWebSiteCategory("产品展示");
            fy.Use(new User("大鸟"));

            WebSite fz = f.GetWebSiteCategory("产品展示");
            fz.Use(new User("娇娇"));

            WebSite fl = f.GetWebSiteCategory("博客");
            fl.Use(new User("老顽童"));

            WebSite fm = f.GetWebSiteCategory("博客");
            fm.Use(new User("南海鳄鱼"));

            WebSite fn = f.GetWebSiteCategory("博客");
            fn.Use(new User("骨头"));
        }
    }

    public class User
    {
        private string name;

        public User(string name)
        {
            this.name = name;
        }

        public string Name { get { return name; } }
    }

    internal abstract class WebSite
    {
        public abstract void Use(User user);
    }

    internal class ConcreteWebSite : WebSite
    {
        private string name = "";

        public ConcreteWebSite(string name)
        {
            this.name = name;
        }

        public override void Use(User user)
        {
            Console.WriteLine("网站分类:" + name + "用户:" + user.Name);
        }
    }

    /// <summary>
    /// 网站工厂类
    /// </summary>
    internal class WebSiteFactory
    {
        private Hashtable flyweights = new Hashtable();

        public WebSite GetWebSiteCategory(string key)
        {
            if (!flyweights.ContainsKey(key))
                flyweights.Add(key, new ConcreteWebSite(key));

            return ((WebSite)flyweights[key]);
        }

        public int GetWebSiteCount()
        {
            return flyweights.Count;
        }
    }
}