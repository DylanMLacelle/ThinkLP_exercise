using System;
using System.Collections.Generic;

namespace ThinkLP
{
    /// <summary>
    /// This class holds data for employees 
    /// </summary>
    class Employee
    {
        public string Name { get; }
        public int ID { get; }
        public DateTime FireDate { get; }

        private static int lastId = 0;
        private static List<Employee> employees = new List<Employee>();

        public Employee(string name)
        {
            ID = GetNextID();
            Name = name;
        }

        /// <summary>
        /// Search through the list of employees and return all
        /// </summary>
        public List<Employee> GetAllEmployees()
        {
            List<Employee> listOfEmployees = new List<Employee>();
            foreach (Employee employee in employees)
            {
                if(FireDate == null)
                {
                    listOfEmployees.Add(employee);
                }
            }
            return listOfEmployees;
            //ideally would pull this from a database 
        }

        /// <summary>
        /// Return all employees whos termination date was 30 days or sooner
        /// </summary>
        /// <param name="daysAgo">Amount of days to search. Default = 30 days</param>
        public List<Employee> GetTerminatedEmployees(int daysAgo = 30)
        {
            List<Employee> listOfEmployees = new List<Employee>();
            foreach (Employee employee in employees)
            {
                if ((DateTime.Now - FireDate).TotalDays <= 30)
                {
                    listOfEmployees.Add(employee);
                }
            }
            return listOfEmployees;
        }

        /// <summary>
        /// Add an employee to the list
        /// </summary>
        /// <param name="name"></param>
        public void AddEmployee(string name)
        {
            employees.Add(new Employee(name));
        }

        /// <summary>
        /// Remove an employee from the list
        /// </summary>
        /// <param name="id">id of the employee to remove</param>
        public void RemoveEmployee(int id)
        {
            foreach (Employee employee in employees)
            {
                if(employee.ID == id)
                {
                    employees.Remove(employee);
                }
            }
        }

        private int GetNextID()
        {
            //ideally would implement this with an auto-incrementing primary key from DB
            return lastId++; 
        }

    }
}
