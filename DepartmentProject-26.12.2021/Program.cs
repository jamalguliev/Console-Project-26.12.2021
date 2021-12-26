using DepartmentProject_26._12._2021.Models;
using DepartmentProject_26._12._2021.Services;
using System;

namespace DepartmentProject_26._12._2021
{
    class Program
    {
        static void Main(string[] args)
        {
            HumanResourceManager humanResourceManager = new HumanResourceManager();

            do
            {
                Console.ResetColor();
                Console.WriteLine("-------------------------Human Resource Manager---------------------------");
                Console.WriteLine("Yerine Yetirmek Isdediyniz Emeliyyatin Qarsisindaki Nomreni Daxil Edin:");
                Console.WriteLine("1 - Departament Uzerinde Emeliyyatlar:");
                Console.WriteLine("2 - Isciler Uzerinde Emeliyyatlar:");
                Console.WriteLine("3 - Sistemden Cixis:");
                Console.Write("Daxil Edin:");
                string choose = Console.ReadLine();
                int chooseNum;
                int.TryParse(choose, out chooseNum);
                switch (chooseNum)
                {
                    case 1:
                        Console.Clear();
                        DepartmentOperation(ref humanResourceManager);
                        break;
                    case 2:
                        Console.Clear();
                        EmployeeOperation(ref humanResourceManager);
                        break;
                    case 3:
                        return;
                    default:
                        Console.Clear();
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Duzgun Daxil Edin!");
                        break;
                }

            } while (true);



            static void DepartmentOperation(ref HumanResourceManager humanResourceManager)
            {
                do
                {
                    Console.ResetColor();
                    Console.WriteLine("-------------------------Departament Emeliyyatlari---------------------------");
                    Console.WriteLine("Yerine Yetirmek Isdediyniz Emeliyyatin Qarsisindaki Nomreni Daxil Edin");
                    Console.WriteLine("1 - Departamentlerin Siyahisi");
                    Console.WriteLine("2 - Yeni Departament Yaratmaq");
                    Console.WriteLine("3 - Departamentde Deyisiklik Etmek");
                    Console.WriteLine("4 - Departamentdeki Iscilerin Siyahisi");
                    Console.WriteLine("5 - Esas Menuya Qayitmaq");
                    Console.Write("Daxil Et:");
                    string choose = Console.ReadLine();
                    int chooseNum;
                    int.TryParse(choose, out chooseNum);
                    switch (chooseNum)
                    {
                        case 1:
                            GetDepartments(ref humanResourceManager);
                            break;
                        case 2:
                            AddDepartment(ref humanResourceManager);
                            Console.Clear();
                            break;
                        case 3:
                            EditDepartment(ref humanResourceManager);
                            break;
                        case 4:
                            GetEmployeesByDepartment(ref humanResourceManager);
                            break;
                        case 5:
                            Console.Clear();
                            return;
                        default:
                            Console.Clear();
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("Duzgun Daxil Edin!");
                            break;
                    }

                } while (true);
            }

            static void AddDepartment(ref HumanResourceManager humanResourceManager)
            {
                string name;
                bool check = true;
                do
                {
                    if (check)
                    {
                        Console.Clear();
                        Console.Write("Departament adini daxil edin:");
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Departamentin Adi Minimum 2 Herfden Ibaret Olmalidir!");
                        Console.ResetColor();
                        Console.Write("Departamentin Adini Yeniden Daxil Edin:");
                    }
                    name = Console.ReadLine();
                    check = false;

                } while (!humanResourceManager.CheckName(name));

                do
                {
                    if (check)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Daxil Edtiyiniz Departament Movcuddur!");
                        Console.ResetColor();
                        Console.Write("Yeni Departament Adi Daxil Edin:");
                        name = Console.ReadLine();
                    }
                    check = true;

                } while (!humanResourceManager.CheckDepartment(name));


                int workerlimit;
                string workerlimitNO;
                check = true;
                do
                {
                    if (check)
                    {
                        Console.Write("Departamentin Maximum Isci Limitini Daxil Edin:");
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Departamentin Minimum Isci Limiti 1 Olmalidir!");
                        Console.ResetColor();
                        Console.Write("Isci Limitini Yeniden Daxil Edin:");
                    }
                    workerlimitNO = Console.ReadLine();
                    check = false;

                } while (!int.TryParse(workerlimitNO, out workerlimit) || workerlimit <= 0);

                double salarylimit;
                string salarylimitNO;
                check = true;
                do
                {
                    if (check)
                    {
                        Console.Write("Departamentin Iscileri Ucun Maas Limitini Daxil Edin:");
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Maas Limiti 250 Manatdan Asagi Ola Bilmez!");
                        Console.ResetColor();
                        Console.Write("Maas Limitini Yeniden Daxil Edin:");
                    }
                    salarylimitNO = Console.ReadLine();
                    check = false;

                } while (!double.TryParse(salarylimitNO, out salarylimit) || salarylimit < 250);

                humanResourceManager.AddDepartment(name, workerlimit, salarylimit);
            }

