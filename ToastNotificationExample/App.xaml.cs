using System.Windows;
using AppNotificationExample.ViewModel;
using AppNotificationLibrary;

namespace AppNotificationExample
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private MainWindow _mainWindow;
        private MainWindowViewModel _mainWindowViewModel;
        private ActivationHandler _activationHandler;

        public App()
        {
            _activationHandler = new ActivationHandler();
            _mainWindowViewModel = new MainWindowViewModel();
            _mainWindow = new MainWindow()
            {
                DataContext = _mainWindowViewModel
            };

            //SUBSCRIBE TOAST ACTIVATION
            _activationHandler.SubsribeAction(NotificationResults.DEFAULT, _mainWindowViewModel.OnNotificationWasClicked);
            _activationHandler.SubsribeAction(NotificationResults.LIKE, _mainWindowViewModel.OnLike);
            _activationHandler.SubsribeAction(NotificationResults.DISLIKE, _mainWindowViewModel.OnDislike);
            _activationHandler.SubsribeAction(NotificationResults.REPLY, _mainWindowViewModel.OnMessageWasRecieved);

            MainWindow = _mainWindow;
            MainWindow.Show();
        }
    }
}
