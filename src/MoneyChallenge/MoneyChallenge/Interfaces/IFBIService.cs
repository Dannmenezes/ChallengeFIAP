using MoneyChallenge.Models;

namespace MoneyChallenge.Interfaces
{
    public interface IFBIService
    {
        Task<List<FBIPerson>> GetWantedPeopleList();
        Task<FBIPerson> GetWantedPeopleById(int id);
    }
}
