/*
    City finder

    Challenge: User enters a country and zip/postal code - this should return the city

    Option 1: Do the challenge with fake data
    Option 2: Contact another api using for example  https://docs.microsoft.com/en-us/dotnet/api/system.net.http.httpclient?view=net-5.0 to get real data.

    Info: If you want to validate a country code you could use https://docs.microsoft.com/en-us/dotnet/api/system.globalization.regioninfo?redirectedfrom=MSDN&view=net-5.0

    public apis: https://github.com/public-apis/public-apis
*/

using Microsoft.Extensions.Configuration;
using System;
using System.Net.Http;
using System.Threading.Tasks;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Net;
using System.Net.Http.Headers;
using System.Collections.Generic;
using System.Linq;
using CityFinder.Models;
using System.Globalization;
using ConsoleTables;

namespace CityFinder
{
    internal class Program
    {
        private static readonly HttpClient client = new HttpClient();
        private static IConfigurationRoot config;

        private struct CountryCode
        {
            public String CountryName { get; set; }
            public String TwoLetterCode { get; set; }
        }

        private static async Task Main(string[] args)
        {
            InitialSetup();

            string countryInput = GetUserCountryInput();

            Console.WriteLine("Enter a zip/postal code:");
            string postalCodeInput = Console.ReadLine();
        /// <summary>
        /// This method sets up the json config file and sets the user-agent header on the HttpClient.
        /// </summary>
        private static void InitialSetup()
        {
            // Set up handling json config files
            IConfigurationBuilder builder = new ConfigurationBuilder()
                .AddJsonFile($"appsettings.json", true, true)
                .AddEnvironmentVariables();
            config = builder.Build();

            // Set default user-agent on the HttpClient to enable using the Google API from code
            client.DefaultRequestHeaders.Add("User-Agent", "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/90.0.4430.212 Safari/537.36");
        }

        /// <summary>
        /// This method gets the user's input country code safely.
        /// </summary>
        /// <returns>Returns a valid country code.</returns>
        private static string GetUserCountryInput()
        {
            Console.WriteLine("Do you know the valid country code you need?");
            string userResponse = Console.ReadLine();
            if (userResponse.ToLower() != "y")
            {
                ListCountryCodes();
            }

            bool IsValidCountryInput = false;
            string countryInput = string.Empty;

            while (!IsValidCountryInput)
            {
                Console.WriteLine("Enter a country code:");
                countryInput = Console.ReadLine();

                try
                {
                    // Check that it's a valid country code by initialising a RegionInfo object
                    RegionInfo regionInfo = new RegionInfo(countryInput);
                    IsValidCountryInput = true;
                }
                catch (Exception)
                {
                    Console.WriteLine($"{countryInput} is not a valid country code. Please press any key then find your desired country code from this table.");
                    Console.ReadKey();
                    ListCountryCodes();
                }
            }

            return countryInput;
        }

        /// <summary>
        /// This method displays a table of valid country codes.
        /// </summary>
        private static void ListCountryCodes()
        {
            IEnumerable<RegionInfo> region = CultureInfo.GetCultures(CultureTypes.SpecificCultures)
                   .Select(x => new RegionInfo(x.LCID));

            List<CountryCode> countries = (from x in region select new CountryCode { CountryName = x.EnglishName, TwoLetterCode = x.TwoLetterISORegionName })
                         .Distinct()
                         .OrderBy(x => x.CountryName)
                         .ToList<CountryCode>();

            ConsoleTable table = new ConsoleTable("Country", "Country Code");

            foreach (CountryCode country in countries)
            {
                table.AddRow(country.CountryName, country.TwoLetterCode);
            }

            table.Write();
            Console.WriteLine();
        }
    }
}
