﻿using Castle.DynamicProxy;

namespace MikyM.Autofac.Extensions.Attributes;

/// <summary>
/// Defines with what interceptors should the service be intercepted
/// </summary>
[AttributeUsage(AttributeTargets.Class, AllowMultiple = true)]
public sealed class InterceptedByAttribute : Attribute
{
    public Type Interceptor { get; private set; }
    public bool IsAsync { get; private set; }


    public InterceptedByAttribute(Type interceptor)
    {
        Interceptor = interceptor ?? throw new ArgumentNullException(nameof(interceptor));

        if (interceptor.GetInterfaces().Any(x => x == typeof(IAsyncInterceptor)))
            IsAsync = true;
    }
}