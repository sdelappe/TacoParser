﻿using System;
using System.Linq;
using System.IO;
using GeoCoordinatePortable;

namespace LoggingKata
{
    class Program
    {
        static readonly ILog logger = new TacoLogger();
        const string csvPath = "TacoBell-US-AL.csv";

        static void Main(string[] args)
        {
            //logger.LogInfo("Log initialized");     === IGNORE THIS ===
            // Log and error if you get 0 lines and a warning if you get 1 line     === IGNORE THIS ===
            //logger.LogInfo($"Lines: {lines[0]}");  === IGNORE THIS ===
            // DON'T FORGET TO LOG YOUR STEPS        === IGNORE THIS ===



            // TODO:  Find the two Taco Bells that are the furthest from one another.
            // HINT:  You'll need two nested forloops ---------------------------
            
            // use File.ReadAllLines(path) to grab all the lines from your csv file, RETURNS A STRING ARRAY CONTAINING ALL LINES OF THE FILE
            var lines = File.ReadAllLines(csvPath);

            // Create a new instance of your TacoParser class
            var parser = new TacoParser();

            // Grab an IEnumerable of locations using the Select command: var locations = lines.Select(parser.Parse);
            var locations = lines.Select(parser.Parse).ToArray();



            // Now that your Parse method is completed, START BELOW ----------

            // TODO: Create two `ITrackable` variables with initial values of `null`. These will be used to store your two taco bells that are the farthest from each other.
            // Create a `double` variable to store the distance

            ITrackable tacoBellA = null;
            ITrackable tacoBellB = null;

            double distance = 0;

            

            // Include the Geolocation toolbox, so you can compare locations: `using GeoCoordinatePortable;`

            //HINT NESTED LOOPS SECTION---------------------
            // Do a loop for your locations to grab each location as the origin (perhaps: `locA`)

            for (int i = 0; i < locations.Length; i++)
            {
                var locA = locations[i].Name; //Ashworth
                var CorA = locations[i].Location;

                for (int j = 0; j < locations.Length; j++)
                {
                    var locB = locations[j].Name;
                    var CorB = locations[j].Location;

                    var spot1 = new GeoCoordinate(CorA.Latitude, CorA.Longitude);
                    var spot2 = new GeoCoordinate(CorB.Latitude, CorB.Longitude);

                    double distanceBetween = spot1.GetDistanceTo(spot2);

                    if (distanceBetween > distance)
                    {
                        tacoBellA = locations[i];
                        tacoBellB = locations[j];
                        distance = distanceBetween;
                    }

                }
            }

            Console.WriteLine(distance);
            Console.WriteLine(tacoBellA.Name);
            Console.WriteLine(tacoBellB.Name);




            // Create a new corA Coordinate with your locA's lat and long

            // Now, do another loop on the locations with the scope of your first loop, so you can grab the "destination" location (perhaps: `locB`)

            // Create a new Coordinate with your locB's lat and long

            // Now, compare the two using `.GetDistanceTo()`, which returns a double
            // If the distance is greater than the currently saved distance, update the distance and the two `ITrackable` variables you set above

            // Once you've looped through everything, you've found the two Taco Bells farthest away from each other.



        }
    }
}
