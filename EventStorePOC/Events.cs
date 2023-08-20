namespace EventStorePOC;

public interface IEvent
{
    Guid Id { get; }
}

public class AccountCreatedEvent : IEvent
{
    public Guid Id { get; private set; }
    public string Name { get; private set; }

    public AccountCreatedEvent(Guid id, string name)
    {
        Id = id;
        Name = name;
    }
}

public class FundsDepositedEvent : IEvent
{
    public Guid Id { get; private set; }
    public decimal Amount { get; private set; }

    public FundsDepositedEvent(Guid id, decimal amount)
    {
        Id = id;
        Amount = amount;
    }
}

public class FundsWithdrawnEvent : IEvent
{
    public Guid Id { get; private set; }
    public decimal Amount { get; private set; }

    public FundsWithdrawnEvent(Guid id, decimal amount)
    {
        Id = id;
        Amount = amount;
    }
}