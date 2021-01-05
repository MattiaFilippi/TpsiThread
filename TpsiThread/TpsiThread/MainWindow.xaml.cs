﻿using System;
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
using System.Threading;
using System.Diagnostics;

namespace TpsiThread
{
    /// <summary>
    /// Logica di interazione per MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        private double inizio;
        private double fine;
        private double altezza;

        Thread t1;
        Thread t2;
        Thread t3;
        Thread t4;
        private Stopwatch Cronometro1;
        private Stopwatch Cronometro2;
        private Stopwatch Cronometro3;
        private List<Tuple<string, double>> tempo;

        public MainWindow()
        {
            InitializeComponent();
            inizio = 10;
            fine = 750;
            altezza = 30;


            BitmapImage bitmap1 = new BitmapImage();
            bitmap1.BeginInit();
            bitmap1.UriSource = new Uri("tm.png", UriKind.RelativeOrAbsolute);
            bitmap1.EndInit();
            tm.Source = bitmap1;
            tm.Margin = new Thickness(inizio, altezza + 0, 0, 0);


            BitmapImage bitmap2 = new BitmapImage();
            bitmap2.BeginInit();
            bitmap2.UriSource = new Uri("ovetto.png", UriKind.RelativeOrAbsolute);
            bitmap2.EndInit();
            ovetto.Source = bitmap2;
            ovetto.Margin = new Thickness(inizio, altezza + 120, 0, 0);

            BitmapImage bitmap3 = new BitmapImage();
            bitmap3.BeginInit();
            bitmap3.UriSource = new Uri("panigale.png", UriKind.RelativeOrAbsolute);
            bitmap3.EndInit();
            panigale.Source = bitmap3;
            panigale.Margin = new Thickness(inizio, altezza + 240, 0, 0);

            tempo = new List<Tuple<string, double>>();
            tempo.Add(new Tuple<string, double>("Tm", 0));
            tempo.Add(new Tuple<string, double>("MBK ovetto ", 0));
            tempo.Add(new Tuple<string, double>("Ducati Panigale ", 0));


            t1 = new Thread(new ThreadStart(Metodo1));
            t2 = new Thread(new ThreadStart(Metodo2));
            t3 = new Thread(new ThreadStart(Metodo3));
            t4 = new Thread(new ThreadStart(Metodo4));

            Cronometro1 = new Stopwatch();
            Cronometro2 = new Stopwatch();
            Cronometro3 = new Stopwatch();
        }

        private void Metodo1()
        {
            Cronometro1.Start();
            Sposta1();

        }
        private void Metodo2()
        {
            Cronometro2.Start();
            Sposta2();

        }
        private void Metodo3()
        {
            Cronometro3.Start();
            Sposta3();

        }

        private void Sposta1()
        {

            Random rnd = new Random();
            double ml = 10;


            while (ml < fine)
            {
                this.Dispatcher.BeginInvoke(new Action(() =>
                {
                    ml = tm.Margin.Left;
                    int tmp = rnd.Next(10, 51);
                    tm.Margin = new Thickness(ml + tmp, tm.Margin.Top, 0, 0);

                }));
                Thread.Sleep(rnd.Next(500, 1001));

            }
        }
        private void Sposta2()
        {
            Random rnd = new Random();
            double ml = 10;

            while (ml < fine)
            {
                this.Dispatcher.BeginInvoke(new Action(() =>
                {
                    ml = ovetto.Margin.Left;
                    int tmp = rnd.Next(10, 51);
                    ovetto.Margin = new Thickness(ml + tmp, ovetto.Margin.Top, 0, 0);

                }));
                Thread.Sleep(rnd.Next(500, 1001));

            }
        }
        private void Sposta3()
        {
            Random rnd = new Random();
            double ml = 10;

            while (ml < fine)
            {
                this.Dispatcher.BeginInvoke(new Action(() =>
                {
                    ml = panigale.Margin.Left;
                    int tmp = rnd.Next(10, 51);
                    panigale.Margin = new Thickness(ml + tmp, panigale.Margin.Top, 0, 0);

                }));
                Thread.Sleep(rnd.Next(500, 1001));

            }
        }
        private void btn_init_Click(object sender, RoutedEventArgs e)
        {
            Thread t = new Thread(new ThreadStart(Start));
            t.Start();
        }
    }
}
