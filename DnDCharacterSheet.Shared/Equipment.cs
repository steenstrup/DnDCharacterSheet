using System.Collections.Generic;

namespace DnDCharacterSheet.Shared
{
    public enum BodySlots
    {
        Head, Neck, Hand, Arm, Pans, Feed, Finger, Body, Backpack, LeftHand, RightHand
    }

    public enum EquipmentType
    {
        Armor, Weapon, Tool, Gear
    }

    public enum ArmorType
    {
        Light, Medium, Heavy, Shield
    }

    public enum WeaponType
    {
        SimpleMelee, SimpleRanged, MartialMelee, MartialRanged
    }

    public class Equipment
    {
        public Equipment() { }

        public Equipment(string name, BodySlots bodyslot, int cost, int weight)
        {
            Name = name;
            Slot = BodySlots.Backpack;
            IsEquipped = false;
            Slot = bodyslot;
            Cost = cost;
            Weight = weight;
        }

        public Equipment Armor(ArmorType armorType, int ac, int strengthRequament, bool stealthInpetement)
        {
            ArmorType = armorType;
            Ac = ac;
            StrengthRequament = strengthRequament;
            StealthInpetement = stealthInpetement;
            EquipmentType = EquipmentType.Armor;
            return this;
        }

        public Equipment Weapon(WeaponType weaponType, string damage, string damageType, string weaponProperties)
        {
            WeaponType = weaponType;
            Damage = damage;
            DamageType = damageType;
            WeaponProperties = weaponProperties;
            EquipmentType = EquipmentType.Weapon;
            return this;
        }

        public Equipment AdventuringGear()
        {
            EquipmentType = EquipmentType.Gear;
            return this;
        }

        public int equipmentId { get; set; }

        // General Information
        public string Name { get; set; }
        public bool IsEquipped { get; set; }
        public BodySlots Slot { get; set; }
        public EquipmentType EquipmentType { get; set; }
        public int Cost { get; set; }
        public int Weight { get; set; }
        public bool Magical { get; set; }

        // Armor information
        public ArmorType ArmorType { get; private set; }
        public int Ac { get; private set; }
        public int StrengthRequament { get; private set; }
        public bool StealthInpetement { get; private set; }

        // Weapon information
        public WeaponType WeaponType { get; private set; }
        public string Damage { get; set; }
        public string DamageType { get; set; }
        public string WeaponProperties { get; set; }
        public int WeaponBonus { get; set; }
    }

    public class EquipmentsBuilder
    {
        private readonly List<Equipment> _equipments;
        
        public static EquipmentsBuilder DefualdEquipmentBuilder()
        {
            return new EquipmentsBuilder();
        }

        public EquipmentsBuilder()
        {
            _equipments = new List<Equipment>();
        }

        public EquipmentsBuilder LoadArmor()
        {
            // ligth armor
            _equipments.Add(new Equipment("Padded", BodySlots.Body, 5, 8).Armor(ArmorType.Light, 11, 0, true));
            _equipments.Add(new Equipment("Leather", BodySlots.Body, 10, 10).Armor(ArmorType.Light, 11, 0, false));
            _equipments.Add(new Equipment("Studded leather", BodySlots.Body, 45, 13).Armor(ArmorType.Light, 12, 0, false));

            // medium armor
            _equipments.Add(new Equipment("Hide", BodySlots.Body, 10, 12).Armor(ArmorType.Medium, 12, 0, false));
            _equipments.Add(new Equipment("Chain Shirt", BodySlots.Body, 50, 20).Armor(ArmorType.Medium, 13, 0, false));
            _equipments.Add(new Equipment("Scale mail", BodySlots.Body, 50, 45).Armor(ArmorType.Medium, 14, 0, true));
            _equipments.Add(new Equipment("Brestplate", BodySlots.Body, 400, 20).Armor(ArmorType.Medium, 14, 0, false));
            _equipments.Add(new Equipment("Half plate", BodySlots.Body, 750, 40).Armor(ArmorType.Medium, 15, 0, true));

            // Heavy armor
            _equipments.Add(new Equipment("Ring mail", BodySlots.Body, 14, 40).Armor(ArmorType.Heavy, 11, 0, true));
            _equipments.Add(new Equipment("Chain mail", BodySlots.Body, 16, 55).Armor(ArmorType.Heavy, 11, 13, true));
            _equipments.Add(new Equipment("Splint", BodySlots.Body, 17, 60).Armor(ArmorType.Heavy, 11, 15, true));
            _equipments.Add(new Equipment("Plate", BodySlots.Body, 18, 65).Armor(ArmorType.Heavy, 11, 15, true));

            // Shield
            _equipments.Add(new Equipment("Shield", BodySlots.LeftHand, 10, 6).Armor(ArmorType.Shield, 2, 0, false));

            return this;
        }

