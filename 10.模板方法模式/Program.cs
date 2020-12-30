using System;

namespace 模板方法模式
{
    class Program
    {
        static void Main(string[] args)
        {
            AbstractClass c;
            c = new ConcreteClassA();
            c.TemplateMedthod();

            c = new ConcreteClassB();
            c.TemplateMedthod();
            Console.Read();
        }
    }
    abstract class AbstractClass
    {
        public abstract void PrimitiveOperation1();
        public abstract void PrimitiveOperation2();

        public void TemplateMedthod()
        {
            PrimitiveOperation1();
            PrimitiveOperation2();
            Console.WriteLine("");
        }
    }
    class ConcreteClassA : AbstractClass
    {
        public override void PrimitiveOperation1()
        {
            Console.WriteLine("A 1");
        }

        public override void PrimitiveOperation2()
        {
            Console.WriteLine("A 2");
        }
    }
    class ConcreteClassB : AbstractClass
    {
        public override void PrimitiveOperation1()
        {
            Console.WriteLine("B 1");
        }

        public override void PrimitiveOperation2()
        {
            Console.WriteLine("B 2");
        }
    }
}
