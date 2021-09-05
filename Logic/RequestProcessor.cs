using EnergyConsumption.Context;
using EnergyConsumption.Models;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;

namespace EnergyConsumption.Logic
{
    public class RequestProcessor : IProcessRequest
    {
        private readonly IDataExtractor dataReader;
        private readonly IProcessData dataProcess;

        public RequestProcessor(IDataExtractor _dataReader, IProcessData _data)
        {
            dataReader = _dataReader;
            dataProcess = _data;
        }
        public Response ProcessFileUploadRequest(IFormFile file)
        {
            try
            {
                var data = dataReader.ReadFileData(file);
                return dataProcess.ProcessRecords(data);
            }
            catch(Exception ex)
            {
                return new Response { StatusMessage = "Error Occured While processing Request! Kindly check the uploaded file" };
            }
        }

        public Response ProcessSingleRequest(MeterReadingDto request)
        {
            try
            {
              return dataProcess.ProcessRecords(new List<MeterReadingDto> { request });
            }
            catch (Exception ex)
            {
                return new Response { StatusMessage = "Error Occured While processing Request! Kindly check the uploaded file" };
            }
        }
        
        public List<AccountDto> Accounts(int? id)
        {
            return dataProcess.GetAccounts(id??0);
        }

    }
}
