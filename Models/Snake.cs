using MostSnake.Utility;
using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace MostSnake.Models
{
    public class Snake
    {
        [ForeignKey("Player")]
        public int SnakeId { get; set; }
        public int SnakeMatchNumber { get; set; }
        public virtual Player Player { get; set; }
        public Direction CurrentDirection { get; set; }
        public bool StillMoving { get; set; }
        public Coordinate HeadCoordinate { get; set; }

        public Snake()
        {
            this.StillMoving = true;
            this.CurrentDirection = (Direction)RNG.Next(1, 5);
        }

        public Snake(Coordinate coordinate)
        {
            this.StillMoving = true;
            this.HeadCoordinate = coordinate;
            this.CurrentDirection = (Direction)RNG.Next(1,5);
        }

        /// <summary>
        /// Players will put their code in this method
        /// </summary>
        /// <returns></returns>
        public Heading DecideDirection(Match match)
        {
            Heading directionOfNextMove = Heading.Straight;
            /*
             * Code that has decision tree which decides which direction to move in the next round of movement
             */
                switch (CurrentDirection)
                {
                   case Direction.Left:
                   if (match.Arena.Single(t => t.Coordinate.X == HeadCoordinate.X - 1 && t.Coordinate.Y == HeadCoordinate.Y).TileState != TileState.Empty)
                   {
                        int random = RNG.Next(1, 3);
                        if (random == 1)
                        {
                            directionOfNextMove = Heading.Left;
                        }
                        else if (random == 2)
                        {
                            directionOfNextMove = Heading.Right;
                        }
                   }
                   break;
                   case Direction.Right:
                   if (match.Arena.Single(t => t.Coordinate.X == HeadCoordinate.X + 1 && t.Coordinate.Y == HeadCoordinate.Y).TileState != TileState.Empty)
                   {
                       int random = RNG.Next(1, 3);
                       if (random == 1)
                       {
                           directionOfNextMove = Heading.Left;
                       }
                       else if (random == 2)
                       {
                           directionOfNextMove = Heading.Right;
                       }
                   }
                   break;
                   case Direction.Down:
                   if (match.Arena.Single(t => t.Coordinate.X == (HeadCoordinate.X) && t.Coordinate.Y == HeadCoordinate.Y - 1).TileState != TileState.Empty)
                   {
                        int random = RNG.Next(1, 3);
                        if (random == 1)
                        {
                            directionOfNextMove = Heading.Left;
                        }
                        else if (random == 2)
                        {
                            directionOfNextMove = Heading.Right;
                        }
                   }
                   break;
                   case Direction.Up:
                   if (match.Arena.Single(t => t.Coordinate.X == (HeadCoordinate.X) && t.Coordinate.Y == HeadCoordinate.Y + 1).TileState != TileState.Empty)
                   {
                        int random = RNG.Next(1, 3);
                        if (random == 1)
                        {
                            directionOfNextMove = Heading.Left;
                        }
                        else if (random == 2)
                        {
                            directionOfNextMove = Heading.Right;
                        }
                   }
                   break;
                }
                return directionOfNextMove;
        }

        /// <summary>
        /// Returns the new coordinate of a snake's head based on the direction in which it is traveling
        /// </summary>
        /// <param name="direction"></param>
        /// <returns></returns>
        public Coordinate NewHeadCoordinate(Direction direction)
        {
            switch (direction)
            {
                case Direction.Left: return new Coordinate(HeadCoordinate.X - 1, HeadCoordinate.Y);
                case Direction.Right: return new Coordinate(HeadCoordinate.X + 1, HeadCoordinate.Y);
                case Direction.Down: return new Coordinate(HeadCoordinate.X, HeadCoordinate.Y - 1);
                case Direction.Up: return new Coordinate(HeadCoordinate.X, HeadCoordinate.Y + 1);
                default: return new Coordinate(HeadCoordinate.X, HeadCoordinate.Y);
            }
        }

        /// <summary>
        /// Accepts a heading from snake point of view and returns the corresponding map based direction
        /// </summary>
        /// <param name="heading"></param>
        /// <returns></returns>
        public Direction NewDirection(Heading heading)
        {
            switch (heading)
            {
                case Heading.Left:
                    if (CurrentDirection == Direction.Left)
                    {
                        return Direction.Down;
                    }
                    else
                    {
                        return --CurrentDirection;
                    }
                case Heading.Straight:
                    return CurrentDirection;
                case Heading.Right:
                    if (CurrentDirection == Direction.Down)
                    {
                        return Direction.Left;
                    }
                    else
                    {
                        return ++CurrentDirection;
                    }
                default:
                    return CurrentDirection;
            }
        }
    }

    public enum Heading
    {
        Left = 1, Straight = 2, Right = 3
    }

    public enum Direction
    {
        Left = 1, Up =2, Right = 3, Down = 4
    }

    public struct Coordinate
    {
        public int X { get; set; }
        public int Y { get; set; }

        public Coordinate(int x, int y)
        {
            this.X = x;
            this.Y = y;
        }
    }
}