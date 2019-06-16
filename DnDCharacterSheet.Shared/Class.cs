namespace DnDCharacterSheet.Shared
{
    public class Class
    {
        public Class(){}

        public Class(string name, int level)
        {
            Name = name;
            Level = level;
        }

        public string Name { get; set; }
        public int Level { get; set; }
    }
}