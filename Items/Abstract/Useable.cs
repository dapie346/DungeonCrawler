﻿using RoguelikeGame.DungeonManagement;
namespace RoguelikeGame.Items.Abstract
{
    public abstract class Useable : Items
    {
        public int Attack { get; set; }
        public int Armor { get; set; }
        protected Useable(Square square, string name, char mapSymbol, int attack, int armor) : base(square, name, mapSymbol)
        {
            Attack = attack;
            Armor = armor;
        }
    }
}
