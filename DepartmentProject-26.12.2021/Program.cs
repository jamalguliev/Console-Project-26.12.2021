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
                Console.WriteLine("-------------------------Departament---------------------------");
                Console.WriteLine("Yerine Yetirmek Isdediyniz Emeliyyatin Qarsisindaki Nomreni Daxil Edin:");
                Console.WriteLine("1 - Departament Uzrinde Emeliyyatlar:");
                Console.WriteLine("2 - Isciler Uzerinde Emeliyyatlar:");
                Console.Write("Daxil Edin:");
                string choose = Console.ReadLine();
                int chooseNum;
                int.TryParse(choose, out chooseNum);
                switch (chooseNum)
                {
                    case 1:
                        Console.Clear();
                        EmployeeOperation(ref humanResourceManager);
                        break;
                    case 2:
                        Console.Clear();
                        AddDepartment(ref humanResourceManager);
                        break;
                    case 3:
                        Console.Clear();

                        break;
                }

            } while (true);
            static void EmployeeOperation(ref HumanResourceManager humanResourceManager)
            {
                do
                {
                    Console.WriteLine("-------------------------Departament Emeliyyatlari---------------------------");
                    Console.WriteLine("Yerine Yetirmek Isdediyniz Emeliyyatin Qarsisindaki Nomreni Daxil Edin:");
                    Console.WriteLine("1 - Departamentlerin siyahisi:");
                    Console.WriteLine("2 - Yeni Departament Yaratmaq:");
                    Console.WriteLine("3 - Departamentde Deyisiklik Etmek:");
                    Console.Write("Daxil Et:");
                    string choose = Console.ReadLine();
                    int chooseNum;
                    int.TryParse(choose, out chooseNum);
                    switch (chooseNum)
                    {
                        case 1:
                            Console.Clear();
                            DepartmentShowAllList(ref humanResourceManager);
                            break;
                        case 2:
                            Console.Clear();

                            break;
                        case 3:
                            Console.Clear();
                            break;
                        default:
                            Console.Clear();
                            Console.WriteLine("Duzgun Daxil Edin!");
                            break;
                    }

                } while (true);
            }
            static void DepartmentShowAllList(ref HumanResourceManager humanResourceManager)
            {
                if (humanResourceManager.employees.Length <= 0)
                {
                    Console.WriteLine("Departament Yoxdur!");
                    return;
                }

                foreach (Department item in humanResourceManager.departments)
                {
                    Console.WriteLine(item);
                    Console.WriteLine("------------------------------------");
                }
            }
            static void AddDepartment(ref HumanResourceManager humanResourceManager)
            {
                Console.Write("Departamentin Adini Daxil Edin: ");
                string name = Console.ReadLine();
                bool checkName = true;
                int count = 0;
                while (checkName)
                {
                    foreach (Department item in humanResourceManager.departments)
                    {
                        if (item.Name.ToLower() == name.ToLower())
                        {
                            count++;
                        }
                    }

                    if (count > 0)
                    {
                        Console.WriteLine("Daxil Etdiyniz Adda Departament Artiq Movcuddur");
                        Console.Write("Duzgun Ad Daxil Et: ");
                        name = Console.ReadLine();
                    }
                    else
                    {
                        checkName = false;
                    }

                    count = 0;
                    
                }
            }
        }
    }
}