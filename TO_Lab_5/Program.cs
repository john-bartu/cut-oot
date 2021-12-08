// See https://aka.ms/new-console-template for more information

using System;
using System.Threading;
using TO_Lab_5;
using TO_Lab_5.Core;

ControlStation controlStation = new();
controlStation.RegisterFireStations(CSVParser.LoadStationsFromCSV());
controlStation.RegisterIncident(new Incident());
Console.WriteLine("Press ESC to stop");
do
{
    while (!Console.KeyAvailable)
    {
        
        // if (Random.Shared.NextSingle() < 0.04f)
        // {
        //     controlStation.RegisterIncident(new Incident());
        // }

        Thread.Sleep(100);
    }
} while (Console.ReadKey(true).Key != ConsoleKey.Escape);