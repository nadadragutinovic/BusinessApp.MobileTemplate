using BusinessApp.Features.Authentication.Services;
using BusinessApp.Features.Dashboard.Views;
using BusinessApp.ViewModels;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.ComponentModel;

namespace BusinessApp.Features.Authentication.ViewModels
{
    public partial class LoginViewModel : BaseViewModel
    {
        private readonly IAuthenticationService _authenticationService;
        public LoginViewModel(IAuthenticationService authenticationService)
        {
            _authenticationService = authenticationService;

            Title = "Login";
        }

        [ObservableProperty]
        [NotifyPropertyChangedFor(nameof(CanLogin))]
        public string userName = string.Empty;

        [ObservableProperty]
        [NotifyPropertyChangedFor(nameof(CanLogin))]
        public string password = string.Empty;

        [ObservableProperty]
        public bool rememberMe = true;

        public bool CanLogin =>
            !string.IsNullOrWhiteSpace(UserName) &&
            !string.IsNullOrWhiteSpace(Password) &&
            IsNotBusy;
         
        [RelayCommand]
        private async Task LoginAsync()
        {
            if (IsBusy)
                return;
            try
            {
                IsBusy = true;
                var success = await _authenticationService.LoginAsync(UserName, Password);
                if (success)
                {
                    await Shell.Current.GoToAsync(nameof(DashboardPage));
                }
                else
                {
                    await Shell.Current.DisplayAlert("Login", "Pogrešno korisničko ime ili lozinka.", "OK");
                }
            }
            finally
            {
                IsBusy = false;
            }
        }

        protected override void OnPropertyChanged(PropertyChangedEventArgs e)
        {
            base.OnPropertyChanged(e);
            if(e.PropertyName == nameof(IsBusy))
            {
                OnPropertyChanged(nameof(CanLogin));
            }
        }
    }
}
