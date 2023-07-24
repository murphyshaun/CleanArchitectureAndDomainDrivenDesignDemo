using Application.Common.Interfaces.Persistence;
using Domain.MenuAggregate;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence.Repositories
{
    public class MenuRepository : IMenuRepository
    {
        private readonly AppDbContext _dbContext;

        public MenuRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void Add(MenuModel menuModel)
        {
            _dbContext.Add(menuModel);

            _dbContext.SaveChanges();
        }
    }
}