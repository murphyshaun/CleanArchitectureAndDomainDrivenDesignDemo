using Domain.Common.Models;

namespace Domain.MenuAggregate.ValueObjects
{
    public sealed class MenuSectionId : ValueObject
    {
        public Guid Value { get; set; }

        private MenuSectionId(Guid value)
        {
            Value = value;
        }

        public static MenuSectionId CreateUnique()
        {
            return new(Guid.NewGuid());
        }

        public override IEnumerable<object> GetEqualityComponents()
        {
            yield return Value;
        }

        public static MenuSectionId Create(Guid value)
        {
            return new MenuSectionId(value);
        }
    }
}