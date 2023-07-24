using Domain.Common.Models;

namespace Domain.BillAggregate.ValueObjects
{
    public sealed class BillId : ValueObject
    {
        public Guid Value { get; set; }

        private BillId(Guid value)
        {
            Value = value;
        }

        public static BillId CreateUnique()
        {
            return new(Guid.NewGuid());
        }

        public override IEnumerable<object> GetEqualityComponents()
        {
            yield return Value;
        }
    }
}