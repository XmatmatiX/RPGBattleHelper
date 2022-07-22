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

namespace RPGBattleHelper.Views
{
    /// <summary>
    /// Interaction logic for PlayersSetUpView.xaml
    /// </summary>
    public partial class PlayersSetUpView : UserControl
    {
        public List<Character> Players { get; set; }
        public PlayersSetUpView()
        {
            InitializeComponent();
            PlayerLB.ItemsSource = Players;
        }

        public List<Character> GetData()
        {
            return Players;
        }

        public void UpdateData(List<Character> characters)
        {
            Players = characters;
            PlayerLB.ItemsSource = null;
            PlayerLB.ItemsSource = Players;
        }

        private void PlayerLB_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (PlayerLB.Items.Count != 0)
            {
                Character character = (Character)PlayerLB.SelectedItem;
                NameTB.Text = character.Name;
                StrengthTB.Text = character.Strength.ToString();
                AgilityTB.Text = character.Agility.ToString();
                IntelligenceTB.Text = character.Intelligence.ToString();
                VitalityTB.Text = character.Vitality.ToString();
                HPTB.Text = character.HP.ToString();
                MPTB.Text = character.MP.ToString();
                FireResistanceTB.Text = character.Resistance.FireResistance.ToString();
                EarthResistanceTB.Text = character.Resistance.EarthResistance.ToString();
                WindResistanceTB.Text = character.Resistance.WindResistance.ToString();
                WaterResistanceTB.Text = character.Resistance.WaterResistance.ToString();
                ArmorTB.Text = character.Resistance.Armor.ToString();
            }
        }

        private void AddNewBtn_Click(object sender, RoutedEventArgs e)
        {
            Players.Add(new Character() { Name = "New player"});
            PlayerLB.ItemsSource = null;
            PlayerLB.ItemsSource = Players;
        }

        private void SaveBtn_Click(object sender, RoutedEventArgs e)
        {
            if (PlayerLB.SelectedItem != null)
            {
                Players.Remove((Character)PlayerLB.SelectedItem);
                Character character = new Character();
                character.Name = NameTB.Text;
                character.Strength = int.Parse(StrengthTB.Text);
                character.Agility = int.Parse(AgilityTB.Text);
                character.Intelligence = int.Parse(IntelligenceTB.Text);
                character.Vitality = int.Parse(VitalityTB.Text);
                character.HP = int.Parse(HPTB.Text);
                character.MP = int.Parse(MPTB.Text);
                character.Resistance.FireResistance = int.Parse(FireResistanceTB.Text);
                character.Resistance.EarthResistance = int.Parse(EarthResistanceTB.Text);
                character.Resistance.WindResistance = int.Parse(WindResistanceTB.Text);
                character.Resistance.WaterResistance = int.Parse(WaterResistanceTB.Text);
                character.Resistance.Armor = int.Parse(ArmorTB.Text);

                Players.Add(character);

                PlayerLB.ItemsSource = null;
                PlayerLB.ItemsSource = Players;
            }
        }

        private void DeleteBtn_Click(object sender, RoutedEventArgs e)
        {
            if (PlayerLB.SelectedItem!= null)
            {
                Players.Remove((Character)PlayerLB.SelectedItem);
                PlayerLB.ItemsSource = null;
                PlayerLB.ItemsSource = Players;
            }
        }
    }
}
