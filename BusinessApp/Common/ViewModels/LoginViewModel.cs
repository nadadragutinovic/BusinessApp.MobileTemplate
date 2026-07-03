using BusinessApp.Features.Authentication.Services;
using BusinessApp.ViewModels;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

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
        public string userName = string.Empty;
        [ObservableProperty]
        public string password = string.Empty;
        [ObservableProperty]
        public bool rememberMe = true;

        
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
                    await Shell.Current.GoToAsync("//Dashboard");
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
    }
}
