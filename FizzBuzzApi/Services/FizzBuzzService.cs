using FizzBuzzApi.Model;
using System.Text.Json;
namespace FizzBuzzApi.Services
{
    public class FizzBuzzService : IFizzBuzzService
    {
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
                        if (int.TryParse(value, out int Number))
                        {
                            if (Number % 3 == 0 && Number % 5 == 0)
                            {
                                results.Add($"{value} = FizzBuzz");
                            }
                            else if (Number % 3 == 0)
                            {
                                results.Add($"{value} = Fizz");
                            }
                            else if (Number % 5 == 0)
                            {
                                results.Add($"{value} = Buzz");
                            }
                            else if (Number % 3 != 0 || Number % 5 != 0)
                            {
                                results.Add($"{value} = Divided {value} by 5 Divided {value} by 3 ");
                            }
                        }
                        else
                        {
                            results.Add($"{value} = Invalid Item");
                        }
                    }
                }
            }
            catch (Exception ex)
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
