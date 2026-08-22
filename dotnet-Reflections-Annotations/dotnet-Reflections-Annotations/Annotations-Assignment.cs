using System;
using System.Collections.Generic;
using System.Text;

namespace dotnet_Reflections_Annotations
{
    
    class Animal
    {
        public virtual void MakeSound()
        {
            Console.WriteLine("Animal makes a sound");
        }
    }

    class Dog : Animal
    {
        public override void MakeSound()
        {
            Console.WriteLine("Dog barks");
        }
    }

    class LegacyAPI
    {
        [Obsolete("OldFeature() is obsolete. Use NewFeature() instead.")]
        public void OldFeature()
        {
            Console.WriteLine("Old Feature");
        }

        public void NewFeature()
        {
            Console.WriteLine("New Feature");
        }
    }

    class Annotations_Assignment
    {
        //question 1
        public static void MethodOverriding()
        {
            Dog dog = new Dog();

            dog.MakeSound();
        }



        //question 2
        public static void ObsoleteAttributeExample()
        {
            LegacyAPI api = new LegacyAPI();

            api.OldFeature();

            api.NewFeature();
        }
    }






}
