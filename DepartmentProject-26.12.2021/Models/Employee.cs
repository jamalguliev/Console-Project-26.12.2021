using System;
using System.Collections.Generic;
using System.Text;

namespace DepartmentProject_26._12._2021.Models
{
    class Employee
    {
        private static int Count = 1000;
        public string No { get; set; }
        public string Fullname { get; set; }
        public string Position { get; set; }
        public double Salary { get; set; }
        public string DepartmentName { get; set; }


        public Employee(string No, string fullname, string position, double salary, string departmentName)
        {
            if (position.Length < 2)
            {
                Console.WriteLine("Vezife Adini Duzgun Daxil Edin!");
            }
            if (salary <= 250)
            {
                Console.WriteLine("Bu maas movcud deyil");
            }
            No = departmentName.Substring(0, 2) + Count;
            Count++;
            Fullname = fullname;
            Position = position;
            Salary = salary;
            DepartmentName = departmentName;


        }
        public override string ToString()
        {
            return $"nomresi: {No}\nFullname: {Fullname}\nPosition: {Position}\nsalary: {Salary}\ndepartmentname: {DepartmentName}";

        }
    }
}