        public EquipmentsBuilder LoadWeapon()
        {
            // Simple Melee
            _equipments.Add(new Equipment("Club", BodySlots.RightHand, 1, 2).Weapon(WeaponType.SimpleMelee, "1d4", "Bludgeoning", "Light"));
            _equipments.Add(new Equipment("Dagger", BodySlots.RightHand, 2, 1).Weapon(WeaponType.SimpleMelee, "1d4", "Bludgeoning", "Finesse, light, thrown (range 20/60)"));
            _equipments.Add(new Equipment("Greatclub", BodySlots.RightHand, 1, 10).Weapon(WeaponType.SimpleMelee, "1d8", "Bludgeoning", "Two-handed"));
            _equipments.Add(new Equipment("Handaxe", BodySlots.RightHand, 5, 2).Weapon(WeaponType.SimpleMelee, "1d6", "Bludgeoning", "Light, throw (range 20/60)"));
            _equipments.Add(new Equipment("Javelin", BodySlots.RightHand, 1, 2).Weapon(WeaponType.SimpleMelee, "1d6", "Bludgeoning", "Thrown (range 30/120)"));
            _equipments.Add(new Equipment("Light hammer", BodySlots.RightHand, 2, 2).Weapon(WeaponType.SimpleMelee, "1d4", "Bludgeoning", "Light, thrown (range 20/60)"));
            _equipments.Add(new Equipment("Mace", BodySlots.RightHand, 5, 4).Weapon(WeaponType.SimpleMelee, "1d6", "Bludgeoning", ""));
            _equipments.Add(new Equipment("Quarterstaff", BodySlots.RightHand, 1, 4).Weapon(WeaponType.SimpleMelee, "1d6", "Bludgeoning", "Versatile (1d8)"));
            _equipments.Add(new Equipment("Sickle", BodySlots.RightHand, 1, 2).Weapon(WeaponType.SimpleMelee, "1d4", "Bludgeoning", "Light"));
            _equipments.Add(new Equipment("Spear", BodySlots.RightHand, 1, 3).Weapon(WeaponType.SimpleMelee, "1d6", "Bludgeoning", "Thrown (range 20/60), versatile (1d8)"));
            _equipments.Add(new Equipment("Unarmed strike", BodySlots.RightHand, 0, 0).Weapon(WeaponType.SimpleMelee, "1", "Bludgeoning", ""));
            // add all weapon to _equipments

            return this;

        }

