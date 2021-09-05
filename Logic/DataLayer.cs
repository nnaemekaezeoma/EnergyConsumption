using EnergyConsumption.Context;
using EnergyConsumption.Models;
using System.Collections.Generic;
using System.Linq;

namespace EnergyConsumption.Logic
{

    public class DataLayer : IDataContext
    {
        public MeterReadingDbContext context;


        public DataLayer(MeterReadingDbContext _context)
        {
            this.context = _context;
        }

        //check if account exist
        public bool AccountExist(int AccountId)
        {
            return context.Accounts.Where(a => a.AccountId == AccountId).Any();
        }

        //return all accounts
        public List<Account> Accounts(int id)
        {
            if (id == 0)
            {
                return context.Accounts.ToList();
            }
            return context.Accounts.Where(a => a.AccountId == id).ToList();
        }

        //check if record item already exist
        public bool RecordExist(MeterReading record)
        {
            return context.MeterReadings.Where(a => (a.AccountId == record.AccountId
                                             && a.MeterReadingDateTime == record.MeterReadingDateTime
                                             && a.MeterReadingValue == record.MeterReadingValue)).Any();
        }

        //save new meter readings record
        public void SaveReading(List<MeterReading> records)
        {
            context.MeterReadings.AddRange(records);
            context.SaveChanges();
        }

    }
}
