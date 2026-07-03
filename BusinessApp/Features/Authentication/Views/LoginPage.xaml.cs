using BusinessApp.Features.Authentication.ViewModels;

namespace BusinessApp.Features.Authentication.Views;

public partial class LoginPage : ContentPage
{
    public LoginPage(LoginViewModel viewModel)
    {
        InitializeComponent();

        BindingContext = viewModel;
    }
}