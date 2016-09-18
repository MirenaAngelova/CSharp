using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Exam_Preparation_Capitalism.Core.Factories;
using Exam_Preparation_Capitalism.Interfaces;
using Exam_Preparation_Capitalism.Models.Employees;
using Exam_Preparation_Capitalism.OrganizationalUnits;

namespace Exam_Preparation_Capitalism.Core.Commands
{
    public class CreateCompanyCommand:CommandAbstract
    {
        private string companyName;
        private string ceoFirstName;
        private string ceoLastName;
        private decimal ceoSalary;
        public CreateCompanyCommand(
            Database db, 
            string companyName, 
            string ceoFirstName,
            string ceoLastName,
            decimal ceoSalary
                ) 
        : base(db)
        {
            this.companyName = companyName;
            this.ceoFirstName = ceoFirstName;
            this.ceoLastName = ceoLastName;
            this.ceoSalary = ceoSalary;
        }

        public override string Execute()
        {
            foreach (IOrganizationalUnits c in this.db.Companies)
            {
                if (c.Name == this.companyName)
                {
                    throw new ArgumentException(string.Format("Company {0} already exists", c.Name));
                }
            }
            IOrganizationalUnits company = new Company(this.companyName);
            IEmployee ceo = EmployeeFactory.Create(this.ceoFirstName, this.ceoLastName, "CEO", company, this.ceoSalary);
            this.db.AddCompanies(company);
            company.AddEmployee(ceo);
            company.Head = ceo;
            return "";
        }
    }
}
