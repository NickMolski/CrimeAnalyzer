using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace CrimeAnalyzer
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Crime Analyzer");
            Console.WriteLine("");
            Console.WriteLine("What is the CSV file name?: ");
            string input = Console.ReadLine();
            string filename = input + ".csv";

            int fileLength = File.ReadLines(filename).Count();
            Data[] values = new Data[fileLength - 1];

            StreamReader streamReader = new StreamReader(filename);
            string currentLine;
            bool hasSeenFirstLine = false;
            int i = 0;
            while((currentLine = streamReader.ReadLine()) != null)
            {
                if (!hasSeenFirstLine)
                {
                    hasSeenFirstLine = true;
                    continue;
                }

                int[] readValues = Array.ConvertAll(currentLine.Split(','), int.Parse);

                values[i] = new Data(readValues[0], readValues[1], readValues[2], readValues[3], readValues[4], readValues[5], readValues[6], readValues[7], readValues[8], readValues[9], readValues[10]);
                i++;
            }

            var years = from value in values select value.year;
            int firstYear = 0;
            int lastYear = 0;
            int range = 0;
            foreach (var year in years)
            {
                if (range == 0)
                {
                    firstYear = year;
                } else if (range == years.Count() - 1)
                {
                    lastYear = year;
                }
                range++;
            }

            Console.WriteLine("Period: " + firstYear + "-" + lastYear + " (" + range + " years)");

            //What years is the number of murders per year less than 15000?
            //Years murders per year < 15000: 2010, 2011, 2012, 2013

            var murderYears = from value in values where value.murder < 15000 select value.year;
            range = 0;
            Console.Write("Years murders per year < 15000: ");
            foreach (var year in murderYears)
            {
                if (range == murderYears.Count())
                {
                    Console.Write(year);
                } else
                {
                    Console.Write(year + ", ");
                }
                range++;
            }

            var robberyYears = from value in values where value.robbery > 500000 select value;
            Console.WriteLine("Robberies per year > 500000: ");
            foreach (var robberyYear in robberyYears)
            {
                Console.Write(robberyYear.year + " = " + robberyYear.robbery + ", ");
            }
            Console.WriteLine("");
            var crimePerCapita = from value in values where value.year == 2010 select value;
            Console.Write("Violent crime per capita rate (2010): ");
            foreach (var crime2010 in crimePerCapita)
            {
                double vCrime = crime2010.violentCrime;
                double pop = crime2010.population;
                Console.Write(vCrime / pop);
            }

            Console.WriteLine("");


            var averageMurders = from value in values select value;
            int totalMurders = 0;
            int mCount = 0;
            Console.Write("Average murder per year (all years): ");
            foreach (var avgMurderValue in averageMurders)
            {
                
                totalMurders = totalMurders + avgMurderValue.murder;
                mCount++;
            }
            int avgM = totalMurders / mCount;
            Console.Write(avgM);


            Console.WriteLine("");


            var avgMurder9497 = from value in values where value.year >= 1994 && value.year <= 1997 select value.murder;
            totalMurders = 0;
            mCount = 0;
            Console.Write("Average murder per year (1994-1997): ");
            foreach (var avgMur in avgMurder9497)
            {
                totalMurders = totalMurders + avgMur;
                mCount++;
            }
            avgM = totalMurders / mCount;
            Console.Write(avgM);


            Console.WriteLine("");



            var avgMurder1014 = from value in values where value.year >= 2010 && value.year <= 2014 select value.murder;
            totalMurders = 0;
            mCount = 0;
            Console.Write("Average murder per year (2010-2014): ");
            foreach (var avgMur in avgMurder1014)
            {
                totalMurders = totalMurders + avgMur;
                mCount++;
            }
            avgM = totalMurders / mCount;
            Console.Write(avgM);



            Console.WriteLine("");



            var avgTheft9904 = from value in values where value.year >= 1999 && value.year <= 2004 select value.theft;
            Console.Write("Minimum thefts per year (1999-2004): ");
            int max = 0;
            int min = 0;
            int count = 1;
            foreach (var avgTheft in avgTheft9904)
            {
                if (count == 1)
                {
                    max = avgTheft;
                }
                if (avgTheft < max)
                {
                    min = avgTheft;
                }
                count++;
            }
            Console.Write(min);

            Console.WriteLine("");


            var maxTheft = from value in values where value.year >= 1999 && value.year <= 2004 select value.theft;
            Console.Write("Maximum thefts per year (1999-2004): ");
            max = 0;
            foreach (var theftValue in maxTheft)
            {
                if (theftValue > max)
                {
                    max = theftValue;
                }
            }
            Console.Write(max);



            Console.WriteLine("");

            var highestMotorThefts = from value in values select value;
            int maxMotor = 0;
            int maxMotorYear = 0;
            Console.Write("Year of highest number of motor vehicle thefts: ");
            foreach (var highestTheft in highestMotorThefts)
            {
                if (highestTheft.motorVehicleTheft > maxMotor)
                {
                    maxMotor = highestTheft.motorVehicleTheft;
                    maxMotorYear = highestTheft.year;
                }
            }
            foreach (var theft in highestMotorThefts)
            {
                if (theft.year == maxMotorYear)
                {
                    Console.Write(theft.year);
                }
            }
            










            Console.ReadLine();
        }
    }
}
