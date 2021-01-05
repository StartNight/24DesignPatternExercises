using System;

namespace 备忘录模式
{
    class Program
    {
        static void Main(string[] args)
        {
            GameRole lixiaoyao = new GameRole();
            lixiaoyao.GetInitState();
            lixiaoyao.StateDisplay();

            // 保存进度
            RoleStateCaretaker stateAdmin = new RoleStateCaretaker();
            stateAdmin.Memento = lixiaoyao.SaveState();

            // 大战Boss,损耗严重
            lixiaoyao.Fight();
            lixiaoyao.StateDisplay();

            // 恢复之前状态
            lixiaoyao.RecoveryState(stateAdmin.Memento);
            lixiaoyao.StateDisplay();
            Console.Read();
        }
    }
    class  GameRole
    {
        // 生命力
        private int vit;
        public int Vitality
        {
            get { return vit; }
            set { vit = value; }
        }
        private int atk;
        public int Attack
        {
            get { return atk; }
            set { atk = value; }
        }
        // 防御力
        private int def;
        public int Defense
        {
            get { return def; }
            set { def = value; }
        }
        public void StateDisplay()
        {
            Console.WriteLine("角色当前状态:");
            Console.WriteLine("体力{0}",this.vit);
            Console.WriteLine("攻击力{0}", this.atk);
            Console.WriteLine("防御力{0}", this.def);
            Console.WriteLine("");
        }
        // 获得初始状态
        public void GetInitState()
        {
            this.vit = 100;
            this.atk = 100;
            this.def = 100;
        }
        // 战斗
        public void Fight()
        {
            this.vit = 0;
            this.atk = 0;
            this.def = 0;
        }

        public RoleStateMemento SaveState()
        {
            return new RoleStateMemento(vit, atk, def);
        }
        public void RecoveryState(RoleStateMemento memento)
        {
            this.vit = memento.Vitality;
            this.atk = memento.Attack;
            this.def = memento.Defanse;
        }
    }
    class RoleStateMemento
    {
        private int vit;
        private int atk;
        private int def;
        public RoleStateMemento(int vit, int atk, int def)
        {
            this.vit = vit;
            this.atk = atk;
            this.def = def;
        }
        public int Vitality
        {
            get { return vit; }
            set { vit = value; }
        }
        public int Attack 
        {
            get { return atk; }
            set { atk = value; }
        }
        public int Defanse
        {
            get { return def; }
            set { def = value; }
        }
    }
    class RoleStateCaretaker
    {
        private RoleStateMemento memento;
        public RoleStateMemento Memento
        {
            get { return memento; }
            set { memento = value; }
        }
    }
}
