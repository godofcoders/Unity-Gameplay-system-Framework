using System;
using System.Collections.Generic;

public static class ServiceLocator
{
    private static Dictionary<Type, IService> services = new();

    public static void Register<T>(T service) where T : IService
    {
        services[typeof(T)] = service;
    }

    public static T Get<T>() where T : IService
    {
        if (services.TryGetValue(typeof(T), out var service))
            return (T)service;

        throw new Exception($"Service {typeof(T)} not registered");
    }
}