namespace MostSnake.Models
{
    public class ArenaTile
    {
        public Coordinate Coordinate { get; set; }
        public TileState TileState { get; set; }

        public void Update(ArenaTile desiredResult)
        {
            this.Coordinate = desiredResult.Coordinate;
            this.TileState = desiredResult.TileState;
        }

        public ArenaTile()
        {
            this.TileState = TileState.Empty;
        }

        public ArenaTile(int xCoord, int yCoord)
        {
            this.Coordinate = new Coordinate(xCoord, yCoord);
            this.TileState = TileState.Empty;
        }
    }

    public enum TileState
    {
        Empty = 0, SnakeHeadOne = 1, SnakeHeadTwo = 2, SnakeHeadThree = 3, SnakeHeadFour = 4, SnakeBodyOne = 5, SnakeBodyTwo = 6, SnakeBodyThree = 7, SnakeBodyFour = 8, Wall = 9, SnakeCollision = 10
    }
}