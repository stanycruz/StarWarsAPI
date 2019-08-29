using StarWarsAPI.Controllers;
using System;

namespace StarWarsAPI
{
    class Program
    {
        static void Main(string[] args)
        {
            var api = StarWarsController.SwApi("people", 1);

            Console.WriteLine(api);
            Console.ReadKey();
        }
    }
}
