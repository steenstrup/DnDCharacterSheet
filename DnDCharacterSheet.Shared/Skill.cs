using System;

namespace DnDCharacterSheet.Shared
{
    public class Skill
    {
        public Skill() { }

        public Skill(string decription, Stat stat, int profesion, int expert)
        {
            if (decription == null || decription == "")
                throw new ArgumentException("decription not valid");

            if (stat == null)
                throw new ArgumentException("stat not sat");

            if (profesion < 0)
                throw new ArgumentException("profesion can not be negative");

            if (expert < 0 || expert > 2)
                throw new ArgumentException("expert can only be 0, 1 or, 2");

            Decription = decription;
            Stat = stat;
            Profesion = profesion;
            Expert = expert;
        }

        public string Decription { get; set; }
        public Stat Stat { get; set; }
        public int Profesion { get; set; }
        public int Expert { get; set; }
        
        public int GetPoints()
        {
            return Stat.GetBonus() + Expert * Profesion;
        }
    }
}
