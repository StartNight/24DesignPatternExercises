using System;

namespace 桥接模式
{
    class Program
    {
        static void Main(string[] args)
        {
            Abstraction ab = new RefinedAbstraction();
            ab.SetImplenmentor(new ConcreteImplementorA());
            ab.Operation();

            ab.SetImplenmentor(new ConcreteImplementorB());
            ab.Operation();
        }
    }
    abstract class Implementor
    {
        public abstract void Operation();
    }
    class ConcreteImplementorA : Implementor
    {
        public override void Operation()
        {
            Console.WriteLine("具体实现A的方法执行");
        }
    }
    class ConcreteImplementorB : Implementor
    {
        public override void Operation()
        {
            Console.WriteLine("具体实现B的方法执行");
        }
    }
    class Abstraction
    {
        protected Implementor implementor;
        public void SetImplenmentor(Implementor implementor)
        {
            this.implementor = implementor;
        }
        public virtual void Operation()
        {
            implementor.Operation();
        }
    }
    class RefinedAbstraction:Abstraction
    {
        public override void Operation()
        {
            implementor.Operation();
        }
    }
}
