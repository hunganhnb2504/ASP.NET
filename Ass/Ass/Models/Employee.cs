using System.ComponentModel.DataAnnotations;

namespace Ass.Models
{
    public class Employee
    {
        public int EmployeeId { get; set; }

        [Required(ErrorMessage = "Tên nhân viên là bắt buộc")]
        [StringLength(50, ErrorMessage = "Tên nhân viên không được vượt quá 50 ký tự")]
        public string? EmployeeName { get; set; }

        [Required(ErrorMessage = "Mã nhân viên là bắt buộc")]
        [StringLength(10, ErrorMessage = "Mã nhân viên không được vượt quá 10 ký tự")]
        public string? EmployeeCode { get; set; }

        public string? Rank { get; set; }

        [Range(1, int.MaxValue, ErrorMessage = "Phải chọn một bộ phận")]
        public int DepartmentId { get; set; }

        public Department? Department { get; set; }
    }
}
