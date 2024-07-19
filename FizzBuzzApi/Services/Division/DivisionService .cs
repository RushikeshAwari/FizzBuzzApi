namespace FizzBuzzApi.Services.Division
{
    public class DivisionService : IDivisionService
    {
        public string GetDivisionResult(int number)
        {
            if (number % 3 == 0 && number % 5 == 0)
            {
                return "FizzBuzz";
            }
            else if (number % 3 == 0)
            {
                return "Fizz";
            }
            else if (number % 5 == 0)
            {
                return "Buzz";
            }
            else
            {
                return $"Divided {number} by 5 Divided {number} by 3";
            }
        }
    }
}
