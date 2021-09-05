using EnergyConsumption.Context;
using System.Collections.Generic;

namespace EnergyConsumption.Models
{
    public interface IProcessData
    {
        Response ProcessRecords(List<MeterReadingDto> data);
        List<AccountDto> GetAccounts(int id);
    }
}
