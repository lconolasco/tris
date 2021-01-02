using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using Xamarin.Forms;
namespace tris{    public class trisPageViewModel : INotifyPropertyChanged    {        public trisPageViewModel()        {            ClickOkCommand = new Command(ClickOk);        }
        string name = string.Empty;        public string Name
        {            get { return name; }            set
            {                if (name == value)                    return;                name = value;                OnPropertyChanged();                OnPropertyChanged(nameof(DisplayNamePlayerX));
                OnPropertyChanged(nameof(DisplayNamePlayerO));            }        }

        string nameO = string.Empty;
        public string NameO
        {
            get { return nameO; }
            set
            {
                if (nameO == value)
                    return;
                nameO = value;
                OnPropertyChanged();
                OnPropertyChanged(nameof(DisplayNamePlayerO));
            }
        }        public string DisplayNamePlayerX => Name;
        public string DisplayNamePlayerO => NameO;
        public event PropertyChangedEventHandler PropertyChanged;        void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {            var args = new PropertyChangedEventArgs(propertyName);            PropertyChanged?.Invoke(this, args);        }        public Command ClickOkCommand{get;}        void ClickOk(){            Debug.WriteLine("ClickOk by Command");
        }
    }}