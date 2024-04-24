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

namespace s_MorGame
{
    /// <summary>
    /// Логика взаимодействия для GameWindow.xaml
    /// </summary>
    public partial class GameWindow : Window
    {
        public Bird ptichka;

        public GameWindow(Bird bird)
        {
            InitializeComponent();
            this.ptichka = bird;

        }

        DispatcherTimer timer = new DispatcherTimer();
        int k = 0;
        private void BirdClick(object sender, MouseButtonEventArgs e)
        {


            timer.Interval = new TimeSpan(0, 0, 0, 0, 30);
            timer.Tick += timer_tick;


            ptichka.Calculate(36, 172);



            timer.Start();



        }

        private void timer_tick(object sender, object e)
        {
            int i = ptichka.Points.Count;
            Canvas.SetTop(Bird, (600 - (ptichka.Points[k].y)));
            Canvas.SetLeft(Bird, 36 + (ptichka.Points[k].x));

            k++;
            if (k == i)
            {

                timer.Stop();
            }

        }
    }
}
