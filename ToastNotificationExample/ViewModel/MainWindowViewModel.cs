using System.Windows;
using AppNotificationLibrary;

namespace AppNotificationExample.ViewModel
{
    internal class MainWindowViewModel : ViewModelBase
    {
        //PROPERTIES
        private string _message = string.Empty;
        public string Message { get => _message; set { _message = value; OnPropertyChanged(); } }

        //COMMANDS
        public DelegateCommand CheckButtonCommand { get; set; }
        public DelegateCommand SendButtonCommand { get; set; }
        public DelegateCommand SendNotificationWithButtonsCommand { get; set; }
        public DelegateCommand RecieveMessageCommand { get; set; }

        public MainWindowViewModel()
        {
            CheckButtonCommand = new DelegateCommand(CheckButtonFunction);
            SendButtonCommand = new DelegateCommand(SendButtonFunction);
            SendNotificationWithButtonsCommand = new DelegateCommand(SendNotificationWithButtonsFunction);
            RecieveMessageCommand = new DelegateCommand(RecieveMessageFunction);
        }

        //COMMAND FUNCTIONS
        private void RecieveMessageFunction(object obj) =>
            NotificationSender.Instance.NotificationWithTextInput();

        private void SendNotificationWithButtonsFunction(object obj) =>
            NotificationSender.Instance.NotificationWithButtons();

        private void SendButtonFunction(object obj) =>
            NotificationSender.Instance.SendMessage(Message);

        private void CheckButtonFunction(object obj) =>
            NotificationSender.Instance.CheckNotification();

        //NOTIFICATION HANDLERS
        public void OnMessageWasRecieved(object obj) =>
            Application.Current.Dispatcher.Invoke(() => MessageBox.Show(obj.ToString()));

        public void OnNotificationWasClicked(object obj) =>
            Application.Current.Dispatcher.Invoke(() => MessageBox.Show("You have just activated the notification."));

        public void OnLike(object obj) =>
            Application.Current.Dispatcher.Invoke(() => MessageBox.Show(":)"));

        public void OnDislike(object obj) =>
            Application.Current.Dispatcher.Invoke(() => MessageBox.Show(":("));
    }
}
