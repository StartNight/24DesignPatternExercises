using System;

namespace 中介者模式
{
    class Program
    {
        static void Main(string[] args)
        {
            ConcreteMediator m = new ConcreteMediator();
            ConcreteColleague1 c1 = new ConcreteColleague1(m);
            ConcreteColleague2 c2 = new ConcreteColleague2(m);

            m.Colleague1 = c1;
            m.Colleague2 = c2;

            c1.Send("吃过饭了吗?");
            c2.Send("没有呢,你打算情况吗");
        }
    }
    /// <summary>
    /// 抽象中介者类
    /// </summary>
    abstract class Mediator
    {
        public abstract void Send(string message, Colleague colleague);
    }
    /// <summary>
    /// 抽象同事类
    /// </summary>
    abstract class Colleague
    {
        protected Mediator mediator;
        public Colleague(Mediator mediator)
        {
            this.mediator = mediator;
        }
    }

    class ConcreteMediator : Mediator
    {
        private ConcreteColleague1 colleague1;
        private ConcreteColleague2 colleague2;
        public ConcreteColleague1 Colleague1
        {
            set { colleague1 = value; }
        }
        public ConcreteColleague2 Colleague2
        {
            set { colleague2 = value; }
        }
        public override void Send(string message, Colleague colleague)
        {
            if (colleague == colleague1)
            {
                colleague2.Notify(message);
            }
            else
            {
                colleague1.Notify(message);
            }
        }
    }

    class ConcreteColleague1 : Colleague
    {
        public ConcreteColleague1(Mediator mediator) : base(mediator)
        { }
        public void Send(string messgae)
        {
            mediator.Send(messgae, this);
        }
        public void Notify(string message)
        {
            Console.WriteLine("同事1得到消息" + message);
        }
    }

    class ConcreteColleague2 : Colleague
    {
        public ConcreteColleague2(Mediator mediator) : base(mediator)
        { }
        public void Send(string messgae)
        {
            mediator.Send(messgae, this);
        }
        public void Notify(string message)
        {
            Console.WriteLine("同事2得到消息" + message);
        }
    }
}
