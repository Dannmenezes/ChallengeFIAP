using MoneyChallenge.Models;

namespace MoneyChallenge.Services
{
    public interface IInterpolService
    {
        Task<List<InterpolPerson>> GetWantedPeopleList();
    }
}
