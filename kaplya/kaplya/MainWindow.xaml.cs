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
using System.Windows.Threading;

namespace kaplya
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>




    public partial class MainWindow : Window
    {

        bool goleft = false;
        bool goright = false;

        DispatcherTimer gameTimer = new DispatcherTimer();

        int score;
        bool gameOver;
        int gravity = 2;
        Rect vedroHitbox;

        Random rnd = new Random();


        private void KeyIsDown(object sender, KeyEventArgs e)
        {
            if (Canvas.GetLeft(vedro) > 10)
            {
                if (e.Key == Key.A)
                {
                    goleft = true;
                }
            }

            if (Canvas.GetLeft(vedro) < 650)
            {
                if (e.Key == Key.D)
                {
                    goright = true;
                }
            }

            if (e.Key == Key.R)
            {
                if (gameOver == true)
                {
                    StartGame();
                }
            }
        }

        private void KeyIsUp(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.A)
            {
                goleft = false;
            }
            if (e.Key == Key.D)
            {
                goright = false;
            }
        }

        public MainWindow()
        {
            InitializeComponent();

            gameTimer.Tick += MainEventTimer;
            gameTimer.Interval = TimeSpan.FromMilliseconds(25);
            StartGame();
        }

        private void MainEventTimer(object sender, EventArgs e)
        {
            txtScore.Content = "Score: " + score;

            vedroHitbox = new Rect(Canvas.GetLeft(vedro), Canvas.GetTop(vedro), vedro.Width, vedro.Height);

            Canvas.SetTop(vedro, 400);

            if (goleft)
            {
                Canvas.SetLeft(vedro, Canvas.GetLeft(vedro) - 25);
            }

            if (goright)
            {
                Canvas.SetLeft(vedro, Canvas.GetLeft(vedro) + 25);
            }

            foreach (var x in MyCanvas.Children.OfType<Image>())
            {
                if ((string)x.Name == "kapla")
                {

                    Canvas.SetTop(x, Canvas.GetTop(x) + gravity); // Спуск капли

                    Rect kaplaHitbox = new Rect(Canvas.GetLeft(x), Canvas.GetTop(x), x.Width, x.Height);

                    // Если капля втащится в ведро, то + очки
                    if (vedroHitbox.IntersectsWith(kaplaHitbox))
                    {
                        StartPosKapla();
                        score += 1;
                    }
                }
                else if ((string)x.Name == "kapla2")
                {
                    Canvas.SetTop(x, Canvas.GetTop(x) + gravity); // Спуск капли

                    Rect kaplaHitbox = new Rect(Canvas.GetLeft(x), Canvas.GetTop(x), x.Width, x.Height);
                    if (vedroHitbox.IntersectsWith(kaplaHitbox))
                    {
                        StartPosKapla2();
                        score += 1;
                    }
                }
                else if ((string)x.Name == "kapla3")
                {
                    Canvas.SetTop(x, Canvas.GetTop(x) + gravity); // Спуск капли

                    Rect kaplaHitbox = new Rect(Canvas.GetLeft(x), Canvas.GetTop(x), x.Width, x.Height);
                    if (vedroHitbox.IntersectsWith(kaplaHitbox))
                    {
                        StartPosKapla3();
                        score += 1;
                    }
                }
                else if ((string)x.Name == "kapla4")
                {
                    Canvas.SetTop(x, Canvas.GetTop(x) + gravity); // Спуск капли

                    Rect kaplaHitbox = new Rect(Canvas.GetLeft(x), Canvas.GetTop(x), x.Width, x.Height);
                    if (vedroHitbox.IntersectsWith(kaplaHitbox))
                    {
                        StartPosKapla4();
                        score += 1;
                    }
                }
            }
            if (Canvas.GetTop(kapla) + kapla.Height > 540 || Canvas.GetTop(kapla2) + kapla2.Height > 540 || Canvas.GetTop(kapla3) + kapla3.Height > 540 || Canvas.GetTop(kapla4) + kapla4.Height > 540)
            {
                EndGame();
            }
        }


        
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

        }

        private void StartGame()
        {
            MyCanvas.Focus();

            score = 0;

            gameOver = false;

            Canvas.SetLeft(vedro, 334);
            Canvas.SetTop(vedro, 410);


            foreach (var x in MyCanvas.Children.OfType<Image>())
            {
                if (x is Image && (string)x.Name == "kapla")
                {
                    Canvas.SetTop(x, rnd.Next(-600, -20));
                }

                if (x is Image && (string)x.Name == "kapla2")
                {
                    Canvas.SetTop(x, rnd.Next(-600, -20));
                }

                if (x is Image && (string)x.Name == "kapla3")
                {
                    Canvas.SetTop(x, rnd.Next(-600, -20));
                }

                if (x is Image && (string)x.Name == "kapla4")
                {
                    Canvas.SetTop(x, rnd.Next(-600, -20));
                }
            }
            gameTimer.Start();
        }

        private void StartPosKapla()
        {
            Canvas.SetLeft(kapla, rnd.Next(30, 720));
            Canvas.SetTop(kapla, rnd.Next(-200, -2));
        }

        private void StartPosKapla2() 
        {
            Canvas.SetLeft(kapla2, rnd.Next(30, 720));
            Canvas.SetTop(kapla2, rnd.Next(-200, -2));
        }

        private void StartPosKapla3()
        {
            Canvas.SetLeft(kapla3, rnd.Next(30, 720));
            Canvas.SetTop(kapla3, rnd.Next(-200, -2));
        }

        private void StartPosKapla4()
        {
            Canvas.SetLeft(kapla4, rnd.Next(30, 720));
            Canvas.SetTop(kapla4, rnd.Next(-200, -2));
        }

        private void EndGame()
        {
            gameTimer.Stop();
            gameOver = true;
            txtScore.Content += "                   Press R to try again";
        }

    }
}
