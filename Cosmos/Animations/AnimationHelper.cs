using System.Windows;
using System.Windows.Media.Animation;

namespace Cosmos
{
    public class AnimationHelper
    {

        public static void NextAnimation(BasePage page)
        {
            ThicknessAnimation animation = new ThicknessAnimation(new Thickness(page.WindowWidth, 0, -page.WindowWidth, 0),
                                            new Thickness(0),
                                            new Duration(new System.TimeSpan(0, 0, 0, 0, 500)));

            Storyboard.SetTargetProperty(animation, new PropertyPath("Margin"));
            Storyboard sb = new Storyboard();
            sb.Children.Add(animation);

            sb.Begin(page);
        }

        public static void PrevAnimation(BasePage page)
        {
            ThicknessAnimation animation = new ThicknessAnimation(new Thickness(-page.WindowWidth, 0, page.WindowWidth, 0),
                                            new Thickness(0),
                                            new Duration(new System.TimeSpan(0, 0, 0, 0, 500)));

            Storyboard.SetTargetProperty(animation, new PropertyPath("Margin"));
            Storyboard sb = new Storyboard();
            sb.Children.Add(animation);

            sb.Begin(page);
        }
    }
}
