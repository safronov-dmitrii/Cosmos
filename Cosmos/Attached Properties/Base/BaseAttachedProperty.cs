using System;
using System.Windows;

namespace Cosmos
{

    /// <summary>
    /// Базовая реализация для присоединяемого свойства зависимости
    /// </summary>
    /// <typeparam name="Parent">Наследник для <see cref="BaseAttachedProperty{Parent, Property}" /> </typeparam>
    /// <typeparam name="Property">Тип возвращаемого значения для присоединяемого свойства</typeparam>
    public class BaseAttachedProperty<Parent, Property>
        where Parent : new()
    {
        /// <summary>
        /// Событие возникающее при изменении значения для присоединяемого свойства
        /// </summary>
        public event Action<DependencyObject, DependencyPropertyChangedEventArgs> ValueChanged = (sender, e) => { };

        /// <summary>
        /// Макет для присоединяемого свойства
        /// </summary>
        public static Parent Instance { get; private set; } = new Parent();
        
        /// <summary>
        /// Присоединяемое свойство
        /// </summary>
        public static readonly DependencyProperty ValueProperty = DependencyProperty.RegisterAttached("Value",
                                                                    typeof(Property),
                                                                    typeof(BaseAttachedProperty<Parent, Property>), new UIPropertyMetadata(default(Property), new PropertyChangedCallback(ValueProperty_Changed)));

        /// <summary>
        /// Вызывается при изменении значения присоединяемого свойства
        /// </summary>
        /// <param name="depObj"></param>
        /// <param name="e"></param>
        private static void ValueProperty_Changed(DependencyObject depObj, DependencyPropertyChangedEventArgs e)
        {
            (Instance as BaseAttachedProperty<Parent, Property>)?.OnValueChanged(depObj, e);
            (Instance as BaseAttachedProperty<Parent, Property>)?.ValueChanged(depObj, e);
        }

        /// <summary>
        /// Метод возникает при изменении значения присоединяемого свойства
        /// </summary>
        /// <param name="depObj"></param>
        /// <param name="e"></param>
        public virtual void OnValueChanged(DependencyObject depObj, DependencyPropertyChangedEventArgs e) { }

        /// <summary>
        /// Инициализация присоединяемого свойства
        /// </summary>
        /// <param name="element">Элемент, к которому присоединяется свойство зависимости</param>
        /// <param name="value">Значение, которое нужно присвоить свойству зависимости </param>
        public static void SetValue(DependencyObject element, Property value) => element.SetValue(ValueProperty, value);

        /// <summary>
        /// Возвращает значение свойства зависимости
        /// </summary>
        /// <param name="element">Элемент, к которому относится данное свойство зависимости</param>
        /// <returns>Возвращает значение свойства зависимости</returns>
        public static Property GetValue(DependencyObject element) => (Property)element.GetValue(ValueProperty);
    }
}
