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
            Cat cat = new Cat();
            //cat.Meow();//cat can access Eat bark & meow() method
            //cat.Bark();//inherited from Dog superclass
            cat.Eat();//inherited from Cat superclass of superclass
        }
    }
}
