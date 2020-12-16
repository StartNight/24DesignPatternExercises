using System;

namespace 简单工场模式
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Console.WriteLine("请输入第一个数字:");
                var strA = Console.ReadLine();
                Console.WriteLine("请输入第二个数字:");
                var strB = Console.ReadLine();
                Console.WriteLine("请输入运算(+,-,*,/)");
                var strOper = Console.ReadLine();
                var oper = OperationFactory.creatorOperate(strOper);
                oper.NumberA = int.Parse(strA);
                oper.NumberB = int.Parse(strB);
                var result = oper.GetResult();
                Console.WriteLine("结果:"+result);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
        }
    }

    /// <summary>
    /// 运算的基类
    /// </summary>
    public class Operation
    {
        private double _numberA = 0;
        private double _numberB = 0;

        public double NumberA { get => _numberA; set => _numberA = value; }

        public double NumberB { get => _numberB; set => _numberB = value; }

        public virtual double GetResult()
        {
            double result = 0;
            return result;
        }
    }


    class OperationAdd : Operation
    {
        public override double GetResult()
        {
            double result = 0;
            result = NumberA + NumberB;
            return result;
        }
    }
    class OperationSub : Operation
    {
        public override double GetResult()
        {
            double result = 0;
            result = NumberA - NumberB;
            return result;
        }
    }
    class OperationMul : Operation
    {
        public override double GetResult()
        {
            double result = 0;
            result = NumberA * NumberB;
            return result;
        }
    }
    class OperationDiv : Operation
    {
        public override double GetResult()
        {
            double result = 0;
            if (NumberB == 0)
            {
                throw new Exception("除数不能为0");
            }
            result = NumberA / NumberB;
            return result;
        }
    }

    public class OperationFactory
    {
        public static Operation creatorOperate(string operate)
        {
            Operation oper = null;
            switch (operate)
            {
                case "+":
                    oper = new OperationAdd();
                    break;

                case "-":
                    oper = new OperationSub();
                    break;

                case "*":
                    oper = new OperationMul();
                    break;

                case "/":
                    oper = new OperationDiv();
                    break;
                default:
                    throw new Exception("输入错误,请输入符号+ - * / ");
                   
            }
            return oper;
        }
    }
}
