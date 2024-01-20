
using Ass.Models;

public interface IReportRepository
{
    IEnumerable<Department> GetAllDepartments();
    IEnumerable<Employee> GetEmployeesByDepartment(int departmentId);
   
}
