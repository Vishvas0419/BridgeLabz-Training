using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;

namespace _05_Polymorphism_Interfaces_AbstractClasses
{

    internal interface IMedicalRecord
    {
        void AddRecord(string record);
        List<string> ViewRecords();
    }

    internal abstract class Patient
    {
        private int patientID;
        private string name;
        private int age;

        public int PatientID
        {
            get { return patientID; }
            private set
            {
                patientID = value;
            }
        }

        public string Name
        {
            get { return name; }
            private set
            {
                name = value;
            }
        }

        public int Age
        {
            get { return age; }
            private set
            {
                age = value;
            }
        }

        public Patient(int patientID, string name, int age)
        {
            this.patientID = patientID;
            this.name = name;
            this.age = age;
        }

        public abstract double CalculateBill();


        public void GetPatientDetails()
        {
            Console.WriteLine("=========== Patient Details ==========");
            Console.WriteLine("Patient ID : "+patientID);
            Console.WriteLine("Patient Name : "+name);
            Console.WriteLine("Patient Age : "+age);

            Console.Write("Patient Type : ");

            if (this is InPatient) Console.WriteLine("InPatient");
            else Console.WriteLine("OutPatient");

            if(this is IMedicalRecord medicalRecordPatient)
            {
                List<string> records = medicalRecordPatient.ViewRecords();
                Console.WriteLine("========= Medical Records =========");

                for(int i=0;i<records.Count;i++)
                {
                    Console.WriteLine(records[i]);
                }
            }

            Console.WriteLine("===============================");


        }

        //public void DisplayBillingDetails()
        //{
        //    Console.WriteLine("====== Billing Details ======");
        //    GetPatientDetails();

        //    if(this is InPatient)
        //    {
        //        Console.WriteLine("No of Days Admitted : "+);
        //    }

        //}
    }

    class InPatient : Patient, IMedicalRecord
    {
        private int numberOfDaysAdmitted;
        private double roomChargePerDay;
        private string diagnosis;
        private List<string> medicalHistory;


        public int NumberOfDaysAdmitted
        {
            get { return numberOfDaysAdmitted; }
            private set
            {
                numberOfDaysAdmitted = value;
            }
        }

        public double RoomChargePerDay
        {
            get
            {
                return roomChargePerDay;
            }
            private set
            {
                roomChargePerDay = value;
            }
        }

        public string Diagnosis
        {
            get
            {
                return diagnosis;
            }
            private set
            {
                diagnosis = value;
            }
        }


        public InPatient(int patientID, string name, int age, int numberOfDaysAdmitted, double roomChargePerDay, string diagnosis) : base(patientID, name, age)
        {
            this.numberOfDaysAdmitted = numberOfDaysAdmitted;
            this.roomChargePerDay = roomChargePerDay;
            this.diagnosis = diagnosis;
            medicalHistory = new List<string>();
        }
        public override double CalculateBill()
        {
            return numberOfDaysAdmitted * roomChargePerDay;
        }

        public void AddRecord(string record)
        {
            medicalHistory.Add(record);
        }
        public List<string> ViewRecords()
        {
            return medicalHistory;
        }
    }

    class OutPatient : Patient, IMedicalRecord
    {
        private double visitingFee;
        private string diagnosis;
        private List<string> medicalHistory;

        public OutPatient(int patientID, string name, int age, double visitingFee, string diagnosis) : base(patientID, name, age)
        {
            this.visitingFee = visitingFee;
            this.diagnosis = diagnosis;
            medicalHistory = new List<string>();
        }



        public override double CalculateBill()
        {
            return visitingFee;
        }

        public void AddRecord(string record)
        {
            medicalHistory.Add(record);
        }
        public List<string> ViewRecords()
        {
            return medicalHistory;
        }

    }
}
