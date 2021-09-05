using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EnergyConsumption.Context
{
    public class MeterReading
    {
        public int Id { get; set; }
        public int AccountId { get; set; }
        public DateTime MeterReadingDateTime { get; set; }
        public string MeterReadingValue { get; set; }
        public DateTime DateUploaded { get; set; }
    }
}
