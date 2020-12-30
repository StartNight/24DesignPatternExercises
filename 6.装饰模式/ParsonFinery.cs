using System;
using System.Collections.Generic;
using System.Text;

namespace 装饰模式
{
    class ParsonFinery
    {
        static void Main(string[] args)
        {
            var p = new Parson("小菜");
            var bigT = new BigTrouser();
            var t = new TShirts();
            var s = new Sneaker();

            t.Decorate(p);
            s.Decorate(t);
            bigT.Decorate(s);
            bigT.Show();
        }
    }
    class Parson
    {
        public Parson()
        { }
        private string name;
        public Parson(string name)
        {
            this.name = name;
        }
        public virtual void Show()
        {
            Console.WriteLine("装饰的{0}", name);
        }
    }
    class Finery : Parson
    {
        protected Parson component;
        public void Decorate(Parson parson)
        {
            component = parson;
        }

        public override void Show()
        {
            if (component != null)
            {
                component.Show();
            }
        }
    }
    class Sneaker : Finery
    {
        public override void Show()
        {
            Console.WriteLine("运动鞋");
            base.Show();
        }
    }
    class TShirts : Finery
    {
        public override void Show()
        {
            Console.WriteLine("大T桖");
            base.Show();
        }
    }

    class BigTrouser : Finery
    {
        public override void Show()
        {
            Console.WriteLine("垮裤");
            base.Show();
        }
    }


}
