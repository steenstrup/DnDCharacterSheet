using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DnDCharacterSheet.Shared;

namespace DnDCharacterSheet.Server.Controllers
{
    public static class MockCharactherRepository
    {

        private static Characther Farson()
        {
            var prof = 4;

            var stats = new List<Stat>
                {
                    new Stat(STATEnum.Str, 15),
                    new Stat(STATEnum.CON, 14),
                    new Stat(STATEnum.DEX, 18),
                    new Stat(STATEnum.INT, 14),
                    new Stat(STATEnum.WIS, 12),
                    new Stat(STATEnum.CHA, 16)
                };

            var strState = stats.Where(x => x.Type == STATEnum.Str).First();
            var dexState = stats.Where(x => x.Type == STATEnum.DEX).First();
            var intState = stats.Where(x => x.Type == STATEnum.INT).First();
            var wisState = stats.Where(x => x.Type == STATEnum.WIS).First();
            var chaState = stats.Where(x => x.Type == STATEnum.CHA).First();
            var conState = stats.Where(x => x.Type == STATEnum.CON).First();

            var skills = new List<Skill>
                {
                    new Skill("Athletics", strState, prof, 2),
                    new Skill("Acrobatics", dexState, prof, 2),
                    new Skill("Sleight of Hand", dexState, prof, 1),
                    new Skill("Stealth", dexState, prof, 1),

                    new Skill("Arcana", intState, prof, 0),
                    new Skill("History", intState, prof, 0),
                    new Skill("Investifation", intState, prof, 0),
                    new Skill("Nature", intState, prof, 0),
                    new Skill("Religion", intState, prof, 0),

                    new Skill("Animal Handling", wisState, prof, 0),
                    new Skill("Insight", wisState, prof, 0),
                    new Skill("Medicine", wisState, prof, 0),
                    new Skill("Perception", wisState, prof, 1),
                    new Skill("Survival", wisState, prof, 1),

                    new Skill("Deception", chaState, prof, 0),
                    new Skill("Intimidation", chaState, prof, 0),
                    new Skill("Performance", chaState, prof, 1),
                    new Skill("Persuasion", chaState, prof, 1),
                };

            var savingThrows = new List<SavingThrow>
            {
                new SavingThrow("Str", strState, prof, 0, 1),
                new SavingThrow("Dex", dexState, prof, 1, 1),
                new SavingThrow("Con", conState, prof, 0, 1),
                new SavingThrow("Int", intState, prof, 1, 1),
                new SavingThrow("Con", wisState, prof, 0, 1),
                new SavingThrow("Con", chaState, prof, 0, 1)

            };

            var classes = new List<Class>
            {
                new Class("Rough", 5),
                new Class("Figther", 5)
            };


            var loadEquipment = EquipmentsBuilder.DefualdEquipmentBuilder().LoadAllItems().Build();

            var equipment = new List<Equipment>
            {
                    loadEquipment.Where(x => x.Name == "Lucky Rapier").First(),
                    loadEquipment.Where(x => x.Name == "Dagger").First(),
                    loadEquipment.Where(x => x.Name == "Shield").First(),
                    loadEquipment.Where(x => x.Name == "Studded leather").First(),
                    new Equipment("Potion(1): Protection from Evil", BodySlots.Backpack, 0, 0).AdventuringGear(),
                    new Equipment("Potion(1): Fire resistens", BodySlots.Backpack, 0, 0).AdventuringGear(),
                    new Equipment("Potion(1): Greater healing", BodySlots.Backpack, 0, 0).AdventuringGear(),
                    new Equipment("Potion(100): Red Dragon", BodySlots.Backpack, 0, 0).AdventuringGear(),
                    new Equipment("1 Large tressure", BodySlots.Backpack, 0, 0).AdventuringGear(),
                    new Equipment("Clock of billoing", BodySlots.Body, 0, 0){ Magical = true}.AdventuringGear(),
                    new Equipment("Gloves of missile snatching", BodySlots.Hand, 0, 0){ Magical = true}.AdventuringGear(),
                    new Equipment("Vissial of selestrial pegasus", BodySlots.Neck, 0, 0){ Magical = true}.AdventuringGear(),
                    new Equipment("Ring of feather falling", BodySlots.Hand, 0, 0){ Magical = true}.AdventuringGear(),
            };

            equipment[0].IsEquipped = true;
            equipment[0].Damage = "1d8 + (3d6) + 7";
            equipment[1].IsEquipped = true;
            equipment[2].IsEquipped = true;
            equipment[3].IsEquipped = true;


            var languages = new List<string>
            {
                "Comment",
                "Elves",
                "Draconic"
            };

            var featuresAndTrains = new List<string>
                {
                    "Darkvision 30 feet",
                    "Fey Ancestry, advantage Charmed, can’t put to sleep",
                    "Sneak Attack +3d6",
                    "Thieves’ Cant",
                    "Cunning Action",
                    "Fancy Footwork",
                    "Rakish Audacity",
                    "Champion 19 crits",
                    "Dueling Fighting Style +2 Dam",
                    "Second Wind",
                    "Action Surge",
                    "Extra Attack",
                    "Lucky",
                    "Uncanny Dodge, (Reaction halve damage)"
                }.OrderBy(x => x).ToList();

            return new Characther()
            {
                id = 0,
                Name = "Farson",
                PlayerName = "Kasper Steenstrup",
                Race = "Half Elf",
                Background = "Entertaner",
                ProfBonus = prof,
                Initiative = 7,
                Speed = 30,
                HitDice = 10,
                Luck = 4,
                ArmorClass = 18,
                HitPoint = 82,
                PassivePerception = 5,
                Skills = skills.OrderBy(x => x.Decription).ToList(),
                Stats = stats,
                SavingThrows = savingThrows,
                Classes = classes,
                Equipment = equipment,
                Languages = languages,
                FeaturesAndTrains = featuresAndTrains,
                ImageUrl = @"Images\Farson.jpg"
            };
        }

