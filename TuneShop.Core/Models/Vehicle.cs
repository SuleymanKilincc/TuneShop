using TuneShop.Core.Enums;

namespace TuneShop.Core.Models
{
    public class Vehicle
    {
        public int Id { get; set; }
        public string Model { get; set; }
        public int Horsepower { get; set; }
        public int Torque { get; set; }
        public VehicleType Type { get; set; }
        public int Year { get; set; }

        private double _weight;
        public double Weight
        {
            get => _weight;
            set
            {
                if (value <= 0)
                    throw new ArgumentException("Weight must be positive.", nameof(value));
                _weight = value;
            }
        }

        public Vehicle(string model, int horsepower, int torque, double weight, VehicleType type, int year)
        {
            Model = model;
            Horsepower = horsepower;
            Torque = torque;
            Weight = weight;
            Type = type;
            Year = year;
        }

        public string Describe()
        {
            return $"{Model} ({Year}): {Horsepower} hp, {Torque} Nm, {Weight} kg, {Type}";
        }

        public int CalculateScore()
        {
            int typeBase = Type switch
            {
                VehicleType.Street => 10,
                VehicleType.Sport => 40,
                VehicleType.Race => 70,
                _ => 0
            };

            double powerToWeight = (Horsepower + Torque) / Weight;
            int ratioScore = (int)Math.Min(powerToWeight * 40, 30);

            return typeBase + ratioScore;
        }
    }
}