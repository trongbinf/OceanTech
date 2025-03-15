using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessModels.Entities
{
    public class Ward
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "Tên xã/phường là bắt buộc.")]
        [StringLength(100, ErrorMessage = "Tên xã/phường không được dài quá 100 ký tự.")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Mã quận/huyện là bắt buộc.")]
        public int DistrictId { get; set; }
        public District District { get; set; }
        public List<Employee> Employees { get; set; }
    }
    
}
