using DepartmentProject_26._12._2021.Interface;
using DepartmentProject_26._12._2021.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DepartmentProject_26._12._2021.Services
{
    class HumanResourceManager : IHumanResourceManager
    {
        public Employee[] employees => _employee;
        private Employee[] _employee;

        public Department[] departments => _department;
        private Department[] _department;
        public HumanResourceManager()
        {
            _employee = new Employee[0];
            _department = new Department[0];
        }

        public void AddDepartment(Department[] departments, string name, double workerlimit, double salarylimit)
        {
            Department department = new Department(name, workerlimit, salarylimit, employees);
            Array.Resize(ref _department, _department.Length + 1);
            _department[_department.Length - 1] = department;
        }

        public Department[] GetDepartments(Department[] departments)
        {
            return departments;
        }

        public void EditDepartaments(string name, string newname)
        {
            Department employee = null;

            foreach (Department item in _department)
            {
                if (item.Name == name)
                {
                    employee = item;
                    break;
                }
            }

            employee.Name = newname;
        }

        public void AddEmployee(string no, string fullname, string position, double salary, string departmentName)
        {
            Employee employee = new Employee(no, fullname, position, salary, departmentName);
            Array.Resize(ref _employee, _employee.Length + 1);
            _employee[_employee.Length - 1] = employee;
        }

        public void RemoveEmployee(string no, string departmentname)
        {
            for (int i = 0; i < _employee.Length; i++)
            {
                if (_employee[i] != null && _employee[i].No == no)
                {
                    _employee[i] = null;
                    return;
                }
            }
        }
        public void EditEmploye(string no, string fullname, double salary, string position)
        {
            Employee employee = null;

            foreach (Employee item in _employee)
            {
                if (item.No == no)
                {
                    employee = item;
                    break;
                }
            }

            employee.Salary = salary;
            employee.Fullname = fullname;
            employee.Position = position;
        }

    }
}

