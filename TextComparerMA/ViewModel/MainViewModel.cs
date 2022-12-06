using System;


namespace TextComparerMA.ViewModel
{
    class MainViewModel : ObservableObject
    {
        private string? _oldData = String.Empty;
        public string? OldData
        {
            get { return _oldData; }
            set
            {
                _oldData = value;
                OnPropertyChanged();
            }
        }

        private string? _newData = String.Empty;

        public string? NewData
        {
            get { return _newData; }
            set
            {
                _newData = value;
                OnPropertyChanged();
            }
        }

        public MainViewModel()
        {


        }

    }
}

