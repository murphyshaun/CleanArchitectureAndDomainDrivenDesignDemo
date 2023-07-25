using Domain.Common.Models;
using Domain.HostAggregate.ValueObjects;
using Domain.MenuAggregate.ValueObjects;

namespace Domain.HostAggregate
{
    public sealed class HostModel : AggregateRoot<HostId, Guid>
    {
        private readonly List<MenuId> _menuIds = new();

        public IReadOnlyList<MenuId> MenuIds => _menuIds.AsReadOnly();

        public HostModel(HostId id) : base(id)
        {
        }
    }
}