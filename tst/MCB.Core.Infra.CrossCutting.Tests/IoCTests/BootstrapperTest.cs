using FluentAssertions;
using MCB.Core.Infra.CrossCutting.Abstractions.DateTime;
using MCB.Core.Infra.CrossCutting.Abstractions.Serialization;
using MCB.Core.Infra.CrossCutting.Abstractions.Utils;
using MCB.Core.Infra.CrossCutting.DateTime;
using MCB.Core.Infra.CrossCutting.DependencyInjection.Abstractions.Enums;
using MCB.Core.Infra.CrossCutting.DependencyInjection.Abstractions.Interfaces;
using MCB.Core.Infra.CrossCutting.DependencyInjection.Abstractions.Models;
using MCB.Core.Infra.CrossCutting.IoC;
using MCB.Core.Infra.CrossCutting.Serialization;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace MCB.Core.Infra.CrossCutting.Tests.IoCTests;

public class BootstrapperTest
{
    [Fact]
    public void Bootstrapper_Shuold_Register_Correctly()
    {
        // Arrange
        var dependencyInjectionContainer = new DependencyInjectionContainer();

        // Act
        Bootstrapper.ConfigureDependencyInjection(dependencyInjectionContainer);

        // Assert
        var dateTimeProviderRegistration = dependencyInjectionContainer.GetRegistrationCollection().FirstOrDefault(q => q.ServiceType == typeof(IDateTimeProvider));
        var jsonSerializerRegistration = dependencyInjectionContainer.GetRegistrationCollection().FirstOrDefault(q => q.ServiceType == typeof(IJsonSerializer));
        var protobufSerializerRegistration = dependencyInjectionContainer.GetRegistrationCollection().FirstOrDefault(q => q.ServiceType == typeof(IProtobufSerializer));
        var utilsRegistration = dependencyInjectionContainer.GetRegistrationCollection().FirstOrDefault(q => q.ServiceType == typeof(IUtils));

        dateTimeProviderRegistration.Should().NotBeNull();
        jsonSerializerRegistration.Should().NotBeNull();
        protobufSerializerRegistration.Should().NotBeNull();
        utilsRegistration.Should().NotBeNull();

        dateTimeProviderRegistration.ConcreteType.Should().Be(typeof(DateTimeProvider));
        dateTimeProviderRegistration.DependencyInjectionLifecycle.Should().Be(DependencyInjectionLifecycle.Singleton);

        jsonSerializerRegistration.ConcreteType.Should().Be(typeof(JsonSerializer));
        jsonSerializerRegistration.DependencyInjectionLifecycle.Should().Be(DependencyInjectionLifecycle.Singleton);

        protobufSerializerRegistration.ConcreteType.Should().Be(typeof(ProtobufSerializer));
        protobufSerializerRegistration.DependencyInjectionLifecycle.Should().Be(DependencyInjectionLifecycle.Singleton);

        utilsRegistration.ConcreteType.Should().Be(typeof(Utils.Utils));
        utilsRegistration.DependencyInjectionLifecycle.Should().Be(DependencyInjectionLifecycle.Singleton);
    }

    public class DependencyInjectionContainer
        : IDependencyInjectionContainer
    {
        // Fields
        private List<Registration> _registrationCollection = new List<Registration>();

        // Public Methods
        public IEnumerable<Registration> GetRegistrationCollection()
        {
            return _registrationCollection.AsReadOnly().AsEnumerable();
        }
        public void RegisterSingleton<TServiceType, TConcreteType>()
        {
            _registrationCollection.Add(new Registration(
                dependencyInjectionLifecycle: DependencyInjectionLifecycle.Singleton,
                serviceType: typeof(TServiceType),
                concreteType: typeof(TConcreteType)
            ));
        }

        public void CreateNewScope()
        {
            throw new NotImplementedException();
        }
        public void Register(DependencyInjectionLifecycle lifecycle, Type serviceType)
        {
            throw new NotImplementedException();
        }
        public void Register(DependencyInjectionLifecycle lifecycle, Type serviceType, Func<IDependencyInjectionContainer, object?> serviceTypeFactory)
        {
            throw new NotImplementedException();
        }
        public void Register(DependencyInjectionLifecycle lifecycle, Type serviceType, Type concreteType)
        {
            throw new NotImplementedException();
        }
        public void Register(DependencyInjectionLifecycle lifecycle, Type serviceType, Type concreteType, Func<IDependencyInjectionContainer, object?> concreteTypeFactory)
        {
            throw new NotImplementedException();
        }
        public void Register<TServiceType>(DependencyInjectionLifecycle lifecycle)
        {
            throw new NotImplementedException();
        }
        public void Register<TServiceType>(DependencyInjectionLifecycle lifecycle, Func<IDependencyInjectionContainer, TServiceType?> serviceTypeFactory)
        {
            throw new NotImplementedException();
        }
        public void Register<TServiceType, TConcreteType>(DependencyInjectionLifecycle lifecycle)
        {
            throw new NotImplementedException();
        }
        public void Register<TServiceType, TConcreteType>(DependencyInjectionLifecycle lifecycle, Func<IDependencyInjectionContainer, TConcreteType?> concreteTypeFactory)
        {
            throw new NotImplementedException();
        }
        public void RegisterScoped<TServiceType>()
        {
            throw new NotImplementedException();
        }
        public void RegisterScoped<TServiceType>(Func<IDependencyInjectionContainer, TServiceType?> serviceTypeFactory)
        {
            throw new NotImplementedException();
        }
        public void RegisterScoped<TServiceType, TConcreteType>()
        {
            throw new NotImplementedException();
        }
        public void RegisterScoped<TServiceType, TConcreteType>(Func<IDependencyInjectionContainer, TConcreteType?> concreteTypeFactory)
        {
            throw new NotImplementedException();
        }
        public void RegisterSingleton<TServiceType>()
        {
            throw new NotImplementedException();
        }
        public void RegisterSingleton<TServiceType>(Func<IDependencyInjectionContainer, TServiceType?> serviceTypeFactory)
        {
            throw new NotImplementedException();
        }
        public void RegisterSingleton<TServiceType, TConcreteType>(Func<IDependencyInjectionContainer, TConcreteType?> concreteTypeFactory)
        {
            throw new NotImplementedException();
        }
        public void RegisterTransient<TServiceType>()
        {
            throw new NotImplementedException();
        }
        public void RegisterTransient<TServiceType>(Func<IDependencyInjectionContainer, TServiceType?> serviceTypeFactory)
        {
            throw new NotImplementedException();
        }
        public void RegisterTransient<TServiceType, TConcreteType>()
        {
            throw new NotImplementedException();
        }
        public void RegisterTransient<TServiceType, TConcreteType>(Func<IDependencyInjectionContainer, TConcreteType?> concreteTypeFactory)
        {
            throw new NotImplementedException();
        }
        public object? Resolve(Type type)
        {
            throw new NotImplementedException();
        }
        public TType? Resolve<TType>()
        {
            throw new NotImplementedException();
        }
        public void Unregister(Type serviceType)
        {
            throw new NotImplementedException();
        }
        public void Unregister<TService>()
        {
            throw new NotImplementedException();
        }
    }
}
