using CreditSuisse.Core.Enums;
using CreditSuisse.Core.Interfaces;
using CreditSuisse.Entities;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;

namespace CreditSuisse
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] formats = { "MM/dd/yyyy" };
            DateTime referenceDate;
            List<Trade> allTrades = new List<Trade>();
            string category;

            Console.WriteLine("Insert Reference Date: (with /)");
            referenceDate = DateTime.ParseExact(Console.ReadLine(), formats, new CultureInfo("en-US"), DateTimeStyles.None);

            Console.WriteLine();

            allTrades = GetTrades(referenceDate);

            Console.WriteLine(referenceDate);

            Console.WriteLine();
            Console.WriteLine(allTrades.Count);

            foreach (var l in allTrades)
            {
                Console.WriteLine(l.Value + " " + l.ClientSector + " " + l.NextPaymentDate);
            }

            Console.WriteLine();

            foreach (var c in allTrades)
            {
                category = GetCategory(c, referenceDate);
                Console.WriteLine(category);
            }

            Console.WriteLine();
            Console.WriteLine("Press Any Key to Close.");
            Console.ReadKey();
        }

        private static string GetCategory(Trade trade, DateTime referenceDate)
        {
            if (trade.NextPaymentDate < referenceDate)
                return CategoryEnum.Expired.ToString();
            else if (trade.Value > 1000000 && trade.ClientSector == "Private")
                return CategoryEnum.HighRisk.ToString();
            else if (trade.Value > 1000000 && trade.ClientSector == "Public")
                return CategoryEnum.MediumRisk.ToString();
            else
                return "";
        }

        private static List<Trade> GetTrades(DateTime dateReference)
        {
            var dataTrades = @"D:\_Projects\ConsoleApp\Trades.txt";
            List<Trade> trades = new List<Trade>();
            string[] formats = { "MM/dd/yyyy" };

            try
            {
                StreamReader file = new StreamReader(dataTrades);

                string line = "";
                while (true)
                {
                    line = file.ReadLine();
                    if (line != null)
                    {
                        string[] data = line.Split(';');

                        if (DateTime.ParseExact(data[2], formats, new CultureInfo("en-US"), DateTimeStyles.None) > dateReference)
                            trades.Add(new Trade { Value = Convert.ToDouble(data[0]), ClientSector = data[1], NextPaymentDate = DateTime.ParseExact(data[2], formats, new CultureInfo("en-US"), DateTimeStyles.None) });
                    }
                    else
                        break;
                }
            }
            catch(Exception ex)
            {
                throw new Exception("Problem while trying to read Trades file. Please contact support: " + ex.Message);
            }

            return trades;
        }
    }
}