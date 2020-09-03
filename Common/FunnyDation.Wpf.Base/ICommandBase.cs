using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace FunnyDation.Wpf.Base
{
    /// <summary>
    /// CommandInterface
    /// </summary>
    public class CommandInterface : ICommand
    {
        public CommandInterface(Action<object> excute, Func<object, bool> canExcute)
        {
            this.ActionExcute = excute;
            this.FuncCanExcute = canExcute;
        }
        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            if (FuncCanExcute != null)
            {
                return FuncCanExcute(parameter);
            }

            return false;
        }

        public void Execute(object parameter)
        {
            if (ActionExcute != null)
            {
                ActionExcute(parameter);
            }

        }

        protected Action<object> ActionExcute { get; set; }
        protected Func<object, bool> FuncCanExcute { get; set; }

        public void RaiseCanExcuteChanged()
        {
            if (CanExecuteChanged != null)
            {
                CanExecuteChanged(this, EventArgs.Empty);
            }
        }

    }
}
