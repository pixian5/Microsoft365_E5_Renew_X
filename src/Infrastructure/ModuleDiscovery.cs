using System.Reflection;

namespace Microsoft365_E5_Renew_X.Infrastructure;

public static class ModuleDiscovery
{
    public static IEnumerable<Assembly> Discover(Assembly rootAssembly)
    {
        yield return rootAssembly;

        foreach (var attribute in rootAssembly.GetCustomAttributes())
        {
            if (attribute.GetType().FullName != "E5Renewer.AssemblyContainsModuleAttribute")
            {
                continue;
            }

            var assemblyProperty = attribute.GetType().GetProperty("assembly", BindingFlags.Instance | BindingFlags.Public);
            if (assemblyProperty?.GetValue(attribute) is Assembly assembly)
            {
                yield return assembly;
            }
        }
    }
}
