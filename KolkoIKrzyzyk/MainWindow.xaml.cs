using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace KolkoIKrzyzyk
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    /// 
    public partial class MainWindow : Window
    {
        public bool IsPlayerTurn { get; set; }

        public int Counter { get; set; }

        private int PointsX { get; set; }
        private int PointsO { get; set; }

        public MainWindow()
        {
            InitializeComponent();
            NewGame();
        }

        public void NewGame()
        {
            IsPlayerTurn = false;
            Counter = 0;

            Button1.Content = string.Empty;
            Button2.Content = string.Empty;
            Button3.Content = string.Empty;
            Button4.Content = string.Empty;
            Button5.Content = string.Empty;
            Button6.Content = string.Empty;
            Button7.Content = string.Empty;
            Button8.Content = string.Empty;
            Button9.Content = string.Empty;
            
            Button1.Background = Brushes.LightGray;
            Button2.Background = Brushes.LightGray;
            Button3.Background = Brushes.LightGray;
            Button4.Background = Brushes.LightGray;
            Button5.Background = Brushes.LightGray;
            Button6.Background = Brushes.LightGray;
            Button7.Background = Brushes.LightGray;
            Button8.Background = Brushes.LightGray;
            Button9.Background = Brushes.LightGray;


        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            IsPlayerTurn = !IsPlayerTurn;
            Counter++;

            if (Counter > 9)
            {
                ShowTieMessage();
                return;
            }

            var button = sender as Button;

            button.Content = IsPlayerTurn ? "X" : "O";

            if (WinCheck())
            {
                Counter = 9;

                if (IsPlayerTurn)
                {
                    PointsX++;
                }
                else
                {
                    PointsO++;
                }

                ShowWinnerMessage(IsPlayerTurn ? "Gracz X" : "Gracz O");
                UpdatePointsLabels();
            }
        }

        private bool WinCheck()
        {
            if(Button1.Content.ToString() != string.Empty && Button1.Content == Button2.Content && Button2.Content == Button3.Content)
            {
                Button1.Background = Brushes.Green;
                Button2.Background = Brushes.Green;
                Button3.Background = Brushes.Green;
                return true;
            }            
            
            if(Button4.Content.ToString() != string.Empty && Button4.Content == Button5.Content && Button5.Content == Button6.Content)
            {
                Button4.Background = Brushes.Green;
                Button5.Background = Brushes.Green;
                Button6.Background = Brushes.Green;
                return true;
            }            
            
            if(Button7.Content.ToString() != string.Empty && Button7.Content == Button8.Content && Button8.Content == Button9.Content)
            {
                Button7.Background = Brushes.Green;
                Button8.Background = Brushes.Green;
                Button9.Background = Brushes.Green;
                return true;
            }            
            
            if(Button1.Content.ToString() != string.Empty && Button1.Content == Button4.Content && Button4.Content == Button7.Content)
            {
                Button1.Background = Brushes.Green;
                Button4.Background = Brushes.Green;
                Button7.Background = Brushes.Green;
                return true;
            }            
            
            if(Button2.Content.ToString() != string.Empty && Button2.Content == Button5.Content && Button5.Content == Button8.Content)
            {
                Button2.Background = Brushes.Green;
                Button5.Background = Brushes.Green;
                Button8.Background = Brushes.Green;
                return true;
            }            
            
            if(Button3.Content.ToString() != string.Empty && Button3.Content == Button6.Content && Button6.Content == Button9.Content)
            {
                Button3.Background = Brushes.Green;
                Button6.Background = Brushes.Green;
                Button9.Background = Brushes.Green;
                return true;
            }            
            
            if(Button1.Content.ToString() != string.Empty && Button1.Content == Button5.Content && Button5.Content == Button9.Content)
            {
                Button1.Background = Brushes.Green;
                Button5.Background = Brushes.Green;
                Button9.Background = Brushes.Green;
                return true;
            }            
            
            if(Button3.Content.ToString() != string.Empty && Button3.Content == Button5.Content && Button5.Content == Button7.Content)
            {
                Button3.Background = Brushes.Green;
                Button5.Background = Brushes.Green;
                Button7.Background = Brushes.Green;
                return true;
            }
            return false;
        }

        private void UpdatePointsLabels()
        {
            points1.Content = "Punkty X: " + PointsX;
            points2.Content = "Punkty O: " + PointsO;
        }

        private void ShowWinnerMessage(string winner)
        {
            MessageBox.Show($"Zwyciężył {winner}!", "Koniec gry", MessageBoxButton.OK);
            NewGame();
        }

        private void ShowTieMessage()
        {
            MessageBox.Show("Remis! Gra zakończona bez zwycięzcy.", "Koniec gry", MessageBoxButton.OK);
            NewGame();
        }
    }
}
