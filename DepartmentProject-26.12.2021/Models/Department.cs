using System;
using System.Collections.Generic;
using System.Text;

namespace DepartmentProject_26._12._2021.Models
{
    class Department
    {
        public string Name { get; set; }
        public double WorkerLimit { get; set; }
        public double SalaryLimit { get; set; }
        public Employee[] Employees { get; set; }
        public Department(string name, double workerlimit, double salarylimit, Employee[] employees)
        {
            Name = name;
            WorkerLimit = workerlimit;
            SalaryLimit = salarylimit;
            Employees = employees;
            if (WorkerLimit <= 1)
            {


                Console.WriteLine("Isci Sayini Duzgun Daxil Edin!");
                return;
            }
            if (Name.Length <= 2)
            {
                Console.WriteLine("Yazdigini Ada Uygun Departament Yoxdur!");
            }
            if (SalaryLimit <= 250)
            {
                Console.WriteLine("Maas 250-den asagi ola bilmez");
                return;
            }
            if (Employees.Length <= 0)
            {
                Console.WriteLine("Employees bos ola bilmez");
                return;
            }

        }
        public double CalcAverageSalary(Department department)
        {
            double TotalSalary = 0;
            int count = 0;
            foreach (Employee item in department.Employees)
            {
                TotalSalary += item.Salary;
                count++;
            }
            return TotalSalary / count;
        }
    }
}
