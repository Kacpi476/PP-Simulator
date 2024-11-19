using Simulator;


namespace TestSimulator
{
    public class PointTests
    {
        [Fact]
        public void Constructor_ShouldInitializeCorrectly()
        {
            // Arrange
            int x = 3, y = 4;

            // Act
            var point = new Point(x, y);

            // Assert
            Assert.Equal(3, point.X);
            Assert.Equal(4, point.Y);
        }

        [Theory]
        [InlineData(3, 4, Direction.Up, 3, 5)]
        [InlineData(3, 4, Direction.Right, 4, 4)]
        [InlineData(3, 4, Direction.Down, 3, 3)]
        [InlineData(3, 4, Direction.Left, 2, 4)]
        public void Next_ShouldReturnCorrectPoint(int x, int y, Direction direction, int expectedX, int expectedY)
        {
            // Arrange
            var point = new Point(x, y);

            // Act
            var result = point.Next(direction);

            // Assert
            Assert.Equal(new Point(expectedX, expectedY), result);
        }

        [Theory]
        [InlineData(3, 4, Direction.Up, 4, 5)]
        [InlineData(3, 4, Direction.Right, 4, 3)]
        [InlineData(3, 4, Direction.Down, 2, 3)]
        [InlineData(3, 4, Direction.Left, 2, 5)]
        public void NextDiagonal_ShouldReturnCorrectPoint(int x, int y, Direction direction, int expectedX, int expectedY)
        {
            // Arrange
            var point = new Point(x, y);

            // Act
            var result = point.NextDiagonal(direction);

            // Assert
            Assert.Equal(new Point(expectedX, expectedY), result);
        }
    }
}