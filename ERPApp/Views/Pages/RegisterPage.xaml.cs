using ERPApp.ViewModels;
using Microsoft.Extensions.DependencyInjection;
using System.Windows.Controls;

namespace ERPApp.Views.Pages
{
    /// <summary>
    /// Interaction logic for RegisterPage.xaml
    /// </summary>
    public partial class RegisterPage : Page
    {
        public RegisterPage()
        {
            InitializeComponent();
        }

        private void PasswordBox_PasswordChanged(object sender, System.Windows.RoutedEventArgs e)
        {
            if (DataContext is RegisterViewModel vm)
            {
                vm.Password = PasswordBox.Password;
            }
        }

        private void ConfirmPasswordBox_PasswordChanged(object sender, System.Windows.RoutedEventArgs e)
        {
            if (DataContext is RegisterViewModel vm)
            {
                vm.ConfirmPassword = ConfirmPasswordBox.Password;
            }
        }

        private void BackToLogin_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            var loginPage = App.Services?.GetRequiredService<LoginPage>();
            loginPage!.DataContext = App.Services?.GetRequiredService<LoginViewModel>();
            MainWindow.Instance?.MainFrame.Navigate(loginPage);
        }
    }
}
