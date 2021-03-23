using System;
using System.Collections;
using System.Collections.Generic;

namespace 访问者模式
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            ObjectStructure o = new ObjectStructure();
            o.Attack(new Man());
            o.Attack(new Woman());

            Success v1 = new Success();
            o.Display(v1);
            Failing v2 = new Failing();

            o.Display(v2);
            Amativeness v3 = new Amativeness();
            o.Display(v3);
        }
    }

    internal abstract class Action
    {
        public abstract void GetManConclusion(Man man);

        public abstract void GetWonmanConclusion(Woman woman);
    }

    internal abstract class Person
    {
        // 接受
        public abstract void Accept(Action visitor);
    }

    internal class Man : Person
    {
        public override void Accept(Action visitor)
        {
            visitor.GetManConclusion(this);
        }
    }

    internal class Woman : Person
    {
        public override void Accept(Action visitor)
        {
            visitor.GetWonmanConclusion(this);
        }
    }

    internal class Success : Action
    {
        public override void GetManConclusion(Man man)
        {
            Console.WriteLine($"{man.GetType().Name}{this.GetType().Name}时,背后多半有一个伟大的女人.");
        }

        public override void GetWonmanConclusion(Woman woman)
        {
            Console.WriteLine($"{woman.GetType().Name}{this.GetType().Name}时,背后大多有一个不成功的男人");
        }
    }

    internal class Failing : Action
    {
        public override void GetManConclusion(Man man)
        {
            Console.WriteLine($"{man.GetType().Name}{this.GetType().Name}时,蒙头喝酒,谁也不用劝.");
        }

        public override void GetWonmanConclusion(Woman woman)
        {
            Console.WriteLine($"{woman.GetType().Name}{this.GetType().Name}时,泪汪汪,谁也劝不了");
        }
    }

    internal class Amativeness : Action
    {
        public override void GetManConclusion(Man man)
        {
            Console.WriteLine($"{man.GetType().Name}{this.GetType().Name}时,凡事不懂也装懂.");
        }

        public override void GetWonmanConclusion(Woman woman)
        {
            Console.WriteLine($"{woman.GetType().Name}{this.GetType().Name}时,凡事懂也装不懂");
        }
    }

    /// <summary>
    /// 对象结构
    /// </summary>
    internal class ObjectStructure
    {
        private IList<Person> elements = new List<Person>();

        // 增加
        public void Attack(Person element)
        {
            elements.Add(element);
        }

        public void Deatch(Person element)
        {
            elements.Remove(element);
        }

        public void Display(Action visitor)
        {
            foreach (var e in elements)
            {
                e.Accept(visitor);
            }
        }
    }
}