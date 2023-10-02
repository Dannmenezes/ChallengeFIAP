using MoneyChallenge.Interfaces;
using MoneyChallenge.Services;

namespace MoneyChallenge.IoC.Registers
{
    public class ServicesRegister : IRegister
    {
        public void Register(IServiceCollection services)
        {
            services.AddScoped<IFBIService, FBIService>();
        }
    }
}
