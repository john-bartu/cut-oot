using System;
using System.Collections.Generic;
using Microsoft.VisualBasic.FileIO;
using TO_Lab_5.Core;
using TO_Lab_5.Vector;

namespace TO_Lab_5
{
    public class CSVParser
    {
        private static string _csvPath = @"./osp-coord.csv";

        public static List<FireStation> LoadStationsFromCSV()
        {
            List<FireStation> fireStations = new();

            using (TextFieldParser parser = new(_csvPath))
            {
                parser.TextFieldType = FieldType.Delimited;
                parser.SetDelimiters(",");
                while (!parser.EndOfData)
                {
                    //Process row
                    string[]? fields = parser.ReadFields();

                    Vector2 vector2 = new(
                        float.Parse(fields[1]),
                        float.Parse(fields[2])
                    );


                    FireStation newFireStation = new(
                        fields[0],
                        vector2
                    );

                    fireStations.Add(newFireStation);
                }
            }

            return fireStations;
        }
    }
}