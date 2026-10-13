using TuneShop.Core.Enums;
using TuneShop.Core.Models;
using TuneShop.Core.Parts;

Vehicle car1 = new Vehicle("Coupe GT", 200, 250, 1250, VehicleType.Sport, 2018);
Build build1 = new Build(car1);

Vehicle car2 = new Vehicle("Sedan LX", 150, 200, 1500, VehicleType.Sport, 2019);
Build build2 = new Build(car2);

Engine engine = new Engine
{
    Name = "V8 Turbo",
    Horsepower = 400,
    Torque = 500,
    Cylinders = 8,
    DisplacementCc = 4000,
    MaxRpm = 7000,
    FuelType = FuelType.Petrol,
    Weight = 250,
    Price = 8000
};

Tire tire = new Tire
{
    Name = "Performance Tires",
    Diameter = 20,
    Width = 250,
    AspectRatio = 35,
    TireType = TireType.Sport,
    Weight = 20,
    Price = 500
};

Brake brake = new Brake
{
    Name = "High-Performance Brakes",
    Diameter = 350,
    PadThickness = 30,
    RotorThickness = 20,    
    BrakeType = BrakeType.Sport,
    Weight = 15,
    Price = 1000
};


build1.AddPart(engine);
build1.AddPart(tire);
build1.AddPart(brake);


Console.WriteLine(build1.GetTotalWeight());       
Console.WriteLine(build1.GetTotalPrice());        
Console.WriteLine(build1.GetTotalHorsepower());  
Console.WriteLine(build1.GetTotalTorque());       
Console.WriteLine(build2.GetAveragePartScore());  

build1.RemovePart(engine);
Console.WriteLine(build1.GetTotalHorsepower());  
Console.WriteLine(build1.Parts.Count);

Console.WriteLine(build1.GetAveragePartScore());   
Console.WriteLine(build1.GetTotalWeight());        

var newTire = new Tire {
    Name = "Race Tires",
    Diameter = 20,
    Width = 250,
    AspectRatio = 35,
    TireType = TireType.Sport,
    Weight = 25,
    Price = 600
};
build1.ReplacePart(newTire);
Console.WriteLine(build1.GetTotalWeight());        
Console.WriteLine(build1.Parts.Count);            

try { build1.RemovePart(engine); }                
catch (InvalidOperationException ex) { Console.WriteLine(ex.Message); }

try
{
    build1.AddPart(engine);              
    Console.WriteLine(build1.Parts.Count);   

    build1.AddPart(engine);              
}
catch (InvalidOperationException ex)
{
    Console.WriteLine($"Error: {ex.Message}");
}