using System;

namespace 解释器模式
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            PlayContext context = new PlayContext();
            // 音乐上海滩
            Console.WriteLine("上海滩: ");
            context.PlayText = "O 2 E 0.5 G 0.5 A 3 E 0.5 G 0.5 D 3 E 0.5 G 0.5 G 0.5 A 0.5 O 3 C 1 O 2 A 0.5 G A C 0.5 E 0.5 D 3";
            Expression expression = null;
            try
            {
                while (context.PlayText.Length > 0)
                {
                    string str = context.PlayText.Substring(0, 1);
                    switch (str)
                    {
                        case "O": expression = new Scale(); break;
                        case "C":
                        case "D":
                        case "E":
                        case "F":
                        case "G":
                        case "A":
                        case "B":
                        case "P": expression = new Note(); break;
                    }
                    expression.Interpret(context);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }

    internal class PlayContext
    {
        //演奏文本
        private string text;

        public string PlayText { get { return text; } set { text = value; } }
    }

    internal abstract class Expression
    {
        public void Interpret(PlayContext context)
        {
            if (context.PlayText.Length == 0)
            {
                return;
            }
            else
            {
                string playKey = context.PlayText.Substring(0, 1);
                context.PlayText = context.PlayText.Substring(2);
                double playValue = Convert.ToDouble(context.PlayText.Substring(0, context.PlayText.IndexOf(" ")));
                context.PlayText = context.PlayText.Substring(context.PlayText.IndexOf(" ") + 1);
                Excute(playKey, playValue);
            }
        }

        // 执行
        public abstract void Excute(string key, double value);
    }

    internal class Note : Expression
    {
        public override void Excute(string key, double value)
        {
            string note = "";
            switch (key)
            {
                case "C": note = "1"; break;
                case "D": note = "2"; break;
                case "E": note = "3"; break;
                case "F": note = "4"; break;
                case "G": note = "5"; break;
                case "A": note = "6"; break;
                case "B": note = "7"; break;
                default:
                    break;
            }

            Console.WriteLine("{0} ", note);
        }
    }

    internal class Scale : Expression
    {
        public override void Excute(string key, double value)
        {
            string scale = "";
            switch (Convert.ToInt32(value))
            {
                case 1: scale = "低音"; break;
                case 2: scale = "中音"; break;
                case 3: scale = "高音"; break;

                default:
                    break;
            }
            Console.WriteLine("{0} ", scale);
        }
    }
}