using nanoFramework.Presentation;
using nanoFramework.Presentation.Controls;
using nanoFramework.Presentation.Media;
using SimpleWpf;
using System;

namespace nanoFramework.UI.Console
{
    public class ConsoleWindow : Window
    {
        private readonly Font Small =  Resource.GetFont(Resource.FontResources.small);
        private readonly Font CourierRegular10 = Resource.GetFont(Resource.FontResources.courierregular10);
        //private readonly Font NinaB = Resource.GetFont(Resource.FontResources.NinaB);

        private readonly TextFlow log;
        private readonly Text timeText;
        private readonly Brush solidBlack = new SolidColorBrush(Color.Black);

        public ConsoleWindow()
        {
            StackPanel panel = new StackPanel();

            timeText = new Text(CourierRegular10, "Embarrassing second of silence.")
            {
                TextAlignment = TextAlignment.Right,
                VerticalAlignment = VerticalAlignment.Top,
                ForeColor = ColorUtility.ColorFromRGB(255, 255, 0)
            };
            panel.Children.Add(timeText);

            ScrollViewer scroll = new ScrollViewer
            {
                Height = 1, // SystemMetrics.ScreenHeight - CourierRegular10.Height;
                Width = 1, // SystemMetrics.ScreenWidth;
                ScrollingStyle = ScrollingStyle.Last,
                Background = null,
                LineHeight = Small.Height
            };

            panel.Children.Add(scroll);

            log = new TextFlow
            {
                HorizontalAlignment = HorizontalAlignment.Left,
                VerticalAlignment = VerticalAlignment.Top
            };
            scroll.Child = log;            

            Background = solidBlack;
            Child = panel;

            //ExtendedTimer clock = new ExtendedTimer(
            //    new System.Threading.TimerCallback(
            //        delegate
            //        {
            //            timeText.TextContent = DateTime.Now.ToString("ddd d. MMMM yyyy HH:mm:ss");
            //            timeText.Invalidate();
            //        }),
            //    null, ExtendedTimer.TimeEvents.Second);
        }

        //public void WriteLine(string s)
        //{
        //    //Dispatcher.BeginInvoke( new EventHandler(InvokedWriteLine), new object[] { s, EventArgs.Empty });
        //}

        private void InvokedWriteLine(object text, EventArgs e)
        {
            log.TextRuns.Add(new TextRun(text.ToString(), Small, Color.White));
            log.TextRuns.Add(TextRun.EndOfLine);
            ((ScrollViewer)log.Parent).LineDown();
        }

        protected virtual void OnStart() { }
    }
}
