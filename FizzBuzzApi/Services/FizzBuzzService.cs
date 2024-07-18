using FizzBuzzApi.Model;
namespace FizzBuzzApi.Services
{
    public class FizzBuzzService : IFizzBuzzService
    {
        public FizzBuzzResult ProcessValues(int[] values)
        {
            var results = new List<string>();

            foreach (var value in values)
            {
                try
                {
                    if (value % 3 == 0 && value % 5 == 0)
                    {
                        results.Add($"{value} = FizzBuzz");
                    }
                    else if (value % 3 == 0)
                    {
                        results.Add($"{value} = Fizz");
                    }
                    else if (value % 5 == 0)
                    {
                        results.Add($"{value} = Buzz");
                    }
                    else if (value % 3 != 0 || value % 5 != 0)
                    {
                        results.Add($"{value} = Divided {value} by 5 Divided {value} by 3 ");
                    }
                    else
                    {
                        results.Add(value.ToString());
                    }
                }
                catch (Exception ex)
                {
                    results.Add("Invalid Item");
                }
            }

            return new FizzBuzzResult
            {
                Results = results,
            };
        }
    }
}
