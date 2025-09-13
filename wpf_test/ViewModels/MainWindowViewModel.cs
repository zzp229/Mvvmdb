using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using wpf_test.Models;
using wpf_test.Services;

namespace wpf_test.ViewModels
{
    public class MainWindowViewModel : ObservableObject
    {
        private readonly IPoetryStorage _poetryStorage;

        public MainWindowViewModel(IPoetryStorage poetryStorage)
        {
            _poetryStorage = poetryStorage;
            SayHelloCommand = new RelayCommand(SayHello);
            InitialCommand = new AsyncRelayCommand(InitializeAsync);



            //#region test
            //ButtonCommand = new RelayCommand(() =>
            //{
            //    MessageBox.Show("Button clicked! Text: " + Text);
            //    Text = "Button was clicked!";
            //});
            //#endregion

        }

        //#region test
        //private string text;

        //public string Text
        //{
        //    get { return text; }
        //    set { SetProperty(ref text, value); }
        //}


        //private string _message;

        //public string Message
        //{
        //    get { return _message; }
        //    set { SetProperty(ref _message, value); }
        //}

        //public ICommand ButtonCommand { get; }
        //#endregion

        private string _message;

        public string Message
        {
            get { return _message; }
            set { SetProperty(ref _message, value); }
        }

        public ICommand SayHelloCommand { get; }
        public void SayHello()
        {
            Message = "Hello, MVVM!";
        }

        /// <summary>
        /// 确保数据库表存在
        /// </summary>
        /// <returns></returns>
        public async Task InitializeAsync()
        {
            //int a = 1;
            await _poetryStorage.InitializeAsync();
        }

        public ICommand InitialCommand { get; }

  
        public ICommand InsertCommand { get; }

        public ObservableCollection<Poetry> Poetries { get; set; } = new();

     

        public ICommand ListCommand { get; set; }
    }
}
