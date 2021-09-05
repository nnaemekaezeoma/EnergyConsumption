using EnergyConsumption.Context;
using System.Collections.Generic;

namespace EnergyConsumption.Models
{
    public interface IDataContext
    {
        bool AccountExist(int AccountId);
        List<Account> Accounts(int id);
        bool RecordExist(MeterReading record);
        void SaveReading(List<MeterReading> records);
    }
}
