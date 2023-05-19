using Microsoft.Toolkit.Uwp.Notifications;

namespace AppNotificationLibrary
{
    public class ActivationHandler
    {
        private Dictionary<string, Action<object>> _eventDictionary = new Dictionary<string, Action<object>>();

        public ActivationHandler()
        {
            ToastNotificationManagerCompat.OnActivated += toastArgs =>
            {
                // Obtain the arguments from the notification
                ToastArguments args = ToastArguments.Parse(toastArgs.Argument);

                if (args.Count != 1)
                {
                    switch (args["action"])
                    {
                        case NotificationResults.LIKE:
                        case NotificationResults.DISLIKE:
                            _eventDictionary[args["action"]].Invoke(null);
                            break;
                        case NotificationResults.REPLY:
                            _eventDictionary[NotificationResults.REPLY].Invoke(toastArgs.UserInput[NotificationResults.REPLY_MESSAGE]);
                            break;
                    }
                }
                else
                    _eventDictionary[NotificationResults.DEFAULT].Invoke(null);
            };
        }

        public void SubsribeAction(string action, Action<object> callback)
        {
            if (!_eventDictionary.Keys.Contains(action))
                _eventDictionary.Add(action, callback);
        }
    }
}
