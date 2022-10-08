class AccountsCRUD
{
  List<Account> accountsStorage = new List<Account>();
  Screen screen;

  public AccountsCRUD(Screen screen)
  {
    this.screen = screen;
  }

  public void buildScreen(int initialColumn, int initialRow, int finalColumn, int finalRow)
  {
    this.screen.buildFrame(initialColumn, initialRow, finalColumn, finalRow);
    this.screen.buildHorizontalRow(initialRow + 2, initialColumn, finalColumn);
    this.screen.center(initialRow + 1, initialColumn, finalColumn, "Cadastro de Contas");
  }
}