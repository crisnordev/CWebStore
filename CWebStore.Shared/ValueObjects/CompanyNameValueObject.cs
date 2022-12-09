﻿namespace CWebStore.Shared.ValueObjects;

public class CompanyName : NameBaseValueObject
{
    protected CompanyName()
    {
    }
    
    public CompanyName(string name)
    {
        Validate(name);
        if (IsValid) EditorNameBase(name);
    }

    public void Validate(string name)
    {
        AddNotifications(new Contract<string>()
            .IsNotNullOrEmpty(name, "CompanyName.Name",
                "Company name must not be null or empty.")
            .IsLowerThan(2, name.Length, "CompanyName.Name",
                "Company name must have between 2 and 120 characters long.")
            .IsGreaterOrEqualsThan(120, name.Length, "CompanyName.Name",
                "Company name must have between 2 and 120 characters long."));
    }

    public void EditCompanyName(string name)
    {
        Validate(name);
        if (IsValid) EditorNameBase(name);
    }

    public override string ToString() => Name;
}