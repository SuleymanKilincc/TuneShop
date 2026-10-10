using TuneShop.Core.Enums;
using TuneShop.Core.Parts;

Engine engine = new Engine
{
    Id = 1,
    Name = "V8 Turbo",
    Price = 15000m,
    Weight = 220,
    Cylinders = 8,
    DisplacementCc = 4000,
    Horsepower = 500,
    Torque = 600,
    MaxRpm = 7000,
    FuelType = FuelType.Petrol
};

Tire tire = new Tire
{
    Id = 2,
    Name = "Sport Contact",
    Price = 8000m,
    Weight = 9,
    Width = 225,
    AspectRatio = 45,
    Diameter = 17,
    Type = TireType.Sport,

};

Brake brake = new Brake
{
    Id = 3,
    Name = "Brembo GT",
    Price = 1200m,
    Weight = 15,
    Diameter = 350,
    PadThickness = 30,
    RotorThickness = 28,
    Type = BrakeType.Sport,
};


List<Part> parts = new List<Part> { engine, tire, brake };

foreach (var part in parts)
{
    Console.WriteLine(part.Describe());
    Console.WriteLine($"Performance Score: {part.CalculateScore()}");
    Console.WriteLine();
}