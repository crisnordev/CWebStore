using CWebStore.Shared.Enums;

namespace CWebStore.Domain.Entities;

public class Payment : Entity
{
    private readonly IList<InstallmentsValueObject> _installments;
    
    protected Payment()
    {
    }

    public Payment(string id, EPaymentType type, EPaymentMethod paymentMethod, IList<InstallmentsValueObject> installments) : base(id)
    {
        AddInstalments(installments);
        if (!IsValid) return;
        Type = type;
        PaymentMethod = paymentMethod;
    }
    
    public EPaymentType Type { get; private set; }

    public EPaymentMethod PaymentMethod { get; private set; }

    public IReadOnlyCollection<InstallmentsValueObject> Installments => _installments.ToArray();

    public void Validate(IList<InstallmentsValueObject> installments)
    {
        if (!installments.Any())
        {
            AddNotification("Payment.Installments", "Installments must not be null.");
            return;
        }
        foreach (var installment in installments)
        {
            AddNotifications(installment);
        }
    }
    
    public void AddInstalments(IList<InstallmentsValueObject> installments)
    {
        Validate(installments);
        if (IsValid)
            foreach (var installment in installments)
            {
                _installments.Add(installment);
            }
    }
}