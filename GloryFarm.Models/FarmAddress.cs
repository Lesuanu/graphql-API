using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GloryFarm.Models
{
    public class FarmAddress
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string City { get; set; } = string.Empty;
        [Required]
        public string State { get; set; } = string.Empty;
        [Required]
        public string Country { get; set; } = string.Empty;
        [Required]
        public int PhoneNumber { get; set; }
        [Required]
        public string Email { get; set; } = string.Empty;

        [Required]
        public int FarmInfoId { get; set; }
        public Farm FarmInfo { get; set; } = new Farm();
    }
}
