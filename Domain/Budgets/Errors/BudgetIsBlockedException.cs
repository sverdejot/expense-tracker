using Domain.Budget;
using Domain.Shared.Base;

namespace Domain;

public class BudgetIsBlockedException : DomainException
{
    private BudgetRecord _record;
    public BudgetIsBlockedException(BudgetRecord LastRecord) : base($"The Budget has been blocked previous on [{LastRecord.Created}]")
    {
        _record = LastRecord;
    }
}
