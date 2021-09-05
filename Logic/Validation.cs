using EnergyConsumption.Context;
using EnergyConsumption.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace EnergyConsumption.Logic
{
    public class Validation : IValidation
    {
        private IDataContext dataContext;

        public Validation(IDataContext _dataContext)
        {
           dataContext =  _dataContext;
        }

        public bool ValidateReading(MeterReading reading)
        {
            //Validating reading if in format NNNNN, five digits
            Regex pattern = new Regex(@"^[0-9]{5}\b");
            Match validReading = pattern.Match(reading.MeterReadingValue);

            //check if reading is associated with a valid accountId
            bool validAccount = dataContext.AccountExist(reading.AccountId);

            //check if data earlier uploaded
            bool recordExist = dataContext.RecordExist(reading);

            return (validReading.Success && validAccount && !recordExist);
        }
    }
}
