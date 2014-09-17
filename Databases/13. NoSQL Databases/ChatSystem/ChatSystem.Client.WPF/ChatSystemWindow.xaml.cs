namespace SystemChat.Client.WPF
{
    using System;
    using System.Diagnostics;
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;
    using System.Windows;

    using ChatSystem.Data.MessageManager;
    using ChatSystem.Model.Message;

    /// <summary>
    /// Interaction logic for CrowdChatWindow.xaml
    /// </summary>
    public partial class SystemChatWindow : Window
    {
        private Thread updatePostsThread; // XXX: bad
        private MessageManager messageManager;

        public SystemChatWindow(UserSession user)
        {
            this.InitializeComponent();
            this.User = user;
        }

        private UserSession User { get; set; }

        private bool IsInShowAllPostsMode { get; set; }

        protected override void OnClosed(EventArgs e)
        {
            base.OnClosed(e);
            this.updatePostsThread.Abort();
            App.Current.Shutdown();
        }

        private void OnWindowFormLoaded(object sender, RoutedEventArgs e)
        {
            this.InitializeChatSystemModule();
            this.ShowAllPostsAsync(this.GetDateTimeRange());
            this.postContent.Focus();
            this.UpdatePostsEachMs();
        }

        private void InitializeChatSystemModule()
        {
            this.messageManager = new MessageManager();
        }

        private async void ShowAllPostsAsync(Tuple<DateTime, DateTime> dateTimeRanges)
        {
            var postsAsString = await this.GetPostsAsString(dateTimeRanges);
            this.allPostsTextBox.Text = postsAsString;
            this.allPostsTextBox.ScrollToEnd();
        }

        private Task<string> GetPostsAsString(Tuple<DateTime, DateTime> dateTimeRange)
        {
            return Task.Run(() => this.messageManager.GetMessages(dateTimeRange.Item1));
        }

        private void UpdatePostsEachMs(int refreshMs = 500)
        {
            this.updatePostsThread = new Thread(() =>
            {
                while (true)
                {
                    this.allPostsTextBox.Dispatcher.BeginInvoke((Action)this.UpdatePosts);
                    Thread.Sleep(refreshMs);
                }
            });

            this.updatePostsThread.Start();
        }
 
        private async void UpdatePosts()
        {
            var haveNewPosts = await this.messageManager.HaveNewPosts();
            if (!haveNewPosts)
            {
                return;
            }

            var newPostsAsString = await this.GetPostsAsString(this.GetDateTimeRange());
            this.allPostsTextBox.Text = newPostsAsString;
            this.allPostsTextBox.ScrollToEnd();
        }

        private void OnPostButtonClick(object sender, RoutedEventArgs e)
        {
            var postContent = this.postContent.Text;
            if (string.IsNullOrEmpty(postContent))
            {
                return;
            }

            var postModel = new Message()
            {
                MessageText = postContent,
                Time = DateTime.Now,
                User = this.User.Name
            };

            this.postContent.Text = string.Empty;
            this.messageManager.PostMessage(postModel);
            this.allPostsTextBox.Text += (this.allPostsTextBox.Text.Length > 0 ? Environment.NewLine : string.Empty) +
                                         this.messageManager.GenerateOnePostAsString(postModel);
            this.allPostsTextBox.ScrollToEnd();
        }

        private void OnShowAllPostsButtonClick(object sender, RoutedEventArgs e)
        {
            this.IsInShowAllPostsMode = true;
            this.ShowAllPostsAsync(this.GetDateTimeRange());
        }

        private void OnShowAllPostsFromCurrentSessionButtonClick(object sender, RoutedEventArgs e)
        {
            this.IsInShowAllPostsMode = false;
            this.ShowAllPostsAsync(this.GetDateTimeRange());
        }

        private Tuple<DateTime, DateTime> GetDateTimeRange()
        {
            if (this.IsInShowAllPostsMode)
            {
                return Tuple.Create(DateTime.MinValue, DateTime.MaxValue);
            }
            return Tuple.Create(this.User.LoggedOn, DateTime.MaxValue);
        }
    }
}