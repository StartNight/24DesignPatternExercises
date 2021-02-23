using System;
using System.Collections;
using System.Collections.Generic;

namespace 命令模式
{
    class Program
    {
        static void Main(string[] args)
        {
            Barbecuer boy = new Barbecuer();
            Command bakeMuttonCommand1 = new BakeChickenWingCommand(boy);
            Command bakeMuttonCommand2 = new BakeChickenWingCommand(boy);
            Command bakeChickenWingCommand1 = new BakeChickenWingCommand(boy);
            Waiter girl = new Waiter();

            // 开始点菜
            girl.SetOrder(bakeMuttonCommand1);
            girl.SetOrder(bakeMuttonCommand2);

            girl.SetOrder(bakeChickenWingCommand1);

            // 点菜完毕,通知厨房
            girl.Notify();

        }
    }
    public class Waiter
    {
        private IList<Command> orders = new List<Command>();

        public void SetOrder(Command command)
        {
            if (command.ToString() == "命令模式.BackChickenWingCommand")
            {
                Console.WriteLine("服务员:鸡翅没有了,清点别的烧烤");
            }
            else
            {
                orders.Add(command);
                Console.WriteLine("增加订单:" + command.ToString() + "时间:" + DateTime.Now.ToString());
            }
        }

        public void CancelOrder(Command command)
        {
            orders.Remove(command);
            Console.WriteLine("取消订单:" + command.ToString() + "时间:" + DateTime.Now.ToString());
        }
        public void Notify()
        {
            foreach (Command cmd in orders)
            {
                cmd.ExcuteCommand();
            }
        }


    }
    public abstract class Command
    {
        protected Barbecuer receiver;
        public Command(Barbecuer receiver)
        {
            this.receiver = receiver;
        }
        abstract public void ExcuteCommand();

    }
    /// <summary>
    /// 烤肉串命令
    /// </summary>
    class BakeMuttonCommand : Command
    {
        public BakeMuttonCommand(Barbecuer receiver) : base(receiver)
        {
        }
        public override void ExcuteCommand()
        {
            receiver.BakeMutton();
        }
    }
    class BakeChickenWingCommand : Command
    {
        public BakeChickenWingCommand(Barbecuer receiver) : base(receiver)
        {
        }
        public override void ExcuteCommand()
        {
            receiver.BakeMutton();
        }
    }
    public class Barbecuer
    {
        public void BakeMutton()
        {
            Console.WriteLine("烤羊肉串!");
        }
        public void BakeChickenWing()
        {
            Console.WriteLine("烤鸡翅!");
        }
    }
}