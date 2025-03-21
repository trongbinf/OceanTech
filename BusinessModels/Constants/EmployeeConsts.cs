using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessModels.Constants
{
    public static class EmployeeConsts
    {
        
        public static readonly List<string> EthnicGroups = new List<string>
        {
            "Kinh", "Tày", "Thái", "Mường", "Khơ-me", "H'Mông", "Nùng", "Hoa", "Dao", "Gia-rai"
        };

        public static readonly List<string> Jobs = new List<string>
        {
            "Nhân viên văn phòng", "Giáo viên", "Công nhân", "Kĩ sư", "Bác sĩ", "Nông dân", "Lái xe"
        };
        
    }
}
