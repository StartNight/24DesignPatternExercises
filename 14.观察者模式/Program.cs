using System;
using System.Collections;
using System.Collections.Generic;

namespace 观察者模式
{
    class Program
    {
        static void Main(string[] args)
        {
            Boss huhansan = new Boss();
            StockObserver tongshi1 = new StockObserver("魏关", huhansan);
            NBAObserver tongshi2 = new NBAObserver("关", huhansan);
            huhansan.Update += new Boss.EventHandler(tongshi1.ColseStockMarket);
            huhansan.Update += new Boss.EventHandler(tongshi2.ColseStockMarket);
            huhansan.SubjectState = "我回来了";
            huhansan.Notify();
            Console.Read();
        }
    }
    interface Subject
    {
        void Notify();
        string SubjectState { get; set; }
    }
    abstract class Observer
    {
        public abstract void Update();
    }
    class Boss : Subject
    {
        public delegate void EventHandler();
        public event EventHandler Update;
        private string action;

        public string SubjectState
        {
            get { return action; }
            set { action = value; }
        }

        public void Notify()
        {
            Update();
        }
    }

    class StockObserver
    {
        private string name;
        private Subject sub;
        public StockObserver(string name, Subject sub)
        {
            this.name = name;
            this.sub = sub;
        }
        public void ColseStockMarket()
        {
            Console.WriteLine("{0} {1} 关闭股票行情,继续工作");
        }
    }
    class NBAObserver
    {
        private string name;
        private Subject sub;
        public NBAObserver(string name, Subject sub)
        {
            this.name = name;
            this.sub = sub;
        }
        public void ColseStockMarket()
        {
            Console.WriteLine("{0} {1} 关闭股票行情,继续工作", sub.SubjectState, name);
        }
    }

}