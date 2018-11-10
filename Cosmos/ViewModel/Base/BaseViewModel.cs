using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Cosmos
{
    /// <summary>
    /// Основа ViewModel
    /// </summary>
    public class BaseViewModel : INotifyPropertyChanged
    {
        /// <summary>
        /// Событие срабатывает при изменении значения элемента
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged = (sender, e) => { };
        
        /// <summary>
        /// Реализация для <see cref="PropertyChanged"/> события
        /// </summary>
        /// <param name="propertyName">Наименование свойства, которое изменяется</param>
        public void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
