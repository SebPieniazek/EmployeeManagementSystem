using System.Windows;

namespace EmployeeManagementSystem.Commands
{
    public class CloseWindowCommand : CommandBase
    {
        public override void Execute(object parameter)
        {
            Application.Current.Shutdown();
        }
    }
}
