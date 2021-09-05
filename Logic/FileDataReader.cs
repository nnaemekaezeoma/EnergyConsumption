using EnergyConsumption.Context;
using EnergyConsumption.Models;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;

namespace EnergyConsumption.Logic
{
    public class FileDataReader : IDataExtractor
    {
        //reads the data from uploaded file
        public List<MeterReadingDto> ReadFileData(IFormFile formFile)
        {
            List<MeterReadingDto> readings = new List<MeterReadingDto>();
            string data = string.Empty;
            using (var reader = new StreamReader(formFile.OpenReadStream()))
            {
                while (!reader.EndOfStream)
                {
                    var lineContent = reader.ReadToEnd();
                    data = lineContent.ToString();
                }
            }

            if (!string.IsNullOrEmpty(data))
            {
                string[] fileRecords = data.Trim().Split('\n');

                for (int i = 1; i < fileRecords.Length; i++)
                {
                    var items = fileRecords[i].Split(',');
                    if (items.Length > 0)
                    {
                        readings.Add(new MeterReadingDto
                        {
                            AccountId = int.Parse(items[0]),
                            MeterReadingDateTime = items[1],
                            MeterReadingValue = items[2]
                        });
                    }
                }
            }
            return readings;
        }
    }
}
