using System;
using System.Collections.Generic;
using System.Text;

namespace ObjectModeling
{
    internal class Car
    {
        public string name;
        private Engine engine;
        public Car(string name,Engine engine)
        {
            this.name = name;
            this.engine = engine;
        }
        public void StartCar()
        {
            //Console.WriteLine(engine.Start())
            engine.Start();
            Console.WriteLine($"{name} started vroom - vroom");
        }
    }
}
