using System;

namespace 单例模式
{
    class Program
    {
        static void Main(string[] args)
        {

        }
    }
    /// <summary>
    /// 双重锁定单例
    /// </summary>
    class Singleton
    {
        private static Singleton instance;
        private static readonly object syncRoot = new object();
        private Singleton()
        { }
        public static Singleton Getinstance()
        {
            if (instance == null)
            {
                lock (syncRoot)
                {
                    if (instance == null)
                    {
                        instance = new Singleton();
                    }
                }
            }
            return instance;
        }
    }
    /// <summary>
    /// 使用公共语言Sealed
    /// </summary>
    public sealed class SingletonSealed
    {
        private static readonly SingletonSealed instance = new SingletonSealed();
        private SingletonSealed()
        { }
        public static SingletonSealed GetInstance()
        {
            return instance;
        }

    }
}
