using Employee_Management_System;

internal class Program
{
    static void Main(string[] args)
    {
        Developer developer =
            new Developer(101, "Vishvas", 24, "IT");

        Manager manager =
            new Manager(102, "Rahul", 35, "Management", 10);

        HRRepresentative hr =
            new HRRepresentative(103, "USER", 30, "HR");


        // Developer overtime
        developer.AddOvertimeShift();
        developer.AddOvertimeShift();


        // Developer
        developer.DisplayDetails();
        developer.ClockIn();
        developer.WriteCode();
        developer.ReviewCode();
        developer.PerformEvaluation();
        developer.ProcessPayment();


        Console.WriteLine();


        // Manager
        manager.DisplayDetails();
        manager.AssignTask();
        manager.ApproveLeave();
        manager.ConductMeeting();
        manager.PerformEvaluation();
        manager.ProcessPayment();


        Console.WriteLine();


        // HR
        hr.DisplayDetails();
        hr.OnboardEmployee();
        hr.ConductInterview();
        hr.PerformEvaluation();
        hr.ProcessPayment();
    }
}