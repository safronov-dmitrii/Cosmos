using System.Windows;
using System.Windows.Controls;

namespace Cosmos
{
    /// <summary>
    /// Свойство показывает наличие текста в PasswordBox
    /// </summary>
    public class PasswordBoxHasTextProperty : BaseAttachedProperty<PasswordBoxHasTextProperty, bool>
    {
        /// <summary>
        /// Устанавливает значение для <see cref="PasswordBoxHasTextProperty"/>
        /// </summary>
        /// <param name="element"></param>
        public static void SetValue(DependencyObject element) => 
            SetValue(element, ((PasswordBox)element).SecurePassword.Length > 0);
    }

    /// <summary>
    /// Включает/отключает возможность проверки наличия текста в <see cref="PasswordBox"/>
    /// </summary>
    public class PasswordBoxTextObserverProperty : BaseAttachedProperty<PasswordBoxTextObserverProperty, bool>
    {
        public override void OnValueChanged(DependencyObject depObj, DependencyPropertyChangedEventArgs e)
        {
            PasswordBox pb = depObj as PasswordBox;

            if (pb == null) return;
            
            // Отписываюсь от предыдущих реализаций
            pb.PasswordChanged -= Pb_PasswordChanged;

            if ((bool)e.NewValue)
            {
                PasswordBoxHasTextProperty.SetValue(pb);

                // Подписываюсь на событие
                pb.PasswordChanged += Pb_PasswordChanged;
            }

        }

        private void Pb_PasswordChanged(object sender, RoutedEventArgs e)
        {
            PasswordBoxHasTextProperty.SetValue((PasswordBox)sender);
        }
    }
}
