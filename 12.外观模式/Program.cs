using System;

namespace 外观模式
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            Facade facede = new Facade();
            facede.MethedA();
            facede.MethodB();
            Console.Read();
        }
    }
    class SubSystemOne
    {
        public void MethodOne()
        {
            Console.WriteLine("Sud Method One");
        }
    }
    class SubSystemTwo
    {
        public void MethodTwo()
        {
            Console.WriteLine("Sub Method Two");
        }
    }
    class SubSystemThree
    {
        public void MethodThree()
        {
            Console.WriteLine("Sub Method Three");
        }
    }
    class SubSystemFour
    {
        public void MethoedFour()
        {
            Console.WriteLine("Sub System Four");
        }
    }
    class Facade
    {
        SubSystemOne one;
        SubSystemTwo two;
        SubSystemThree three;
        SubSystemFour four;
        public Facade()
        {
            one = new SubSystemOne();
            two = new SubSystemTwo();
            three = new SubSystemThree();
            four = new SubSystemFour();
        }
        public void MethedA()
        {
            Console.WriteLine("Acitve MethedA-----");
            one.MethodOne();
            two.MethodTwo();
            four.MethoedFour();
        }
        public void MethodB()
        {
            Console.WriteLine("Acitve MethedB-----");
            two.MethodTwo();
            three.MethodThree();
        }
    }

}
