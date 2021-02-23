using System;

namespace 职责链模式
{
    class Program
    {
        static void Main(string[] args)
        {
            CommonManager jinli = new CommonManager("JINGLI");
            Majordomo zongjian = new Majordomo("ZONGJINA");
            GeneralManager zhongjingli = new GeneralManager("ZHONGJINGLI");

            jinli.SetSuperior(zongjian);
            zongjian.SetSuperior(zhongjingli);

            Request request = new Request();
            request.RequestType = "请假";
            request.RequestContent = "小菜请假";
            request.Number = 1;
            jinli.RequestApplications(request);

            Request request2 = new Request();
            request2.RequestType = "请假";
            request2.RequestContent = "小菜请假";
            request2.Number = 4;
            jinli.RequestApplications(request2);


            Request request3 = new Request();
            request3.RequestType = "加薪";
            request3.RequestContent = "小菜请求加薪";
            request3.Number = 500;
            jinli.RequestApplications(request3);


            Request request4 = new Request();
            request4.RequestType = "加薪";
            request4.RequestContent = "小菜请求加薪";
            request4.Number = 1000;
            jinli.RequestApplications(request4);



        }
    }
    class Request
    {
        public string RequestType { get; set; }
        public string RequestContent { get; set; }
        public int Number { get; set; }
    }
    abstract class Manager
    {
        protected string name;
        protected Manager superior;
        public Manager(string name)
        {
            this.name = name;
        }
        public void SetSuperior(Manager superior)
        {
            this.superior = superior;
        }
        abstract public void RequestApplications(Request request);
    }
    class CommonManager : Manager
    {
        public CommonManager(string name) : base(name)
        { }

        public override void RequestApplications(Request request)
        {
            if (request.RequestType == "请假" && request.Number <= 2)
            {
                Console.WriteLine($"{name}:{request.RequestContent},{request.Number}");
            }
            else
            {
                if (superior != null)
                {
                    superior.RequestApplications(request);
                }
            }
        }
    }

    class Majordomo : Manager
    {
        public Majordomo(string name) : base(name)
        { }
        public override void RequestApplications(Request request)
        {
            if (request.RequestType == "请假" && request.Number <= 5)
            {
                Console.WriteLine($"{name}:{request.RequestContent}数量{request.Number}被批准");
            }
            else
            {
                if (superior != null)
                {
                    superior.RequestApplications(request);

                }
            }
        }
    }
    class GeneralManager : Manager
    {
        public GeneralManager(string name) : base(name)
        { }

        public override void RequestApplications(Request request)
        {
            if (request.RequestType == "请假")
            {
                Console.WriteLine($"{name}:{request.RequestType}数量{request.Number}被批准");
            }
            else if (request.RequestType == "加薪" && request.Number <= 500)
            {
                Console.WriteLine($"{name}:{request.RequestType}数量{request.Number}被批准");
            }
            else if (request.RequestType == "加薪" && request.Number > 500)
            {
                Console.WriteLine($"{name}:{request.RequestType}数量{request.Number}再说吧");
            }

        }
    }
}
