namespace _04_OOPS_Inheritance
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");

            //Dog d = new Dog();
            //d.Eat(); //called parent's inherited method

            //d.Bark();

            //Animal a = new Animal();
            //a.Eat(); //Animal is Eating..

            ////Dog d2 = new Animal();

            //Animal a2 = new Dog();
            //a2.Eat(); //Animal is Eating..

            //when we use new keyword with a method
            //Because Eat() is not virtual, C# decides which method to call based on the reference type(left side), not the actual object type.

            //single inheritance

            //Dog dog = new Dog();
            //dog.Bark();
            //dog.Eat(); //inherited from animal class

            //multiple inheritance
            //Cat cat = new Cat();
            ////cat.Meow();//cat can access Eat bark & meow() method
            ////cat.Bark();//inherited from Dog superclass
            //cat.Eat();//inherited from Cat superclass of superclass

            //Hierarchical Inheritance: Multiple classes can inherit from a single superclass.


            Parent p = new Child2();
            //p.display();
            p.GetHashCode


            //Parent p = new Parent();
            //p.display();

            //Parent p2 = new Child1();
            //p2.display();

            //Parent p3 = new Child2();
            //p3.display();

            //Child1 c1 = new Child1();
            //c1.display();

            //Child1 c2 = new Child2();

            Child2 c3 = new Child2();
            c3.display();































            //ChildClass c = new ChildClass();
            //c.age = 20;
            //c.Age = 22;


            

        }
    }
}
