using Microsoft.Extensions.DependencyInjection;

namespace DiterionLabs.ServiceAttributes.Attributes;

/// <summary>
///     [TransientService] attribute which can be added on top of any
///     class. Sets ServiceLifetime in the base <see cref="Service" />
///     to Transient.
/// </summary>
public class TransientService : Service
{
    public TransientService() 
        => ServiceLifetime = ServiceLifetime.Transient;
}