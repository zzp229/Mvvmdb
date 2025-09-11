using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace wpf_test
{
    public class MainWindowViewModel : ObservableObject
    {
        public MainWindowViewModel()
        {
            ButtonCommand = new RelayCommand(() =>
            {
                MessageBox.Show("Button clicked! Text: " + Text);
                Text = "Button was clicked!";
            });
        }

        private string text;

		public string Text
		{
			get { return text; }
			set { SetProperty(ref text, value); }
		}


        private string _message;

        public string Message
        {
            get { return _message; }
            set { SetProperty(ref _message, value); }
        }

        public ICommand ButtonCommand { get; }

    }
}
