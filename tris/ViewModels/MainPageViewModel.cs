using System.ComponentModel;
using System.Runtime.CompilerServices;
using Xamarin.Forms;

namespace tris.ViewModels
{
    public class MainPageViewModel : INotifyPropertyChanged
    {
        public MainPageViewModel()
        {

        }
        public MainPageViewModel(Command<string> clickOkCommand)
        {
            ClickOkCommand = clickOkCommand;
        }

        private static readonly string empty = string.Empty;
        private string name = empty;
        public string Name
        {
            get => name;
            set
            {
                if (name == value)
                {
                    return;
                }

                name = value;
                OnPropertyChanged();
                OnPropertyChanged(nameof(DisplayNamePlayerX));
                OnPropertyChanged(nameof(DisplayNamePlayerO));
            }
        }

        private string nameO = empty;

        public string NameO
        {
            get => nameO;
            set
            {
                if (nameO == value)
                {
                    return;
                }

                nameO = value;
                OnPropertyChanged();
                OnPropertyChanged(nameof(DisplayNamePlayerO));
            }
        }
        public string DisplayNamePlayerX => Name;
        public string DisplayNamePlayerO => NameO;
        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            var args = new PropertyChangedEventArgs(propertyName);

            PropertyChanged?.Invoke(this, args);
        }
        private Command<string> ClickOkCommand { get; set; }
    }
}
