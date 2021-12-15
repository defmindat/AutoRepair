
using DomainModel.Vehicles;

namespace Application.InputModels
{
    public class EditVehicleInputModel
    {
        public long? Id { get; set; }
        public long CustomerId { get; set; }
        public string Firm { get; set; }
        public string ModelName { get; set; }
        public short Year { get; set; }
        public float EngineVolume { get; set; }
        public HandSide HandSide { get; set; }

        public bool IsValid()
        {
            return !Globals.IsAnyNullOrEmpty(Firm, ModelName) && Year != default && EngineVolume != default;
        }
    }
}