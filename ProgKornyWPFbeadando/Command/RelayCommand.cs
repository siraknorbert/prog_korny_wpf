using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ProgKornyWPFbeadando.Command
{
    public class RelayCommand : ICommand
    {
        private Action DoWork;
        public RelayCommand(Action work)
        {
            DoWork = work;
        }

        public event EventHandler CanExecuteChanged;

        bool ICommand.CanExecute(object parameter)
        {
            return true;
        }

        void ICommand.Execute(object parameter)
        {
            DoWork();
        }
    }
}
