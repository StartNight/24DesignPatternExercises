using System;

namespace 代理模式
{
    class Program
    {
        static void Main(string[] args)
        {
            SchoolGirl jiaojiao = new SchoolGirl();
            jiaojiao.name = "娇娇";
            Proxy proxy = new Proxy(jiaojiao);
            proxy.GiveFlowers();
            proxy.GiveDolls();
            proxy.GiveChocolate();

            Console.Read();

        }
    }
    class SchoolGirl
    {
        public string name;
    }
    interface IGiveGift
    {
        void GiveDolls();
        void GiveFlowers();
        void GiveChocolate();
    }
    class Pursuit : IGiveGift
    {
        SchoolGirl mm;
        public Pursuit(SchoolGirl mm)
        {
            this.mm = mm;
        }

        public void GiveDolls()
        {
            Console.WriteLine(mm.name + "送你的洋娃娃");
        }
        public void GiveFlowers()
        {
            Console.WriteLine(mm.name + "送你的鲜花");
        }
        public void GiveChocolate()
        {
            Console.WriteLine(mm.name + "送你的巧克力");
        }
    }

    class Proxy : IGiveGift
    {
        public Pursuit gg;

        public Proxy(SchoolGirl mm)
        {
            gg = new Pursuit(mm);
        }
        public void GiveChocolate()
        {
            gg.GiveChocolate();
        }

        public void GiveDolls()
        {
            gg.GiveDolls();
        }

        public void GiveFlowers()
        {
            gg.GiveFlowers();
        }
    }
}

// 核心代码
abstract class Subject
{
    public abstract void Request();
}
/// <summary>
/// 定义Proxy代表的真实体
/// </summary>
class RealSubject : Subject
{
    public override void Request()
    {
        Console.WriteLine("真实的请求");
    }
}

class Proxy : Subject
{
    RealSubject realSubject;
    public override void Request()
    {
        if (realSubject == null)
        {
            realSubject = new RealSubject();
        }
        realSubject.Request();
    }
}

// 客户端代码
class PMain
{
    void Main()
    {
        Proxy proxy = new Proxy();
        proxy.Request();
        Console.Read();
    }
}