        private static Characther Akercera()
        {
            var prof = 3;

            var stats = new List<Stat>
                {
                    new Stat(STATEnum.Str, 8),
                    new Stat(STATEnum.CON, 14),
                    new Stat(STATEnum.DEX, 14),
                    new Stat(STATEnum.INT, 16),
                    new Stat(STATEnum.WIS, 14),
                    new Stat(STATEnum.CHA, 10)
                };

            var strState = stats.Where(x => x.Type == STATEnum.Str).First();
            var dexState = stats.Where(x => x.Type == STATEnum.DEX).First();
            var intState = stats.Where(x => x.Type == STATEnum.INT).First();
            var wisState = stats.Where(x => x.Type == STATEnum.WIS).First();
            var chaState = stats.Where(x => x.Type == STATEnum.CHA).First();
            var conState = stats.Where(x => x.Type == STATEnum.CON).First();

            var skills = new List<Skill>
                {
                    new Skill("Athletics", strState, prof, 0),
                    new Skill("Acrobatics", dexState, prof, 0),
                    new Skill("Sleight of Hand", dexState, prof, 0),
                    new Skill("Stealth", dexState, prof, 0),

                    new Skill("Arcana", intState, prof, 1),
                    new Skill("History", intState, prof, 1),
                    new Skill("Investifation", intState, prof, 0),
                    new Skill("Nature", intState, prof, 1),
                    new Skill("Religion", intState, prof, 1),

                    new Skill("Animal Handling", wisState, prof, 0),
                    new Skill("Insight", wisState, prof, 1),
                    new Skill("Medicine", wisState, prof, 0),
                    new Skill("Perception", wisState, prof, 1),
                    new Skill("Survival", wisState, prof, 0),

                    new Skill("Deception", chaState, prof, 0),
                    new Skill("Intimidation", chaState, prof, 0),
                    new Skill("Performance", chaState, prof, 0),
                    new Skill("Persuasion", chaState, prof, 0),
                };

            var savingThrows = new List<SavingThrow>
            {
                new SavingThrow("Str", strState, prof, 0, 0),
                new SavingThrow("Dex", dexState, prof, 0, 0),
                new SavingThrow("Con", conState, prof, 0, 0),
                new SavingThrow("Int", intState, prof, 0, 0),
                new SavingThrow("Wis", wisState, prof, 1, 0),
                new SavingThrow("Cha", chaState, prof, 1, 0)

            };

            var classes = new List<Class>
            {
                new Class("Clerick", 1),
                new Class("Wizzard", 4)
            };


            var loadEquipment = EquipmentsBuilder.DefualdEquipmentBuilder().LoadAllItems().Build();

            var equipment = new List<Equipment>
            {
                    loadEquipment.Where(x => x.Name == "Half plate").First(),
                    loadEquipment.Where(x => x.Name == "Dagger").First(),
                    loadEquipment.Where(x => x.Name == "Shield").First(),
                    new Equipment("Clothes: Warm", BodySlots.Backpack, 0, 0).AdventuringGear(),
                    new Equipment("Clothes: Summer", BodySlots.Backpack, 0, 0).AdventuringGear(),
                    new Equipment("Component pouch", BodySlots.Backpack, 0, 0).AdventuringGear(),
                    new Equipment("Hat", BodySlots.Backpack, 0, 0).AdventuringGear(),
                    new Equipment("Diamon", BodySlots.Backpack, 0, 0).AdventuringGear(),
                    new Equipment("Pensle", BodySlots.Backpack, 0, 0).AdventuringGear(),
                    new Equipment("Papier", BodySlots.Backpack, 0, 0).AdventuringGear(),
                    new Equipment("Ink", BodySlots.Backpack, 0, 0).AdventuringGear(),
                    new Equipment("Pen", BodySlots.Backpack, 0, 0).AdventuringGear(),
                    new Equipment("2 Rations", BodySlots.Backpack, 0, 0).AdventuringGear(),
                    new Equipment("2 Herp pack", BodySlots.Backpack, 0, 0).AdventuringGear(),
                    new Equipment("3 Vin", BodySlots.Backpack, 0, 0).AdventuringGear(),
                    new Equipment("Gold bar", BodySlots.Backpack, 0, 0).AdventuringGear(),
                    new Equipment("Googles of Dwarf Identification", BodySlots.Head, 0, 0){ Magical = true}.AdventuringGear(),
                    new Equipment("Dwarfen Armor of Headenheim", BodySlots.Body, 0, 0){ Magical = true}.AdventuringGear(),
            };

            equipment[1].IsEquipped = true;
            equipment[2].IsEquipped = true;
            equipment[0].IsEquipped = true;


            var languages = new List<string>
            {
                "Drakinc",
                "Undercommen",
                "Common",
                "Elvish",
                "Drawen",
                "Celestial",
                "Ingernal"
            };

            var featuresAndTrains = new List<string>
                {
                    "Darkvision 30 feet",
                    "Fey Ancestry, advantage Charmed, can’t put to sleep",
                    "SpellCasting Divine",
                    "Knowledge Domain",
                    "Blessing of knowledge",
                    "Ritual Caster (c)",
                    "SpelCasting Arcane",
                    "Arcane Revovery",
                    "War magic",
                    "Arcane deflecting +4 saving",
                    "Tactical wit - int to initativ",
                    "War Caster",
                    "Ritual Caster (w)",
                    "Keen Senses",
                    "Trance",
                    "Cantrip",
                };

            return new Characther()
            {
                id = 1,
                Name = "Akercera",
                PlayerName = "Kasper Steenstrup",
                Race = "High Elf",
                Background = "Sage",
                ProfBonus = prof,
                Initiative = 5,
                Speed = 30,
                HitDice = 5,
                ArmorClass = 19,
                HitPoint = 37,
                PassivePerception = 3,
                Skills = skills.OrderBy(x => x.Decription).ToList(),
                Stats = stats,
                SavingThrows = savingThrows,
                Classes = classes,
                Equipment = equipment,
                Languages = languages,
                FeaturesAndTrains = featuresAndTrains,
                ImageUrl = @"Images\Akecera.jpg"
            };
        }

        public static List<Characther> Characthers
        {

            get
            {

                return new List<Characther>
                {
                    Farson(),
                    Akercera(),
                };
            }
        }


        public static Characther GetCharacther(int id)
        {
            return Characthers[id];
        }
    }
}
