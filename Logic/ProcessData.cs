using EnergyConsumption.Context;
using EnergyConsumption.Models;
using System;
using System.Collections.Generic;

namespace EnergyConsumption.Logic
{
    public class ProcessData : IProcessData
    {
        public int ValidRecords { get; set; }
        public int InvalidRecords { get; set; }
        private IDataContext dataContext;
        private IValidation validation;

        public ProcessData(IDataContext _dataContext, IValidation _validation)
        {
            dataContext = _dataContext;
            validation = _validation;
        }

        public Response ProcessRecords(List<MeterReadingDto> data)
        {
            List<MeterReading> records = new List<MeterReading>();
            foreach (MeterReadingDto record in data)
            {
                MeterReading readingRecord = new MeterReading();
                readingRecord.AccountId = record.AccountId;
                readingRecord.MeterReadingDateTime = DateTime.Parse(record.MeterReadingDateTime);
                readingRecord.MeterReadingValue = record.MeterReadingValue;
                readingRecord.DateUploaded = DateTime.Now;

                //validate Reading
                bool Valid = validation.ValidateReading(readingRecord);

                if (Valid)
                {
                    //add new valid records to list 
                    records.Add(readingRecord);
                    //increment valid record count
                    ValidRecords += 1;
                }
                else
                {
                    //increment invalid record count
                    InvalidRecords += 1;
                }
            }
            if (records.Count > 0)
            {
                dataContext.SaveReading(records);
                return new Response { StatusMessage = "Processed", Successful = ValidRecords, Failed = InvalidRecords };
            }

            return new Response { StatusMessage = "Record(s) already exist or accountId(s) doesn't exist or readings are invalid", Successful = ValidRecords, Failed = InvalidRecords };
        }

        public List<AccountDto> GetAccounts(int id)
        {
            List<AccountDto> AccountResponse = new List<AccountDto>();

            var data = dataContext.Accounts(id);
            foreach(Account rec in data)
            {
                AccountResponse.Add(new AccountDto { AccountId = rec.AccountId, AccountName = $" { rec.FirstName } {rec.LastName}" });
            }
            return AccountResponse;
        }
    }
}
