public class Tetromino

{

    public Grid Grid { get; set; }



    /// <summary>
    ///  Tetromino orientation
    /// </summary>
    /// <value>Default value is LeftRight</value>
    public TetrominoOrientation Orientation { get; set; }
    = TetrominoOrientation.LeftRight;

    public int CenterPieceRow { get; set; }


    public int CenterPieceColumn { get; set; }


    public virtual TetrominoStyle Style { get; }


    public virtual string CssClass { get; } = " ";

    public virtual CellCollection CoveredCells { get; }


    public Tetromino(Grid grid)
    {
        Grid = grid;

        CenterPieceRow = grid.Height;

        CenterPieceColumn = grid.Width / 2;
    }


    public bool CanMoveLeft()
    {
        foreach (var cell in CoveredCells.GetLeftMost())

        {

            if (Grid.Cells.Contains(cell.Row, cell.Column - 1))
                return false;

        }


        if (CoveredCells.HasColumn(1))
            return false;

        return true;
    }

    public bool CanMoveRight()
    {
        foreach (var cell in CoveredCells.GetRightmost())

        {

            if (Grid.Cells.Contains(cell.Row, cell.Column + 1))
                return false;

        }


        if (CoveredCells.HasColumn(Grid.Width))
            return false;

        return true;
    }

    public void MoveLeft()
    {
        if (CanMoveLeft())
            CenterPieceColumn--;
    }

    public void MoveRight()
    {
        if (CanMoveRight())
            CenterPieceColumn++;
    }

    public bool CanMoveDown()
    {

        foreach (var coord in CoveredCells.GetLowest())
        {
            if (Grid.Cells.Contains(coord.Row - 1, coord.Column))
                return false;
        }

        if (CoveredCells.HasRow(1))
            return false;

        return true;
    }

    public void MoveDown()
    {
        if (CanMoveDown())
            CenterPieceRow--;
    }

}


