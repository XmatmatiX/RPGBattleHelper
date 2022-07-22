using RPGBattleHelper.Models;
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

namespace RPGBattleHelper
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public List<Character> Players = new List<Character>();
        public List<Character> Enemies = new List<Character>();
        

        public MainWindow()
        {
            InitializeComponent();
            
        }


        private void PlayerSetUpBtn_Click(object sender, RoutedEventArgs e)
        {
            StartV.Visibility = Visibility.Hidden;
            AddEnemyV.Visibility = Visibility.Hidden;
            FightV.Visibility = Visibility.Hidden;
            PlayerSetUpV.Visibility = Visibility.Visible;
        }

        private void AddEnemyBtn_Click(object sender, RoutedEventArgs e)
        {
            StartV.Visibility = Visibility.Hidden;
            PlayerSetUpV.Visibility = Visibility.Hidden;
            FightV.Visibility = Visibility.Hidden;
            AddEnemyV.Visibility = Visibility.Visible;
        }

        private void FightBtn_Click(object sender, RoutedEventArgs e)
        {
            StartV.Visibility = Visibility.Hidden;
            PlayerSetUpV.Visibility = Visibility.Hidden;
            AddEnemyV.Visibility = Visibility.Hidden;
            FightV.Visibility = Visibility.Visible;
        }

        private void PlayerSetUpV_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            if (PlayerSetUpV.Visibility == Visibility.Visible)
            {
                PlayerSetUpV.UpdateData(Players);
            }
            else
            {
                Players = PlayerSetUpV.GetData();
            }
        }

        private void AddEnemyV_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            if (AddEnemyV.Visibility == Visibility.Visible)
            {
                AddEnemyV.UpdateData(Enemies);
            }
            else
            {
                Enemies = AddEnemyV.GetData();
            }
        }

        private void FightV_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            if (FightV.Visibility == Visibility.Visible)
            {
                FightV.UpdateData(Players, Enemies);
            }
            else
            {
                Players = FightV.GetPlayers();
                Enemies = FightV.GetEnemies();
            }
        }
    }
}
