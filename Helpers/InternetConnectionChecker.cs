using NETWORKLIST;
using System.Windows;

namespace EmployeeManagementSystem.Helpers
{
    public class InternetConnectionChecker
    {
        private readonly INetworkListManager _networkListManager;

        public InternetConnectionChecker()
        {
            _networkListManager = new NetworkListManager();
        }

        public void CheckInternetConnection()
        {
            if (!IsConnected())
            {
                _ = MessageBox.Show("No internet connection. Try again later.", "No internet connection", MessageBoxButton.OK, MessageBoxImage.Warning);
                Application.Current.Shutdown();
            }
        }

        private bool IsConnected()
        {
            return _networkListManager.IsConnectedToInternet;
        }

    }
}
