using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace Robot
{
    public partial class GameWindow : Window,IintercanviEstat
    {
        private static string estatMoviment;

        public const int SNAKE_HEAD_SIZE_WIDTH = 100;
        public const int SNAKE_HEAD_SIZE_HEIGHT = 100;
        JocRobot joc;
        DispatcherTimer timer;
        SolidColorBrush brushSnake = new SolidColorBrush(Colors.Green);
        SolidColorBrush brushPoma = new SolidColorBrush(Colors.Red);
        private UIElement elpoma;

        public GameWindow()
        {
            InitializeComponent();
            joc = new JocRobot();
            timer = new DispatcherTimer();
            timer.Tick += Timer_Tick;
            timer.Interval = TimeSpan.FromMilliseconds(500);
        }


        private void Timer_Tick(object sender, EventArgs e)
        {
            //Pintar
            canvas.Children.Clear();
            Ellipse elSnake = new Ellipse()
            {
                Fill = brushSnake,
                Width = SNAKE_HEAD_SIZE_WIDTH,
                Height = SNAKE_HEAD_SIZE_HEIGHT,
            };
            Canvas.SetTop(elSnake, joc.Cap.Y * SNAKE_HEAD_SIZE_HEIGHT);
            Canvas.SetLeft(elSnake, joc.Cap.X * SNAKE_HEAD_SIZE_HEIGHT);
            canvas.Children.Add(elSnake);
           
            IntercanviEstatXaml();
            joc.moure();
        }


        private void btnIniciaJoc(object sender, RoutedEventArgs e)
        {
            timer.Start(); 
        }


        public static void SetRobotMovimentEstat(String estat)
        {
            estatMoviment = estat;
        }

        public  void IntercanviEstatXaml()
        {
            robotMoviment.Text = estatMoviment;
        }
    }
    public  interface IintercanviEstat
    {
        void IntercanviEstatXaml();
    }
}
