using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPGBattleHelper.Models
{
    public class Item
    {
        public int ID { get; set; }
        public int Duration { get; set; }
        public string Name { get; set; }
        public int HPRestore { get; set; }
        public int MPRestore { get; set; }
        public Resistance ResistanceAdd { get; set; }
        public int StrengthAdd { get; set; }
        public int AgilityAdd { get; set; }
        public int IntelligenceAdd { get; set; }
        public int VitalityAdd { get; set; }

        public Item()
        {
            ResistanceAdd = new Resistance();
        }
    }
}
