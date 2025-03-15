using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessModels.Entities
{
    public class Certificate
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Tên chứng chỉ là bắt buộc.")]
        [StringLength(100, ErrorMessage = "Tên không được dài quá 100 ký tự.")]
        public string Name { get; set; }

        [StringLength(500, ErrorMessage = "Mô tả không được dài quá 500 ký tự.")]
        public string Description { get; set; }

        [Required(ErrorMessage = "Mã nhân viên là bắt buộc.")]
        public int EmployeeId { get; set; }

        public Employee Employee { get; set; }

        [Required(ErrorMessage = "Ngày cấp là bắt buộc.")]
        [DataType(DataType.Date, ErrorMessage = "Ngày cấp không hợp lệ.")]
        public DateTime DateOfIssue { get; set; }
        public DateTime DateOfExpiry { get; set; }

        public int? ProvinceId { get; set; }

        public Province? Province { get; set; }
    }
}