            static void GetDepartments(ref HumanResourceManager humanResourceManager)
            {

                if (humanResourceManager.Departments.Length > 0)
                {
                    foreach (Department item in humanResourceManager.Departments)
                    {

                        Console.WriteLine($"{item} - Maas ortalamasi:{ item.ClcSalaryAverage(item)}\n");

                    }
                }

                else
                {
                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Departament Yoxdur!");
                    Console.ResetColor();
                }

            }

            static void EditDepartment(ref HumanResourceManager humanResourceManager)
            {

                GetDepartments(ref humanResourceManager);

                if (humanResourceManager.Departments.Length > 0)
                {

                    string name;
                    bool check = true;
                    do
                    {

                        if (check)
                        {
                            Console.Write("Deyisiklik Etmek Istediyiniz Departamentin Adini Daxil edin: ");
                        }
                        else
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("Departament Adinda Reqem Ola Bilmez ve Minimum 2 Herfli Olmalidir!");
                            Console.ResetColor();
                            Console.Write("Yeniden Daxil Edin:");
                        }
                        name = Console.ReadLine();
                        check = false;

                    } while (!humanResourceManager.CheckName(name));

                    do
                    {
                        if (check)
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("Daxil Etdiyiniz Adda Departament Movcud Deyil!");
                            Console.ResetColor();
                            Console.Write("Departament Adini Yeniden Daxil Edin:");
                            name = Console.ReadLine();
                        }
                        check = true;

                    } while (humanResourceManager.FindDepartment(name) == null);

                    string newname;
                    check = true;

                    do
                    {

                        if (check)
                        {
                            Console.Write("Departamentin Yeni Adini Daxil Edin: ");
                        }
                        else
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("Departament Reqemle Ola Bilmez Ve Minimum 2 Herfli Olmalidir!");
                            Console.ResetColor();
                            Console.Write("Departamentin Yeni Adini Yeniden Daxil Edin:");
                        }
                        newname = Console.ReadLine();
                        check = false;

                    } while (!humanResourceManager.CheckName(newname));

