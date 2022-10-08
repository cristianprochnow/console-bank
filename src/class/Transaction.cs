class Transaction
{
  public decimal value;
  public string description;
  public DateTime date; // DateTime não é um tipo primitivo, como `int`, `string`...

  public Transaction(decimal value, DateTime date, string description)
  {
    this.value = value;
    this.date = date;
    this.description = description;
  }
}