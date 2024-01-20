using System.ComponentModel.DataAnnotations;

namespace Ass.Models
{
    public class Department
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Tên bộ phận là bắt buộc")]
        [StringLength(50, ErrorMessage = "Tên bộ phận không được vượt quá 50 ký tự")]
        public string? DepartmentName { get; set; }

        [Required(ErrorMessage = "Mã bộ phận là bắt buộc")]
        [StringLength(10, ErrorMessage = "Mã bộ phận không được vượt quá 10 ký tự")]
        public string? DepartmentCode { get; set; }

        public string? Location { get; set; }

        [Range(0, int.MaxValue, ErrorMessage = "Số lượng nhân viên không hợp lệ")]
        public int NumberOfPersonnel { get; set; }

        public List<Employee> Employees { get; set; }
    }
}
