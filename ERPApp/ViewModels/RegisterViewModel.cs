using ERPAppApplication.DTOs.AuthenticationDTOs;
using ERPAppApplication.Interfaces;
using ERPApp.Commands;
using ERPApp.Views.Pages;
using Microsoft.Extensions.DependencyInjection;
using System.Windows.Input;

namespace ERPApp.ViewModels
{
    public class RegisterViewModel : ViewModelBase
    {
        private readonly IAuthenticationService _authService;

        public RegisterViewModel(IAuthenticationService authService)
        {
            _authService = authService;
            RegisterCommand = new AsyncRelayCommand(RegisterAsync);
        }

        // Input fields
        public string FullName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public string ConfirmPassword { get; set; } = string.Empty;

        // Error message binding
        private string? _errorMessage;
        public string? ErrorMessage
        {
            get => _errorMessage;
            set => SetProperty(ref _errorMessage, value);
        }

        // Command
        public ICommand RegisterCommand { get; }

        // Registration logic
        private async Task RegisterAsync(object? _)
        {
            ErrorMessage = null;

            if (Password != ConfirmPassword)
            {
                ErrorMessage = "Passwords do not match.";
                return;
            }

            if (string.IsNullOrWhiteSpace(Email) || string.IsNullOrWhiteSpace(FullName))
            {
                ErrorMessage = "Email and Full Name are required.";
                return;
            }

            // Split FullName into FirstName / LastName
            string firstName = FullName.Split(' ')[0];
            string lastName = FullName.Contains(' ') ? FullName.Substring(firstName.Length).Trim() : "";

            var dto = new RegisterDto
            {
                UserName = Email,
                Email = Email,
                Password = Password,
                ConfirmPassword = ConfirmPassword,
                FirstName = firstName,
                LastName = lastName
            };

            // Call the service
            var result = await _authService.RegisterAsync(dto);

            if (result.Succeeded)
            {
                // Navigate to LoginPage
                var loginPage = App.Services?.GetRequiredService<LoginPage>();
                loginPage!.DataContext = App.Services?.GetRequiredService<LoginViewModel>();
                MainWindow.Instance?.MainFrame.Navigate(loginPage);
            }
            else
            {
                // Show errors
                ErrorMessage = string.Join(Environment.NewLine, result.Errors);
            }
        }
    }
}
