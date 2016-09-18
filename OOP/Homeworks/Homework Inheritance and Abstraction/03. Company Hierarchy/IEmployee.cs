
namespace _03.Company_Hierarchy
{
    interface IEmployee : IPerson
    {
        decimal Salary { get;  }
        Department Department { get; }
    }
}
