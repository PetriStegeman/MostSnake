using System.Collections.Generic;
using System.Linq;

namespace MostSnake.Models
{
    public class Match
    {
        private int arenaDimensionX = 20;
        private int arenaDimensionY = 20;

        public int MatchId { get; set; }
        public bool IsCompleted { get; set; }
        public int MatchWinner { get; set; }
        public int ArenaDimensionX { get { return arenaDimensionX; } set { arenaDimensionX = value; } }
        public int ArenaDimensionY { get { return arenaDimensionY; } set { arenaDimensionY = value; } }
        public virtual ICollection<ArenaTile> Arena { get; private set; }
        public virtual ICollection<Snake> Snakes { get; private set; }

        private List<ArenaTile> InitializeArena(List<Snake> snakes)
        {
            List<ArenaTile> arena = new List<ArenaTile>();
            for (int i = 1; i <= ArenaDimensionX; i++)
            {
                for (int j = 1; j <= ArenaDimensionY; j++)
                {
                    var tile = new ArenaTile(i, j);
                    if (i == 20 || j == 20 || i == 1 || j == 1)
                    {
                        tile.TileState = TileState.Wall;
                    }
                    arena.Add(tile);
                }
            }
            return AssignStartingLocations(snakes, arena);
        }

        private List<ArenaTile> AssignStartingLocations(List<Snake> snakes, List<ArenaTile> arena)
        {
            int counter = 1;
            while (snakes.Count() < 4)
            {
                snakes.Add(new Snake());
            }
            foreach (var snake in snakes)
            {
                SetStartLocation(snake, counter, arena);
                snake.SnakeMatchNumber = counter;
                counter++;
            }
            return arena;
        }

        private List<ArenaTile> SetStartLocation(Snake snake, int snakeNumber, List<ArenaTile> arena)
        {
            switch (snakeNumber)
            {
                case 1:
                    var tileOne = arena.Single(t => t.Coordinate.X == 5 && t.Coordinate.Y == 5);
                    snake.HeadCoordinate = new Coordinate(5, 5);
                    tileOne.TileState = (TileState)snakeNumber;
                    break;
                case 2:
                    var tileTwo = arena.Single(t => t.Coordinate.X == 15 && t.Coordinate.Y == 15);
                    snake.HeadCoordinate = new Coordinate(15, 15);
                    tileTwo.TileState = (TileState)snakeNumber;
                    break;
                case 3:
                    var tileThree = arena.Single(t => t.Coordinate.X == 15 && t.Coordinate.Y == 5);
                    snake.HeadCoordinate = new Coordinate(15, 5);
                    tileThree.TileState = (TileState)snakeNumber;
                    break;
                case 4:
                    var tileFour = arena.Single(t => t.Coordinate.X == 5 && t.Coordinate.Y == 15);
                    snake.HeadCoordinate = new Coordinate(5, 15);
                    tileFour.TileState = (TileState)snakeNumber;
                    break;
            }
            return arena;
        }

        public Match() { }

        public Match(List<Snake> snakes)
        {
            this.Snakes = snakes;
            this.Arena = InitializeArena(snakes);
        }
    }
}