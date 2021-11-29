// See https://aka.ms/new-console-template for more information

using System;
using TO_Lab_5;
using TO_Lab_5.Core;

ControlStation controlStation = new();
controlStation.RegisterFireStations(CSVParser.LoadStationsFromCSV());


Console.WriteLine("Press ESC to stop");
do {
    while (! Console.KeyAvailable) {
        
    }       
} while (Console.ReadKey(true).Key != ConsoleKey.Escape);