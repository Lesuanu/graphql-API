using HotChocolate;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GloryFarm.Models
{
    // [GraphQLDescription("repreents farmers general info")]
    public class Farm
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string FarmName { get; set; } = string.Empty;
        [Required]
        public int FarmIdNumber { get; set; }
        public string FarmAddress { get; set; } = string.Empty;

        // [GraphQLDescription("Describe your farm and its requirements")]  
        // keep your description away from your internal models
        public string Description { get; set; } = string.Empty;
        public string FarmStandard { get; set; } = string.Empty;
        public int FarmCapacity { get; set; }
        public string FarmHistory { get; set; } = string.Empty;
        public int FarmProduction { get; set; }

        public ICollection<FarmAddress>? FarmAddresses { get; set; }

        public ICollection<FarmEmployees>? FarmEmployees { get; set; }
    }
 

}

