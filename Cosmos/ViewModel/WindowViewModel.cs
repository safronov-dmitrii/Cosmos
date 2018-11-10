using System.Windows;
using System.Windows.Input;

namespace Cosmos
{
    public class WindowViewModel : BaseViewModel
    {
        #region Приватные поля

        private Window currentWindow;
        private ICommand mMinimizeCommand;
        private ICommand mRestoreCommand;
        private ICommand mMaximizeCommand;
        private ICommand mCloseCommand;
        private ICommand mMenuCommand;
        private int mOuterBorderThickness = 6;

        #endregion
        #region Публичные поля
        /// <summary>
        /// Минимальная ширина окна
        /// </summary>
        public int WindowMinWidth { get; set; } = 300;
        /// <summary>
        /// Минимальная высота окна
        /// </summary>
        public int WindowMinHeight { get; set; } = 100;
        #endregion

        #region Свойства пользовательского окна

        /// <summary>
        /// Ширина границы окна, предназначенной для изменения размера
        /// </summary>
        public int WindowResizeBorderThickness { get { return 15; } }
        /// <summary>
        /// Закругленность углов пользовательского окна
        /// </summary>
        public int WindowCornerRadius { get { return 6; } }
        /// <summary>
        /// Высота header пользовательского окна
        /// </summary>
        public int WindowCaptionHight { get { return 40; } }
        /// <summary>
        /// Ширина внешней рамки окна
        /// </summary>
        public int WindowOuterBorderThickness { get { return mOuterBorderThickness; } set { mOuterBorderThickness = value; OnPropertyChanged(); } }

        /// <summary>
        /// Команда скрытия пользовательского окна
        /// </summary>
        public ICommand WindowMinimizeCommand { get { return mMinimizeCommand; } set { mMinimizeCommand = value; OnPropertyChanged(); } }
        /// <summary>
        /// Команда для восстановления размеров окна
        /// </summary>
        public ICommand WindowRestoreCommand { get { return mRestoreCommand; } set { mRestoreCommand = value; OnPropertyChanged(); } }
        /// <summary>
        /// Команда раскрытия во весь экран пользовательского окна
        /// </summary>
        public ICommand WindowMaximizeCommand { get { return mMaximizeCommand; } set { mMaximizeCommand = value; OnPropertyChanged(); } }
        /// <summary>
        /// Команда закрытия окна
        /// </summary>
        public ICommand WindowCloseCommand { get { return mCloseCommand; } set { mCloseCommand = value; OnPropertyChanged(); } }
        /// <summary>
        /// Команда для отображения системного меню при нажатии на значок в заголовке окна
        /// </summary>
        public ICommand WindowMenuCommand { get { return mMenuCommand; } set { mMenuCommand = value; OnPropertyChanged(); } }

        #endregion

        /// <summary>
        /// Конструктор по умолчанию
        /// </summary>
        /// <param name="win">Окно, к которому применяется данная модель</param>
        public WindowViewModel(Window win)
        {
            WindowMinimizeCommand = new RelayCommand(() => { SystemCommands.MinimizeWindow(currentWindow); }, () => true);
            WindowRestoreCommand = new RelayCommand(() => { SystemCommands.RestoreWindow(currentWindow); }, () => true);
            WindowMaximizeCommand = new RelayCommand(() => { SystemCommands.MaximizeWindow(currentWindow); }, () => true);
            WindowCloseCommand = new RelayCommand(() => { currentWindow.Close(); }, () => true);
            WindowMenuCommand = new RelayCommand(() => { SystemCommands.ShowSystemMenu(win, GetWindowPosition()); }, () => true);

            this.currentWindow = win;
        }

        /// <summary>
        /// Получение координат мышки
        /// </summary>
        /// <returns></returns>
        private Point GetWindowPosition()
        {
            Point point = Mouse.GetPosition(currentWindow);
            // Отсутпы нужно прибавлять только при условии, что окно не развернуто на весь экран
            if (currentWindow.WindowState != WindowState.Maximized)
                return new Point(point.X + currentWindow.Left, point.Y + currentWindow.Top);
            else return point;
        }
    }
}
