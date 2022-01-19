public class Cell
{
  public int Row { get; set;} 
  public int Column { get; set; }
  // If error it is due to setting CssClass to " "
  public string CssClass { get; set; } = " ";

/// <summary>
/// Constuctor called when Cell is called
/// </summary>
/// <param name="row">set the row of the cell</param>

/// <param name="column">sets the column of row</param>
  public Cell (int row, int column)
  {
    Row = row;
    Column = column;
  }
/// <summary>
/// Constuctor called when Cell is called
/// </summary>
/// <param name="row">The row of the cell</param>
/// <param name="column">the column of the cell</param>
/// <param name="css">the css of the cell</param>
  public Cell(int row, int column, string css)
  {
    Row = row;
    Column = column;
    CssClass = css;
  }
}
