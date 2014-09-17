namespace SystemChat.Client.WPF
{
    using System.Windows;

    using ChatSystem.Model.Message;

    /// <summary>
    ///     Interaction logic for LoginWindow.xaml
    /// </summary>
    public partial class LoginWindow : Window
    {
        public LoginWindow()
        {
            this.InitializeComponent();
            this.usernameTextBox.Focus();
        }

        private void OnSignUpButtonClick(object sender, RoutedEventArgs e)
        {
            var username = this.usernameTextBox.Text;

            this.Hide();
            this.ShowCrowdChatWindow(username);
            this.Close();
        }

        private void ShowCrowdChatWindow(string username)
        {
            var user = new UserSession(username);
            var mainWindow = new SystemChatWindow(user);
            mainWindow.Show();
        }
    }
}