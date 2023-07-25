using Domain.HostAggregate.ValueObjects;
using Domain.MenuAggregate;
using Domain.MenuAggregate.Entities;
using Domain.MenuAggregate.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence.Configurations
{
    public class MenuConfigurations : IEntityTypeConfiguration<MenuModel>
    {
        public void Configure(EntityTypeBuilder<MenuModel> builder)
        {
            ConfigureMenusTable(builder);
            ConfigureMenuSectionsTable(builder);
            ConfigureMenuDinnerIdsTable(builder);
            ConfigureMenuReviewIdsTable(builder);
        }
       
        private void ConfigureMenusTable(EntityTypeBuilder<MenuModel> builder)
        {
            builder.ToTable("Menus");

            builder.HasKey(m => m.Id);

            builder.Property(m => m.Id)
                .ValueGeneratedNever()
                .HasConversion(
                    id => id.Value,
                    value => MenuId.Create(value));

            builder.Property(m => m.Name)
                .HasMaxLength(100);

            builder.Property(m => m.Description)
                .HasMaxLength(100);

            builder.OwnsOne(m => m.AverageRating);

            builder.Property(m => m.HostId)
                .HasConversion(
                    id => id.Value,
                    value => HostId.Create(value));
        }

        private void ConfigureMenuSectionsTable(EntityTypeBuilder<MenuModel> builder)
        {
            builder.OwnsMany(m => m.Sections, sb =>
            {
                sb.ToTable("MenuSections");

                sb.WithOwner().HasForeignKey("MenuId");

                sb.HasKey("Id", "MenuId");

                sb.Property(s => s.Id)
                    .HasColumnName("MenuSectionId")
                    .ValueGeneratedNever()
                    .HasConversion(
                    id => id.Value,
                    value => MenuSectionId.Create(value));

                sb.Property(s => s.Name)
                    .HasMaxLength(100);

                sb.Property(s => s.Description)
                    .HasMaxLength(100);

                sb.OwnsMany(s => s.MenuItems, ib =>
                {
                    ib.ToTable("MenuItems");

                    ib.WithOwner().HasForeignKey("MenuSectionId", "MenuId");

                    ib.HasKey(nameof(MenuItem.Id), "MenuSectionId", "MenuId");

                    ib.Property(i => i.Id)
                        .HasColumnName("MenuItemId")
                        .ValueGeneratedNever()
                        .HasConversion(
                        id => id.Value,
                        value => MenuItemId.Create(value));

                    ib.Property(s => s.Name)
                        .HasMaxLength(100);

                    ib.Property(s => s.Description)
                        .HasMaxLength(100);
                });

                sb.Navigation(s => s.MenuItems).Metadata.SetField("_menuItems");
                sb.Navigation(s => s.MenuItems).UsePropertyAccessMode(PropertyAccessMode.Field);
            }
            );

            builder.Metadata.FindNavigation(nameof(MenuModel.Sections))!
                .SetPropertyAccessMode(PropertyAccessMode.Field);
        }

        private void ConfigureMenuDinnerIdsTable(EntityTypeBuilder<MenuModel> builder)
        {
            builder.OwnsMany(m => m.DinnerIds, dib =>
            {
                dib.ToTable("MenuDinnerIds");

                dib.WithOwner().HasForeignKey("MenuId");

                dib.HasKey("Id");

                dib.Property(d => d.Value)
                    .HasColumnName("DinnerId")
                    .ValueGeneratedNever();
            });

            builder.Metadata.FindNavigation(nameof(MenuModel.DinnerIds))
                .SetPropertyAccessMode(PropertyAccessMode.Field);
        }
       
        private void ConfigureMenuReviewIdsTable(EntityTypeBuilder<MenuModel> builder)
        {
            builder.OwnsMany(m => m.MenuReviewIds, dib =>
            {
                dib.ToTable("MenuReviewIds");

                dib.WithOwner().HasForeignKey("MenuId");

                dib.HasKey("Id");

                dib.Property(d => d.Value)
                    .HasColumnName("ReviewId")
                    .ValueGeneratedNever();
            });

            builder.Metadata.FindNavigation(nameof(MenuModel.MenuReviewIds))
                .SetPropertyAccessMode(PropertyAccessMode.Field);
        }
    }
}