using BlazorDemo.Models;

namespace BlazorDemo.Pages
{
    public partial class Airplanes
    {
        protected override async Task OnInitializedAsync()
        {
            await base.OnInitializedAsync();

            await Task.Delay(3000);

            if (airplaneService.Loaded)
                return;

            airplaneService.AirplaneList.Add(new AirplaneViewModel
            {
                Name = "F-15",
                Country = "USA",
                Description = "The McDonnell Douglas F-15 Eagle is an American twin-engine, all-weather fighter aircraft designed by McDonnell Douglas (now part of Boeing).",
                Price = 75000000,
                ImageName = "/Images/Airplanes/f15.png"
            });

            airplaneService.AirplaneList.Add(new AirplaneViewModel
            {
                Name = "F-16",
                Country = "USA",
                Description = "The General Dynamics F-16 Fighting Falcon is an American single-engine supersonic multirole fighter aircraft originally developed by General Dynamics for the United States Air Force (USAF).",
                Price = 55000000,
                ImageName = "/Images/Airplanes/f16.png"
            });

            airplaneService.AirplaneList.Add(new AirplaneViewModel
            {
                Name = "F-35",
                Country = "USA",
                Description = "The Lockheed Martin F-35 Lightning II is an American single-seat, single-engine, supersonic stealth strike fighter.",
                Price = 110000000,
                ImageName = "/Images/Airplanes/f35.png"
            });

            airplaneService.AirplaneList.Add(new AirplaneViewModel
            {
                Name = "Rafale",
                Country = "France",
                Description = "The Dassault Rafale is a French twin-engine, canard delta wing, multirole fighter aircraft designed and built by Dassault Aviation.",
                Price = 90000000,
                ImageName = "/Images/Airplanes/rafale.png"
            });

            airplaneService.AirplaneList.Add(new AirplaneViewModel
            {
                Name = "Gripen",
                Country = "USA",
                Description = "The Saab JAS 39 Gripen is a light single-engine supersonic multirole fighter aircraft manufactured by the Swedish aerospace and defence company Saab AB.",
                Price = 70000000,
                ImageName = "/Images/Airplanes/gripen.png"
            });

            airplaneService.AirplaneList.Add(new AirplaneViewModel
            {
                Name = "Tornado",
                Country = "UK, GER, IT",
                Description = "The Panavia Tornado is a family of twin-engine, variable-sweep wing multi-role combat aircraft, jointly developed and manufactured by Italy, the United Kingdom and Germany.",
                Price = 55000000,
                ImageName = "/Images/Airplanes/tornado.png"
            });

            airplaneService.Loaded = true;            
        }
    }
}
