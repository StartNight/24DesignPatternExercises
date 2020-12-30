using System;

namespace 装饰模式
{
    class Program
    {
        static void sMain(string[] args)
        {
            var c = new ConcreteComponent();
            var a = new ConcreteDecoratorA();
            var b = new ConcreteDecoratorB();
            a.SetComponent(c);
            b.SetComponent(a);
            b.Operation();
        }
    }

    abstract class Component
    {
        public abstract void Operation();

    }
    class ConcreteComponent : Component
    {
        public override void Operation()
        {
            Console.WriteLine("具体的操作对象");
        }
    }
    abstract class Decorator : Component
    {
        protected Component component;
        public void SetComponent(Component component)
        {
            this.component = component;   
        }
        public override void Operation()
        {
            if (component!=null)
            {
                component.Operation();
            }
        }
    }

    class ConcreteDecoratorA : Decorator {

        public override void Operation()
        {
            base.Operation();
            AddedBehavior();
            Console.WriteLine("具体的操作A");
        }
        // 独立的方法
        private void AddedBehavior()
        { 
        
        }
    }
    class ConcreteDecoratorB : Decorator
    {

        public override void Operation()
        {
            base.Operation();
            AddedBehavior();
            Console.WriteLine("具体的操作B");
        }
        // 独立的方法
        private void AddedBehavior()
        {

        }
    }
}
