using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessModels.Entities
{
    public class Province
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "Tên tỉnh/TP là bắt buộc.")]
        [StringLength(100, ErrorMessage = "Tên tỉnh/TP không được dài quá 100 ký tự.")]
        public string Name { get; set; }
        public List<District> Districts { get; set; }
    }
}
