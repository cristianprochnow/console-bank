class Account
{
  public static int accountsAmount = 0;
  
  public string number;
  public string bearer;

  public decimal balance
  {
    get
    {
      decimal result = 0;
      foreach (Transaction transaction in this.moviments)
      {
        result += transaction.value;
      }
      return result;
    }
  }

  protected List<Transaction> moviments = new List<Transaction>();

  public Account(string number, string bearer, decimal balance)
  {
    this.number = number;
    this.bearer = bearer;
    this.deposit(balance, DateTime.Now, "Depósito Inicial da Conta Nº "+number);

    accountsAmount++;
  }

  public string getData()
  {
    string text = "";

    text += "Conta "+this.number;
    text += " do correntista "+this.bearer;
    text += " com saldo de "+this.balance.ToString();

    return text;
  }

  public void deposit(decimal value, DateTime date, string description)
  {
    Transaction deposit = new Transaction(value, date, description);

    this.moviments.Add(deposit);
  }

  public virtual void withdraw(decimal value, DateTime date, string description)
  {
    if (this.balance >= value) {
      Transaction withdraw = new Transaction(-value, date, description);

      this.moviments.Add(withdraw);
    }
  }

  public string showExtract()
  {
    var extract = new System.Text.StringBuilder();

    decimal saldo = 0;

    string space = "\t\t";
    string header = "Data"+space+"Valor"+space+"Saldo"+space+"Motivo";

    extract.AppendLine(this.getData());
    extract.AppendLine(header);

    foreach (Transaction moviment in this.moviments)
    {
      saldo += moviment.value;

      string date = moviment.date.ToShortDateString();
      string value = moviment.value.ToString();
      string balance = saldo.ToString();
      string description = moviment.description;

      extract.AppendLine(date+space+value+space+balance+space+description);
    }
    extract.AppendLine(saldo.ToString());

    return extract.ToString();
  }
}