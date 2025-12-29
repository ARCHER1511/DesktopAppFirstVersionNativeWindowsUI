using ERPApp.Commands;
using ERPApp.Views.Pages;
using ERPAppApplication.Common.Results;
using ERPAppApplication.DTOs.AuthenticationDTOs;
using ERPAppApplication.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using System.Windows.Input;

namespace ERPApp.ViewModels
{
    public class LoginViewModel : ViewModelBase
    {
        private readonly IAuthenticationService _authService;
        public ICommand NavigateToRegisterCommand { get; }
        public LoginViewModel(IAuthenticationService authService)
        {
            _authService = authService;
            LoginCommand = new AsyncRelayCommand(LoginAsync, CanLogin);
            NavigateToRegisterCommand = new RelayCommand(_ => NavigateToRegister());
        }
        //bindable properties
        private string _userNameOrEmail = string.Empty;
        public string UserNameOrEmail
        {
            get => _userNameOrEmail;
            set
            {
                SetProperty(ref _userNameOrEmail,value);
                LoginCommand.RaiseCanExecuteChanged();
            }
        }
        private string _password = string.Empty;
        public string Password
        {
            get => _password;
            set
            {
                SetProperty(ref _password,value);
                LoginCommand.RaiseCanExecuteChanged();
            }
        }

        private string? _errorMessage;
        public string? ErrorMessage
        {
            get => _errorMessage;
            set => SetProperty(ref _errorMessage,value);
        }

        private bool _isBusy;
        public bool IsBusy
        {
            get => _isBusy;
            set => SetProperty(ref _isBusy,value);
        }
        //Commands
        public AsyncRelayCommand LoginCommand { get; }

        private bool CanLogin(object? _)
            => !string.IsNullOrEmpty(UserNameOrEmail)
            && !string.IsNullOrEmpty(Password)
            && !IsBusy;

        private async Task LoginAsync(object? _)
        {
            IsBusy = true;
            ErrorMessage = null;

            var dto = new LoginDto
            {
                UserNameOrEmail = UserNameOrEmail,
                Password = Password
            };

            Result<AuthResultDto> result = await _authService.LoginAsync(dto);
            if (!result.Succeeded)
            {
                ErrorMessage = result.Errors.FirstOrDefault();
                IsBusy = false;
                return;
            }
            //Success path
            var user = result.Data!.User;
            IsBusy = false;

            var homePage = App.Services?.GetRequiredService<HomePage>();
            homePage!.DataContext = App.Services?.GetRequiredService<HomeViewModel>();
            MainWindow.Instance?.MainFrame.Navigate(homePage);
        }
        private void NavigateToRegister()
        {
            var registerPage = App.Services?.GetRequiredService<RegisterPage>();
            registerPage!.DataContext = App.Services?.GetRequiredService<RegisterViewModel>();
            // Assuming your main window has a Frame named "MainFrame"
            MainWindow.Instance?.MainFrame.Navigate(registerPage);
        }
    }
}
