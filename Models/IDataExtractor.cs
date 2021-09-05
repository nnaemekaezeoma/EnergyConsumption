using EnergyConsumption.Context;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;

namespace EnergyConsumption.Models
{
    public interface IDataExtractor
    {
        List<MeterReadingDto> ReadFileData(IFormFile formFile);
    }
}
