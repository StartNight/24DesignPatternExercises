using System;

namespace 原型模式
{
    class Program
    {
        static void Main(string[] args)
        {
            Resume a = new Resume("大鸟");
            a.SetPersonalInfo("男", "29");
            a.SetWorkExperience("1998-2000", "xx公司");

            Resume b = (Resume)a.Clone();
            b.SetWorkExperience("1998-2006", "yy公司");

            Resume c = (Resume)a.Clone();
            c.SetPersonalInfo("男", "24");
            c.SetWorkExperience("1998-2003", "zz公司");

            a.Display();
            b.Display();
            c.Display();

        }
    }

    class WorkExperience : ICloneable
    {
        private string workDate;
        public string WorkDate
        {
            get { return workDate; }
            set { workDate = value; }
        }

        private string company;
        public string Company
        {
            get { return company; }
            set { company = value; }
        }
        public Object Clone()
        {
            return (Object)this.MemberwiseClone();
        }
    }
    class Resume : ICloneable
    {
        private string name;
        private string sex;
        private string age;
        private WorkExperience work;

        public Resume(string name)
        {
            this.name = name;
            work = new WorkExperience();
        }

        private Resume(WorkExperience work)
        {
            this.work = (WorkExperience)work.Clone();
        }

        public void SetPersonalInfo(string sex, string age)
        {
            this.sex = sex;
            this.age = age;
        }
        public void SetWorkExperience(string workDate, string company)
        {
            work.WorkDate = workDate;
            work.Company = company;
        }
        public void Display()
        {
            Console.WriteLine("{0} {1} {2}", name, sex, age);
            Console.WriteLine("工作经历,{0} {1}", work.WorkDate, work.Company);
        }
        public Object Clone()
        {   // 实现深复制
            Resume obj = new Resume(this.work);
            obj.name = this.name;
            obj.sex = this.sex;
            obj.age = this.age;
            return obj;
        }
    }



    // 核心代码
    abstract class Prototype
    {
        private string id;
        public Prototype(string id)
        {
            this.id = id;
        }
        public string Id
        {
            get { return id; }
        }
        public abstract Prototype Clone();
    }
    class ConcreProtype1 : Prototype
    {
        public ConcreProtype1(string id) : base(id)
        {
        }
        public override Prototype Clone()
        {
            return (Prototype)this.MemberwiseClone();//创建当前对象的浅层副本.方法是创建一个新对象,然后将当前对象的非静态字段复制到该新对象.如果字段是指类型的,则复制引用但不复制引用的对象,因此,原始对象的副本引用同一个对象
        }
    }
    // 客户端代码
    class Clinet
    {
        void Main()
        {
            ConcreProtype1 p1 = new ConcreProtype1("I");
            ConcreProtype1 c1 = (ConcreProtype1)p1.Clone();
            Console.WriteLine("Cloned:{0}", c1.Id);
            Console.Read();
        }
    }
}