                    do
                    {
                        if (check)
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("Daxil Etdiyiniz Adda Departament Movcuddur!");
                            Console.ResetColor();
                            Console.Write("Departamentin Adinini Yeniden Daxil Edin: ");
                            newname = Console.ReadLine();
                        }
                        check = true;

                    } while (humanResourceManager.FindDepartment(newname) != null);

                    humanResourceManager.EditDepartments(name, newname);
                }
            }

            static void GetEmployeesByDepartment(ref HumanResourceManager humanResourceManager)
            {
                if (humanResourceManager.Departments.Length <= 0)
                {
                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Departament Ve Isci Yoxdur!");
                    Console.ResetColor();
                }
                else
                {
                    GetDepartments(ref humanResourceManager);

                    string name;
                    bool check = true;
                    Department department = null;
                    do
                    {
                        if (check)
                        {
                            Console.Write("Gormek Istediyiniz Iscilerin Departament Adini Daxil Edin:");
                        }
                        else
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("Daxil Etdiyiniz Department Movcud Deyil!");
                            Console.ResetColor();
                            Console.Write("Departamentin Adini Yeniden Daxil Edin:");
                        }

                        name = Console.ReadLine();
                        department = humanResourceManager.FindDepartment(name);
                        check = false;

                    } while (department == null);

                    if (department.Employees.Length > 0)
                    {

                        Console.WriteLine($"{name} Departamentindeki Isciler:\n");
                        foreach (Employee emps in department.Employees)
                        {
                            Console.WriteLine(emps);
                        }
                    }
                    else
                    {
                        Console.Clear();
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine($"{name}--Departamentinde Hec Bir Isci Yoxdur!");

                    }
                }
            }

            static void EmployeeOperation(ref HumanResourceManager humanResourceManager)
            {

                do
                {
                    Console.WriteLine("-------------------------Isciler Uzerinde Emeliyyatlar---------------------------");
                    Console.WriteLine("Yerine Yetirmek Isdediyniz Emeliyyatin Qarsisindaki Nomreni Daxil Edin");
                    Console.WriteLine("1 - Iscilerin Siyahisi");
                    Console.WriteLine("2 - Isci Elave Etmek");
                    Console.WriteLine("3 - Isci Uzerinde Deyisiklik Etmek");
                    Console.WriteLine("4 - Departamentden Isci Silmek");
                    Console.WriteLine("5 - Esas Menuya Qayitmaq");
                    Console.Write("Daxil Edin:");
                    string choose = Console.ReadLine();
                    int chooseNum;
                    int.TryParse(choose, out chooseNum);
                    switch (chooseNum)
                    {
                        case 1:
                            GetEmployee(ref humanResourceManager);
                            break;
                        case 2:
                            AddEmployee(ref humanResourceManager);

                            break;
                        case 3:
                            EditEmployee(ref humanResourceManager);
                            break;
                        case 4:
                            RemoveEmployee(ref humanResourceManager);
                            break;
                        case 5:
                            Console.Clear();
                            return;
                        default:
                            Console.Clear();

                            break;
                    }

                } while (true);
            }

            static void GetEmployee(ref HumanResourceManager humanResourceManager)
            {
                if (humanResourceManager.Employees.Length > 0)
                {
                    if (humanResourceManager.Employees.Length > 0)
                    {
                        foreach (Employee item in humanResourceManager.Employees)
                        {

                            Console.WriteLine($"{item}\n");

                        }
                    }

                }
                else
                {
                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Sistemde Isci Yoxdur!");
                    Console.ResetColor();
                }
            }

            static void AddEmployee(ref HumanResourceManager humanResourceManager)
            {

                if (humanResourceManager.Departments.Length == 0)
                {
                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Departament Yoxdur!");
                    Console.ResetColor();
                }
                else
                {
                    string departmentname;
                    Department department = null;
                    bool check = true;
                    do
                    {
                        if (check)
                        {
                            Console.Write("Isci Elave Etmek Istediyiniz Departmentin Adini Daxil Edin:");
                        }
                        else
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("Daxil Etdiyiniz Adda Departament Yoxdur!");
                            Console.ResetColor();
                            Console.Write("Departamentin Adini Yeniden Daxil Edin:");
                        }
                        departmentname = Console.ReadLine();
                        department = humanResourceManager.FindDepartment(departmentname);
                        check = false;

                    } while (department == null);
                    int m = department.Employees.Length;

                    if (department.Employees.Length >= department.WorkerLimit)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Departmentin Isci Limiti Doludur!");
                        Console.ResetColor();

                        return;
                    }

                    string fullname;
                    check = true;
                    do
                    {
                        if (check)
                        {
                            Console.Write("Iscinin Adini Ve Soyadini Daxil Edin:");
                        }

                        else
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("Ad ve Soyad Yanlisdir!");
                            Console.ResetColor();
                            Console.Write("Ad Ve Soyadi Yeniden Daxil Edin:");
                        }

                        fullname = Console.ReadLine();
                        check = false;

                    } while (!humanResourceManager.CheckFullName(fullname));

                    string position;
                    check = true;
                    do
                    {
                        if (check)
                        {
                            Console.Write("Iscinin Vezifesini Daxil Edin:");
                        }
                        else
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("Iscinin Vezife Adi 2 Simvoldan Boyuk Olmalidir!");
                            Console.ResetColor();
                            Console.Write("Iscinin Vezifesini Yeniden Daxil edin:");
                        }

                        position = Console.ReadLine();
                        check = false;

                    } while (!humanResourceManager.CheckName(position));

                    double salary;
                    string salarystr;
                    check = true;
                    do
                    {

                        if (check)
                        {
                            Console.Write("Iscinin Maasini Daxil Edin:");
                        }

                        else
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine($"Iscinin Maasi 250 Manatdan Asagi Ve Departamentin Maksimum Maas Limiti olan {department.SalaryLimit}-Den Yuxari Ola Bilmez!");
                            Console.ResetColor();
                            Console.Write("Iscinin Maasini Yeniden Daxil Edin:");
                        }

                        salarystr = Console.ReadLine();
                        check = false;

                    } while (!double.TryParse(salarystr, out salary) || salary < 250 || salary > department.SalaryLimit);

                    humanResourceManager.AddEmployee(departmentname, fullname, position, salary);
                }
            }

            static void EditEmployee(ref HumanResourceManager humanResourceManager)
            {

            }

            static void RemoveEmployee(ref HumanResourceManager humanResourceManager)
            {
                if (humanResourceManager.Employees.Length <= 0)
                {
                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Isci Yoxdur!");
                    Console.ResetColor();
                    return;
                }
                foreach (Employee item in humanResourceManager.Employees)
                {
                    Console.WriteLine(item);
                    Console.WriteLine("--------------------------");
                }
                Console.Write("Silmek Istediyiniz Iscinin Nomresini Daxil Edin:");
                string empno = Console.ReadLine();
                bool check = true;
                int count = 0;
                while (check)
                {
                    foreach (Employee item in humanResourceManager.Employees)
                    {
                        if (item.No.ToLower() == empno.ToLower())
                        {
                            count++;
                        }
                    }
                    if (count <= 0)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Daxil Etdiyiniz Nomrede Isci Yoxdur!");
                        Console.ResetColor();
                        Console.Write("Isci Nomresini Duzgun Daxil Edin:");
                        empno = Console.ReadLine();
                    }
                    else
                    {
                        check = false;
                    }
                    count = 0;
                }
                Console.Write("Silmek Istediyiniz Iscinin Department Adini Daxil Edin:");
                string departmentname = Console.ReadLine();
                bool checkdepartment = true;
                int result = 0;
                while (checkdepartment)
                {
                    foreach (Department item in humanResourceManager.Departments)
                    {
                        if (item.Name.ToLower() == departmentname.ToLower())
                        {
                            result++;
                        }
                    }
                    if (count <= 0)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Daxil Etdiyiniz Adda Departament Yoxdur!");
                        Console.ResetColor();
                        Console.Write("Departament Adini Duzgun Daxil Edin:");
                        departmentname = Console.ReadLine();
                    }
                    else
                    {
                        checkdepartment = false;
                    }
                    result = 0;
                }

                humanResourceManager.RemoveEmployee(empno,departmentname);
            }
        }
    }
}
    

    
