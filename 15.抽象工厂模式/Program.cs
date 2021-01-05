using System;
using System.Reflection;
using System.Configuration;
using Microsoft.IdentityModel.Protocols;
namespace 抽象工厂模式
{
    class Program
    {
        static void Main(string[] args)
        {
            User user = new User();
            Departement dept = new Departement();
            IUser iu = DataAccess.CreateUser();

            iu.Instert(user);
            iu.GetUser(1);

            IDepartment id = DataAccess.CreateDepartment();
            id.Insert(dept);
            id.GetDepartement(1);
            Console.Read();
        }
    }
    class User
    {
        private int _id;
        public int ID
        {
            get { return _id; }
            set { _id = value; }
        }
        private string _name;
        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }
    }
    class Departement
    {
        private int _id;
        public int ID
        {
            get { return _id; }
            set { _id = value; }
        }
        private string _deptName;
        public string DeptName
        {
            get { return _deptName; }
            set { _deptName = value; }
        }
    }
    interface IUser
    {
        void Instert(User user);
        User GetUser(int id);
    }
    class SqlserverUser : IUser
    {
        public User GetUser(int id)
        {
            Console.WriteLine("在SQL Server中根据ID得到User表记录一条.");
            return null;
        }

        public void Instert(User user)
        {
            Console.WriteLine("在SQL Server中给User表增加一条记录.");
        }
    }
    class AccessUser : IUser
    {
        public User GetUser(int id)
        {
            Console.WriteLine("在Access 中根据ID得到User表记录一条.");
            return null;
        }

        public void Instert(User user)
        {
            Console.WriteLine("在Access 中给User表增加一条记录.");
        }
    }

    interface IDepartment
    {
        void Insert(Departement departement);
        Departement GetDepartement(int id);
    }
    class SqlserverDepertment : IDepartment
    {
        public Departement GetDepartement(int id)
        {
            Console.WriteLine("在SQL Server 中根据ID得到Department表一条记录");
            return null;
        }

        public void Insert(Departement departement)
        {
            Console.WriteLine("在SQL Server中给Department表增加一条记录");
        }
    }
    class AccessDepartment : IDepartment
    {
        public Departement GetDepartement(int id)
        {
            Console.WriteLine("Access Server 中根据ID得到Department表一条记录");
            return null;
        }

        public void Insert(Departement departement)
        {
            Console.WriteLine("在Access Server中给Department表增加一条记录");
        }
    }
  
   
    class DataAccess
    {
        private static readonly string AssemblyName = "抽象工厂模式";
        //private static readonly string db = "Sqlserver";
        private static readonly string db = ConfigurationManager.AppSettins["DB"];
        // private static readonly string db = "Access";
        public static IUser CreateUser()
        {
            string className = AssemblyName + "." + "User";
            return (IUser) Assembly.Load(AssemblyName).CreateInstance(className);
        }
        public static IDepartment CreateDepartment()
        {
            string className = AssemblyName + "." +db+ "Department";
            return (IDepartment)Assembly.Load(AssemblyName).CreateInstance(className);
        }
    }
}
