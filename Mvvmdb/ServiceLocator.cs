using System;
using Avalonia;
using Avalonia.Controls;
using Microsoft.Extensions.DependencyInjection;
using Mvvmdb.Services;
using Mvvmdb.ViewModels;

namespace Mvvmdb
{
    public class ServiceLocator
    {
        private readonly IServiceProvider _serviceProvider;

        private static ServiceLocator _current;

        public static ServiceLocator Current
        {
            get
            {
                if (_current is not null)
                {
                    return _current;
                }

                if (Application.Current.TryGetResource(nameof(ServiceLocator),
                        out var resource) &&
                    resource is ServiceLocator serviceLocator)
                {
                    return _current = serviceLocator;
                }

                throw new Exception("理论上来讲不应该发生这种情况。");
            }
        }

        public ResultViewModel ResultViewModel => _serviceProvider.GetRequiredService<ResultViewModel>();

        public ServiceLocator()
        {
            var serviceCollection = new ServiceCollection();

            serviceCollection.AddSingleton<IPreferenceStorage, FilePreferenceStorage>();

            serviceCollection.AddSingleton<IPoetryStorage, PoetryStorage>();

            serviceCollection.AddSingleton<ResultViewModel>();


            _serviceProvider = serviceCollection.BuildServiceProvider();
        }

    }
}
