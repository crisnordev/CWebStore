namespace CWebStore.Shared.Entities;

public abstract class Entity : Notifiable<Notification>
{
    public Entity()
    {
        Id = Guid.NewGuid();
    }

    public virtual Guid Id { get; protected internal set; }
}