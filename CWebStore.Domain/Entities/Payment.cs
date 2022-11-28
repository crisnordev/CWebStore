using CWebStore.Domain.Enums;

namespace CWebStore.Domain.Entities;

public class Payment : Entity, IValidatable
{
    public Guid PaymentId { get; set; }

    public EPaymentType Type { get; set; }

    public EPaymentMethod PaymentMethod { get; set; }

    public Installments Installments { get; set; }

    public string FinancialAccountId { get; set; }
}