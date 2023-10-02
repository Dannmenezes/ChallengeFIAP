using ChallengeIdwall.Model;

namespace ChallengeIdwall.Interfaces
{
    public interface IWantedService
    {
        Task<List<Fbi>> GetWantedPersonAsync();

        Task<List<Interpol>> GetInterpolWanted();
    }
}