        public EquipmentsBuilder LoadAdventuringGear()
        {
            // added ordered by alphabet
            _equipments.Add(new Equipment("Abacus", BodySlots.Backpack, 2, 2).AdventuringGear());
            _equipments.Add(new Equipment("Acid (vial)", BodySlots.Backpack, 25, 1).AdventuringGear());
            _equipments.Add(new Equipment("Alchemist's fire (flask)", BodySlots.Backpack, 50, 1).AdventuringGear());
            _equipments.Add(new Equipment("Arrows (20)", BodySlots.Backpack, 1, 1).AdventuringGear());
            _equipments.Add(new Equipment("Blowgun needles (50)", BodySlots.Backpack, 1, 1).AdventuringGear());
            _equipments.Add(new Equipment("Crossbow bolts (20)", BodySlots.Backpack, 1, 2).AdventuringGear());

            _equipments.Add(new Equipment("Sling bullets (20)", BodySlots.Backpack, 1, 2).AdventuringGear());
            _equipments.Add(new Equipment("Antitoxin (vail)", BodySlots.Backpack, 50, 0).AdventuringGear());

            _equipments.Add(new Equipment("Crystal", BodySlots.Backpack, 10, 2).AdventuringGear());
            _equipments.Add(new Equipment("Orb", BodySlots.Backpack, 20, 3).AdventuringGear());
            _equipments.Add(new Equipment("Rod", BodySlots.Backpack, 20, 3).AdventuringGear());
            _equipments.Add(new Equipment("Staff", BodySlots.Backpack, 5, 4).AdventuringGear());
            _equipments.Add(new Equipment("Wand", BodySlots.Backpack, 10, 1).AdventuringGear());

            _equipments.Add(new Equipment("Backpack", BodySlots.Backpack, 2, 5).AdventuringGear());
            _equipments.Add(new Equipment("Ball bearings (bog of 1000)", BodySlots.Backpack, 1, 2).AdventuringGear());
            _equipments.Add(new Equipment("Barrel", BodySlots.Backpack, 2, 70).AdventuringGear());
            _equipments.Add(new Equipment("Basket", BodySlots.Backpack, 1, 2).AdventuringGear());
            _equipments.Add(new Equipment("Redroll", BodySlots.Backpack, 1, 7).AdventuringGear());
            _equipments.Add(new Equipment("Bell", BodySlots.Backpack, 1, 0).AdventuringGear());

            _equipments.Add(new Equipment("Blanket", BodySlots.Backpack, 5, 3).AdventuringGear());
            _equipments.Add(new Equipment("Block and tackle", BodySlots.Backpack, 1, 5).AdventuringGear());
            _equipments.Add(new Equipment("Book", BodySlots.Backpack, 25, 5).AdventuringGear());
            _equipments.Add(new Equipment("Bottle, glass", BodySlots.Backpack, 2, 2).AdventuringGear());


            _equipments.Add(new Equipment("Bucket", BodySlots.Backpack, 1, 2).AdventuringGear());
            _equipments.Add(new Equipment("Caltrops (bag of 20)", BodySlots.Backpack, 1, 2).AdventuringGear());
            _equipments.Add(new Equipment("Candle", BodySlots.Backpack, 1, 0).AdventuringGear());
            _equipments.Add(new Equipment("Case, crossbow bolt", BodySlots.Backpack, 1, 1).AdventuringGear());

            _equipments.Add(new Equipment("Case, map or scroll", BodySlots.Backpack, 1, 1).AdventuringGear());
            _equipments.Add(new Equipment("Chain (10 feet)", BodySlots.Backpack, 5, 10).AdventuringGear());
            _equipments.Add(new Equipment("Chalk (1 piece)", BodySlots.Backpack, 1, 0).AdventuringGear());
            _equipments.Add(new Equipment("Chest", BodySlots.Backpack, 5, 25).AdventuringGear());
            _equipments.Add(new Equipment("Climber's kit", BodySlots.Backpack, 25, 12).AdventuringGear());

            _equipments.Add(new Equipment("Clothes, Worm", BodySlots.Backpack, 10, 4).AdventuringGear());
            _equipments.Add(new Equipment("Clothes, common", BodySlots.Backpack, 5, 3).AdventuringGear());
            _equipments.Add(new Equipment("Clothes, costume", BodySlots.Backpack, 5, 4).AdventuringGear());
            _equipments.Add(new Equipment("Clothes, fine", BodySlots.Backpack, 15, 6).AdventuringGear());
            _equipments.Add(new Equipment("Clothes, traveler's", BodySlots.Backpack, 2, 4).AdventuringGear());
            _equipments.Add(new Equipment("Component pouch", BodySlots.Backpack, 25, 2).AdventuringGear());

            _equipments.Add(new Equipment("Crowbar", BodySlots.Backpack, 2, 5).AdventuringGear());

            
            // added rest that I needed for the char that I am creating
            _equipments.Add(new Equipment("Hat", BodySlots.Backpack, 1, 1).AdventuringGear());
            _equipments.Add(new Equipment("Dimon", BodySlots.Backpack, 25, 1).AdventuringGear());
            _equipments.Add(new Equipment("Pensle", BodySlots.Backpack, 2, 0).AdventuringGear());
            _equipments.Add(new Equipment("Papier", BodySlots.Backpack, 1, 0).AdventuringGear());

            _equipments.Add(new Equipment("Ink", BodySlots.Backpack, 10, 0).AdventuringGear());
            _equipments.Add(new Equipment("Pen", BodySlots.Backpack, 1, 0).AdventuringGear());
            _equipments.Add(new Equipment("Rations", BodySlots.Backpack, 1, 1).AdventuringGear());
            _equipments.Add(new Equipment("Watherskin", BodySlots.Backpack, 1, 5).AdventuringGear());
            _equipments.Add(new Equipment("Herp pack", BodySlots.Backpack, 2, 0).AdventuringGear());
            _equipments.Add(new Equipment("Rope", BodySlots.Backpack, 1, 10).AdventuringGear());
            _equipments.Add(new Equipment("Vin", BodySlots.Backpack, 5, 1).AdventuringGear());
            _equipments.Add(new Equipment("Gold bar", BodySlots.Backpack, 500, 50).AdventuringGear());

            return this;

        }

        public EquipmentsBuilder LoadTools()
        {
            // add all Tools to _equipments

            return this;

        }

        public EquipmentsBuilder LoadMagicItems()
        {
            // add all Magic Items to _equipments
            _equipments.Add(new Equipment("Googgles of Dwarf Identification", BodySlots.Head, 0, 0) { Magical = true});
            _equipments.Add(new Equipment("The Identificed Cube", BodySlots.Backpack, 0, 0) { Magical = true });
            _equipments.Add(new Equipment("Dwarfen Armor of HeadenHeim", BodySlots.Body, 50, 45) { Magical = true }
                .Armor(ArmorType.Medium, 14, 0, true));

            _equipments.Add(new Equipment("Lucky Rapier", BodySlots.Hand, 0, 0) { Magical = true,
            WeaponBonus = 1}.Weapon(WeaponType.MartialMelee, "1d8", "Magic pircing", ""));

            return this;
        }
        
        public EquipmentsBuilder AddEquipment(Equipment equipment)
        {
            _equipments.Add(equipment);
            return this;
        }

        public EquipmentsBuilder LoadAllItems()
        {
            LoadArmor();
            LoadMagicItems();
            LoadTools();
            LoadWeapon();
            LoadAdventuringGear();
            return this;
        }
        
        public IEnumerable<Equipment> Build()
        {
            return _equipments;
        }
    }

}
