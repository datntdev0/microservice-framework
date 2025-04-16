using datntdev.Microservices.Common.Modular;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace datntdev.Microservices.ServiceDefaults.Hosting
{
    internal class ServiceBootstrap(IServiceProvider serviceProvider, Type startupModuleType)
    {
        private readonly Type _startupModuleType = startupModuleType;
        private readonly IServiceProvider _serviceProvider = serviceProvider;

        public void Initialize()
        {
            var modules = GetAllModuleInstances().ToList();
            modules.ForEach(x => x.PreInitialize());
            modules.ForEach(x => x.Initialize());
            modules.ForEach(x => x.PostInitialize());
        }

        public static IEnumerable<Type> FindDependedModuleTypes(Type moduleType)
        {
            if (!moduleType.GetTypeInfo().IsDefined(typeof(DependOnAttribute), true)) return [];

            var moduleTypes = moduleType.GetTypeInfo()
                .GetCustomAttributes(typeof(DependOnAttribute), true)
                .Cast<DependOnAttribute>()
                .SelectMany(x => x.DependedModuleTypes)
                .Distinct();

            return moduleTypes
                .SelectMany(FindDependedModuleTypes)
                .Concat(moduleTypes);
        }

        private IEnumerable<BaseModule> GetAllModuleInstances()
        {
            var modules = FindDependedModuleTypes(_startupModuleType).Append(_startupModuleType);
            return modules
                .Select(_serviceProvider.GetRequiredService)
                .Where(module => module != null)
                .Select(module => (BaseModule)module);
        }
    }
}
