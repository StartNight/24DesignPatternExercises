using System;

namespace 状态模式
{
    class Program
    {
        static void Main(string[] args)
        {
            Work emergencyProjects = new Work();
            emergencyProjects.Hour = 9;
            emergencyProjects.WriteProgram();
            emergencyProjects.Hour = 10;
            emergencyProjects.WriteProgram();
            emergencyProjects.Hour = 12;
            emergencyProjects.WriteProgram();
            emergencyProjects.Hour = 13;
            emergencyProjects.WriteProgram();
            emergencyProjects.Hour = 14;
            emergencyProjects.WriteProgram();
            emergencyProjects.Hour = 17;

            emergencyProjects.TaskFinished = false;

            emergencyProjects.Hour = 19;
            emergencyProjects.WriteProgram();
            emergencyProjects.Hour = 22;
            emergencyProjects.WriteProgram();

            Console.Read();
        }
    }
    public class Work
    {
        private State current;

        public int Hour { get; internal set; }
        public bool TaskFinished { get; internal set; }

        public Work()
        {
            current = new FarenoonState();
        }

        internal void WriteProgram()
        {
            current.WriteProgram(this);
        }

        internal void SetState(State noonState)
        {
            current = noonState;
        }
    }
    public abstract class State
    {
        public abstract void WriteProgram(Work w);
    }
    public class FarenoonState : State
    {
        public override void WriteProgram(Work w)
        {
            if (w.Hour < 12)
            {
                Console.WriteLine("当前时间:{0}点 上午工作,精神百倍", w.Hour);
            }
            else
            {
                w.SetState(new NoonState());
                w.WriteProgram();
            }
        }
    }
    public class NoonState : State
    {

        public override void WriteProgram(Work w)
        {
            if (w.Hour < 13)
            {
                Console.WriteLine("当前时间:{0}点 饿了,午饭;犯困,午休.", w.Hour);
            }
            else
            {
                w.SetState(new AfternoonState());
                w.WriteProgram();
            }
        }
    }
    public class AfternoonState : State
    {
        public override void WriteProgram(Work w)
        {
            if (w.Hour < 17)
            {
                Console.WriteLine("当前时间:{0}点 下午状态还不错,继续努力", w.Hour);
            }
            else
            {
                w.SetState(new EveningState());
                w.WriteProgram();
            }
        }
    }
    public class EveningState : State
    {
        public override void WriteProgram(Work w)
        {
            if (w.TaskFinished)
            {
                w.SetState(new RestState());
                w.WriteProgram();
            }
            else
            {
                if (w.Hour < 21)
                {
                    Console.WriteLine("当前时间:{0}点 加班哦,疲惫之极.", w.Hour);
                }
                else
                {
                    w.SetState(new SleepingState());
                    w.WriteProgram();
                }
            }
            Console.WriteLine("");
        }
    }
    // 睡眠状态
    public class SleepingState : State
    {
        public override void WriteProgram(Work w)
        {
            Console.WriteLine("当前时间:{0}点不行了,睡着了.", w.Hour);
        }
    }

    // 下部休息状态
    public class RestState : State
    {
        public override void WriteProgram(Work w)
        {
            Console.WriteLine("当前时间:{0}点下班回家了", w.Hour);
        }
    }
}
