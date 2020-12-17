using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace 策略模式
{
    static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.SetHighDpiMode(HighDpiMode.SystemAware);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new CashWin());
        }
    }
    //收费的父类
    abstract class CashSuper
    {
        public abstract double acceptCash(double money);
    }
    /// <summary>
    /// 正常收费子类
    /// </summary>
    class CashNormal : CashSuper
    {
        public override double acceptCash(double money)
        {
            return money;
        }
    }
    /// <summary>
    /// 打折收费子类
    /// </summary>
    class CashRebate : CashSuper
    {
        private double moneyRebate = 1d;
        public CashRebate(string moneyRabate)
        {
            this.moneyRebate = double.Parse(moneyRabate);
        }
        public override double acceptCash(double money)
        {
            return money * moneyRebate;
        }

    }

    class CashReturn : CashSuper
    {
        private double moneyCondition = 0.0d;
        private double moneyReturn = 0.0d;
        public CashReturn(string moneyCondition, string moneyReturn)
        {
            this.moneyCondition =double.Parse( moneyCondition);
            this.moneyReturn = double.Parse(moneyReturn);
        }
        public override double acceptCash(double money)
        {
            double result = money;
            return result;
        }
    }

    class CashFactory
    {
        public static CashSuper createCashAccept(string type)
        {
            CashSuper cs = null;
            switch (type)
            {
                case "正常收费":
                    cs = new CashNormal();
                    break;
                case "满300减100":
                    cs = new CashReturn("300","100");
                    break;
                case "打8折":
                    cs = new CashRebate("0.8");
                    break;
                default:
                    break;
            }
            return cs;
        }
    }
    class CashContext
    {
        private CashSuper cs;
      
        public CashContext(CashSuper csuper)
        {
            this.cs = csuper;
        }
        public double GetResult(double money)
        {
            return cs.acceptCash(money);
        }

        public CashContext(string type)
        {

            switch (type)
            {
                case "正常收费":
                    cs = new CashNormal();
                    break;
                case "满300减100":
                    cs = new CashReturn("300", "100");
                    break;
                case "打8折":
                    cs = new CashRebate("0.8");
                    break;
                default:
                    break;
            }
        }
    }

}
