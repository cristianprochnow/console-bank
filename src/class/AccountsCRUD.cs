class AccountsCRUD
{
  List<Account> accountsStorage = new List<Account>();
  Screen screen;

  string? number;
  string? holder;
  int position;

  public AccountsCRUD(Screen screen)
  {
    this.screen = screen;

    this.accountsStorage.Add(new Account("1001", "Zé Colmeia", 1000));
    this.accountsStorage.Add(new Account("1002", "Coelho Ricochete", 500));
  }

  public void buildScreen(int initialColumn, int initialRow, int finalColumn, int finalRow)
  {
    this.screen.buildFrame(initialColumn, initialRow, finalColumn, finalRow);
    this.screen.buildHorizontalRow(initialRow + 2, initialColumn, finalColumn);
    this.screen.center(initialRow + 1, initialColumn, finalColumn, "Cadastro de Contas");

    this.screen.write(11, 8,  "Número  :");
    this.screen.write(11, 9,  "Titular :");
    this.screen.write(11, 10, "Saldo   :");
  }

  public void controlCRUD()
  {
    while (true) {
      this.buildScreen(10, 5, 70, 15);

      Console.SetCursorPosition(22, 8);
      this.number = Console.ReadLine();

      if (this.number == "") {
        break;
      }

      bool found = false;
      int counter;

      for (counter = 0; counter < this.accountsStorage.Count; counter++)
      {
        if (this.accountsStorage[counter].number == this.number) {
          found = true;
          this.position = counter;
          break;
        }
      }

      if (found) {
        this.showAccountData(this.position);
        Console.ReadKey();
      }
      else {
        this.screen.write(22, 9, "Conta não encontrada!");
        Console.ReadKey();
      }
    }
  }

  void showAccountData(int userId)
  {
    this.screen.write(22, 9, this.accountsStorage[userId].bearer);
    this.screen.write(22, 10, this.accountsStorage[userId].balance.ToString());
    Console.ReadKey();
  }
}