using System;

namespace 工场方法模式
{
    class Program
    {
        static void Main(string[] args)
        {
            IFactory factory = new UndergraduateFactory();// 只需要更换此处的代码即可
            // IFactory factory = new VolunteerFacroey();
            LeiFeng student = factory.CreateLeiFeng();
            student.BuyRice();
            student.Sweep();
            student.Wash();
        }
    }

    class LeiFeng
    {
        public void Sweep()
        {
            Console.WriteLine("扫地");
        }
        public void Wash()
        {
            Console.WriteLine("洗衣");
        }
        public void BuyRice()
        {
            Console.WriteLine("买米");
        }
    }
    /// <summary>
    /// 大学生
    /// </summary>
    class Undergraduate : LeiFeng
    { 
    }
    /// <summary>
    /// 志愿者
    /// </summary>
    class Volunteer : LeiFeng
    { }

    class SimpleFactory
    {
        public static LeiFeng CreateLeiFeng(string type)
        {
            LeiFeng result = null;
            switch (type)
            {
                case "学雷锋的大学生":
                    result = new LeiFeng();
                    break;
                case "志愿者":
                    result = new Volunteer();
                    break;
                default:
                    break;
            }
            return result;
        }
    }
    /// <summary>
    /// 工厂接口
    /// </summary>
    interface IFactory
    {
        LeiFeng CreateLeiFeng();
    }

    /// <summary>
    /// 大学生工厂
    /// </summary>
    class UndergraduateFactory : IFactory
    { 
        public LeiFeng CreateLeiFeng()
        {
            return new Undergraduate();
        }
    }
    /// <summary>
    /// 社区志愿者工厂
    /// </summary>
    class VolunteerFacroey : IFactory
    {
        public LeiFeng CreateLeiFeng()
        {
            return new LeiFeng();
        }
    }
}
