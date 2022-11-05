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
        this.screen.write(21, 12, "Deseja alterar/excluir/voltar (A/E/V): ");
        string? response;
        response = Console.ReadLine();

        if (response == null) {
          response = "";
        }

        if (response.ToUpper() == "A") {
          this.screen.write(11, 13, "Novo nome: ");

          this.holder = Console.ReadLine();
          if (this.holder == null) {
            this.holder = "";
          }

          this.screen.write(21, 14, "Confirma a alteração (S/N): ");

          response = Console.ReadLine();
          if (response == null) {
            response = "";
          }

          if (response.ToUpper() == "S") {
            this.accountsStorage[this.position].bearer = this.holder;
          }
        } 
        else if (response.ToUpper() == "E") {
          this.screen.write(21, 14, "Confirma exclusão (S/N) : ");

          response = Console.ReadLine();
          if (response == null) {
            response = "";
          }

          if (response.ToUpper() == "S") {
            this.accountsStorage.RemoveAt(this.position);
          }
        }
      }
      else {
        this.screen.write(22, 9, "Conta não encontrada!");
        this.screen.write(22, 12, "Deseja cadastrar? (S/N): ");
        
        string? response = Console.ReadLine();

        if (response == "s" || response == "S") {
          this.screen.clearArea(21, 9, 69, 9);

          Console.SetCursorPosition(21, 9);
          this.holder = Console.ReadLine();

          Console.SetCursorPosition(21, 10);
          decimal initialDeposit = Convert.ToDecimal(Console.ReadLine());

          this.screen.write(21, 12, "Confirma o cadastro? (S/N): ");
          response = Console.ReadLine();

          if (response == "s" || response == "S") {
            if (this.number == null) {
              this.number = (new System.Random()).Next().ToString();
            }
            if (this.holder == null) {
              this.holder = (new System.Random()).Next().ToString();
            }
            this.accountsStorage.Add(new Account(this.number, this.holder, initialDeposit));
          }
        }
      }
    }
  }

  public void showAccountData(int userId)
  {
    this.screen.write(22, 9, this.accountsStorage[userId].bearer);
    this.screen.write(22, 10, this.accountsStorage[userId].balance.ToString());
    Console.ReadKey();
  }

  public void showExtract()
  {
    this.screen.clearArea(1, 4, 70, 24);

    this.screen.write(1, 4, "Número da conta : ");
    this.number = Console.ReadLine();
    if (this.number != "") {
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
        string extract = this.accountsStorage[this.position].showExtract();
        this.screen.write(1, 4, extract);
        Console.ReadKey();
      }
    }
  }

  public void buildScreenMoviment(int initialColumn, int initialRow, int finalColumn, int finalRow)
  {
    this.screen.buildFrame(initialColumn, initialRow, finalColumn, finalRow);
    this.screen.buildHorizontalRow(initialRow + 2, initialColumn, finalColumn);
    this.screen.center(initialRow + 1, initialColumn, finalColumn, "Movimentar Contas");

    this.screen.write(11, 8,  "Conta     : ");
    this.screen.write(11, 9,  "Tipo (D/R): ");
    this.screen.write(11, 10, "Motivo    : ");
    this.screen.write(11, 11, "Valor     : ");
  }

  public void moviment()
  {
    while (true) {
      this.buildScreenMoviment(10, 5, 70, 15);
      Console.SetCursorPosition(23, 8);

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
        string? type, description, response;
        decimal value;

        Console.SetCursorPosition(23, 9);
        type = Console.ReadLine();
        if (type == null) {
          type = "";
        }

        Console.SetCursorPosition(23, 10);
        description = Console.ReadLine();
        if (description == null) {
          description = "";
        }
        
        Console.SetCursorPosition(23, 11);
        value = Convert.ToDecimal(Console.ReadLine());

        this.screen.write(23, 12, "Confirma movimentação (S/N): ");
        response = Console.ReadLine();
        if (response == null) {
          response = "";
        }
        if (response.ToUpper() == "S") {
          if (type.ToUpper() == "D") {
            this.accountsStorage[this.position].deposit(value, DateTime.Now, description);
          }
          else if (type.ToUpper() == "R") {
            this.accountsStorage[this.position].withdraw(value, DateTime.Now, description);
          }
        }
      }
    } 
  }
}