﻿using RoguelikeGame.DungeonManagement;

namespace RoguelikeGame.Entity.Creatures
{

    public class Ally : Abstract.Character
    {
        public int BonusDamage { get; set; }
        public int BonusHealth { get; set; }
        public int BonusArmor { get; set; }
        public string Message { get; set; }
        public Ally(Square square) : base(square, "", ' ')
        {
            var randomAlly = ItemsDbManager.GetAlly();
            Name = randomAlly["Name"];
            MapSymbol = randomAlly["Symbol"].ToCharArray()[0];
            switch (randomAlly["Type"])
            {
                case "Health":
                    BonusHealth = int.Parse(randomAlly["Bonus"]);
                    break;
                case "Damage":
                    BonusDamage = int.Parse(randomAlly["Bonus"]);
                    break;
                case "Armor":
                    BonusArmor = int.Parse(randomAlly["Bonus"]);
                    break;
            }
        }
        
        public static void PlaceCreature(Game game)
        {
            var (randX, randY) = RandomGenerator.FindRandomPlacement(game.Dungeon);
            var ally = new Enemy(game.Dungeon.Board[randX, randY]);
            game.Dungeon.Board[randX, randY].Entity = ally;
        }


    }
}