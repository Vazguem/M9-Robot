using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;

namespace Robot
{
    class JocRobot
    {
        private bool girarDreta=true;
        int contDirecion = 0;//

        public const int WIDTH = 5;
        public const int HEIGHT = 5;
        public const int NPOMES = 3;


        private Point cap;
        private Point caixa;
        List<Point> caps;
        DireccioSnake direccio;
        private List<Point> pomes;
        private List<object> bodySnake;

        public JocRobot()
        {
            cap = new Point(0, 0);
            caps = new List<Point>();
            direccio = DireccioSnake.Sud;
            pomes = new List<Point>();
            //distribuir les pomes
            Random r = new Random();
            for (int i = 0; i < NPOMES; i++)
            {
                var x = r.Next(0, WIDTH - 1);
                var y = r.Next(0, HEIGHT - 1);
                while (x == 0 && y == 0)
                {
                    x = r.Next(0, WIDTH - 1);
                    y = r.Next(0, HEIGHT - 1);
                }

                pomes.Add(new Point(x, y));
            }

        }

        public DireccioSnake Direccio { get => direccio; set => direccio = value; }
        public Point Cap { get => cap; set => cap = value; }
        public Point Caixa{ get => caixa; set => cap = value; }
    public List<Point> Pomes { get => pomes; set => pomes = value; }

        public void GetDirection(int numero)
        {
            
            switch (numero)
            {
                case 0:
                    direccio = DireccioSnake.Nord;
                    break;
                case 1:
                    direccio = DireccioSnake.Est;
                    break;
                case 2:
                    direccio = DireccioSnake.Oest;
                    break;
                case 3:
                    direccio = DireccioSnake.Sud;
                    break;
            }
             
        }

        public void GiraDreta()
        {
            GetDirection(contDirecion);
            GameWindow.SetRobotMovimentEstat("-->");
            contDirecion++; 
            contDirecion = contDirecion % 4;
        }
        public void GiraIzqierda()
        { 
            GameWindow.SetRobotMovimentEstat("<--");
            GetDirection(contDirecion);
            contDirecion--;
            if (contDirecion == 0) contDirecion = 3;//pasem a altre direcio
        }
        public void Avanza()
        {
            
            if(cap.X>=0 && cap.Y>=0 && cap.X<200&& cap.Y < 200)
            {
                GameWindow.SetRobotMovimentEstat("^");
                if (direccio.Equals(DireccioSnake.Nord)) cap.Y--;
                else if(direccio.Equals(DireccioSnake.Sud)) cap.Y++;
                else if(direccio.Equals(DireccioSnake.Est)) cap.X--;
                else cap.X++;
            }
            else
            {
                GameWindow.SetRobotMovimentEstat("^ ..!");
            }
        }
        public void moure()
        {
            Random rm = new Random();
            int num=rm.Next(0, 100);
             
            if (num <= 50)//50 % recte
            {
                GiraDreta();  
            }
            else if(num<75)
            {
                Avanza(); 
            }
            else
            {
             
                GiraIzqierda(); 
            } 
        }

        public void CrossPomesSnake(List<Point> pomes, Point cap)
        {
            for (int i = 0; i < pomes.Count; i++)
            {
                if (cap.Y == pomes[i].Y) { caps.Add(cap); pomes.RemoveAt(1); }
            }
        }

    }
    public enum DireccioSnake
    {
        Nord,
        Sud,
        Est,
        Oest
    }
}
