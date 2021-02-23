using System;
using System.Collections.Generic;

namespace 组合模式
{
    class Program
    {
        static void Main(string[] args)
        {
            Composite root = new Composite("root");
            root.Add(new Leaf("Leaf A"));
            root.Add(new Leaf("Leaf B"));

            Composite comp = new Composite("Composite X");
            comp.Add(new Leaf("Leaf A"));
            comp.Add(new Leaf("Leaf B"));

            root.Add(comp);

            Composite comp2 = new Composite("Composite XY");
            comp2.Add(new Leaf("Leaf XYA"));
            comp2.Add(new Leaf("Leaf XYB"));

            comp.Add(comp2);

            root.Add(new Leaf("Leaf C"));

            Leaf leaf = new Leaf("Leaf D");
            root.Add(leaf);
            root.Remover(leaf);

            root.Display(1);

            Console.Read();

        }
    }
    abstract class Componet
    {
        protected string name;
        public Componet(string name)
        {
            this.name = name;
        }
        public abstract void Add(Componet c);
        public abstract void Remover(Componet c);
        public abstract void Display(int depth);
    }
    class Leaf : Componet
    {
        public Leaf(string name):base(name)
        { 
        }
        public override void Add(Componet c)
        {
            Console.WriteLine("Cannot Add to c leaf");
        }

        public override void Remover(Componet c)
        {
            Console.WriteLine("Cannot Remove from a leaf");
        }

        public override void Display(int depth)
        {
            Console.WriteLine(new String('-',depth)+name);
        }
    }
    class Composite : Componet
    {
        private List<Componet> children = new List<Componet>();
        public Composite(string name) : base(name)
        { }
        public override void Add(Componet c)
        {
            children.Add(c);
        }

        public override void Display(int depth)
        {
            Console.WriteLine(new String('-', depth) + name);
            foreach (var componet in children)
            {
                componet.Display(depth + 2);
            }
        }

        public override void Remover(Componet c)
        {
            children.Remove(c);
        }
    }
}
