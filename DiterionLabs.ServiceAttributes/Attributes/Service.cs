using Microsoft.Extensions.DependencyInjection;

namespace DiterionLabs.ServiceAttributes.Attributes;

/// <summary>
///     Base attribute, used by <see cref="ScopedService" />, <see cref="SingletonService" /> and
///     <see cref="TransientService" />. If applied to any class, the service lifetime will be set to transient by
///     default. The same as using  <see cref="TransientService" />.
/// </summary>
[AttributeUsage(AttributeTargets.Class)]
public class Service : Attribute
{
    protected ServiceLifetime ServiceLifetime { get; set; } = ServiceLifetime.Transient;
}