namespace Exam_Preparation_Capitalism.Core.Factories
{
    using System;
    using Interfaces;
    using Models.Employees;
    public static class EmployeeFactory
    {
        public static IEmployee Create(
            string firstName,
            string lastName,
            string position,
            IOrganizationalUnits inUnit,
            decimal salary = 0
            )
        {
            switch (position)
            {
                case "CEO":
                    return new CEO(firstName, lastName, inUnit, salary);
                case "Manager":
                    return new Manager(firstName, lastName, inUnit);
                case "Regular":
                    return new Regular(firstName, lastName, inUnit);
                case "CleaningLady":
                    return new CleaningLady(firstName, lastName, inUnit);
                case "ChiefTelephoneOfficers":
                    return new ChiefTelephoneOfficers(firstName, lastName,inUnit);
                case "Accountant": 
                    return new Accountant(firstName, lastName, inUnit);
                default:
                    throw new NotSupportedException("Invalid position supplied");
            }
        }
    }
}
