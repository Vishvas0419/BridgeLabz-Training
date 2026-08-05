using System;
using System.Collections.Generic;
using System.Text;

namespace _05_Polymorphism_Interfaces_AbstractClasses
{
    internal interface IDepartment
    {
        void AssignDepartment(string departmentName);
        string GetDepartmentDetails();
    }
}
