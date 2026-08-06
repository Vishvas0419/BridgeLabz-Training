namespace Encapsulation_Practise
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Console.WriteLine("Hello, World to Encapuslation Practise!");


            Student s1 = new Student(23); //now contructor is assigning value 23 to the age instance variable during Object creation

            //now current value of age = 23

            Console.WriteLine(s1.Age); //23 //using getter property

            s1.Age = 18; //using setter property //value = 18 here

            //Console.WriteLine(s1.age); //if age instance variable/field is set to be public then we dont need to use getter or setter property and the data hiding property is destroyed we can simply use that variable oinsteda of using Age property

            s1.SetAge(40); //setting age using SetAge() method this is equal to s1.Age = 40

            Console.WriteLine(s1.GetAge()); //accessing age using custom GetAge() method



            

            
        }
    }
}
