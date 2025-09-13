using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using CommunityToolkit.Mvvm.Input;
using wpf_test.Models;
using wpf_test.Services;

namespace wpf_test.ViewModels
{
    public class ResultViewModel : ViewModelBase
    {
        private readonly IPoetryStorage _poetryStorage;

        public ResultViewModel(IPoetryStorage poetryStorage)
        {
            _poetryStorage = poetryStorage;

            OnInitializedCommand = new AsyncRelayCommand(OnInitializedAsync);
        }

        public ObservableCollection<Poetry> PoetryCollenction { get; } = new();

        public ICommand OnInitializedCommand { get; }

        public async Task OnInitializedAsync()
        {
            await _poetryStorage.InitializeAsync();
            var poetries = await _poetryStorage.GetPoetriesAsync(Expression.Lambda<Func<Poetry, bool>>(Expression.Constant(true),
                Expression.Parameter(typeof(Poetry), "p")), 0, int.MaxValue);
            foreach (var poetry in poetries)
            {
                PoetryCollenction.Add(poetry);
            }
        }
    }
}
