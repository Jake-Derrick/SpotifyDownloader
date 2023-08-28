using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace SpotifyDownloader.Views
{
    /// <summary>
    /// Shares functionality across ViewModels
    /// </summary>
    public class BaseViewModel : ContentPage, INotifyPropertyChanged
    {
        bool showLoading = false;
        public bool ShowLoading
        {
            get { return showLoading; }
            set { SetProperty(ref showLoading, value); }
        }

        private string _errorMessage = "";
        public string ErrorMessage
        {
            get => _errorMessage;
            set
            {
                if (_errorMessage != value)
                {
                    _errorMessage = value;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(ErrorMessage)));
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(HasError)));
                }
            }
        }
        public bool HasError => !string.IsNullOrEmpty(ErrorMessage);

        #region PropertyChanged
        new public event PropertyChangedEventHandler PropertyChanged;
        new protected void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            var changed = PropertyChanged;
            if (changed == null)
                return;

            changed.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        protected bool SetProperty<T>(ref T backingStore, T value, [CallerMemberName] string propertyName = "", Action onChanged = null)
        {
            if (EqualityComparer<T>.Default.Equals(backingStore, value))
                return false;

            backingStore = value;
            onChanged?.Invoke();
            OnPropertyChanged(propertyName);
            return true;
        }
        #endregion
    }
}
