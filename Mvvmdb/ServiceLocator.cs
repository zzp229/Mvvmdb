using Microsoft.Extensions.DependencyInjection;
using Mvvmdb.Services;
using Mvvmdb.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mvvmdb
{
    public class ServiceLocator
    {
        private readonly IServiceProvider _serviceProvider;

        public MainWindowViewModel MainWindowViewModel => _serviceProvider.GetService<MainWindowViewModel>();
        public UserControl1ViewModel UserControl1ViewModel => _serviceProvider.GetService<UserControl1ViewModel>();

        public ServiceLocator()
        {
            var serviceCollection = new ServiceCollection();

            serviceCollection.AddSingleton<MainWindowViewModel>();
            serviceCollection.AddSingleton<IPoetryStorage, PoetryStorage>();

            // 注册其他服务和视图模型
            serviceCollection.AddSingleton<UserControl1ViewModel>();

            _serviceProvider = serviceCollection.BuildServiceProvider();    // 建造者方便后面获取服务
        }
    }
}
