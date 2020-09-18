using System;
using System.Collections.Generic;
using System.Linq;
//temat1/zadanie6
namespace Fiances.Employees
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Employee employee = new Employee();
            
            //Person person = new Person();
        }
    }

    public class Employees<Operation> 
    {
        //temat3/zadanie1
        public List<Employee> ListOfEmployees = new List<Employee>();
        private string[] _EmployeeArray;
        private Operation[] _GenericArray;
        //temat3/zadanie1
        public void SizeOfGenericArray(int size)
        {
            _EmployeeArray = new string[size + 1];
            _GenericArray = new Operation[size + 1];
        }

        //teamt4/zadanie1
        public string GetIndex(int index)
        {
            return _EmployeeArray[index];
        }

        //temat4/zadanie1
        public string GetGenericArray(int index)
        {
            return _EmployeeArray[index];
        }

        public void SetValue(int index, string value)
        {
            _EmployeeArray[index] = value;
        }

        public void SetGenericValue(int index, Operation value)
        {
            _GenericArray[index] = value;
        }

        //temat5/zadanie1
        public class EmployeeFactory
        {
            public static Employee CreateEmployee()
            {
                return new Employee();
            }

            public static Employee CreateEmployee(int id, string firstname, string lastname, int age)
            {
                return new Employee(id, firstname, lastname, age);
            }
        }

        //temat5/zadanie2
        public void AddEmployee()
        {
            ListOfEmployees.Add(EmployeeFactory.CreateEmployee());
        }

        //temat5/zadanie3
        public void AddEmployeeDemo()
        {
            var id = ListOfEmployees.Count + 1;
            Console.Write("Enter first name: ");
            var firstName = Console.ReadLine();
            Console.Write("Enter last name: ");
            var lastName = Console.ReadLine();
            Console.Write("Enter age: ");
            var age = Convert.ToInt32(Console.ReadLine());

            foreach (var employee in ListOfEmployees)
            {
                if (employee.FirstName == firstName && employee.LastName == lastName)
                    Console.WriteLine("User already exist. ");
                return;
            }

            ListOfEmployees.Add(EmployeeFactory.CreateEmployee(id, firstName, lastName, age));
        }

        //temat5/zadanie3
        public void RemoveEmployee()
        {
            ShowEmployees();
            Console.Write("Enter ID to delete employee: ");
            var id = Convert.ToInt32(Console.ReadLine());
            ListOfEmployees.Remove(ListOfEmployees.Where(employee => employee.EmployeeId == id).First());
        }

        //temat5/zadanie3
        public void ShowEmployees()
        {
            Console.WriteLine("List of employees: ");
            foreach (var employee in ListOfEmployees)
            {
                Console.WriteLine($"ID: {employee.EmployeeId} Name: {employee.FirstName} Last name: {employee.LastName}");
            }
        }

        //temat5/zadanie3
        public Employee GetEmployee()
        {
            ShowEmployees();
            Console.Write("Enter employee id: ");
            var id = Convert.ToInt32(Console.ReadLine());
            return ListOfEmployees.First(x => x.EmployeeId == id);
        }

        //temat8/zadanie1,2
        public void ChangeEmployeeName(string firstName, string lastName)
        {
            FirstName = firstName;
            LastName = lastName;
            _changeSomething("Name has been changed.");
        }

        //temat8/zadanie1,2
        public delegate void ChangeSomething(string message);

        //temat8/zadanie1,2
        public ChangeSomething _changeSomething;

        //temat8/zadanie1,2
        public void AddCallback(ChangeSomething msg)
        {
            _changeSomething += msg;
        }

        //temat9/zadanie1
        public delegate void SalaryHasChanged();

        public event SalaryHasChanged ChangeSalary;
        public int Salary { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        protected virtual void OnSalaryChange()
        {
            if (ChangeSalary != null)
                ChangeSalary();
            else
                Console.WriteLine($"New Salary: {Salary}");
        }

        public void SalaryChange(int newSalary)
        {
            Console.WriteLine($"Old Salary: {Salary}");
            Salary = newSalary;
            OnSalaryChange();
        }
    }

    //temat1/zadanie1, //temat6/zadanie1
    public abstract class Person
    {
        public int Id;
        public string FirstName;
        public string LastName;
        public int Age;

        //temat1/zadanie5
        public void SetPerson(string firstName, string lastName, int age)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Age = age;
        }

        //temat1/zadanie5
        public void PrintPersonInformations()
        {
            Console.WriteLine($"Id: {Id}\nFirst name: {FirstName}\nLast name: {LastName}\nAge: {Age}");
        }

        //temat6/zadanie2
        public void Interests(string interests)
        {
            string Interests = interests; 
        }


        //temat1/zadanie9
        public Person()
        {

        }
    }

            //temat1/zadanie5
        public class Wage
        {
            public int BasicWage { get; set; }
            public int BonusWage { get; set; }
            public int OtherWage { get; set; }
        }

    //temat1/zadanie1
    public class Operation
    {
        public int IdPayroll { get; set; }
        public DateTime DatePayroll { get; set; }
        public string NameOfPayroll { get; set; }
        public List<string> listOfOperations = new List<string>();


        //temat1/zadanie9
        public Operation(int idPayroll, DateTime datePayroll, string nameOfPayroll)
        {
            this.IdPayroll = idPayroll;
            this.DatePayroll = datePayroll;
            this.NameOfPayroll = nameOfPayroll;
        }

        public Operation()
        {
        }
    }

    //temat1/zadanie2
    public class Employee : Operation
    {
        static decimal HolidayBonus = 1000;//temat1/zadanie2


        //Person person = new Person();  //temat1/zadanie5   
        //nie można tworzyć obiektu dla klasy abstrakcyjnej

        public Contract ContractType { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int EmployeeId { get; set; }
        Salary salary = new Salary(); //temat1/zadanie3
        private Wage _wage;


        public Employee(int id, string firstname, string lastname, int age)
        {
        }

        public Employee()
        {
        }

        public enum Contract //temat1/zadanie4
        {
            FullTime,
            PartTime,
            Contract,
        }

        public struct Salary //temat1/zadanie3
        {
            public decimal Basic;
            public decimal Bonus;
            public decimal Other;
        }

        //temat1/zadanie5
        public void ChangeEmployeeData(decimal holidayBonus, int id, string firstName, string lastName, int age, decimal basic, decimal bonus, decimal other)
        {
            HolidayBonus = holidayBonus;
            salary.Basic = basic;
            salary.Bonus = bonus;
            salary.Other = other;
        }

        //temat1/zadanie5
        public void PrintEmployeeData()
        {
            Console.WriteLine("Employee holiday bonus: ", HolidayBonus);
            Console.WriteLine("Employee salary basic: ", salary.Basic);
            Console.WriteLine("Employee salary bonus: ", salary.Bonus);
            Console.WriteLine("Employee salary other: ", salary.Other);
        }

        //temat1/zadanie5
        public Wage GetWage()
        {
            //temat2/zadanie1
            Console.Write("Enter username: ");
            var givenLogin = Console.ReadLine();
            Console.Write("Enter passsword: ");
            var givenPass = Console.ReadLine();
            if (givenLogin == "u3ername" && givenPass == "passw0rd")
            {
                return _wage;
            }
            Console.WriteLine("Wrong credentials");
            return new Wage();
        }

        //temat1/zadanie5
        public void SetWage(int basicWage, int bonusWage, int otherWage)
        {
            //temat2/zadanie1
            Console.Write("Enter username: ");
            var givenLogin = Console.ReadLine();
            Console.Write("Enter passsword: ");
            var givenPass = Console.ReadLine();
            if (givenLogin == "u3ername" && givenPass == "passw0rd")
            {
                _wage.BasicWage = basicWage;
                _wage.BonusWage = bonusWage;
                _wage.OtherWage = otherWage; 
            }
            else
            {
                Console.WriteLine("Wrong credentials");
            }
        }
    }

    //temat1/zadanie10
    public class Client
    {
        public int cId;
        public string cFirstName;
        public string cLastName;
        public int cAge;

        //temat1/zadanie10
        public void SetClient(string cfirstName, string clastName, int cage)
        {
            this.cFirstName = cfirstName;
            this.cLastName = clastName;
            this.cAge = cage;
        }

        //temat1/zadanie10
        public void PrintClientInformations()
        {
            Console.WriteLine("Client id: ", cId);
            Console.WriteLine("Client first name: ", cFirstName);
            Console.WriteLine("Client last name: ", cLastName);
            Console.WriteLine("Client age: ", cAge);
        }
    }
    
    //temat1/zadanie10
    public class Manager
    {
        public int mId;
        public string mFirstName;
        public string mLastName;
        public int mAge;

        //temat1/zadanie10
        public void SetManager(string mfirstName, string mlastName, int mage)
        {
            this.mFirstName = mfirstName;
            this.mLastName = mlastName;
            this.mAge = mage;
        }

        //temat1/zadanie10
        public void PrintManagerInformations()
        {
            Console.WriteLine("Manager id: ", mId);
            Console.WriteLine("Manager first name: ", mFirstName);
            Console.WriteLine("Manager last name: ", mLastName);
            Console.WriteLine("Manager age: ", mAge);
        }
    }
}
