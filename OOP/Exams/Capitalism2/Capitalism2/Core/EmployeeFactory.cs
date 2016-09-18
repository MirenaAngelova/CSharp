﻿using System;
using Capitalism2.Models.Employees;
using Capitalism2.Models.Interfaces;

namespace Capitalism2.Core.Factories
{
    public static class EmployeeFactory
    {
        public static IEmployee Create(
            string firstName, 
            string lastName, 
            string position, 
            IOrganizationalUnit inUnit,
            decimal salary = 0)
        {
            switch (position)
            {
                case "CEO":
                    return new CEO(firstName, lastName, inUnit, salary);
                case "Manager":
                    return new Manager(firstName, lastName, inUnit);
                case "Regular":
                    return new Regular(firstName, lastName, inUnit);
                case "Salesman":
                    return new Salesman(firstName, lastName, inUnit);
                case "CleaningLady":
                    return new CleaningLady(firstName, lastName, inUnit);
                case "ChiefTelephoneOfficer":
                    return new ChiefTelephoneOfficer(firstName, lastName, inUnit);
                case "Accountant":
                    return new Accountant(firstName, lastName, inUnit);
                default:
                    throw new NotSupportedException("Invalid position supplied");
            }
        }
    }
}
