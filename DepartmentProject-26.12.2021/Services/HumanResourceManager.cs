using DepartmentProject_26._12._2021.Interface;
using DepartmentProject_26._12._2021.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DepartmentProject_26._12._2021.Services
{
    class HumanResourceManager : IHumanResourceManager
    {
        public Department[] Departments => _departments;
        private Department[] _departments;

        public Employee[] Employees => _employees;
        private Employee[] _employees;

        public HumanResourceManager()
        {
            _departments = new Department[0];
            _employees = new Employee[0];
        }

        public void AddDepartment(string name, int workerlimit, double salarylimit)
        {
            Department departmentitem = new Department(name: name, workerlimit: workerlimit, salarylimit: salarylimit);
            Array.Resize(ref _departments, _departments.Length + 1);
            _departments[_departments.Length - 1] = departmentitem;
        }

        public void AddEmployee(string departmentname, string fullname, string position, double salary)
        {


            Department department = FindDepartment(departmentname);
            if (department == null)
            {
                Console.WriteLine($"Sistemde {departmentname} Adli Departament Yoxdur, Evvelce Departament Elave Edin!");
            }

            else if (_employees.Length > department.WorkerLimit)
            {

                Console.WriteLine("Departamentin Isci Limitiden Artig Isci Elave Oluna Bilmez!");
            }

            else
            {

                Employee employeeitem = new Employee(departmentname)
                {
                    DepartmentName = departmentname,
                    FullName = fullname,
                    Position = position,
                    Salary = salary
                };
                Array.Resize(ref _employees, _employees.Length + 1);
                _employees[_employees.Length - 1] = employeeitem;

            }

        }

        public void EditDepartments(string name, string newname)
        {

            if (FindDepartment(newname) != null) return;
            {
                Department department = FindDepartment(name);

                if (department != null)
                {
                    department.Name = newname;
                    foreach (var item in department.Employees)
                    {
                        item.DepartmentName = newname;
                    }
                }
            }
        }

        public void EditEmployee(string departmentname, string no, string position, double salary)
        {
            throw new NotImplementedException();
        }

        public void RemoveEmployee(string no, string departmentname)
        {
            for (int i = 0; i < _employees.Length; i++)
            {
                if (_employees[i] != null && _employees[i].No == no)
                {
                    _employees[i] = null;
                    return;
                }
            }
            for(int i = 0; i < _departments.Length; i++)
            {
                if (_departments[i] != null && _departments[i].Name == departmentname)
                {
                    _employees[i] = null;
                    return;
                }
            }
        }

        public bool CheckName(string name)
        {
            if (!string.IsNullOrWhiteSpace(name))
            {
                if (name.Length > 1)
                {
                    return true;
                }
            }

            return false;
        }

        public bool CheckDepartment(string name)
        {

            foreach (Department item in _departments)
            {
                if (item.Name == name)
                {
                    return false;

                }
            }

            return true;
        }

        public Department FindDepartment(string name)
        {
            foreach (Department item in _departments)
            {
                if (item.Name == name)
                {
                    return item;

                }
            }
            return null;
        }
        internal bool CheckFullName(string fullname)
        {
            if (!string.IsNullOrWhiteSpace(fullname))
            {
                string[] words = fullname.Split(" ");
                if (words.Length > 1)
                {
                    foreach (string word in words)
                    {
                        if (string.IsNullOrWhiteSpace(word))
                        {
                            return false;
                        }

                        foreach (var chr in word)
                        {
                            if (Char.IsLetter(chr) == false)
                            {
                                return false;
                            }
                        }
                    }
                    return true;
                }
            }
            return false;
        }
    }
}

