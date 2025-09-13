using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using wpf_test.Services;
using wpf_test.ViewModels;

namespace wpf_test
{
    public class ServiceLocator
    {
        private readonly IServiceProvider _serviceProvider;

        public MainWindowViewModel MainWindowViewModel =>
            _serviceProvider.GetService<MainWindowViewModel>();


        public ServiceLocator()
        {
            var serviceCollection = new ServiceCollection();

            serviceCollection.AddSingleton<MainWindowViewModel>();
            serviceCollection.AddSingleton<IPoetryStorage, PoetryStorage>();


            _serviceProvider = serviceCollection.BuildServiceProvider();
        }
    }
}
