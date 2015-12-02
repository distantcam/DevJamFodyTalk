using System;
using System.Windows;
using System.Windows.Input;

namespace Slides
{
    public partial class MainWindow : Window
    {
        private int currentState = 0;

        public MainWindow()
        {
            InitializeComponent();

            VisualStateManager.GoToState(slides, slides.States[currentState], true);
        }

        protected override void OnKeyUp(KeyEventArgs e)
        {
            base.OnKeyUp(e);

            if (e.Key == Key.Escape)
            {
                this.WindowState = WindowState.Normal;
                this.WindowStyle = WindowStyle.SingleBorderWindow;
                return;
            }

            if (e.Key == Key.Left)
                currentState = Math.Max(currentState - 1, 0);
            else if (currentState == slides.States.Length - 1)
                Application.Current.Shutdown();
            else
                currentState = Math.Min(currentState + 1, slides.States.Length - 1);

            VisualStateManager.GoToState(slides, slides.States[currentState], true);
        }

        protected override void OnMouseDoubleClick(MouseButtonEventArgs e)
        {
            base.OnMouseDoubleClick(e);

            this.WindowStyle = WindowStyle.None;
            this.WindowState = WindowState.Maximized;
        }
    }
}