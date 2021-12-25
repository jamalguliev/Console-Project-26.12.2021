using DepartmentProject_26._12._2021.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DepartmentProject_26._12._2021.Interface
{
    interface IHumanResourceManager
    {
            Employee[] employees { get; }
            Department[] departments { get; }

            void AddDepartment(Department[] departments, string name, double workerlimit, double salarylimit);
            Department[] GetDepartments(Department[] departments);
            void EditDepartaments(string name, string newname);
            void AddEmployee(string no, string fullname, string position, double salary, string departmentName);
            void RemoveEmployee(string no, string departmentname);
            void EditEmploye(string no, string fullname, double salary, string position);
        }
    }

