using System.Collections.Generic;
using System.Linq;

namespace MostSnake.Models
{
    public static class GameLogic
    {
        public static Match RunMatch()
        {
            List<Snake> list = new List<Snake>();
            Match match = new Match(list);
            int counter = match.Snakes.Count();
            while (!match.IsCompleted)
            {
                List<Coordinate> newCoordinates = new List<Coordinate>();
                foreach (var snake in match.Snakes.Where(d => d.StillMoving))
                {
                    var heading = snake.DecideDirection(match);
                    var direction = snake.NewDirection(heading);
                    snake.CurrentDirection = direction;
                    var newCoordinate = snake.NewHeadCoordinate(direction);
                    snake.HeadCoordinate = newCoordinate;
                    newCoordinates.Add(newCoordinate);
                }
                foreach (var snake in match.Snakes)
                {
                    if (snake.StillMoving && match.Snakes.Where(c => c.HeadCoordinate.X == snake.HeadCoordinate.X && c.HeadCoordinate.Y == snake.HeadCoordinate.Y).Count() > 1)
                    {
                        snake.StillMoving = false;
                        match.Arena.Single(t => t.Coordinate.X == snake.HeadCoordinate.X && t.Coordinate.Y == snake.HeadCoordinate.Y).TileState = TileState.SnakeCollision;
                        counter--;
                    }
                    else if (snake.StillMoving && match.Arena.Single(a => a.Coordinate.X == snake.HeadCoordinate.X && a.Coordinate.Y == snake.HeadCoordinate.Y).TileState != TileState.Empty)
                    {
                        snake.StillMoving = false;
                        match.Arena.Single(t => t.Coordinate.X == snake.HeadCoordinate.X && t.Coordinate.Y == snake.HeadCoordinate.Y).TileState = TileState.SnakeCollision;
                        counter--;
                    }
                }
                foreach (var snake in match.Snakes.Where(s => s.StillMoving))
                {
                    var headTile = match.Arena.Single(b => b.TileState == (TileState) snake.SnakeMatchNumber);
                    headTile.TileState = (TileState)snake.SnakeMatchNumber + 4;
                    var tile = match.Arena.Single(a => a.Coordinate.X == snake.HeadCoordinate.X && a.Coordinate.Y == snake.HeadCoordinate.Y);
                    tile.TileState = (TileState) snake.SnakeMatchNumber;
                }
                if (counter == 1)
                {
                    match.MatchWinner = match.Snakes.Single(s => s.StillMoving).SnakeMatchNumber;
                    match.IsCompleted = true;
                }
                else if (counter == 0)
                {
                    match.IsCompleted = true;
                }
            }
            return match;
        }
    }
}