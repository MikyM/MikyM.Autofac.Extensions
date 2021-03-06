using Autofac;

namespace MikyM.Autofac.Extensions;

/// <summary>
/// Registration extension configuration.
/// </summary>
[PublicAPI]
public sealed class AttributeRegistrationOptions
{
    internal ContainerBuilder Builder { get; set; }
    /// <summary>
    /// Default lifetime of the registrations.
    /// </summary>
    public Lifetime DefaultLifetime { get; set; } = Lifetime.InstancePerLifetimeScope;

    /// <summary>
    /// Constructor.
    /// </summary>
    /// <param name="builder">Builder.</param>
    public AttributeRegistrationOptions(ContainerBuilder builder)
        => Builder = builder;

    /// <summary>
    /// Registers an interceptor with <see cref="ContainerBuilder"/>.
    /// </summary>
    /// <param name="factoryMethod">Factory method for the registration.</param>
    /// <returns>Current instance of the <see cref="AttributeRegistrationOptions"/>.</returns>
    public AttributeRegistrationOptions AddInterceptor<T>(Func<IComponentContext, T> factoryMethod) where T : notnull
    {
        Builder.Register(factoryMethod);

        return this;
    }
}
