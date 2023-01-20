using Microsoft.Extensions.DependencyInjection;

namespace DiterionLabs.ServiceAttributes.Attributes;

/// <summary>
///     [SingletonService] attribute which can be added on top of any
///     class. Sets ServiceLifetime in the base <see cref="Service" />
///     to Singleton.
/// </summary>
public class SingletonService : Service
{
    public SingletonService() 
        => ServiceLifetime = ServiceLifetime.Singleton;
}