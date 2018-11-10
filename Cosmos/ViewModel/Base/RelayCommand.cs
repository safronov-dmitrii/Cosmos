using System;
using System.Windows.Input;

namespace Cosmos
{
    /// <summary>
    /// Описание команды для ViewModel
    /// </summary>
    public class RelayCommand : ICommand
    {
        /// <summary>
        /// Действие при выполнении команды
        /// </summary>
        private Action executeAction;
        /// <summary>
        /// Func опредляет можно ли выполнять данную команду
        /// </summary>
        private Func<bool> canExecuteFunc;
 
        public event EventHandler CanExecuteChanged;

        /// <summary>
        /// Конструктор для RelayCommand
        /// </summary>
        /// <param name="action">Действие, которое должно выполниться</param>
        /// <param name="canEx">Функция проверки возможности выполнения команды</param>
        public RelayCommand(Action action, Func<bool> canEx)
        {
            this.executeAction = action;
            this.canExecuteFunc = canEx;
        }

        /// <summary>
        /// Проверка разрешения на выполнение команды
        /// </summary>
        /// <param name="parameter"></param>
        /// <returns>true, если выполнение возможно, false - в противном случае</returns>
        public bool CanExecute(object parameter)
        {
            return canExecuteFunc();
        }
        
        /// <summary>
        /// Метод срабатывает при выполнении команды
        /// </summary>
        /// <param name="parameter"></param>
        public void Execute(object parameter)
        {
            executeAction();
        }
    }
}
