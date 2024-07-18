using FizzBuzzApi.Model;
namespace FizzBuzzApi.Services
{
    public interface IFizzBuzzService
    {
        FizzBuzzResult ProcessValues(int[] values);
    }
}

