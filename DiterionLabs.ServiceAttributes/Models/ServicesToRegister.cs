using Microsoft.Extensions.DependencyInjection;

namespace DiterionLabs.ServiceAttributes.Models;

/// <summary>
///     Object used to store the class name, interface name and service
///     lifetime of discovered classes.
/// </summary>
public class ServicesToRegister
{
    public Type? ClassName { get; set; }

    public IEnumerable<Type>? InterfaceName { get; set; }

    public ServiceLifetime ServiceLifetime { get; set; }
}