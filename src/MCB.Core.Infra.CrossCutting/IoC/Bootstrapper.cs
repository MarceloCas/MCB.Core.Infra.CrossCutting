using MCB.Core.Infra.CrossCutting.Abstractions.DateTime;
using MCB.Core.Infra.CrossCutting.Abstractions.Serialization;
using MCB.Core.Infra.CrossCutting.Abstractions.Utils;
using MCB.Core.Infra.CrossCutting.DateTime;
using MCB.Core.Infra.CrossCutting.DependencyInjection.Abstractions.Interfaces;
using MCB.Core.Infra.CrossCutting.Serialization;

namespace MCB.Core.Infra.CrossCutting.IoC;

public static class Bootstrapper
{
    public static void ConfigureDependencyInjection(IDependencyInjectionContainer dependencyInjectionContainer)
    {
        dependencyInjectionContainer.RegisterSingleton<IDateTimeProvider, DateTimeProvider>();
        dependencyInjectionContainer.RegisterSingleton<IJsonSerializer, JsonSerializer>();
        dependencyInjectionContainer.RegisterSingleton<IProtobufSerializer, ProtobufSerializer>();
        dependencyInjectionContainer.RegisterSingleton<IUtils, Utils.Utils>();
    }
}
