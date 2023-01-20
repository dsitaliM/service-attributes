using System.Reflection;
using DiterionLabs.ServiceAttributes.Attributes;
using DiterionLabs.ServiceAttributes.Models;
using Microsoft.Extensions.DependencyInjection;

namespace DiterionLabs.ServiceAttributes.Helpers;

public static class RegisterDependenciesHelper
{
    /// <summary>
    ///     Finds all of the classes which have a base attribute of <see cref="Service" />.
    /// </summary>
    /// <param name="assembly"></param>
    /// <returns></returns>
    public static IEnumerable<ServicesToRegister> FindRegisteredServicesByAttribute(IEnumerable<Assembly> assembly)
    {
        var classes = assembly.SelectMany(x => x.GetTypes())
            .Where(type => type.GetCustomAttributes(typeof(Service), true).Length > 0)
            .Where(x => !x.IsAbstract && !x.IsGenericType && !x.IsNested);

        return MapAssembliesToModel(classes);
    }

    /// <summary>
    ///     Returns an list of assemblies found by checking the base directory for all DLLs.
    /// </summary>
    /// <returns>List of assemblies</returns>
    public static IEnumerable<Assembly> GetAssemblies()
    {
        return Directory.GetFiles(AppDomain.CurrentDomain.BaseDirectory, "*.dll")
            .Select(x => Assembly.Load(AssemblyName.GetAssemblyName(x)));
    }

    /// <summary>
    ///     Maps found assemblies to an ServicesToRegister object
    /// </summary>
    /// <param name="classes"></param>
    /// <returns></returns>
    private static IEnumerable<ServicesToRegister> MapAssembliesToModel(IEnumerable<Type> classes)
    {
        var mappedClasses = classes.Select(x => new ServicesToRegister
        {
            ClassName = x.GetTypeInfo(),
            InterfaceName = x.GetTypeInfo().ImplementedInterfaces.ToList(),
            ServiceLifetime = SetServiceLifetime(x.CustomAttributes
                ?.FirstOrDefault(a => a.AttributeType.FullName != null && !a.AttributeType.FullName.Contains("System.Runtime"))
                ?.AttributeType?.FullName ?? "")
        });

        return mappedClasses;
    }

    /// <summary>
    ///     Maps the name of the attribute above the class to a <see cref="ServiceLifetime" />
    /// </summary>
    /// <param name="customAttribute">The custom attribute above the class for auto registration</param>
    /// <returns></returns>
    private static ServiceLifetime SetServiceLifetime(string customAttribute)
    {
        if (customAttribute.Contains("ScopedService"))
            return ServiceLifetime.Scoped;

        if (customAttribute.Contains("SingletonService"))
            return ServiceLifetime.Singleton;

        return ServiceLifetime.Transient;
    }
}