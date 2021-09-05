using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EnergyConsumption.Models
{
    public class MeterReadingDto
    {
        [Required]
        public int AccountId { get; set; }
        [Required]
        public string MeterReadingDateTime { get; set; }
        [Required]
        public string MeterReadingValue { get; set; }
    }
}
