using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace s_MorGame
{
    public class Flight
    {

        public double x;
        public double y;
        public double Vx;
        public double Vy;

        public Flight(double x, double y, double Vx, double Vy)
        {
            this.x = x;
            this.y = y;
            this.Vx = Vx;
            this.Vy = Vy;
        }
    }

    public class Bird
    {
        readonly double V0;
        readonly double alpha;
        readonly double m;
        readonly double g = 9.8;
        public List<Flight> Points = new List<Flight> { };
        double partition = 50;
        double k = 1 / 10;

        public Bird(double V0, double alpha, double m)
        {
            this.V0 = V0;
            this.alpha = alpha;
            this.m = m;
        }

        public Flight Position(List<Flight> Points, Int32 i, double dt, double m, double k)
        {

            double x = Points[i - 1].x + dt * Points[i - 1].Vx;
            double y = Points[i - 1].y + dt * Points[i - 1].Vy;

            double Vx = Points[i - 1].Vx - k * dt * Points[i - 1].Vx / m;
            double Vy = Points[i - 1].Vy - dt * (g + k * Points[i - 1].Vy / m);

            return new Flight(x, y, Vx, Vy);


        }

        public void Calculate(double x0, double y0)
        {
            double t = 0;
            double T = 2 * V0 * Math.Sin(alpha * Math.PI / 180) / g;
            double dt = Math.Abs(T / partition);


            Flight point = new Flight(x0, y0, V0 * Math.Cos(alpha * Math.PI / 180), V0 * Math.Sin(alpha * Math.PI / 180));
            Points.Add(point);
            t += dt;
            Int32 i = 1;
            double k = 1 / 10;

            while (t <= T)
            {
                Flight position = Position(Points, i, dt, m, k);
                if (position != null)
                {
                    Points.Add(position);
                }
                else
                {

                    break;
                }
                t += dt;
                i += 1;
            }
            
        }


    }
}
