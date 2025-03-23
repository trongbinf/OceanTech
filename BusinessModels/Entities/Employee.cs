using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessModels.Entities
{
    public class Employee
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Họ và tên là bắt buộc.")]
        [StringLength(100, ErrorMessage = "Họ và tên không được dài quá 100 ký tự.")]
        public string FullName { get; set; }

        [Required(ErrorMessage = "Ngày sinh là bắt buộc.")]
        public DateOnly DateOfBirth { get; set; }

        [StringLength(50, ErrorMessage = "Dân tộc không được dài quá 50 ký tự.")]
        public string EthnicGroup { get; set; }

        [Required(ErrorMessage = "Nghề nghiệp là bắt buộc.")]
        [StringLength(100, ErrorMessage = "Nghề nghiệp không được dài quá 100 ký tự.")]
        public string Job { get; set; }

        [Required(ErrorMessage = "Số điện thoại là bắt buộc.")]
        [Phone(ErrorMessage = "Số điện thoại không hợp lệ.")]
        [StringLength(15, ErrorMessage = "Số điện thoại không được dài quá 15 ký tự.")]
        public string PhoneNumber { get; set; }

        [Required(ErrorMessage = "Số CMND/CCCD là bắt buộc.")]
        [RegularExpression(@"^\d{9,12}$", ErrorMessage = "Số CMND/CCCD phải có 9 hoặc 12 chữ số.")]
        public string IdentityCard { get; set; }

        [Required(ErrorMessage = "Mã xã/phường là bắt buộc.")]
        public int WardId { get; set; }

        public Ward Ward { get; set; }
        public string Address { get; set; }
        public List<Certificate> Certificates { get; set; } = new List<Certificate>();
    }
}
