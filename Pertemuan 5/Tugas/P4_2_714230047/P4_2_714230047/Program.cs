using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P4_2_714230047
{
    abstract class Employee
    {
        private string _name;     
        private int _age;         

        public Employee(string name, int age)
        {
            _name = name;
            _age = age;
        }

        public string Name
        {
            get { return _name; }
        }

        public int Age
        {
            get { return _age; }
        }

        public abstract string GetJobDescription();
    }

    class Manager : Employee
    {
        public Manager(string name, int age) : base(name, age) { }

        public override string GetJobDescription()
        {
            return $"{Name} is a manager who oversees the team and manages projects.";
        }
    }

    class Engineer : Employee
    {
        public Engineer(string name, int age) : base(name, age) { }

        public override string GetJobDescription()
        {
            return $"{Name} is an engineer who develops and maintains the company's systems.";
        }
    }

    class AdminStaff : Employee
    {
        public AdminStaff(string name, int age) : base(name, age) { }

        public override string GetJobDescription()
        {
            return $"{Name} is an administrative staff member who handles office management tasks.";
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            Employee manager = new Manager("Alice", 35);
            Employee engineer = new Engineer("Bob", 28);
            Employee adminStaff = new AdminStaff("Eve", 30);

            Employee[] employees = { manager, engineer, adminStaff };
            foreach (Employee employee in employees)
            {
                Console.WriteLine($"{employee.Name} (Age: {employee.Age}) - {employee.GetJobDescription()}");
            }
        }
    }
}