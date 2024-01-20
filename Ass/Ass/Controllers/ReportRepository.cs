// ReportController.cs
using Microsoft.AspNetCore.Mvc;

public class ReportController : Controller
{
    private readonly IReportRepository _reportRepository;

    public ReportController(IReportRepository reportRepository)
    {
        _reportRepository = reportRepository;
    }

    public IActionResult Index()
    {
        var departments = _reportRepository.GetAllDepartments();
        return View(departments);
    }

    public IActionResult EmployeeReport(int departmentId)
    {
        var employees = _reportRepository.GetEmployeesByDepartment(departmentId);
        return View(employees);
    }
    
}
