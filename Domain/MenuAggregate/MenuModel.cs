﻿using Domain.Common.Models;
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

        public string Name { get; private set; }

        public string Description { get; private set; }

        public AverageRating AverageRating { get; private set; }

        public IReadOnlyList<MenuSection> Sections => _sections.AsReadOnly();

        public HostId HostId { get; private set; }

        public IReadOnlyList<DinnerId> DinnerIds => _dinnerIds.AsReadOnly();

        public IReadOnlyList<MenuReviewId> MenuReviewIds => _menuReviewIds.AsReadOnly();

        public DateTime CreatedDateTime { get; private set; }

        public DateTime UpdatedDateTime { get; private set; }

        private MenuModel(
            MenuId id,
            string name,
            string description,
            List<MenuSection>? sections,
            AverageRating averageRating,
            HostId hostId) : base(id)
        {
            Name = name;
            Description = description;
            HostId = hostId;
            _sections = sections;
            AverageRating = averageRating;
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
                sections ?? new(),
                AverageRating.CreateNew(),
                hostId);
        }
    }
}