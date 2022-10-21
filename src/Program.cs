Screen screen = new Screen(ConsoleColor.Black, ConsoleColor.DarkGreen);
AccountsCRUD accountsCRUD = new AccountsCRUD(screen);

List<string> options = new List<string>();
string option = "";

// Opções do menu para visualização.
options.Add("1 - Contas      ");
options.Add("2 - Movimentação");
options.Add("3 - Extrato     ");
options.Add("0 - Sair        ");

while (true)
{
  screen.buildGeneralScreen();
  screen.buildHorizontalRow(2, 0, 70);
  screen.center(1, 0, 70, "Console Bank");
  option = screen.showMenu(2, 3, options);

  if (option == "0") {
    break;
  }

  if (option == "1") {
    accountsCRUD.controlCRUD();
  }
}

Console.Clear();
