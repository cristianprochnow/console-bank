class SpecialAccount: Account
{
  public decimal limit;

  public SpecialAccount(
    string register, 
    string title, 
    decimal balance,
    decimal limit
  ): base(register, title, balance)
  {
    this.limit = limit;
  }

  public override void withdraw(decimal value, DateTime date, string description)
  {
    if ((this.balance + this.limit) >= value) {
      Transaction withdraw = new Transaction(-value, date, description);

      this.moviments.Add(withdraw);
    }
  }
}