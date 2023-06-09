﻿using GameLogic.DungeonManagement;
using GameLogic.DungeonManagement.RoomCreator;
using GameLogic.DungeonManagement.SquareCreator;
namespace GameLogic.Entity.Interaction.Item.Useable
{
    public class Armor : Abstract.Useable
    {
        public int Protection;
        public Armor(Square square) : base(square)
        {
            var randomArmor = DbManager.GetItem("Armor", "Armor");
            Name = randomArmor["Name"];
            MapSymbol = randomArmor["Symbol"].ToCharArray()[0];
            Protection = int.Parse(randomArmor["Stat"]);
            Id = int.Parse(randomArmor["Id"]);
        }

        public static void PlaceItem(Dungeon dungeon, Room room)
        {
            Coordinates coordinates = RandomGenerator.FindRandomPlacement(dungeon, room);
            var item = new Armor(dungeon.Grid[coordinates.X, coordinates.Y]);
            dungeon.Grid[coordinates.X, coordinates.Y].Interactive = item;
        }

        public override string Interact(Player player)
        {
            AddToInventory(player);
            player.Armor += Protection;
            RemoveFromBoard();
            return $"You have picked up {Name}";
        }
    }
}
