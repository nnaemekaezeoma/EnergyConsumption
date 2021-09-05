using EnergyConsumption.Context;

namespace EnergyConsumption.Models
{
    public interface IValidation
    {
        bool ValidateReading(MeterReading reading);
    }
}
