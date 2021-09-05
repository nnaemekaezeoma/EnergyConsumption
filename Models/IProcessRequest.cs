using Microsoft.AspNetCore.Http;
using System.Collections.Generic;

namespace EnergyConsumption.Models
{
    public interface IProcessRequest
    {
        Response ProcessFileUploadRequest(IFormFile file);
        Response ProcessSingleRequest(MeterReadingDto data);
        List<AccountDto> Accounts(int? id);

    }
}
