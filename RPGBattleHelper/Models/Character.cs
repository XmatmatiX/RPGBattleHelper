using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace RPGBattleHelper.Models
{
    public class Character
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public int Strength { get; set; }
        public int Agility { get; set; }
        public int Intelligence { get; set; }
        public int Vitality { get; set; }
        public int HP { get; set; }
        public int MP { get; set; }
        public int MaxHP
        {
            get { return Vitality * 5; }
        }
        public int MaxMP
        {
            get { return Intelligence * 5; }
        }
        public Resistance Resistance { get; set; }
        public List<Item> Items { get; set; }


        public Character()
        {
            Resistance = new Resistance();
            Items = new List<Item>();
        }

        public SolidColorBrush HPBarColor
        {
            get
            {
                if (MaxHP>0)
                {
                    if (HP * 100 / MaxHP <= 5)
                    {
                        return Brushes.Red;
                    }
                    else if (HP * 100 / MaxHP <= 15)
                    {
                        return Brushes.Yellow;
                    }
                    else
                    {
                        return Brushes.Green;
                    }
                }
                return Brushes.Red;
            }
        }

        public SolidColorBrush MPBarColor
        {
            get
            {
                if (MaxMP>0)
                {
                    if (MP * 100 / MaxMP <= 10)
                    {
                        return Brushes.Red;
                    }
                    else if (MP * 100 / MaxMP <= 20)
                    {
                        return Brushes.Yellow;
                    }
                    else
                    {
                        return Brushes.Blue;
                    }
                }
                return Brushes.Red;
            }
        }



    }
}
