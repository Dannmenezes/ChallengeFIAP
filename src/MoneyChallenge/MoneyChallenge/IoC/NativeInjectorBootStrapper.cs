using MoneyChallenge.Interfaces;
using System.Reflection;

namespace MoneyChallenge.IoC
{
    public static class NativeInjectorBootStrapper
    {
        public static void Register(IServiceCollection services)
        {
            RegisterServices(services);

        }

        public static void RegisterServices(IServiceCollection services)
        {
            var instances = Assembly.GetExecutingAssembly()
                                    .GetTypes()
                                    .Where(type => type.GetInterfaces().Contains(typeof(IRegister)))
                                    .Select(x => (IRegister)Activator.CreateInstance(x));

            foreach (var instance in instances)
                instance.Register(services);
        }
    }
}
