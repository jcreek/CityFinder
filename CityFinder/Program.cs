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
        private static async Task Main(string[] args)
        {
        }
}
