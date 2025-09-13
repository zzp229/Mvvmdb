using Microsoft.Extensions.DependencyInjection;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using wpf_test.Services;
using wpf_test.ViewModels;

namespace wpf_test
{
    public class ServiceLocator
    {
        private readonly IServiceProvider _serviceProvider;

        private static ServiceLocator _current;

        public static ServiceLocator Current
        {
            get
            {
                if (_current != null)
                {
                    return _current;
                }

                // WPF 中从 Application.Current.Resources 查找
                if (Application.Current.Resources.Contains(nameof(ServiceLocator)) &&
                    Application.Current.Resources[nameof(ServiceLocator)] is ServiceLocator serviceLocator)
                {
                    _current = serviceLocator;
                    return _current;
                }

                throw new Exception("ServiceLocator 未在应用程序资源中注册。");
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
