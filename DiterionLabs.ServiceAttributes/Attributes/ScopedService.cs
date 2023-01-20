using Microsoft.Extensions.DependencyInjection;

namespace DiterionLabs.ServiceAttributes.Attributes;

/// <summary>
///     [ScopedService] attribute which can be added on top of any
///     class. Sets ServiceLifetime in the base <see cref="Service" />
///     to Scoped.
/// </summary>
public class ScopedService : Service
{
    public ScopedService() 
        => ServiceLifetime = ServiceLifetime.Scoped;
}