using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessModels.Entities
{
    public class District
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Tên quận/huyện là bắt buộc.")]
        [StringLength(100, ErrorMessage = "Tên quận/huyện không được dài quá 100 ký tự.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Mã tỉnh là bắt buộc.")]
        public int ProvinceId { get; set; }

        public Province Province { get; set; }

        public List<Ward> Wards { get; set; }
    }
}
