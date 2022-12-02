namespace CWebStore.Shared.Entities;

public abstract class Entity : Notifiable<Notification>, IValidatable
{
    public Entity()
    {
    }
    
    public Entity(string id)
    {
        Validate(id);
        if (IsValid) Id = new Guid(id);
    }

    public Guid Id { get; private set; }
    
    public void Validate(string id)
    {
        AddNotifications(new Contract<string>()
            .IsNotNullOrEmpty(id, "Entity.Id",
                "Product Id must not be null or empty.")
            .AreEquals(id, Guid.Empty, "Entity.Id",
                "Product Id must not be null or empty."));
    }

    public void EditEntityId(string id)
    {
        Validate(id);
        if (IsValid) Id = new Guid(id);
    }
}