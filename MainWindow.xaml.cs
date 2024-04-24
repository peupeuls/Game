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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace s_MorGame
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private void Button_Start_Click(object sender, System.Windows.RoutedEventArgs e)
        {


            string def_velocity = start_velocity.Text;
            def_velocity = string.IsNullOrWhiteSpace(def_velocity) ? "35" : def_velocity;
            string def_corner = Corner.Text;
            def_corner = string.IsNullOrWhiteSpace(def_corner) ? "30" : def_corner;
            string def_mass = Mass.Text;
            def_mass = string.IsNullOrWhiteSpace(def_mass) ? "5" : def_mass;


            double velocity = Convert.ToDouble(def_velocity);
            double corner = Convert.ToDouble(def_corner);
            double mass = Convert.ToDouble(def_mass);

            Bird bird = new Bird(velocity, corner, mass);


            GameWindow gameWindow = new GameWindow(bird);
            gameWindow.Show();

        }
    }
}
