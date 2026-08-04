using System;
using System.Collections.Generic;
using System.Text;

namespace ObjectModeling
{
    internal class Engine
    {
        public string name;
        public Engine(string name)
        {
            this.name = name;
        }
        public void Start()
        {
            Console.WriteLine($"{name} engine started and ready to roll on road...");
        }
    }
}
