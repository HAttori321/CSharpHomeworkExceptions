using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleApp1
{
    class Worker
    {
        private string Name;
        private int Age;
        private double Salary;
        private DateTime HireDate;

        public string name
        {
            get { return Name; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new Exception("Name cannot be empty or whitespace.");
                }
                Name = value;
            }
        }

        public int age
        {
            get { return Age; }
            set
            {
                if (value < 18 || value > 65)
                {
                    throw new Exception("Age must be between 18 and 65.");
                }
                Age = value;
            }
        }

        public double salary
        {
            get { return Salary; }
            set
            {
                if (value < 0)
                {
                    throw new Exception("Salary cannot be negative.");
                }
                Salary = value;
            }
        }

        public DateTime hiredate
        {
            get { return HireDate; }
            set
            {
                if (value > DateTime.Now)
                {
                    throw new Exception("Hire date cannot be in the future.");
                }
                HireDate = value;
            }
        }

        public Worker(string name, int age, double salary, DateTime hiredate)
        {
            this.name = name;
            this.age = age;
            this.salary = salary;
            this.hiredate = hiredate;
        }

        public int GetWorkExperience()
        {
            return DateTime.Now.Year - HireDate.Year;
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            List<Worker> workers = new List<Worker>();
            Console.WriteLine("Enter information for 5 workers:");

            for (int i = 0; i < 5; i++)
            {
                try
                {
                    Console.Write("Enter name: ");
                    string name = Console.ReadLine();

                    Console.Write("Enter age: ");
                    int age = int.Parse(Console.ReadLine());

                    Console.Write("Enter salary: ");
                    double salary = double.Parse(Console.ReadLine());

                    Console.Write("Enter hire date (YYYY-MM-DD): ");
                    DateTime hiredate = DateTime.Parse(Console.ReadLine());

                    workers.Add(new Worker(name, age, salary, hiredate));
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error: {ex.Message}. Please enter the details again.");
                    i--;
                }
            }

            workers = workers.OrderBy(w => w.name).ToList();

            Console.Write("Enter minimum work experience: ");
            int minExperience = int.Parse(Console.ReadLine());

            Console.WriteLine("Workers with more than the entered work experience:");
            foreach (var worker in workers)
            {
                if (worker.GetWorkExperience() > minExperience)
                {
                    Console.WriteLine(worker.name);
                }
            }
        }
    }
}
