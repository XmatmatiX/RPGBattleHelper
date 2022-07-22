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
    /// Interaction logic for AddEnemyView.xaml
    /// </summary>
    public partial class AddEnemyView : UserControl
    {
        public List<Character> EnemyLibrary = new List<Character>();
        public List<Character> Enemies { get; set; }
        public AddEnemyView()
        {
            InitializeComponent();
            CreateLibrary();
            EnemyLibraryLB.ItemsSource = EnemyLibrary;
            EnemiesLB.ItemsSource = Enemies;
        }

        private void EnemyLibraryLB_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (EnemyLibraryLB.SelectedItem != null)
            {
                EnemiesLB.SelectedItem = null;

                Character character = (Character)EnemyLibraryLB.SelectedItem;
                StrengthTB.Text = "Strength: " + character.Strength.ToString();
                AgilityTB.Text = "Agility: " + character.Agility.ToString();
                IntelligenceTB.Text = "Intelligence: " + character.Intelligence.ToString();
                VitalityTB.Text = "Vitality: " + character.Vitality.ToString();
                HPTB.Text = "HP: " + character.HP.ToString();
                MPTB.Text = "MP: " + character.MP.ToString();
                FireResistanceTB.Text = "FireResistance: " + character.Resistance.FireResistance.ToString();
                EarthResistanceTB.Text = "EarthResistance: " + character.Resistance.EarthResistance.ToString();
                WindResistanceTB.Text = "WindResistance: " + character.Resistance.WindResistance.ToString();
                WaterResistanceTB.Text = "WaterResistance: " + character.Resistance.WaterResistance.ToString();
                ArmorTB.Text = "Armor: " + character.Resistance.Armor.ToString();
            }
        }

        private void CreateLibrary()
        {
            EnemyLibrary.Add(new Character()
            {
                Name = "Goblin",
                Strength = 3,
                Agility = 5,
                Intelligence = 2,
                Vitality = 3,
                HP = 15,
                MP = 10,
                Resistance = new Resistance()
                {
                    FireResistance = 0,
                    EarthResistance = 0,
                    WindResistance = 0,
                    WaterResistance = 0,
                    Armor = 1
                }
            });
            EnemyLibrary.Add(new Character()
            {
                Name = "Goblin Shaman",
                Strength = 2,
                Agility = 3,
                Intelligence = 8,
                Vitality = 2,
                HP = 10,
                MP = 40,
                Resistance = new Resistance()
                {
                    FireResistance = 2,
                    EarthResistance = 2,
                    WindResistance = 2,
                    WaterResistance = 2,
                    Armor = 0
                }
            });
            EnemyLibrary.Add(new Character()
            {
                Name = "Goblin Warior",
                Strength = 5,
                Agility = 3,
                Intelligence = 2,
                Vitality = 4,
                HP = 20,
                MP = 10,
                Resistance = new Resistance()
                {
                    FireResistance = 0,
                    EarthResistance = 0,
                    WindResistance = 0,
                    WaterResistance = 0,
                    Armor = 3
                }
            });
            EnemyLibrary.Add(new Character()
            {
                Name = "Goblin Archer",
                Strength = 2,
                Agility = 5,
                Intelligence = 3,
                Vitality = 3,
                HP = 15,
                MP = 15,
                Resistance = new Resistance()
                {
                    FireResistance = 0,
                    EarthResistance = 0,
                    WindResistance = 0,
                    WaterResistance = 0,
                    Armor = 0
                }
            });
            EnemyLibrary.Add(new Character()
            {
                Name = "Wolf",
                Strength = 4,
                Agility = 6,
                Intelligence = 3,
                Vitality = 5,
                HP = 25,
                MP = 15,
                Resistance = new Resistance()
                {
                    FireResistance = 0,
                    EarthResistance = 0,
                    WindResistance = 0,
                    WaterResistance = 0,
                    Armor = 2
                }
            });

        }

        private void AddBtn_Click(object sender, RoutedEventArgs e)
        {
            if (EnemyLibraryLB.SelectedItem != null)
            {
                Character enemy = new Character();
                enemy = (Character)EnemyLibraryLB.SelectedItem;
                Enemies.Add(new Character() 
                {
                    Name = enemy.Name,
                    Strength = enemy.Strength,
                    Agility = enemy.Agility,
                    Intelligence = enemy.Intelligence,
                    Vitality = enemy.Vitality,
                    HP = enemy.HP,
                    MP = enemy.MP,
                    Resistance = new Resistance()
                    {
                        FireResistance = enemy.Resistance.FireResistance,
                        EarthResistance = enemy.Resistance.EarthResistance,
                        WindResistance = enemy.Resistance.WindResistance,
                        WaterResistance = enemy.Resistance.WaterResistance,
                        Armor = enemy.Resistance.Armor
                    }
                });
                EnemiesLB.ItemsSource = null;
                EnemiesLB.ItemsSource = Enemies;

            }
        }

        private void DeleteBtn_Click(object sender, RoutedEventArgs e)
        {
            if (EnemiesLB.SelectedItem != null)
            {
                Enemies.Remove((Character)EnemiesLB.SelectedItem);
                EnemiesLB.ItemsSource = null;
                EnemiesLB.ItemsSource = Enemies;
            }
        }

        private void EnemiesLB_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (EnemiesLB.SelectedItem != null)
            {
                EnemyLibraryLB.SelectedItem = null;

                Character character = (Character)EnemiesLB.SelectedItem;
                StrengthTB.Text = "Strength: " + character.Strength.ToString();
                AgilityTB.Text = "Agility: " + character.Agility.ToString();
                IntelligenceTB.Text = "Intelligence: " + character.Intelligence.ToString();
                VitalityTB.Text = "Vitality: " + character.Vitality.ToString();
                HPTB.Text = "HP: " + character.HP.ToString();
                MPTB.Text = "MP: " + character.MP.ToString();
                FireResistanceTB.Text = "FireResistance: " + character.Resistance.FireResistance.ToString();
                EarthResistanceTB.Text = "EarthResistance: " + character.Resistance.EarthResistance.ToString();
                WindResistanceTB.Text = "WindResistance: " + character.Resistance.WindResistance.ToString();
                WaterResistanceTB.Text = "WaterResistance: " + character.Resistance.WaterResistance.ToString();
                ArmorTB.Text = "Armor: " + character.Resistance.Armor.ToString();
            }
        }

        public void UpdateData(List<Character> characters)
        {
            Enemies = characters;
            EnemiesLB.ItemsSource = null;
            EnemiesLB.ItemsSource = Enemies;
        }

        public List<Character> GetData()
        {
            return Enemies;
        }

    }
}
