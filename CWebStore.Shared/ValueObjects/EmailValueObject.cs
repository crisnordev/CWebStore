namespace CWebStore.Shared.ValueObjects;

public class EmailValueObject : ValueObject
{
    protected EmailValueObject() {}
    
    public EmailValueObject(string email)
    {
        Validate(email);
        if (IsValid) Email = email;
    }

    public string Email { get; private set; }

    public void Validate(string email)
    {
        AddNotifications(new Contract<string>()
            .IsGreaterThan(256, email.Length,"EmailValueObject.Email",
                "Email must have a maximum 256 characters long.")
            .IsEmail(email, "EmailValueObject.Email",
                "This is not a valid Email.")
            .IsEmailOrEmpty(email, "EmailValueObject.Email",
                "This is not a valid Email."));
    }

    public void EditEmail(string email)
    {
        Validate(email);
        if (IsValid) Email = email;
    }
    
    public override string ToString() => Email;
}