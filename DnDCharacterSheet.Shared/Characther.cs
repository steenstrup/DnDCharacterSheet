using System.Collections.Generic;
using System.Linq;

namespace DnDCharacterSheet.Shared
{
    public class Characther
    {
        public Characther() { }
        public int id { get; set; }
        public string Name { get; set; } = "No Name";
        public string PlayerName { get; set; }
        public string Race { get; set; }
        public int ProfBonus { get; set; }
        public int ArmorClass { get; set; }
        public int Initiative { get; set; }
        public int Speed { get; set; }
        public int HitPoint { get; set; }
        public int PassivePerception { get; set; }
        public int HitDice { get; set; }
        public int Luck { get; set; }
        public string ImageUrl { get; set; }
        public string Background { get; set; }
        public List<Skill> Skills { get; set; } = new List<Skill>();
        public List<Stat> Stats { get; set; } = new List<Stat>();
        public List<SavingThrow> SavingThrows { get; set; } = new List<SavingThrow>();
        public List<Class> Classes { get; set; } = new List<Class>();
        public List<string> Languages { get; set; } = new List<string>();
        public List<string> FeaturesAndTrains { get; set; } = new List<string>();
        public List<Equipment> Equipment { get; set; } = new List<Equipment>();

        public int AttackBonus => ProfBonus + Stats.Where(x => x.Type == STATEnum.DEX ||
        x.Type == STATEnum.Str).Select(x => x.GetBonus()).Max();
        public List<Equipment> Weapon => Equipment.Where(x => x.Damage != null).ToList();
        public List<Equipment> Armor => Equipment.Where(x => x.Ac != 0).ToList();
        public List<Equipment> AdverturGear => Equipment.Where(x => x.Ac == 0 && x.Damage == null).ToList();


        public string GetClassseOverview()
        {
            var res = "";
            foreach (var c in Classes)
                res += c.Name + " " + c.Level + " ";

            return res;
        }
    }
}