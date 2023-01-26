using GoldenReports.Application.Abstractions.Persistence;
using GoldenReports.Domain.Security;

namespace GoldenReports.Persistence.Repositories;

public class UserRepository : Repository<User>, IUserRepository
{
    public UserRepository(GoldenReportsDbContext dataContext) : base(dataContext)
    {
    }
}