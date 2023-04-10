using GameLogic.DungeonManagement;
using GameLogic.DungeonManagement.RoomCreator;
using GameLogic.DungeonManagement.SquareCreator;

namespace GameLogic.Entity.Interaction.Character
{

    public class Enemy : Abstract.Character
    {
        public int Damage { get; set; }
        public int Health { get; set; }
        public Enemy(Square square) : base(square)
        {
            var randomEnemy = DbManager.GetEnemy();
            Name = randomEnemy["Name"];
            MapSymbol = randomEnemy["Symbol"].ToCharArray()[0];
            Damage = int.Parse(randomEnemy["Damage"]);
            Health = int.Parse(randomEnemy["Health"]);
            Id = int.Parse(randomEnemy["Id"]);
        }

        public static void PlaceCreature(Dungeon dungeon, Room room)
        {
            Coordinates coordinates = RandomGenerator.FindRandomPlacement(dungeon, room);
            var enemy = new Enemy(dungeon.Grid[coordinates.X, coordinates.Y]);
            dungeon.Grid[coordinates.X, coordinates.Y].Interactive = enemy;
        }

        public override string ApproachCharacter(Player player)
        {
            Health -= player.Damage;
            if (Health > 0)
            {
                if (Damage - player.Armor <= 0)
                {
                    return $"You have dealt {player.Damage} damage\n" +
                           $"\nEnemy have missed";
                }
                player.Health -= Damage - player.Armor;
                if (!player.Alive)
                {
                    player.Score = player.Armor + player.Damage + player.Health;
                    DbManager.SaveScore(player);
                    return "Game Over\nYou have been slain";
                }
                else
                {
                    return $"You have dealt {player.Damage} damage" + $"\nEnemy have dealt {Damage - player.Armor} damage to you";
                }
            }
            RemoveFromBoard();
            return $"You successfully defeated {Name}";
        }
    }
}
