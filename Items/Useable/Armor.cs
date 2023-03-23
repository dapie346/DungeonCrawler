﻿using RoguelikeGame.DungeonManagement;

namespace RoguelikeGame.Items.Useable
{

    public class Armor : Abstract.Useable
    {
        public Armor(Square square, string armorType) : base(square, "", ' ', 0, 0)
        {
            ArmorType(armorType);
        }
        public enum armorType
        {
            Gambeson,
            BoiledLeather,
            ShellArmor,
            ScaleArmor,
            LaminarArmor,
            PlatedMailArmor,
            MailArmor,
            BrigandineArmor, 
            PlateArmor
        }
        public void SetArmorType(armorType armorType)
        {
            switch (armorType)
            {
                case armorType.Gambeson:
                    Name = "Gambeson";
                    MapSymbol = '\u104E';
                    Armor = 10;
                    break;
                case armorType.BoiledLeather:
                    Name = "Boiled leather";
                    MapSymbol = '\u104E';
                    Armor = 20;
                    break;
                case armorType.ShellArmor:
                    Name = "Shell armor";
                    MapSymbol = '\u104E';
                    Armor = 50;
                    break;
                case armorType.ScaleArmor:
                    Name = "Scale armor";
                    MapSymbol = '\u104E';
                    Armor = 70;
                    break;
                case armorType.LaminarArmor:
                    Name = "Laminar armor";
                    MapSymbol = '\u104E';
                    Armor = 90;
                    break;
                case armorType.PlatedMailArmor:
                    Name = "Plated mail armor";
                    MapSymbol = '\u104E';
                    Armor = 160;
                    break;
                case armorType.MailArmor:
                    Name = "Mail armor";
                    MapSymbol = '\u104E';
                    Armor = 170;
                    break;
                case armorType.BrigandineArmor:
                    Name = "Brigandine armor";
                    MapSymbol = '\u104E';
                    Armor = 180;
                    break;
                case armorType.PlateArmor:
                    Name = "Plate armor";
                    MapSymbol = '\u104E';
                    Armor = 200;
                    break;
            }
        }


    }
}
