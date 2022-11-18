using aspnetcore_n_tier.DAL.DataContext;
using aspnetcore_n_tier.DAL.Repositories.IRepositories;
using aspnetcore_n_tier.Entity.Entities;

namespace aspnetcore_n_tier.DAL.Repositories
{
    public class UserRepository : GenericRepository<User>, IUserRepository
    {
        private readonly AspNetCoreNTierDbContext _aspNetCoreNTierDbContext;
        public UserRepository(AspNetCoreNTierDbContext aspNetCoreNTierDbContext) : base(aspNetCoreNTierDbContext)
        {
            _aspNetCoreNTierDbContext = aspNetCoreNTierDbContext;
        }
    }
}
