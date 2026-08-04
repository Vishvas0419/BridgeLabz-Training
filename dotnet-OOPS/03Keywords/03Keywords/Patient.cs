using System;
using System.Collections.Generic;
using System.Text;

namespace _03Keywords
{
    internal class Patient
    {
        private string Name;
        private int Age;
        private string Ailment; 
        private static string HospitalName = "Gaba Hospital";
        private static int patients = 0;

        private readonly int PatientID;

        public Patient(string Name,int Age,string Ailment,int PatientID)
        {
            this.Name = Name;
            this.Age = Age;
            this.Ailment = Ailment;
            this.PatientID = PatientID;
            patients++;
        }

        public void changeHospitalName(string newHospitalName)
        {
            HospitalName = newHospitalName;
        }
        public static void ProcessPatient(Patient p)
        {
            if(p is  Patient) //checks type AND casts into 'p' in one step
            {
                Console.WriteLine("Patient is valid to be treated...");
            }
            else
            {
                Console.WriteLine("Incorrect details entered try again bby filling right details...");
            }
            p.display();
        }


        public static int GetTotalPatients()
        {
            return patients;
        }

        public void display()
        {
            Console.WriteLine("Welcome to our aspatal : "+HospitalName);
            Console.WriteLine("patient ID : "+PatientID);
            Console.WriteLine("Patient name : "+Name);
            Console.WriteLine("Patient age : "+Age);
            Console.WriteLine("patient ailment"+Ailment);

            Console.WriteLine("Total Patient : "+GetTotalPatients());

        }


    }
}
