using System;
using System.Collections.Generic;
//temat1/zadanie6
namespace Fiances
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Program działa!");
        }
    }
    //temat1/zadanie1
    public class Person
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
        public void PrintPersonInfo()
        {
            Console.WriteLine("Person id: ", Id);
            Console.WriteLine("Person first name: ", FirstName);
            Console.WriteLine("Person last name: ", LastName);
            Console.WriteLine("Person age: ", Age);
        }
    }

    //temat1/zadanie1
    public class Operation
    {
        public int IdPayroll { get; set; }
        public DateTime DatePayroll { get; set; }
        public string NameOfPayroll { get; set; }

        public List<string> listOfOperations = new List<string>();

        public enum LinkedOperation //temat1/zadanie 5
        {
            Main,
            Correction,
        }
    }

    public class Wage
    {
        public int BasicWage { get; set; }
        public int BonusWage { get; set; }
        public int OtherWage { get; set; }
    }

    //temat1/zadanie2
    public class Employee : Operation
    {
        static decimal HolidayBonus = 1000;//temat1/zadanie2
        public decimal Wage { get; set; }
        Person person = new Person();//temat1/zadanie5
        public Contract ContractType { get; set; }
        Salary salary = new Salary(); //temat1/zadanie3
        public enum Contract
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
            person.Id = id;
            person.FirstName = firstName;
            person.LastName = lastName;
            person.Age = age;
            HolidayBonus = holidayBonus;
            salary.Basic = basic;
            salary.Bonus = bonus;
            salary.Other = other;
        }

        //temat1/zadanie5
        public void PrintEmployeeData()
        {
            Console.WriteLine("Employee id: ", person.Id);
            Console.WriteLine("Employee first name: ", person.FirstName);
            Console.WriteLine("Employee last name: ", person.LastName);
            Console.WriteLine("Employee age: ", person.Age);
            Console.WriteLine("Employee holiday bonus: ", HolidayBonus);
            Console.WriteLine("Employee salary basic: ", salary.Basic);
            Console.WriteLine("Employee salary bonus: ", salary.Bonus);
            Console.WriteLine("Employee salary other: ", salary.Other);
        }
    }
}
