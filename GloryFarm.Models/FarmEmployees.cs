using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GloryFarm.Models
{
    public class FarmEmployees
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; } = string.Empty;
        public int FarmEmployeeId { get; set; } = int.MaxValue;
        public int EmployeeWages { get; set; } = int.MaxValue;
        public FarmDepartment FarmDepartment { get; set; }

        public int FarmId { get; set; }
        public Farm Farm { get; set; } = new Farm();
    }
}
