using Domain.Common.Models;
using Domain.Common.ValueObjects;
using Domain.DinnerAggregate.ValueObjects;
using Domain.HostAggregate.ValueObjects;
using Domain.MenuAggregate.Entities;
using Domain.MenuAggregate.ValueObjects;
using Domain.MenuAggregateReview.ValueObjects;

namespace Domain.MenuAggregate
{
    public sealed class MenuModel : AggregateRoot<MenuId>
    {
        private readonly List<MenuSection> _sections = new();

        private readonly List<DinnerId> _dinnerIds = new();

        private readonly List<MenuReviewId> _menuReviewIds = new();

        public string Name { get; }

        public string Description { get; }

        public AverageRating AverageRating { get; }

        public IReadOnlyList<MenuSection> Sections => _sections.AsReadOnly();

        public HostId HostId { get; }

        public IReadOnlyList<DinnerId> DinnerIds => _dinnerIds.AsReadOnly();

        public IReadOnlyList<MenuReviewId> MenuReviewIds => _menuReviewIds.AsReadOnly();

        public DateTime CreatedDateTime { get; }

        public DateTime UpdatedDateTime { get; }

        private MenuModel(
            MenuId id,
            string name,
            string description,
            List<MenuSection>? sections,
            HostId hostId,
            DateTime createdDateTime,
            DateTime updatedDateTime) : base(id)
        {
            Name = name;
            Description = description;
            HostId = hostId;
            CreatedDateTime = createdDateTime;
            UpdatedDateTime = updatedDateTime;
            _sections = sections;
        }

        public static MenuModel Create(
            HostId hostId,
            string name,
            string description,
            List<MenuSection>? sections)
        {
            return new(
                MenuId.CreateUnique(),
                name,
                description,
                sections,
                hostId,
                DateTime.UtcNow,
                DateTime.UtcNow);
        }
    }
}