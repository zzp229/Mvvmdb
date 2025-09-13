using CommunityToolkit.Mvvm.Input;
using Mvvmdb.Models;
using Mvvmdb.Services;
using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Mvvmdb.ViewModels
{
    public partial class MainWindowViewModel : ViewModelBase
    {
        private readonly IPoetryStorage _poetryStorage;

        public MainWindowViewModel(IPoetryStorage poetryStorage)
        {
            _poetryStorage = poetryStorage;
            SayHelloCommand = new RelayCommand(SayHello);
            InitialCommand = new AsyncRelayCommand(InitializeAsync);

        }
        

        private string _message;

        public string Message
        {
            get { return _message; }
            set { SetProperty(ref _message, value); }
        }

        public ICommand SayHelloCommand { get;}
        public void SayHello()
        {
            Message = "Hello, MVVM!";
        }

        /// <summary>
        /// 进入这里会卡死，很奇怪
        /// </summary>
        /// <returns></returns>
        public async Task InitializeAsync()
        {
            //int a = 1;
            await _poetryStorage.InitializeAsync();
        }

        public ICommand InitialCommand { get; }

        

        public ICommand ListCommand { get; set; }

    }
}
