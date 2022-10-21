class Screen
{
  ConsoleColor backgroundColor, textColor;

  public Screen(ConsoleColor backgroundColor, ConsoleColor textColor)
  {
    this.backgroundColor = backgroundColor;
    this.textColor = textColor;

    this.setUpScreen();
  }

  public void setUpScreen()
  {
    Console.BackgroundColor = this.backgroundColor;
    Console.ForegroundColor = this.textColor;

    Console.Clear();
  }

  public void buildGeneralScreen()
  {
    this.buildFrame(0, 0, 79, 24);
    this.buildHorizontalRow(2, 0, 79);
    this.center(1, 0, 79, "Console Bank");
  }

  public void write(int column, int row, string message)
  {
    Console.SetCursorPosition(column, row);
    Console.Write(message);
  }

  public void buildFrame(int initialColumn, int initialRow, int finalColumn, int finalRow)
  {
    int column, row;

    this.clearArea(initialColumn, initialRow, finalColumn, finalRow);

    // Desenha as linhas horizontais do topo e do footer. 
    for (column = initialColumn; column <= finalColumn; column++)
    {
      this.write(column, initialRow, "-");
      this.write(column, finalRow, "-");
    }

    // Desenha as linhas verticais da equerda e direita.
    for (row = initialRow; row <= finalRow; row++)
    {
      this.write(initialColumn, row, "|");
      this.write(finalColumn, row, "|");
    }

    // Conserta os campos, colocando os símbolos para ficar tudo certin.
    this.write(initialColumn, initialRow, "+");
    this.write(initialColumn, finalRow, "+");
    this.write(finalColumn, initialRow, "+");
    this.write(finalColumn, finalRow, "+");
  }

  public void clearArea(int initialColumn, int initialRow, int finalColumn, int finalRow)
  {
    int column, row;

    // Percorre todas as colunas disponíveis.
    for (column = initialColumn; column <= finalColumn; column++)
    {
      for (row = initialRow; row <= finalRow; row++)
      {
        this.write(column, row, " ");
      }
    }
  }

  public void buildHorizontalRow(int row, int initialColumn, int finalColumn)
  {
    int column;

    for (column = initialColumn; column <= finalColumn; column++)
    {
      this.write(column, row, "-");
    }    

    this.write(initialColumn, row, "+");
    this.write(finalColumn, row, "+");
  }

  public void center(int row, int initialColumn, int finalColumn, string message)
  {
    int column = (initialColumn + ((finalColumn - initialColumn) - message.Length)) / 2;
    
    this.write(column, row, message);
  }

  public string showMenu(int initialColumn, int initialRow, List<string> options)
  {
    string? operation;
    int column, row, finalColumn, finalRow;

    finalRow = (initialRow + 2) + options.Count;
    finalColumn = (initialColumn + 1) + options[0].Length;

    this.buildFrame(initialColumn, initialRow, finalColumn, finalRow);

    column = initialColumn + 1;
    row = initialRow + 1;

    foreach (string option in options)
    {
      this.write(column, row, option);
      row++;
    }

    this.write(column, row, "Opção: ");
    operation = Console.ReadLine();

    if (operation == null) {
      operation = "0";
    }

    return operation;
  }
}