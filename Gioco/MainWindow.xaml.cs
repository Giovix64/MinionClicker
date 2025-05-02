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

namespace Gioco
{

    /// <summary>
    /// Logica di interazione per MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Label L1;
        int Conta = 0;
        int Punti = 1;
        Button B1;
        DispatcherTimer dt;
        Label L2;
        Random rnd = new Random();
        int rig,  col;
        bool[,] matrice = new bool[4, 4];

        public MainWindow()
        {

            Button B2;
            InitializeComponent();
                     
            for (int i = 0; i < 3; i++)
            {
                G1.ColumnDefinitions.Add(new ColumnDefinition() { Width=new GridLength(3, GridUnitType.Star)});
            }
            G1.RowDefinitions.Add(new RowDefinition());
            for (int i = 0; i < 3; i++)
            {
                G1.RowDefinitions.Add(new RowDefinition());
            }
           
            G1.Background = Brushes.BlanchedAlmond;
            B1 = new Button();
            B1.Content = new Image() {Source = new BitmapImage(new Uri("images/minion.jpg", UriKind.Relative))};
            Grid.SetRow(B1, 1);
            B2 = new Button();
            B2.Content = "START!";
            Grid.SetRow(B2, 0);
            Grid.SetColumn(B2, 1);
            G1.Children.Add(B1);
            G1.Children.Add(B2);
            dt = new DispatcherTimer();
            dt.Interval = TimeSpan.FromMilliseconds(500);
            dt.Tick += dt_Tick;
            B2.Click += B2_Click;
            L1 = new Label();
            Grid.SetRow(L1, 0);
            Grid.SetColumn(L1, 0);
            G1.Children.Add(L1);
            L1.Content = 0;
            L1.Background = Brushes.Lavender;
            L2 = new Label();
            L2.Background = Brushes.Lavender;
            //L1.HorizontalAlignment = HorizontalAlignment.Center;
            //L2.VerticalAlignment = VerticalAlignment.Center;
            Grid.SetRow(B1, 1);
            Grid.SetColumn(L2, 2);
            Grid.SetRow(L2, 0);
            L2.Content = "Punteggio: 0";
            G1.Children.Add(L2);
            B1.Click += B1_Click;
            L1.FontSize = 20;
            L2.FontSize = 20;
        }

        void B1_Click(object sender, RoutedEventArgs e)
        {
            
            L2.Content = "Punteggio: " +  Punti++;
            if (Punti == 10)
            {
                this.Close();
                MessageBox.Show("Hai Vinto! :)", "Vittoria", MessageBoxButton.OK, MessageBoxImage.Information);
                
            }
                
            matrice[rig, col] = true;
            Image im = new Image() { Source = new BitmapImage(new Uri("images/x.png", UriKind.Relative)) };
            G1.Children.Add(im);
            Grid.SetRow(im, rig);
            Grid.SetColumn(im, col);
        }
        void dt_Tick(object sender, EventArgs e)
        {
            do{
            col = rnd.Next(0, 3);
            rig = rnd.Next(1, 4);
            }while(matrice[rig, col]==true);

            L1.Content = "Tempo: " +  Conta++;
            Grid.SetColumn(B1, col);
            Grid.SetRow(B1, rig);
        }
        void B2_Click(object sender, RoutedEventArgs e)
        {
            dt.Start();
        }
    }
}
