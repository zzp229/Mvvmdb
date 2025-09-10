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
            InsertCommand = new AsyncRelayCommand(InsertAsync);
            ListCommand = new AsyncRelayCommand(ListAsync);
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

        public async Task InitializeAsync()
        {
            await _poetryStorage.InitializeAsync();
        }

        public ICommand InitialCommand { get; }

        public async Task InsertAsync() =>
            await _poetryStorage.InserAsync(new Poetry()
            {
                Name = "Name" + new Random().Next()
            });
        
        public ICommand InsertCommand { get; }

        public ObservableCollection<Poetry> Poetries { get; set; } = new();

        public async Task ListAsync()
        {
            var poetries = await _poetryStorage.ListAsync();
            Poetries.Clear();
            foreach (var poetry in poetries)
            {
                Poetries.Add(poetry);
            }
        }

        public ICommand ListCommand { get; set; }

    }
}
