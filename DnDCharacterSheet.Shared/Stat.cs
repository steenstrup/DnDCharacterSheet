using System;

namespace DnDCharacterSheet.Shared
{
    public enum STATEnum { DEX, CON, INT, WIS, CHA, Str };

    public class Stat
    {
        public Stat(){}

        public Stat(STATEnum type, int value)
        {
            Type = type;
            Value = value;
        }

        public STATEnum Type { get; set; }
        public int Value { get; set; }

        public int GetBonus()
        {
            return (int)Math.Floor(Value / 2.0f) - 5;
        }
    }
}