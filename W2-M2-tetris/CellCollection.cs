/// <summary>
/// This class will store the colletion of cells
/// </summary>
class CellCollection 
{


  // This will store the list of cells
  private readonly List<Cell> _cells = new List<Cell>();



  public List<Cell> GetAll()
  {
    return _cells;
  }





  /// <summary>
  /// The HasRow boolean will chwck if there are any cells in the given <paramref name="row" />
  /// </summary>
  /// <returns>A Boolean</returns>

  public bool HasRow(int row)
  {
    return _cells.Any( cell => cell.Row == row);
  }


  //Checks if there are any occupied cells in the given column
  public bool HasColumn(int column)
  {
    return _cells.Any( c => c.Column == column);
  }



  public bool Contains(int row, int column)
  {
    // Goes through each cell to check if the that row contains a cell
    return _cells.Any(c => c.Row == row && c.Column == column);
  }



  /// <summary>
  /// This function will Add a cell the the cellColection at location <paramref name="row"/> and <paramref name="column"/>  
  /// </summary>

  /// <param name="column"> the column to add the cell to </param>
  /// <param name="row"> the row to add the cell to </param>

  public void Add(int row, int column)
  {
    _cells.Add(new Cell(row, column));
  }

  public void AddMany(List<Cell> cells, string cssClass)
  {
    foreach(var cell in cells)
    {
      _cells.Add(new Cell(cell.Row, cell.Column, cssClass));
    }
  }

  public void SetCssClass(int row, string cssClass)
  {
    _cells.Where(x => x.Row == row)
      .ToList()
      .ForEach(x => x.CssClass = cssClass);

  }

  public void CollapseRows(List<int> rows){

    var selectedCells = _cells.Where(x => rows.Contains(x.Row));

    // Add those cells to a temporary CellCollection
    List<Cell> toRemove = new List<Cell>();

    foreach (var cell in selectedCells)
    {
      toRemove.Add(cell);
    }

     // Remove all cells int he temporary 
    //   CellCollection from the real collection.
    _cells.RemoveAll ( x=> toRemove.Contains(x));

    foreach (var cell in _cells)
    {
      int numberOfLessRows = 
        rows.Where(x => x <=
            cell.Row).Count();
      cell.Row -= numberOfLessRows;
    }



  }

  // Gets the rightmost (highest Column value) cell in the collection.
  public List<Cell> GetRightmost()
  {
    List<Cell> cells = new List<Cell>();
    foreach (var cell in _cells)
    {
      if (!Contains(cell.Row, cell.Column + 1))
      {
        cells.Add(cell);
      }
    }

    return cells;
  }

  // Get leftmost (lowest Column value)
  public List<Cell> GetLeftMost()
  {
    List<Cell> cells = new List<Cell>();
    foreach (var cell in _cells)
    {
      if (!Contains(cell.Row, cell.Column -1))
      {
        cells.Add(cell);
      }
    }
    return cells;
  }
/// <summary>
/// Finds lowest Cells
/// </summary>
/// <returns>Returns the lowest cells in an array</returns>


  public List<Cell> GetLowest()
  {
    List<Cell> cells = new List<Cell>();
    foreach(var cell in _cells)
    {
      if(!Contains(cell.Row - 1, cell.Column))
      {
        cells.Add(cell);
      }
    }

    return cells;
  }

}

