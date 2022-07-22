using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPGBattleHelper.Models
{
    public class Atack
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public int HPCost { get; set; }
        public int MPCost { get; set; }
        public int HPRestore { get; set; }
        public int MPRestore { get; set; }
        public int PhysicalDamage { get; set; }
        public int FireDamage { get; set; }
        public int EarthDamage { get; set; }
        public int WindDamage { get; set; }
        public int WaterDamage { get; set; }
    }
}
