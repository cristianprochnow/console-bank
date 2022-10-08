Screen screen = new Screen(ConsoleColor.Black, ConsoleColor.DarkGreen);

screen.buildGeneralScreen();
screen.buildHorizontalRow(2, 0, 70);
screen.center(1, 0, 70, "Console Bank");
screen.buildFrame(5, 5, 40, 12);
screen.buildFrame(20, 20, 70, 36);