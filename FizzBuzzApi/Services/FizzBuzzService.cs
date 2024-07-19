using FizzBuzzApi.Model;
using FizzBuzzApi.Services.Division;
using System.Collections.Generic;

namespace FizzBuzzApi.Services
{
    public class FizzBuzzService : IFizzBuzzService
    {
        private readonly IDivisionService _divisionService;
        
        public FizzBuzzService(IDivisionService divisionService)
        {
            _divisionService = divisionService;
        }

        public FizzBuzzResult ProcessValues(string[] values)
        {
            var results = new List<string>();
            try
            {
                if (values == null || values.Length == 0)
                {
                    results.Add("Input values not provided");
                }
                else
                {
                    foreach (string value in values)
                    {
                        if (string.IsNullOrEmpty(value))
                        {
                            results.Add($"{value} = Invalid Item");
                        }
                        if (int.TryParse(value, out int number))
                        {
                            var result = _divisionService.GetDivisionResult(number);
                            results.Add($"{value} = {result}");
                        }
                        else
                        {
                            results.Add($"{value} = Invalid Item");
                        }
                    }
                }
            }
            catch (Exception)
            {
                results.Add("Invalid Item");
            }
            return new FizzBuzzResult
            {
                Results = results,
            };
        }
    }
}
