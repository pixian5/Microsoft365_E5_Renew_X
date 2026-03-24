using System.Reflection;
using E5Renewer.Controllers;
using E5Renewer.Controllers.V1;
using E5Renewer.Models.BackgroundServices;
using E5Renewer.Models.GraphAPIs;
using E5Renewer.Models.Modules;
using E5Renewer.Models.ModulesCheckers;
using E5Renewer.Models.Secrets;
using E5Renewer.Models.Statistics;

namespace Microsoft365_E5_Renew_X.Infrastructure;

public static class E5RenewerHostExtensions
{
    public static IServiceCollection AddE5RenewerHost(
        this IServiceCollection services,
        IEnumerable<Assembly> assemblies,
        FileInfo userSecret,
        FileInfo? tokenFile)
    {
        return services
            .AddModules(assemblies)
            .AddUserSecretFile(userSecret)
            .AddTokenOverride(tokenFile)
            .AddDummyResultGenerator()
            .AddSecretProvider()
            .AddStatusManager()
            .AddTimeStampGenerator()
            .AddUserClientProvider()
            .AddHostedService<PrepareUsersService>();
    }

    public static IServiceCollection AddModules(this IServiceCollection services, IEnumerable<Assembly> assemblies)
    {
        Type[] knownModulesTypes =
        [
            typeof(IModulesChecker),
            typeof(IUserSecretLoader),
            typeof(IGraphAPICaller),
            typeof(IAPIFunction)
        ];

        foreach (var type in assemblies
                     .SelectMany(assembly => assembly.GetCustomAttributes<ModulesInAssemblyAttribute>())
                     .SelectMany(attribute => attribute.types)
                     .Where(type => !type.IsAbstract && type.IsDefined(typeof(ModuleAttribute)) && type.IsAssignableTo(typeof(IModule))))
        {
            var serviceType = knownModulesTypes.FirstOrDefault(known => type.IsAssignableTo(known), typeof(IModule));
            if (!services.Any(descriptor => descriptor.ServiceType == serviceType && descriptor.ImplementationType == type))
            {
                services.AddTransient(serviceType, type);
            }
        }

        return services;
    }

    public static IServiceCollection AddUserClientProvider(this IServiceCollection services) =>
        services.AddSingleton<IUserClientProvider, SimpleUserClientProvider>();

    public static IServiceCollection AddDummyResultGenerator(this IServiceCollection services) =>
        services.AddTransient<IDummyResultGenerator, SimpleDummyResultGeneratorV1>();

    public static IServiceCollection AddSecretProvider(this IServiceCollection services) =>
        services.AddSingleton<ISecretProvider, SimpleSecretProvider>();

    public static IServiceCollection AddStatusManager(this IServiceCollection services) =>
        services.AddSingleton<IStatusManager, MemoryStatusManager>();

    public static IServiceCollection AddTimeStampGenerator(this IServiceCollection services) =>
        services.AddTransient<IUnixTimestampGenerator, UnixTimestampGenerator>();

    public static IServiceCollection AddTokenOverride(this IServiceCollection services, FileInfo? tokenFile) =>
        services.AddSingleton(new TokenOverride(null, tokenFile));

    public static IServiceCollection AddUserSecretFile(this IServiceCollection services, FileInfo userSecret) =>
        services.AddKeyedSingleton<FileInfo>("userSecret", userSecret);

    public static WebApplication RunModulesCheckers(this WebApplication app)
    {
        var moduleCheckers = app.Services.GetServices<IModulesChecker>().ToArray();
        var secretLoaders = app.Services.GetServices<IUserSecretLoader>().Cast<IModule>();
        var graphApiCallers = app.Services.GetServices<IGraphAPICaller>().Cast<IModule>();
        var apiFunctions = app.Services.GetServices<IAPIFunction>().Cast<IModule>();
        var otherModules = app.Services.GetServices<IModule>();

        var modules = moduleCheckers
            .Cast<IModule>()
            .Concat(secretLoaders)
            .Concat(graphApiCallers)
            .Concat(apiFunctions)
            .Concat(otherModules)
            .Distinct()
            .ToArray();

        foreach (var module in modules)
        {
            foreach (var checker in moduleCheckers)
            {
                try
                {
                    checker.CheckModules(module);
                }
                catch
                {
                }
            }
        }

        return app;
    }
}
