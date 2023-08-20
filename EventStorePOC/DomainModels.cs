namespace EventStorePOC;

public class BankAccount
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    private decimal CurrentBalance { get; set; }
    private List<Transaction> Transactions = new List<Transaction>();

    public BankAccount()
    {
    }

    public void Apply(AccountCreatedEvent @event)
    {
        Id = @event.Id;
        Name = @event.Name;
        CurrentBalance = 0;
    }

    public void Apply(FundsDepositedEvent @event)
    {
        var newTransaction = new Transaction { Id = @event.Id, Amount = @event.Amount };
        Transactions.Add(newTransaction);
        CurrentBalance += @event.Amount;
    }

    public void Apply(FundsWithdrawnEvent @event)
    {
        var newTransaction = new Transaction { Id = @event.Id, Amount = @event.Amount };
        Transactions.Add(newTransaction);
        CurrentBalance -= @event.Amount;
    }

    private class Transaction
    {
        public Guid Id { get; set; }
        public decimal Amount { get; set; }
    }
}