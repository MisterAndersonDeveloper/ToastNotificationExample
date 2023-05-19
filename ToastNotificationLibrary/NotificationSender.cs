using Microsoft.Toolkit.Uwp.Notifications;

namespace ToastNotificationLibrary
{
    public class NotificationSender
    {
        #region Pattern
        private static readonly Lazy<NotificationSender> lazy =
                new Lazy<NotificationSender>(() => new NotificationSender());

        public static NotificationSender Instance { get { return lazy.Value; } }

        private NotificationSender()
        {
        }
        #endregion  

        public void CheckToast()
        {
            new ToastContentBuilder()
                .AddArgument("conversationId", 9813)
                .AddText("Hello World")
                .Show();
        }

        public void SendMessage(string message)
        {
            new ToastContentBuilder()
                .AddArgument("conversationId", 9813)
                .AddText(message)
                .Show();
        }

        public void ToastWithButtons()
        {
            new ToastContentBuilder()
                .AddArgument("conversationId", 9813)
                .AddText("Do you like this application?")
                .AddButton(new ToastButton()
                    .SetContent("Like")
                    .AddArgument("action", "like")
                    .SetBackgroundActivation())
                .AddButton(new ToastButton()
                    .SetContent("Dislike")
                    .AddArgument("action", "dislike")
                    .SetBackgroundActivation())
                .Show();
        }

        public void ToastWithTextInput()
        {
            new ToastContentBuilder()
                .AddArgument("conversationId", 9813)
                .AddText("Send a message")
                .AddInputTextBox("replyMessage", placeHolderContent: "Type a message")
                .AddButton(new ToastButton()
                    .SetContent("Reply")
                    .AddArgument("action", "reply")
                    .SetBackgroundActivation())
                .Show();
        }
    }
}