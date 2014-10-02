namespace ShortestPathInMatrix
{
    internal class Cell
    {
        public Cell(int row, int col, int level)
        {
            this.Row = row;
            this.Col = col;
            this.Level = level;
        }

        public int Row { get; set; }

        public int Col { get; set; }

        public int Level { get; set; }
    }
}
