namespace EmployeeManagementSystem.Commands
{
    public class CloseWindowCommand : CommandBase
    {
        public override void Execute(object parameter)
        {
            System.Windows.Application.Current.Shutdown();
        }
    }
}
