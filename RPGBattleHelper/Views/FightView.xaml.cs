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
    /// Interaction logic for FightView.xaml
    /// </summary>
    public partial class FightView : UserControl
    {
        public List<Character> Players { get; set; }
        public List<Character> Enemies { get; set; }
        public List<Atack> Atacks = new List<Atack>();
        public List<Item> Items = new List<Item>();

        public FightView()
        {
            InitializeComponent();

            CreateAtackLibrary();
            CreateItemLibrary();

            PlayersLB.ItemsSource = Players;
            EnemiesLB.ItemsSource = Enemies;
            AtackCB.ItemsSource = Atacks.Select(a => a.Name).ToList();
            ItemCB.ItemsSource = Items.Select(i => i.Name).ToList();
        }

        #region MainWindow
        public void UpdateData(List<Character> Player, List<Character> Enemy)
        {
            Players = Player;
            Enemies = Enemy;

            PlayersLB.ItemsSource = null;
            PlayersLB.ItemsSource = Players;
            EnemiesLB.ItemsSource = null;
            EnemiesLB.ItemsSource = Enemies;
        }
        public List<Character> GetPlayers()
        {
            return Players;
        }

        public List<Character> GetEnemies()
        {
            return Enemies;
        }
        #endregion


        #region Atack
        private void CreateAtackLibrary()
        {
            #region Physical
            Atacks.Add(new Atack()
            {
                Name = "Kopniak(2)",
                PhysicalDamage = 2
            });
            Atacks.Add(new Atack()
            {
                Name = "Atak pięścią(3)",
                PhysicalDamage = 3
            });
            Atacks.Add(new Atack()
            {
                Name = "Duszenie(5)",
                PhysicalDamage = 5
            });
            Atacks.Add(new Atack()
            {
                Name = "Laga(4)",
                PhysicalDamage = 4
            });
            Atacks.Add(new Atack()
            {
                Name = "Nóż myśliwski(5)",
                PhysicalDamage = 5
            });
            Atacks.Add(new Atack()
            {
                Name = "Miecz strażnika(6)",
                PhysicalDamage = 6
            });
            Atacks.Add(new Atack()
            {
                Name = "Nóż kuchenny(4)",
                PhysicalDamage = 4
            });
            Atacks.Add(new Atack()
            {
                Name = "Improwizowana broń: krótka (3)",
                PhysicalDamage = 3
            });
            Atacks.Add(new Atack()
            {
                Name = "Improwizowana broń: długa (4)",
                PhysicalDamage = 4
            });
            Atacks.Add(new Atack()
            {
                Name = "Improwizowana broń: miotana(2)",
                PhysicalDamage = 2
            });
            Atacks.Add(new Atack()
            {
                Name = "Pochodnia(2+2)",
                PhysicalDamage = 2,
                FireDamage = 2
            });
            Atacks.Add(new Atack()
            {
                Name = "Wilk: pazury(3)",
                PhysicalDamage = 3
            });
            Atacks.Add(new Atack()
            {
                Name = "Wilk: Ugryzienie(4)",
                PhysicalDamage = 4
            });
            #endregion

            #region Magic
            Atacks.Add(new Atack()
            {
                Name = "Fireball(5)(5)",
                FireDamage = 5,
                MPCost = 5
            });
            Atacks.Add(new Atack()
            {
                Name = "Improwizowana magia: ogień(3)(5)",
                FireDamage = 3,
                MPCost = 5
            });
            Atacks.Add(new Atack()
            {
                Name = "Improwizowana magia: woda(3)(5)",
                WaterDamage = 3,
                MPCost = 5
            });
            Atacks.Add(new Atack()
            {
                Name = "Improwizowana magia: ziemia(3)(5)",
                EarthDamage = 3,
                MPCost = 5
            });
            Atacks.Add(new Atack()
            {
                Name = "Improwizowana magia: powietrze(3)(5)",
                WindDamage = 3,
                MPCost = 5
            });
            #endregion

            #region Trap

            #endregion
        }

        private Character TakeDamage(Character character, Atack atack)
        {
            int multiplier = AtackMultiplierCB.SelectedIndex + 1;
            if (character.Resistance.Armor < atack.PhysicalDamage *multiplier)
                character.HP = character.HP - (atack.PhysicalDamage * multiplier) + character.Resistance.Armor;

            if (character.Resistance.WaterResistance < atack.WaterDamage * multiplier)
                character.HP = character.HP - (atack.WaterDamage * multiplier) + character.Resistance.WaterResistance;

            if (character.Resistance.FireResistance < atack.FireDamage * multiplier)
                character.HP = character.HP - (atack.FireDamage * multiplier) + character.Resistance.FireResistance;

            if (character.Resistance.EarthResistance < atack.EarthDamage * multiplier)
                character.HP = character.HP - (atack.EarthDamage * multiplier) + character.Resistance.EarthResistance;

            if (character.Resistance.WindResistance < atack.WindDamage * multiplier)
                character.HP = character.HP - (atack.WindDamage * multiplier) + character.Resistance.WindResistance;
            character.HP += (atack.HPRestore * multiplier);
            character.MP += (atack.MPRestore * multiplier);

            if (character.HP > character.MaxHP)
            {
                character.HP = character.MaxHP;
            }
            if (character.MP > character.MaxMP)
            {
                character.MP = character.MaxMP;
            }
            return character;
        }

        private Character TakeResources(Character character, Atack atack, out bool IsCasted)
        {
            IsCasted = true;
            character.HP -= atack.HPCost;
            character.MP -= atack.MPCost;

            if (character.HP <= 0)
            {
                character.HP = 0;
                IsCasted = false;
            }
            if (character.MP < 0)
            {
                character.MP = 0;
                IsCasted = false;
            }

            return character;
        }

        private void AtackBtn_Click(object sender, RoutedEventArgs e)
        {
            if (AtackCB.SelectedItem != null)
            {
                Atack atack = Atacks.Where(a => a.Name == AtackCB.SelectedItem.ToString()).FirstOrDefault();
                if (EnemiesLB.SelectedItem != null)
                {
                    Character Enemy = Enemies.Where(e => e == (Character)EnemiesLB.SelectedItem).FirstOrDefault();
                    Enemies.Remove(Enemy);
                    Enemies.Add(TakeDamage(Enemy, atack));
                }
                else if (PlayersLB.SelectedItem != null)
                {
                    Character Player = Players.Where(e => e == (Character)PlayersLB.SelectedItem).FirstOrDefault();
                    Players.Remove(Player);
                    Players.Add(TakeDamage(Player, atack));
                }
                AtackCB.SelectedItem = null;

                CastRct.Fill = Brushes.White;

                PlayersLB.ItemsSource = null;
                PlayersLB.ItemsSource = Players;
                EnemiesLB.ItemsSource = null;
                EnemiesLB.ItemsSource = Enemies;
            }
        }

        private void PlayersLB_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (PlayersLB.SelectedItem != null)
            {
                EnemiesLB.SelectedItem = null;
            }
        }

        private void EnemiesLB_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (EnemiesLB.SelectedItem != null)
            {
                PlayersLB.SelectedItem = null;
            }
        }

        private void ResourceBtn_Click(object sender, RoutedEventArgs e)
        {
            if (AtackCB.SelectedItem != null)
            {
                bool IsCasted = true;
                Atack atack = Atacks.Where(a => a.Name == AtackCB.SelectedItem.ToString()).FirstOrDefault();
                if (EnemiesLB.SelectedItem != null)
                {
                    Character Enemy = Enemies.Where(e => e == (Character)EnemiesLB.SelectedItem).FirstOrDefault();
                    Enemies.Remove(Enemy);
                    Enemies.Add(TakeResources(Enemy, atack, out IsCasted));
                }
                else if (PlayersLB.SelectedItem != null)
                {
                    Character Player = Players.Where(e => e == (Character)PlayersLB.SelectedItem).FirstOrDefault();
                    Players.Remove(Player);
                    Players.Add(TakeResources(Player, atack, out IsCasted));
                }

                if (IsCasted)
                {
                    CastRct.Fill = Brushes.Green;
                }
                else
                {
                    CastRct.Fill = Brushes.Red;
                }

                PlayersLB.ItemsSource = null;
                PlayersLB.ItemsSource = Players;
                EnemiesLB.ItemsSource = null;
                EnemiesLB.ItemsSource = Enemies;
            }
        }

        #endregion


        #region Items

        private void CreateItemLibrary()
        {
            Items.Add(new Item()
            {
                Name = "Small HP Potion",
                HPRestore = 10
            });

            Items.Add(new Item()
            {
                Name = "Small MP Potion",
                MPRestore = 10
            });

            Items.Add(new Item()
            {
                Name = "Fire Potion",
                ResistanceAdd = new Resistance()
                {
                    FireResistance = 10
                },
                Duration = 5
            });

            Items.Add(new Item()
            {
                Name = "Alcohol",
                AgilityAdd = -5,
                Duration = 10
            });

            Items.Add(new Item()
            {
                Name = "Life Water",
                VitalityAdd =3,
                HPRestore = 15,
                Duration = 3
            });
        }

        public void ItemUseBtn_Click(object sender, RoutedEventArgs e)
        {
            if (ItemCB.SelectedItem != null)
            {
                Item item = Items.Where(i => i.Name == ItemCB.SelectedItem.ToString()).First();

                Item newItem = new Item();

                newItem.Name = item.Name;
                newItem.Duration = item.Duration;
                newItem.HPRestore = item.HPRestore;
                newItem.MPRestore = item.MPRestore;
                newItem.ResistanceAdd.Armor = item.ResistanceAdd.Armor;
                newItem.ResistanceAdd.FireResistance = item.ResistanceAdd.FireResistance;
                newItem.ResistanceAdd.EarthResistance = item.ResistanceAdd.EarthResistance;
                newItem.ResistanceAdd.WindResistance = item.ResistanceAdd.WindResistance;
                newItem.ResistanceAdd.WaterResistance = item.ResistanceAdd.WaterResistance;
                newItem.StrengthAdd = item.StrengthAdd;
                newItem.AgilityAdd = item.AgilityAdd;
                newItem.IntelligenceAdd = item.IntelligenceAdd;
                newItem.VitalityAdd = item.VitalityAdd;

                if (PlayersLB.SelectedItem != null)
                {
                    Character player = (Character)PlayersLB.SelectedItem;
                    player.Items.Add(newItem);

                    player = AddEffect(player, newItem);

                    PlayersLB.ItemsSource = null;
                    PlayersLB.ItemsSource = Players;
                }
                if (EnemiesLB.SelectedItem != null)
                {
                    Character enemy = (Character)EnemiesLB.SelectedItem;
                    enemy.Items.Add(newItem);

                    enemy = AddEffect(enemy, newItem);

                    EnemiesLB.ItemsSource = null;
                    EnemiesLB.ItemsSource = Enemies;
                }
            }
        }

        private Character AddEffect(Character character, Item item)
        {
            character.Strength += item.StrengthAdd;
            character.Agility += item.AgilityAdd;
            character.Intelligence += item.IntelligenceAdd;
            character.Vitality += item.VitalityAdd;
            character.Resistance.FireResistance += item.ResistanceAdd.FireResistance;
            character.Resistance.EarthResistance += item.ResistanceAdd.EarthResistance;
            character.Resistance.WaterResistance += item.ResistanceAdd.WaterResistance;
            character.Resistance.WindResistance += item.ResistanceAdd.WindResistance;
            character.Resistance.Armor += item.ResistanceAdd.Armor;

            character.HP += item.HPRestore;
            character.MP += item.MPRestore;

            if (character.HP > character.MaxHP)
            {
                character.HP = character.MaxHP;
            }

            if (character.MP > character.MaxMP)
            {
                character.MP = character.MaxMP;
            }

            return character;
        }

        private void EndTurnBtn_Click(object sender, RoutedEventArgs e)
        {
            List<Item> items;
            foreach (var character in Players)
            {
                items = new List<Item>();
                foreach (var item in character.Items)
                {
                    if (item.Duration <= 0)
                    {
                        items.Add(item);
                    }
                    else
                    {
                        item.Duration--;
                    }
                }

                foreach (var item in items)
                {
                    character.Strength -= item.StrengthAdd;
                    character.Agility -= item.AgilityAdd;
                    character.Intelligence -= item.IntelligenceAdd;
                    character.Vitality -= item.VitalityAdd;
                    character.Resistance.FireResistance -= item.ResistanceAdd.FireResistance;
                    character.Resistance.EarthResistance -= item.ResistanceAdd.EarthResistance;
                    character.Resistance.WaterResistance -= item.ResistanceAdd.WaterResistance;
                    character.Resistance.WindResistance -= item.ResistanceAdd.WindResistance;
                    character.Resistance.Armor -= item.ResistanceAdd.Armor;

                    if (character.HP > character.MaxHP)
                    {
                        character.HP = character.MaxHP;
                    }

                    if (character.MP > character.MaxMP)
                    {
                        character.MP = character.MaxMP;
                    }
                    character.Items.Remove(item);
                }

            }
            foreach (var character in Enemies)
            {
                items = new List<Item>();
                foreach (var item in character.Items)
                {
                    if (item.Duration <= 0)
                    {
                        items.Add(item);
                    }
                    else
                    {
                        item.Duration--;
                    }
                }

                foreach (var item in items)
                {
                    character.Strength -= item.StrengthAdd;
                    character.Agility -= item.AgilityAdd;
                    character.Intelligence -= item.IntelligenceAdd;
                    character.Vitality -= item.VitalityAdd;
                    character.Resistance.FireResistance -= item.ResistanceAdd.FireResistance;
                    character.Resistance.EarthResistance -= item.ResistanceAdd.EarthResistance;
                    character.Resistance.WaterResistance -= item.ResistanceAdd.WaterResistance;
                    character.Resistance.WindResistance -= item.ResistanceAdd.WindResistance;
                    character.Resistance.Armor -= item.ResistanceAdd.Armor;

                    if (character.HP > character.MaxHP)
                    {
                        character.HP = character.MaxHP;
                    }

                    if (character.MP > character.MaxMP)
                    {
                        character.MP = character.MaxMP;
                    }
                    character.Items.Remove(item);
                }

            }

            PlayersLB.ItemsSource = null;
            PlayersLB.ItemsSource = Players;

            EnemiesLB.ItemsSource = null;
            EnemiesLB.ItemsSource = Enemies;

        }

        #endregion

    }
}
