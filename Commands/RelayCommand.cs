using System;

namespace EmployeeManagementSystem.Commands
{
    public class RelayCommand : CommandBase
    {
        private readonly Action _methodToExecute;

        public RelayCommand(Action methodToExecute)
        {
            _methodToExecute = methodToExecute;
        }

        public override void Execute(object parameter)
        {
            _methodToExecute();
        }
    }
}
